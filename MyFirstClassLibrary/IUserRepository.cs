namespace MyFirstClassLibrary
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserList();
        User? GetUserByLogin(string login);

        User AddUserWithParameters(string phoneNumber, string fullName, string login, string password, Role userRole);
    }
}
