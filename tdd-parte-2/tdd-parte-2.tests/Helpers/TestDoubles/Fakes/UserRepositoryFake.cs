using Domain.Entidades;
using Domain.Interfaces.Repositories;

namespace tdd_parte_2.tests.Helpers.TestDoubles.Fakes
{
    public class UserRepositoryFake : IUserRepository
    {
        public Task<bool> Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            return (username.Equals("user") && password.Equals("12345"));
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return new User();
        }
    }
}
