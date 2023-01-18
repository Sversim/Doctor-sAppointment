namespace MyFirstClassLibrary
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserList();
        Task<User?> GetUserByLogin(string login);
        Task<User> AddUserWithParameters(int id, string phoneNumber, string fullName, string login, string password, Role userRole);
    }
}
