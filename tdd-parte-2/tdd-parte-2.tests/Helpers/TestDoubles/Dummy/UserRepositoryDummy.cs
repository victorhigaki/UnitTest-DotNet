using Data.Repositories;
using Domain.Entidades;
using Domain.Interfaces.Repositories;

namespace tdd_parte_2.tests.Helpers.TestDoubles.Dummy
{
    public class UserRepositoryDummy : IUserRepository
    {
        public Task<bool> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return null;
        }
    }
}
