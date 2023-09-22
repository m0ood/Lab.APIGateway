namespace Lab.APIGateway.User
{
    public class UserService : IUserService
    {
        private static readonly List<User> users = new List<User>
    {
        new User { UserId = 1, Name = "Ivan", Age = 18 },
        new User { UserId = 2, Name = "David", Age = 22 },
        new User { UserId = 3, Name = "Dima", Age = 25 },
    };

        public User? GetUserById(int userId)
        {
            return users.Find(user => user.UserId == userId);
        }
    }
}
