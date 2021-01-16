using System;
using System.Collections.Generic;

namespace Domain.Players
{
    public class CreatedPlayerDTO
    {
        public Guid Id{ get; private set; }
        public IList<string> Errors{ get; set; }
        public bool IsValid { get; set; }

        public CreatedPlayerDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedPlayerDTO(IList<string> errors)
        {
            Errors = errors;
            IsValid = false;
        }
    }
}