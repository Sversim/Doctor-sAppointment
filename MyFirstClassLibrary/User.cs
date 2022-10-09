namespace MyFirstClassLibrary
{
    public class User
    {
        public int Id;
        public string PhoneNumder;
        public string FullName;
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole;

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User()
        {
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