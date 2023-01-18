using Microsoft.AspNetCore.Mvc;
using MyFirstClassLibrary;
using MyFirstSolution.Views;

namespace MyFirstSolution.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly UserInteractor _interactor;
        public UserController(UserInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserSearchView>> GetUserByLogin(string login)
        {
            if (login == string.Empty)
                return Problem(statusCode: 404, detail: "Не указан логин");

            var userRes = await _interactor.SearchUserWithLogin(login);
            if (userRes.IsFailure)
                return Problem(statusCode: 404, detail: userRes.Error);

            return Ok(new UserSearchView
            {
                Id = userRes.Value.Id,
                Login = userRes.Value.Login
            });
        }

        [HttpPost("add_user")]
        public async Task<ActionResult<UserSearchView>> AddUser(int id, string phoneNumber, string fullName, string login, string password, Role role)
        {
            if (login == string.Empty)
                return Problem(statusCode: 404, detail: "Не указан логин");

            if (password == string.Empty)
                return Problem(statusCode: 404, detail: "Не указан пароль");

            if (fullName == string.Empty)
                return Problem(statusCode: 404, detail: "Не указано имя");

            if (phoneNumber == string.Empty)
                return Problem(statusCode: 404, detail: "Не указан номер");

            var userRes = await _interactor.AddUser(id, phoneNumber, fullName, login, password, role);
            if (userRes.IsFailure)
                return Problem(statusCode: 404, detail: userRes.Error);

            return Ok(new UserSearchView
            {
                Id = userRes.Value.Id,
                Login = userRes.Value.Login
            });
        }

        [HttpGet("is_user_exist")]
        public async Task<ActionResult<bool>> IsUserExists(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                return Problem(statusCode: 404, detail: "Не указан логин");
            if (string.IsNullOrEmpty(password))
                return Problem(statusCode: 404, detail: "Не указан пароль");

            var res = await _interactor.IsUserExists(login, password);
            return Ok(res);
        }
    }
}
