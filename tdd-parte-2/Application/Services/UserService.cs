using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Domain.Models;

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

        public async Task<bool> Add(UserModel model)
        {
            var existingUser = await _repository.GetUserByUsername(model.Username);
            if (existingUser != null) return false;

            var user = new User();
            user.Username = model.Username;
            user.Password = model.Password;

            var success = await _repository.Add(user);
            return success;
        }
    }
}
