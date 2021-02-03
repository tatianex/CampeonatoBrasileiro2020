using System;

namespace Domain.Users
{
    public interface IUsersService
    {
        CreatedUserDTO Create(
            UserProfile profile,
            string name,
            string email,
            string password
        );

        User GetById(Guid id);
    }
}
