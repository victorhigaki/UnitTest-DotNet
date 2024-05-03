using Domain.Entidades;
using Domain.Interfaces.Repositories;

namespace tdd_parte_2.tests.Helpers.TestDoubles.Spy
{
    internal class UserRepositorySpy : IUserRepository
    {
        private string _LastUsername;
        private string _LastPassword;
        private int _count;
        private bool _result;

        public async Task<bool> Authenticate(string username, string password)
        {
            _count++;
            _LastUsername = username;
            _LastPassword = password;
            return _result;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return new User();
        }

        public void SetResult(bool result)
        {
            _result = result;
        }

        public string GetLastUsername() => _LastUsername;
        public string GetLastPassword() => _LastPassword;
        public int GetCount() => _count;
    }
}
