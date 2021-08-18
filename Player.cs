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
        public string FName { get; set; }
        public string LName { get; set; }
        public string PlayerNumber { get; set; }

        public Player() { }
        public Player(Position playerPosition, int powerRanking, string fName, string lName, string playerNumber)
        {
            PlayerPosition = playerPosition;
            PowerRanking = powerRanking;
            FName = fName;
            LName = lName;
            PlayerNumber = playerNumber;
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
