using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {

    class ActionRecord {
        public int rocks = 1;
        public int papers = 1;
        public int scissors = 1;

        public int total = 3;
    }
    class Results {
        // Record of their performance within the matches in the rounds.
        public int matchwins = 0;
        public int matchlosses = 0;

        // Record of their performance in rounds.
        public int roundwins = 0;
        public int roundlosses = 0;

        public int HPBonus(Settings settings) {
            int matchwinHP = matchwins * settings.matchWinHPGain;
            int roundwinHP = roundwins * settings.roundWinHPGain;
            int matchlossHP = matchlosses * settings.matchLossHPGain;
            int roundlossHP = roundlosses * settings.roundLossHPGain;

            return matchwinHP + roundwinHP + matchlossHP + roundlossHP;
        }
    }

    class Player {
        // Player Initialisation
        public Player() {
            // Grabs a name
            NameLibrary names = new NameLibrary();
            name = names.GetName();

            // Randomise how much they will attempt to use opponents' move records in their decision
            biasProbability = rnd.NextDouble();

        }

        // Name
        public string name;

        // Records
        public ActionRecord moves = new ActionRecord(); // Move Record
        public Results results = new Results();         // Win/Loss Record

        // Variables and Methods
        Random rnd = new Random();
        Settings settings = new Settings();
        public double biasProbability;

        // Stats
        public int MaxHealth() {
            return settings.baseHP + results.HPBonus(settings);
        }
        public double BlockChance() {
            return Math.Min((double)(results.matchlosses - 1) / (results.matchlosses + results.matchwins * 3), 0.8);
        }

        // Recording and Playing Rolls
        public int Roll(ActionRecord opponentsMoves) {
            int roll = 3;

            // Some biased rolling based on opponent's roll records.
            if (rnd.NextDouble() < biasProbability) {
                int probabilityMove = rnd.Next(opponentsMoves.total);

                if (probabilityMove < opponentsMoves.rocks) {
                    // Play Paper
                    roll = 1;
                }
                else if (probabilityMove < opponentsMoves.rocks + opponentsMoves.papers) {
                    // Play Scissors
                    roll = 2;
                }
                else {
                    // Play Rock
                    roll = 0;
                }

                /*
                double probabilityMove = rnd.NextDouble();
                double rockbound = opponentsMoves.rocks / opponentsMoves.total;
                double scissorsbound = 1 - (opponentsMoves.scissors / opponentsMoves.total);

                Console.WriteLine(probabilityMove);

                if (probabilityMove < rockbound) roll = 1; // Rock countered by Paper
                else if (probabilityMove > scissorsbound) roll = 0; // Scissors countered by Rock
                else roll = 2; // Paper countered by Scissors
                */

            }
            else roll = rnd.Next(3); // When they say "Fuck It"

            // Records the rolls
            switch (roll) {
                case 0:
                    moves.rocks++;
                    break;
                case 1:
                    moves.papers++;
                    break;
                case 2:
                    moves.scissors++;
                    break;
            }
            moves.total++;

            // Returns action
            return roll;
        }
    }
}
