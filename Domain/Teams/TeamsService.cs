using System;

namespace Domain.Teams
{
    public class TeamsService
    {
        private readonly TeamsRepository _teamsRepository = new TeamsRepository();
        public CreatedTeamDTO CreateTeam(string name)
        {
            var team = new Team(name);
            var teamValidation = team.Validate();

            if (teamValidation.isValid)
            {
                _teamsRepository.Add(team);
                return new CreatedTeamDTO(team.Id);
            }
            return new CreatedTeamDTO(teamValidation.errors);
        }

        public Team GetById(Guid id)
        {
            return _teamsRepository.GetById(id);
        }
    }
}