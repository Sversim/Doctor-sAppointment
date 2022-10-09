using Moq;
using MyFirstClassLibrary;
using System.Data;

namespace ClinicTests
{
    public class UserTests
    {
        private readonly UserInteractor _userInteractor;
        private readonly Mock<IRepository> _userRepositoryMock;

        public UserTests()
        {
            _userRepositoryMock = new Mock<IRepository>();
            _userInteractor = new UserInteractor(_userRepositoryMock.Object);
        }

        [Fact]
        public void NullOrEmptyLogin_Fail()
        {
            var res = _userInteractor.SearchUserWithLogin(string.Empty);

            Assert.True(res.IsFailure);
            Assert.Equal("Логин должен быть непустым", res.Error);
        }

        [Fact]
        public void UserNotFound_Fail()
        {

            _userRepositoryMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
            .Returns(() => null);

            var res = _userInteractor.SearchUserWithLogin("Lorem123");

            Assert.True(res.IsFailure);
            Assert.Equal("Пользователь с таким логином не найден", res.Error); 
        }

        [Fact]
        public void UserWasntAdded_Fail()
        {
            var res = _userInteractor.AddUser("81231234545", "Lorem Lorem", "123", "123", new Role());

            Assert.True(res.IsFailure);
            Assert.Equal("Пользователь не добавлен", res.Error);
        }
    }
}