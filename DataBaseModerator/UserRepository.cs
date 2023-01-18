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

        public async Task<User> AddUserWithParameters(int id, string phoneNumber, string fullName, string login, string password, Role userRole)
        {
            var user = new UserModel { 
                Id = id,
                PhoneNumber = phoneNumber, 
                FullName = fullName, 
                Login = login, 
                Password = password, 
                UserRole = userRole
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.ToDomain();
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user?.ToDomain();
        }

        public async Task<IEnumerable<User>> GetUserList()
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
