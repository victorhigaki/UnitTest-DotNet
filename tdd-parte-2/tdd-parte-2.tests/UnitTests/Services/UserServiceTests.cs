using Application.Services;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Moq;
using tdd_parte_2.tests.Helpers.TestDoubles.Dummy;
using tdd_parte_2.tests.Helpers.TestDoubles.Mock;
using tdd_parte_2.tests.Helpers.TestDoubles.Spy;
using tdd_parte_2.tests.Helpers.TestDoubles.Stub;

namespace tdd_parte_2.tests.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
        }


        [Fact]
        public async Task Authenticate_LoginIsValidWithMoq_ReturnTrue()
        {
            //Arrange
            var username = "Teste";
            var password = "Teste";
            _userRepositoryMock.Setup(x => x.GetUserByUsername(username)).ReturnsAsync(new User());
            _userRepositoryMock.Setup(x => x.Authenticate(username, password)).ReturnsAsync(true);

            var service = new UserService(_userRepositoryMock.Object);

            //Act
            var result = await service.Authenticate(username, password);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Authenticate_UserNotExists_ReturnFalse()
        {
            //Arrange
            var username = "Teste";
            var password = "Teste";
            var repository = new UserRepositoryDummy();
            var service = new UserService(repository);

            //Act
            var result = await service.Authenticate(username, password);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Authenticate_LoginIsInvalid_ReturnFalse()
        {
            //Arrange
            var username = "Teste";
            var password = "Teste";
            var repository = new UserRepositoryStub();
            var service = new UserService(repository);

            //Act
            var result = await service.Authenticate(username, password);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task Authenticate_ParamsIsCorrect_ReturnTrue()
        {
            //Arrange
            var username = "Teste";
            var password = "Teste";
            var repository = new UserRepositorySpy();
            var service = new UserService(repository);
            repository.SetResult(true);

            //Act
            var result = await service.Authenticate(username, password);

            //Assert
            Assert.True(result);
            Assert.Equal(username, repository.GetLastUsername());
            Assert.Equal(password, repository.GetLastPassword());
            Assert.Equal(1, repository.GetCount());
        }

        [Fact]
        public async Task Authenticate_ParamsIsCorrectWithMock_ReturnTrue()
        {
            //Arrange
            var username = "Teste";
            var password = "Teste";
            var repository = new UserRepositoryMock(username, password, 1);
            var service = new UserService(repository);
            repository.SetResult(true);

            //Act
            var result = await service.Authenticate(username, password);

            //Assert
            Assert.True(result);
            Assert.True(repository.Validate());
        }

    }
}