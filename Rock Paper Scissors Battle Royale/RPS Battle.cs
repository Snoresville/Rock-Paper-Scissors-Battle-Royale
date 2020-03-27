using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {
    class RPS_Battle {

        void Message(string message, double seconds) {
            Console.WriteLine(message);

            double duration = seconds * 1000;
            Thread.Sleep((int)duration);
        }

        enum Action {
            Rock,
            Paper,
            Scissors,
        }

        // Custom Lines
        readonly List<string> roundOver = new List<string>() {
            // Generic
            "{0} has triumphed over {1}!",
            "{0} has defeated {1}!",
            "{0} bested {1} with luck and skill!",

            // Showoff
            "{0} made a middle-finger gesture towards {1}!",
        };
        readonly List<string> attackBlocked = new List<string>() {
            // Generic
            "{0} manages to block the attack! ({1})",
            "{0} swiftly dodges the attack! ({1})",
            "{0} distracts its opponent... ({1})",
            "{0} deflects the blow! ({1})",

            // Showoff
            "{0} rolled a success in its Charisma DC. ({1})",
        };
        readonly List<string> attackDamaged = new List<string>() {
            // Generic
            "{0} got hurt... ({1}/{2})",
            "{0} received a donk on the head. ({1}/{2})",
            "{0} got a slap on the wrist. ({1}/{2})",

            // Showoff
            "{0} was shocked by a small electric spark. ({1}/{2})",
        };

        // When two players fight it out
        public bool Duel(Player player1, Player player2) {
            // Endlessly loops until someone wins
            while (true) {
                // Rolls the actions
                ActionRecord player1moves = player1.moves;
                ActionRecord player2moves = player2.moves;

                int roll1 = player1.Roll(player2moves);
                int roll2 = player2.Roll(player1moves);

                // Check if first player wins
                if (roll1 == (roll2 + 1) % 3) {
                    Console.WriteLine();
                    Message(string.Format("{0} beats {1}, {2} wins!", (Action)roll1, (Action)roll2, player1.name), 0.25);

                    // Adding win/loss stats because rng is fair
                    player1.results.matchwins++;
                    player2.results.matchlosses++;

                    return true;
                }

                // Check if second player wins
                if (roll2 == (roll1 + 1) % 3) {
                    Console.WriteLine();
                    Message(string.Format("{0} beats {1}, {2} wins!", (Action)roll2, (Action)roll1, player2.name), 0.25);

                    // Adding win/loss stats because rng is fair
                    player1.results.matchlosses++;
                    player2.results.matchwins++;

                    return false;
                }

                // If they play the same action
                Message(string.Format("Both played {0}, rerolling...", (Action)roll1), 0.2);
            }
        }

        public void Battle(Player player1, Player player2) {
            Settings settings = new Settings();
            Random rnd = new Random();

            Console.WriteLine("----------");
            Console.WriteLine("{0} vs {1}", player1.name, player2.name);
            Message("----------", 1);

            Message("Rock...", 0.333);
            Message("Paper...", 0.333);
            Message("Scissors!!", 0.334);

            // Player stats
            int player1HP = player1.MaxHealth();
            int player1MAXHP = player1HP;

            int player2HP = player2.MaxHealth();
            int player2MAXHP = player2HP;

            // Battles it out until one is the victor
            while (player1HP > 0 && player2HP > 0) {
                double blockProbability = rnd.NextDouble();
                bool wincheck = Duel(player1, player2);

                if (wincheck == true) {
                    // If player 2 can block it
                    if (blockProbability < player2.BlockChance()) {
                        string blockPercentChance = string.Format("{0}%", Math.Round(player2.BlockChance() * 100, 2));

                        if (settings.sound) Console.Beep(1400, 250);
                        Message(string.Format(attackBlocked[rnd.Next(attackBlocked.Count)], player2.name, blockPercentChance), 0.15);
                    }
                    else {
                        player2HP--;

                        if (settings.sound) Console.Beep(800, 250);
                        Message(string.Format(attackDamaged[rnd.Next(attackDamaged.Count)], player2.name, player2HP, player2MAXHP), 0.25);
                    }
                }
                else {
                    // If player 1 can block it
                    if (blockProbability < player1.BlockChance()) {
                        string blockPercentChance = string.Format("{0}%", Math.Round(player1.BlockChance() * 100, 2));

                        if (settings.sound) Console.Beep(1400, 250);
                        Message(string.Format(attackBlocked[rnd.Next(attackBlocked.Count)], player1.name, blockPercentChance), 0.15);
                    }
                    else {
                        player1HP--;

                        if (settings.sound) Console.Beep(800, 250);
                        Message(string.Format(attackDamaged[rnd.Next(attackDamaged.Count)], player1.name, player1HP, player1MAXHP), 0.25);
                    }
                    
                }
            }

            // Scoring
            Player winner = null;
            Player loser = null;

            if (player1HP > 0) {
                winner = player1;
                loser = player2;
            }
            else {
                winner = player2;
                loser = player1;
            }
            winner.results.roundwins++;
            loser.results.roundlosses++;
            Message(string.Format(roundOver[rnd.Next(roundOver.Count)], winner.name, loser.name), 1);
            //Console.WriteLine();
        }

    }
}
