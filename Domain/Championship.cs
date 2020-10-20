using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        public int TotalRound { get; set; } = 7;
        private List<Team> Teams { get; set; }
        private List<SoccerRound> _rounds { get; set; }
        public IReadOnlyCollection<SoccerRound> Rounds => _rounds;

        public bool CreateTeams(List<Team> teams, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Teams = teams;
                return true;
            }
            return false;            
        }

        private void CreateRounds(List<Team> teams, User user)
        {
            if ((user.Profile == User.UserProfile.CBF) && (teams.Count > 7) && (teams.Count % 2 == 0))
            {
                //Criar automaticamente uma lista tuplas onde cada time joga com os outros 1 vez.

                _rounds.Add(new SoccerRound(teams, user));

            }
        }

        public void ShowFinalResults()
        {

        }

        public void ShowTeamPoints()
        {

        }
    }
}