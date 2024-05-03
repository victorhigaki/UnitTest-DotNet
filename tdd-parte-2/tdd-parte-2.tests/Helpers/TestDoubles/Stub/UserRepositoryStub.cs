using Domain.Entidades;
using Domain.Interfaces.Repositories;

namespace tdd_parte_2.tests.Helpers.TestDoubles.Stub
{
    public class UserRepositoryStub : IUserRepository
    {
        public async Task<bool> Authenticate(string username, string password)
        {
            return false;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return new User();
        }
    }
}
