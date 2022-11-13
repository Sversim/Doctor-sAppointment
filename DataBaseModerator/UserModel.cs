using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public class UserModel
    {
        public UserModel(int id, string phoneNumber, string fullName, string login, string password, Role userRole)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            FullName = fullName;
            Login = login;
            Password = password;
            UserRole = userRole;
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; } = Role.User;
    }
}
