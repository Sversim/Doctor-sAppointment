namespace MyFirstClassLibrary
{
    public class User
    {
        public int Id;
        public string PhoneNumder;
        public string FullName;
        public Role UserRole;

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