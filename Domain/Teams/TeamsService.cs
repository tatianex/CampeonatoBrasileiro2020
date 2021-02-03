using System.Collections.Generic;

namespace Domain.Teams
{
    public class TeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        public TeamsService(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }

        public CreatedTeamDTO Create(string name, IList<string> playersNames)
        {
            var team = new Team(name, playersNames);
            var TeamValidation = team.Validate();

            if (TeamValidation.isValid)
            {
                _teamsRepository.Add(team);
                return new CreatedTeamDTO(team.Id);
            }

            return new CreatedTeamDTO(TeamValidation.errors);
        }
    }
}