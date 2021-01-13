using System;

namespace Domain.Users
{
    public interface IUsersService
    {
        CreatedUserDTO Create(
            string name,
            string email,
            UserProfile profile,
            string password
        );

        User GetById(Guid id);
    }
}
