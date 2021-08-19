using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public enum Position {Forward, Midfielder, Defender, Goalkeeper}
    public class Player
    {
        public Position PlayerPosition { get; set; }
        public int PowerRanking { get; set; }
        public string FullName { get; set; }
        public string PlayerNumber { get; set; }

        public Player() { }
        public Player(Position playerPosition, int powerRanking, string fullName, string playerNumber)
        {
            PlayerPosition = playerPosition;
            PowerRanking = powerRanking;
            FullName = fullName;
            PlayerNumber = playerNumber;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"\n{FullName} | {PlayerPosition} | Power Ranking:{PowerRanking} | No. {PlayerNumber}");
        }

        /*Position position = Forward;
         * Player genericPlayer = new Player(position, 6, "Bob", "Deer", "3") {
         * PlayerPosition = position;
         * PowerRanking = powerRanking;
         * 
         * }
         * 
         * genericPlayer.PlayerPosition
         */ 

    }
}
