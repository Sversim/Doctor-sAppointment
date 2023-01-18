namespace MyFirstClassLibrary
{
    public class UserInteractor
    {
        private readonly IUserRepository _repository;

        public UserInteractor(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsUserExists(string login, string password)
        {
            User? desiredUser = await _repository.GetUserByLogin(login);
            if (desiredUser is not null)
                if (desiredUser.Password == password)
                    return true;
            
            return false;
        }

        public async Task<Result<User>> AddUser(int id, string phoneNumber, string fullName, string login, string password, Role role)
        {
            User user = await _repository.AddUserWithParameters(id, phoneNumber, fullName, login, password, role);
            return user is null ? Result.Fail<User>("Пользователь не добавлен") : Result.Ok(user);
        }

        public async Task<Result<User>> SearchUserWithLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Логин должен быть непустым");

            var user = await _repository.GetUserByLogin(login);

            return user is null ? Result.Fail<User>("Пользователь с таким логином не найден") : Result.Ok(user);
        }
    }
}
