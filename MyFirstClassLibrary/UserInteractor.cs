namespace MyFirstClassLibrary
{
    public class UserInteractor
    {
        private readonly IRepository _repository;

        public UserInteractor(IRepository repository)
        {
            _repository = repository;
        }



        public bool IsUserExists(string login, string password)
        {
            User? desiredUser = _repository.GetUserByLogin(login);
            if (desiredUser is not null)
                if (desiredUser.Password == password)
                    return true;
            
            return false;
        }

        public Result<User> AddUser(string login, string password)
        {
            User user = _repository.AddUserWithParameters(login, password);
            return user is null ? Result.Fail<User>("Пользователь не добавлен") : Result.Ok(new User());
        }

        public Result<User> SearchUserWithLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Логин должен быть непустым");

            var user = _repository.GetUserByLogin(login);

            return user is null ? Result.Fail<User>("Пользователь с таким логином не найден") : Result.Ok(user);
        }
    }
}
