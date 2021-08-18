using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerGame
{
    public class TeamRepository
    {
        private readonly List<Team> _teams = new List<Team>();

        //public TeamRepository() { }

        public bool AddTeamToRepository(Team team)
        {
            int startingCount = _teams.Count();

            _teams.Add(team);

            bool wasAdded = _teams.Count() > startingCount;

            return wasAdded;
        }

        public void ShowTeams()
        {
            foreach (Team team in _teams)
            {
                Console.WriteLine(team.TeamName);
                Console.ReadKey();
            }
        }
        /*
        public bool UpdateTeam(string teamName, Team team)
        {

        }

        public bool UpdateTeamName(string oldTeamName, string newTeamName)
        {
            Team oldTeam = GetTeamByName(oldTeamName);
            oldTeam.TeamName = newTeamName;
            return true;
        }

        public bool DeleteTeam(Team team)
        {

        }
        */
        public Team GetTeamByName(string teamName)
        {
            foreach (Team team in _teams)
            {
                if (team.TeamName == teamName)
                {
                    return team;
                }
            }
            return null;
        }

        /*
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);

            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.StarRating = newContent.StarRating;
                oldContent.GenreType = newContent.GenreType;

                return true;
            }

            return false;
        }

        // Delete
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
        */
    }
}
