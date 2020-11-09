namespace Domain.Users
{
    public class UsersService
    {
        public CreatedUserDTO Create(string name, UserProfile profile)
        {
            var user = new User(name, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                UsersRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }
            return new CreatedUserDTO(userValidation.errors);
        }
    }
}