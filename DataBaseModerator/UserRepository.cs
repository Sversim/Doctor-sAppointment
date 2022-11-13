using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User AddUserWithParameters(int id, string phoneNumber, string fullName, string login, string password, Role userRole)
        {
            var user = new UserModel(id, phoneNumber, fullName, login, password, userRole);
            _context.Users.Add(user);
            return user.ToDomain();
        }

        public User? GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user?.ToDomain();
        }

        public IEnumerable<User> GetUserList()
        {
            List<User> users = new List<User>(); ;
            foreach (var user in _context.Users.ToList() ?? Enumerable.Empty<UserModel>())
            {
                users.Add(user.ToDomain());
            }
            return users;
        }
    }
}
