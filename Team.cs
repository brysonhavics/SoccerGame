using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class Team
    {
        public string TeamName { get; set; }
        public List<int> Record { get; set; }
        public int PowerRanking { get; set; }
        public Team() { }
        public Team(string name, List<int> record, int power)
        {
            TeamName = name;
            Record = record;
            PowerRanking = power;
        }

    }
    public class Game
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int HomeCards { get; set; }
        public int AwayCards { get; set; }
        public int Time { get; set; } = 90;
        public bool GameOver { get; set; } = false;

        public Game() { }
        public Game(Team home, Team away)
        {
            Home = home;
            Away = away;
        }

        public void Goal()
        {
            Random homeGoal = new Random();
            Random awayGoal = new Random();
            if (homeGoal.Next(0, Home.PowerRanking) > awayGoal.Next(0, Away.PowerRanking))
            {
                HomeGoals++;
                Console.WriteLine($"{Home.TeamName} scored!");
                Console.ReadKey();
            }
            else if (homeGoal.Next(0, Home.PowerRanking) < awayGoal.Next(0, Away.PowerRanking))
            {
                AwayGoals++;
                Console.WriteLine($"{Away.TeamName} scored!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That was close!");
                Console.ReadKey();
            }
        }
        public void YellowCard()
        {
            Random homeCards = new Random();
            Random awayCards = new Random();
            if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                HomeCards++;
                Console.WriteLine($"{Home.TeamName} received a yellow card caution!");
                Console.ReadKey();
            }
            else if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                AwayCards++;
                Console.WriteLine($"{Away.TeamName} received a yellow card caution!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That was close!");
                Console.ReadKey();
            }
        }

        public void RedCard()
        {
            Random homeCards = new Random();
            Random awayCards = new Random();
            if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                HomeCards++;
                Console.WriteLine($"{Home.TeamName} received a red card!");
                Home.PowerRanking -= 3;
                Console.ReadKey();
            }
            else if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                AwayCards++;
                Console.WriteLine($"{Away.TeamName} received a red card!");
                Away.PowerRanking -= 3;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("That was close!");
                Console.ReadKey();
            }
        }

        private void EventChecker(int home)
        {
            //Random eventChance = new Random();
            //int home = eventChance.Next(0, 15);
            //Random eventChanceComparison = new Random();
            //int away = eventChanceComparison.Next(0, 10);
            if (home == 1)
            {
                Goal();
                Console.WriteLine("-", 30);
            }
            else if (home == 2)
            {
                Console.WriteLine("-", 30);
                Console.WriteLine("\nThat sure was something!");
            }
            else if (home == 3)
            {
                Console.WriteLine("-", 20);
                RedCard();
            }
            else if (home > 12)
            {
                YellowCard();
                Console.WriteLine("-", 30);
            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("-", 30);
            }
        }

        public void CheckTime()
        {
            --Time;
            if (Time == 0)
            {
                Console.WriteLine("That's the game folks!");
                GameOver = true;
                Console.ReadKey();
                //return false;
            }
            else if (Time < 90)
            {
                Console.WriteLine($"\n--{Time}--");
                // return false;
            }
            else if (Time == 45)
            {
                Console.WriteLine("\n---Half Time Break!---");
                Console.ReadKey();
                //return true;
            }

        }

        public void PlayGame()
        {
            bool isPlaying = false;
            while (!isPlaying)
            {
                Random eventChance = new Random();
                int num = eventChance.Next(0, 15);
                EventChecker(num);
                CheckTime();
                isPlaying = GameOver;
            }
        }
    }
}
