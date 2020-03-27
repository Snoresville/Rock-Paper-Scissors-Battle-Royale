using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {

    class OverworldGame {
        // Initialisation
        Settings settings = new Settings();
        List<Player> players = new List<Player>();
        RPS_Battle battlegrounds = new RPS_Battle();
        DateTime startDate = DateTime.Now;

        static System.Timers.Timer timer;

        int round = 0;
        int durationSeconds = 0;

        // Methods
        void Message(string message, double seconds) {
            Console.WriteLine(message);

            double duration = seconds * 1000;
            Thread.Sleep((int)duration);
        }

        void TimerStart() {
            timer = new System.Timers.Timer(1000);
            // Creates a timer that counts game duration in seconds
            timer.Elapsed += TimerTick;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        void TimerTick(object sender, System.Timers.ElapsedEventArgs e) {
            durationSeconds++;
        }

        void HOFRecord(Player victor) {
            Message("And so the RPS Battle Royale ends...", 5);
            Message("With " + victor.name + " left standing, it places its stare across the defeated players...", 5);
            Message("The losers stare back, with mixed feelings of congratulation and sadness...", 5);
            Message("On this day, " + victor.name + "'s name shall be forever remembered in the hall of fame....", 5);

            // Records the win
            using (StreamWriter historian = File.AppendText(@"C:\Users\Reflective\source\repos\Rock-Paper-Scissors-Battle-Royale\Hall of Fame.txt")) {
                /// Format of the record:
                // Start Date
                // Finish Date
                // Number of Players
                // Max Rounds
                // Duration
                // Victor
                // Victor's Move Bias
                // Match Wins, Losses, Round Wins, Losses
                // (blank space)

                historian.WriteLine("Start Date: " + startDate);
                historian.WriteLine("Finish Date: " + DateTime.Now.ToString());
                historian.WriteLine("Player Count: " + settings.playerCount);
                historian.WriteLine("Max Rounds: " + settings.roundLossLimit);
                historian.WriteLine("Duration: " + TimeSpan.FromSeconds(durationSeconds));
                historian.WriteLine("Game Speed: " + settings.gameSpeed);
                historian.WriteLine("Victor: " + victor.name);
                historian.WriteLine("Bias Probability: " + victor.biasProbability);
                historian.WriteLine("Matches won: " + victor.results.matchwins);
                historian.WriteLine("Matches lost: " + victor.results.matchlosses);
                historian.WriteLine("Rounds won: " + victor.results.roundwins);
                historian.WriteLine("Rounds lost: " + victor.results.roundlosses);
                historian.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("Start Date: " + startDate);
            Console.WriteLine("Finish Date: " + DateTime.Now.ToString());
            Console.WriteLine("Player Count: " + settings.playerCount);
            Console.WriteLine("Max Rounds: " + settings.roundLossLimit);
            Console.WriteLine("Duration: " + TimeSpan.FromSeconds(durationSeconds));
            Console.WriteLine("Game Speed: " + settings.gameSpeed);
            Console.WriteLine("Victor: " + victor.name);
            Console.WriteLine("Bias Probability: " + victor.biasProbability);
            Console.WriteLine("Matches won: " + victor.results.matchwins);
            Console.WriteLine("Matches lost: " + victor.results.matchlosses);
            Console.WriteLine("Rounds won: " + victor.results.roundwins);
            Console.WriteLine("Rounds lost: " + victor.results.roundlosses); Thread.Sleep(5000);
        }

        // Game In Progress
        public OverworldGame(int tournaments) {
            for (int i = 0; i < settings.playerCount; i++) {
                Player newplayer = new Player();

                players.Add(newplayer);
                //Console.WriteLine(newplayer.name);
                Thread.Sleep(20);
            }

            Message(string.Format("Welcome{0}to the Rock-Paper-Scissors Tournament!", tournaments == 1 ? " " : " back "), 1.5);
            Message(string.Format("{0} players have joined us today!", players.Count), 3);
            Message("Let's not waste any time! Let's go!", 1.5);
            TimerStart();

            // Gameplay
            while (players.Count > 1) {
                // Start round and randomise player order
                round++;
                Console.WriteLine("-------------");
                Message("Round " + round, 0);
                Console.WriteLine("-------------"); Thread.Sleep(1000);

                players = players.OrderBy(x => settings.rnd.Next()).ToList();

                // Start spotting procedure
                List<Player> losers = new List<Player>();

                // Battle it out
                for (int i = 0; i < players.Count; i += 2) {
                    // Check if the player can battle its opponent in this round.
                    if (i + 1 >= players.Count) break;

                    Player player1 = players[i];
                    Player player2 = players[i + 1];

                    battlegrounds.Battle(player1, player2);

                    // Check for losses
                    if (player1.results.roundlosses >= settings.roundLossLimit) losers.Add(player1);
                    if (player2.results.roundlosses >= settings.roundLossLimit) losers.Add(player2);
                }

                // Kick Losers
                if (losers.Count > 0) {
                    Console.WriteLine("8o---------o8");
                    Message("HALL OF DEFEAT", 0);
                    Console.WriteLine("8o---------o8"); Thread.Sleep(1000);
                    foreach (Player loser in losers) {
                        players.Remove(loser);
                        if (settings.sound) Console.Beep(400, 50);
                        Message(string.Format("{0} has been defeated...", loser.name), 0.1);
                    }
                    Thread.Sleep(1000);

                    Console.WriteLine("-===========-");
                    Message("Survivors", 0);
                    Console.WriteLine("-===========-"); Thread.Sleep(1000);

                    for (int i = 0; i < settings.survivorsMaxShown; i++) {
                        if (i >= players.Count) break;
                        Message(players[i].name, 0.1);

                        if (i == settings.survivorsMaxShown - 1 && players.Count - settings.survivorsMaxShown > 0) Message(string.Format("And {0} more...", players.Count - settings.survivorsMaxShown), 0.1);
                    }
                    Console.WriteLine(); Thread.Sleep(1000);
                }
            }



            // Win Screen (Assumes one player left standing)
            timer.Stop();
            timer.Dispose();
            HOFRecord(players[0]);
            Message(string.Format("Next game will commence in {0} seconds...", settings.countdownToNextGame), settings.countdownToNextGame);
        }





    }
}
