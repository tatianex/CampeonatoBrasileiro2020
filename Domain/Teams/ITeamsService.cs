using System.Collections.Generic;

namespace Domain.Teams
{
    public interface ITeamsService
    {
        CreatedTeamDTO Create(string name, IList<string> playersNames);
    }
}
