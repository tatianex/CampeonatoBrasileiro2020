using System.Collections.Generic;

namespace Domain.Users
{
    static class UsersRepository
    {
        private static List<User> _users { get; set; } = new List<User>();
        public static IReadOnlyCollection<User> Users => _users;

        public static void Add(User user)
        {
            _users.Add(user);
        }
    }
}