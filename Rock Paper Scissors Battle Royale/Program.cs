using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Battle_Royale {
    class Program {

        static void Main(string[] args) {
            Random rnd = new Random();
            int tournaments = 0;

            Console.SetWindowSize(100, 60);
            Console.SetBufferSize(100, 10000);
            Console.Beep();

            while (true) {
                tournaments++;

                Console.WriteLine("<======||=====o0          Rock Paper Scissors Tournament          0o=====||======>");
                Console.WriteLine("                        Current Session:  Tournament no. #{0}", tournaments);
                Console.WriteLine("<======||================================================================||======>");

                OverworldGame newGame = new OverworldGame(tournaments);
            }

            Console.ReadKey();
        }
    }
}
