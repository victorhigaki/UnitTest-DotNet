using Domain.Entidades;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> Authenticate(string username, string password);
        Task<User> GetUserByUsername(string username);
    }
}
