namespace MyFirstClassLibrary
{
    public interface IRepository
    {
        IEnumerable<User> GetUserList();
        User? GetUserByLogin(string login);

        User AddUserWithParameters(string login, string password);
    }
}
