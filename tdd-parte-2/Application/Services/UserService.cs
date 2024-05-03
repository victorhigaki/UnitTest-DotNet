using Data.Repositories;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var existingUser = await _repository.GetUserByUsername(username);
            if (existingUser == null) return false;
        
            var success = await _repository.Authenticate(username, password);
            return success;
        }
    }
}
