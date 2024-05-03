using Domain.Entidades;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AllContext _context;

        public UserRepository(AllContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<bool> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
