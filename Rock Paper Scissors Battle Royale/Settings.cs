using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {
    class Settings {
        // Meta
        public bool sound = false;
        public int gameSpeed = 2;
        public double countdownToNextGame = 10;

        // Players
        public readonly int minPlayers = 2;
        public readonly int maxPlayers = 3000;

        public readonly int baseHP = 1;
        public readonly int baseATK = 1;

        // On Loss
        public readonly int matchWinHPGain = 0;
        public readonly int roundWinHPGain = 0;
        public readonly int matchLossHPGain = 0;
        public readonly int roundLossHPGain = 1;

        // Game Loss condition
        public readonly bool roundLossLimitOffsetEnable = false;
        public readonly int roundLossLimitOffset = 2;

        public readonly bool roundLossLimitRandomise = true;
        public readonly int roundLossLimitOffsetMin = 1;
        public readonly int roundLossLimitOffsetMax = 5;

        // Variables
        public Random rnd = new Random();
        public int playerCount;
        public int roundLossLimit;

        // Displays
        public readonly int survivorsMaxShown = 10;

        // Initialising Game
        public Settings() {
            playerCount = rnd.Next(minPlayers, maxPlayers + 1);
            if (roundLossLimitOffsetEnable) {
                if (roundLossLimitRandomise == true) roundLossLimitOffset = rnd.Next(roundLossLimitOffsetMin, roundLossLimitOffsetMax + 1);
                else roundLossLimitOffset = 2;
            }
            else roundLossLimitOffset = 0;

            // Formula for the maximum amount of losses is:
            // floor (log(base 2) playerCount) + roundLossLimitOffset
            double logPlayer = Math.Floor(Math.Log(playerCount, Math.Pow(2, gameSpeed)));
            roundLossLimit = (int)logPlayer + roundLossLimitOffset;

        }
    }
}
