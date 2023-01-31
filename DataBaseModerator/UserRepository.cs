using Microsoft.EntityFrameworkCore;
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
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.ToDomain();
        }

        public async Task<User?> GetUserByLogin(string login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
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
