using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class ProgramUI
    {     
        public ProgramUI() { }

        public void Run()
        {
            TeamRepository _teams = Seeding();
            Menu(_teams);
        }
        
        public void Menu(TeamRepository teams)
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                // \n = new line = CR + LF
                // CR = Carriage Return
                // LF = Line Feed
                Console.WriteLine("Menu:\n" +
                    "1. Start a new game\n" +
                    "2. Display team rosters\n" +
                    "3. Show team records\n" +
                    "4. Create a new team\n" +
                    "5. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        StartGame(teams);
                        break;
                    case "2":
                        teams.TeamRosters(teams);
                        break;
                    case "3":
                        ShowTeamRecords(teams);
                        break;
                    case "4":
                        //CreateTeam();
                        break;
                    case "exit":
                    case "EXIT":
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Goodbye!");
            Thread.Sleep(2000);

            // returns a ConsoleKeyInfo:
            // var key = Console.ReadKey();
            // returns a string:
            // Console.ReadLine();
        }
        
        public void ShowTeamRecords(TeamRepository teams)
        {
            foreach (Team team in teams._teams)
            {
                Console.WriteLine(team.TeamName);
                team.FormatRecord();
                Thread.Sleep(400);
            }
            Console.ReadKey();
        }



        public void StartGame(TeamRepository team)
        {
            //Team Spurs = new Team("Spurs", SpursRecord, SpursRoster);
            //Team Arsenal = new Team("Scum", ScumRecord, ArseRoster);
            //Game game = new Game(teamRepository; 
            Game game = new Game(team.GetTeamByName("Spurs"), team.GetTeamByName("Arsenal"));
            game.PlayGame();
        }

        

        /*
        public void CreateTeam()
        {

        }
        */
        public TeamRepository Seeding()
        {
            TeamRepository teamRepository  = new TeamRepository();

            List<int> SpursRecord = new List<int> { 1, 0, 0 };
            List<int> ScumRecord = new List<int> { 0, 1, 0 };
            List<int> ChelseaRecord = new List<int> { 0, 0, 1 };
            /*

            Team one = new Team("Spurs", SpursRecord, SpursRoster);
            Team two = new Team("Scum", ScumRecord, ArseRoster);

            Game game = new Game(one, two);
            Console.WriteLine(two.PowerRanking);
            Console.WriteLine(one.PowerRanking);
            Console.ReadKey();
            game.PlayGame();
            game.Goal();
            game.YellowCard();
            game.CheckTime();
            Position position = Position.Forward;
            Console.WriteLine(position);
            Console.ReadKey();
            Player player = new Player(position, 6, "Harry Kane", "13");
            Console.WriteLine(player.PlayerNumber + "\n" + player.FullName);
            */
            List<Player> SpursRoster = new List<Player>()
            {
            new Player(Position.Forward, 7, "Lucas Moura", "27"),
            //new Player(Position.Forward, 6, "Stephen Bergwijn", "23"),
            new Player(Position.Forward, 9, "Heung-min Son", "7"),
            new Player(Position.Midfielder, 9, "Pierre Hojbjerg", "26"),
            new Player(Position.Midfielder, 8, "Giovanni Lo Celso", "18"),
            new Player(Position.Midfielder, 9, "Oliver Skipp", "29"),
            new Player(Position.Midfielder, 7, "Tanguy Ndombele", "28"),
            new Player(Position.Defender, 7, "Ben Davies", "33"),
            new Player(Position.Defender, 7, "Joe Rodon", "14"),
            new Player(Position.Defender, 8, "Sergio Reguilon", "3"),
            new Player(Position.Defender, 9, "Christian Romero", "4"),
            new Player(Position.Goalkeeper, 9, "Hugo Lloris", "1"),
            };

            List<Player> ArseRoster = new List<Player>()
            {
            new Player(Position.Forward, 7, "Alexandre Lacazette", "9"),
            //new Player(Position.Forward, 5, "Willian", "12"),
            new Player(Position.Forward, 7, "Nicolas Pepe", "19"),
            new Player(Position.Midfielder, 6, "Granit Xhaka", "34"),
            new Player(Position.Midfielder, 4, "Mohamed Elneny", "25"),
            new Player(Position.Midfielder, 8, "Emile Smith-Rowe", "10"),
            new Player(Position.Midfielder, 7, "Thomas Partey", "5"),
            new Player(Position.Defender, 6, "Hector Bellerin", "2"),
            new Player(Position.Defender, 8, "Kieran Tierney", "3"),
            new Player(Position.Defender, 7, "Gabriel", "6"),
            new Player(Position.Defender, 6, "Ben White", "4"),
            new Player(Position.Goalkeeper, 9, "Bernd Leno", "1"),
            };


            List<Player> ChelseaRoster = new List<Player>()
            {
                new Player(Position.Forward, 3, "Timo Werner", "11"),
                new Player(Position.Forward, 10, "Christian Pulisic", "10"),
                new Player(Position.Forward, 8, "Romelu Luckaku", "9"),
                new Player(Position.Midfielder, 9, "N'Golo Kante", "7"),
                new Player(Position.Midfielder, 7, "Jorgino", "5"),
                new Player(Position.Midfielder, 7, "Mason Mount", "19"),
                new Player(Position.Midfielder, 6, "Mateo Kovacic", "8"),
                new Player(Position.Defender, 8, "Thiago Silva", "6"),
                new Player(Position.Defender, 2, "Marcos Alonso", "3"),
                new Player(Position.Defender, 7, "Cesar Azpilicueta", "28"),
                new Player(Position.Defender, 7, "Reece James", "24"),
                new Player(Position.Goalkeeper, 4, "Kepa Arrizabalaga", "1"),
            };

            /*
            Player Kane = new Player(Position.Forward, 9, "Harry Kane", "10");
            Player Bergwijn = new Player(Position.Forward, 6, "Stephen Bergwijn", "23");
            Player Son = new Player(Position.Forward, 9, "Heung-min Son", "7");
            Player Hojbjerg = new Player(Position.Midfielder, 9, "Pierre Hojbjerg", "26");
            Player LoCelso = new Player(Position.Midfielder, 8, "Giovanni Lo Celso", "18");
            Player Skipp = new Player(Position.Midfielder, 9, "Oliver Skipp", "29");
            Player Ndombele = new Player(Position.Midfielder, 7, "Tanguy Ndombele", "28");
            Player Davies = new Player(Position.Defender, 7, "Ben Davies", "33");
            Player Rodon = new Player(Position.Defender, 7, "Joe Rodon", "14");
            Player Reguilon = new Player(Position.Defender, 8, "Sergio Reguilon", "3");
            Player Romero = new Player(Position.Defender, 9, "Christian Romero", "4");
            Player Lloris = new Player(Position.Goalkeeper, 9, "Hugo Lloris", "1");
            */

            Team Spurs = new Team("Spurs", SpursRecord, SpursRoster);
            Team Arsenal = new Team("Arsenal", ScumRecord, ArseRoster);
            Team Chelsea = new Team("Chelsea", ChelseaRecord, ChelseaRoster);

            teamRepository.AddTeamToRepository(Arsenal);
            teamRepository.AddTeamToRepository(Spurs);
            teamRepository.AddTeamToRepository(Chelsea);

            //teamRepository.ShowTeams();

            return teamRepository;
        }
    }
}
