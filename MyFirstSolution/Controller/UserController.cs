using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyFirstClassLibrary;
using MyFirstSolution.Views;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        [HttpPost("/token")]
        public async Task<IActionResult> Token(string login, string password)
        {
            var identity = await GetIdentity(login, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Пользователя с указанными данными не существует" });
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthorOptions.ISSUER,
            audience: AuthorOptions.AUDIENCE,
            notBefore: now,
            claims: identity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthorOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthorOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = login,
            };
            return new JsonResult(response);
        }

        private async Task<ClaimsIdentity> GetIdentity(string login, string password)
        {
            var person = await _interactor.SearchUserWithLogin(login);
            if (person != null && person.Value.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Value.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Value.Password)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
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

        [Authorize]
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
