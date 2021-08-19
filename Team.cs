using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class Team : TeamRepository
    {
        //private readonly List<Team> _teams = new List<Team>();
        //Properties
        public string TeamName { get; set; }
        public List<Player> Roster { get; set; }
        public List<int> Record { get; set; }
        public int PowerRanking {
                get
                {
                int total = 0;
                foreach(Player player in Roster)
                {
                    total += player.PowerRanking;
                    //Console.WriteLine(total);
                }
                //Console.WriteLine(Roster.Count());
                //Console.ReadKey();
                return total / Roster.Count();
                }
            set { }
            }


        public Team() { }
        public Team(string name, List<int> record, List<Player> roster)
        {
            TeamName = name;
            Record = record;
            Roster = roster;
        }

        public void FormatRecord()
        {
            Console.WriteLine($"Wins: {Record[0]} Losses: {Record[1]} Ties: {Record[2]}");
        }
        /*
        public void TeamRosters(TeamRepository teamRepository)
        {
            foreach (Team team in teamRepository._teams)
            {
                foreach (Player player in team.Roster)
                {
                    player.ShowPlayerInfo();
                }
            }
        }
        */
    }

    public class Game
    {
        public Team Home { get; set; }
        public Team Away { get; set; }
        public int HomeGoals { get; set; } = 0;
        public int AwayGoals { get; set; } = 0;
        public int HomeCards { get; set; } = 0;
        public int AwayCards { get; set; } = 0;
        public int Time { get; set; } = 90;
        public bool GameOver { get; set; } = false;

        private string text = File.ReadAllText(@"C:\Users\bryso\OneDrive\Documents\ElevenFifty Assignments\SoccerFiles\FlavorCommentary.txt");

        public Game() { }
        public Game(Team home, Team away)
        {
            Home = home;
            Away = away;
        }

        public void ShowTeamRosters()
        {
            Console.WriteLine("Your starting 11 for tonights game!");
            Console.WriteLine($"\nAway Team: {Away.TeamName}");
            Thread.Sleep(1000);
            foreach (Player player in Away.Roster)
            {
                player.ShowPlayerInfo();
                Thread.Sleep(500);
            }
            Console.WriteLine($"\nHome Team: {Home.TeamName}");
            Thread.Sleep(1000);
            foreach (Player player1 in Home.Roster)
            {
                player1.ShowPlayerInfo();
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }

        private void Goal()
        {
            Random homeGoal = new Random();
            Random awayGoal = new Random();
            if (homeGoal.Next(0, Home.PowerRanking) > awayGoal.Next(0, Away.PowerRanking))
            {
                HomeGoals++;
                Console.WriteLine($"\n{Home.TeamName} scored!");
                ShowGoals();
                Console.ReadKey();
            }
            else if (homeGoal.Next(0, Home.PowerRanking) < awayGoal.Next(0, Away.PowerRanking))
            {
                AwayGoals++;
                Console.WriteLine($"\n{Away.TeamName} scored!");
                ShowGoals();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nThat was close!");
                Console.ReadKey();
            }
        }

        private void ShowGoals()
        {
            Console.WriteLine($"\n{Home.TeamName}: {HomeGoals} | {Away.TeamName}: {AwayGoals}");
        }
        private void YellowCard()
        {

            
            Random homeCards = new Random();
            Thread.Sleep(50);
            Random awayCards = new Random();
            Thread.Sleep(50);
            Random eventChance = new Random();
            if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                HomeCards++;
                string[] flavor = text.Split('~');
                string[] flavorText = flavor[1].Split('|');
                int i = eventChance.Next(0, flavorText.Length);
                Console.WriteLine($"\n{flavorText[i]}");
                Console.WriteLine($"\n{Home.TeamName} received a yellow card caution!");
                Console.ReadKey();
            }
            else if (homeCards.Next(0, Home.PowerRanking) > awayCards.Next(0, Away.PowerRanking))
            {
                AwayCards++;
                string[] flavor = text.Split('~');
                string[] flavorText = flavor[1].Split('|');
                int i = eventChance.Next(0, flavorText.Length);
                Console.WriteLine($"\n{flavorText[i]}");
                Console.WriteLine($"\n{Away.TeamName} received a yellow card caution!");
                Console.ReadKey();
            }
            else
            {
                //Console.WriteLine("\nThat was close!");
                //Console.ReadKey();
            }
        }

        private void RedCard()
        {
            Random homeCards = new Random();
            Thread.Sleep(50);
            Random awayCards = new Random();
            Thread.Sleep(50);
            Random eventChance = new Random();
            if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                HomeCards++;
                string[] flavor = text.Split('~');
                string[] flavorText = flavor[2].Split('|');
                int i = eventChance.Next(0, flavorText.Length);
                Console.WriteLine($"\n{flavorText[i]}");
                Console.WriteLine($"\n{Home.TeamName} received a red card!");
                Home.PowerRanking -= 3;
                Console.ReadKey();
            }
            else if (homeCards.Next(0, Home.PowerRanking) < awayCards.Next(0, Away.PowerRanking))
            {
                AwayCards++;
                string[] flavor = text.Split('~');
                string[] flavorText = flavor[2].Split('|');
                int i = eventChance.Next(0, flavorText.Length);
                Console.WriteLine($"\n{flavorText[i]}");
                Console.WriteLine($"\n{Away.TeamName} received a red card!");
                Away.PowerRanking -= 3;
                Console.ReadKey();
            }
            else
            {
                //Console.WriteLine("\nThat was close!");
                //Console.ReadKey();
            }
        }

        private void EventChecker(int home)
        {
            Random eventChance = new Random();
            Thread.Sleep(500);
            //int home = eventChance.Next(0, 15);
            int stringLength = 40;
            //Random eventChanceComparison = new Random();
            //int away = eventChanceComparison.Next(0, 10);
            if (home == 1)
            {
                Goal();
                Console.WriteLine(new string('-', stringLength));
            }
            else if (home == 2)
            {
                Console.WriteLine(new string('-', stringLength));
                RedCard();
            }
            else if (home > 12)
            {
                YellowCard();
                Console.WriteLine(new string('-', stringLength));
            }
            else if(home > 2 && home < 9)
            {
                string[] flavor = text.Split('~');
                string[] flavorText = flavor[0].Split('|');
                int i = eventChance.Next(0, flavorText.Length);
                Console.WriteLine($"\n{flavorText[i]}");
                Console.WriteLine(new string('-', stringLength));
                /*
                foreach (string item in flavorText)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
                string flavorText = string.Join("|", flavor[0]);
                string[] flavorFlavorText = flavorText
                */
            }
        }

        private void CheckTime()
        {
            --Time;
            if (Time == 0)
            {
                Console.WriteLine("\nThat's the game folks!");
                DisplayStats();
                GameOver = true;
                Console.ReadKey();
                //return false;
            }
            else if (Time == 45)
            {
                Console.WriteLine("\n--------Half Time Break!--------\n");
                DisplayStats();
                //Console.ReadKey();
                //return true;
            }
            else if (Time < 90)
            {
                Console.WriteLine($"\n--{Time}--");
                // return false;
            }

        }

        private void DisplayStats()
        {
            Console.WriteLine($"\nScore {Home.TeamName}: {HomeGoals} | {Away.TeamName}: {AwayGoals}");
            Console.WriteLine($"\nCards {Home.TeamName}: {HomeCards} | {Away.TeamName}: {AwayCards}");
            Console.ReadKey();
        }

        public void PlayGame()
        {
            ShowTeamRosters();
            Console.WriteLine("\n---Kickoff!---");
            Random eventChance = new Random(); 
            bool isPlaying = false;
            while (!isPlaying)
            {
                //Random eventChance = new Random();
                //int num = eventChance.Next(0, 15);
                EventChecker(eventChance.Next(0, 15));
                CheckTime();
                Thread.Sleep(500);
                isPlaying = GameOver;
            }
            Console.WriteLine(Home.PowerRanking);
            Console.WriteLine(Away.PowerRanking);
            Console.ReadKey();
        }


        //string text = File.ReadAllText(@"C:\Users\bryso\Documents\ElevenFifty Assignments\100SD\Drufsnor\game.txt");
        //string[] birds = text.Split('|');
    }
}
