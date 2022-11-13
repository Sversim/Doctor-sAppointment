namespace MyFirstClassLibrary
{
    public class User
    {
        public int Id;
        public string PhoneNumber;
        public string FullName;
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole;

        public User(int id, string phoneNumber, string fullName, string login, string password, Role userRole)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            FullName = fullName;
            Login = login;
            Password = password;
            UserRole = userRole;
        }

        public bool RegistrationOfUser()
        {
            return true;
        }

        public bool AuthorizationOfUser()
        {
            return true;
        }
    }
}