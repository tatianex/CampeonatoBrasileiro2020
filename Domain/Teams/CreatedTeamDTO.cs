using System;
using System.Collections.Generic;

namespace Domain.Teams
{
    public class CreatedTeamDTO
    {
        public Guid Id{ get; private set; }
        public IList<string> Errors{ get; set; }
        public bool IsValid { get; set; }

        public CreatedTeamDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedTeamDTO(IList<string> errors)
        {
            Errors = errors;
            IsValid = false;
        }
    }
}