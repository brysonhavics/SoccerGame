using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class ProgramUI
    {
        public ProgramUI() { }

        public void Run()
        {
            Seeding();
            //Menu();
        }

        public void Seeding()
        {
            List<int> SpursRecord = new List<int> { 1, 0, 0 };
            List<int> ScumRecord = new List<int> { 0, 1, 0 };

            Team one = new Team("Spurs", SpursRecord, 10);
            Team two = new Team("Scum", ScumRecord, 4);

            Game game = new Game(one, two);
            /*
            game.Goal();
            game.YellowCard();
            game.CheckTime();
            */
            game.PlayGame();
            Position position = Position.Forward;
            Console.WriteLine(position);
            Console.ReadKey();
            Player player = new Player(position, 6, "Harry", "Stiles", "13");
            Console.WriteLine(player.PlayerNumber + "\n" + player.FName);
        }
    }
}
