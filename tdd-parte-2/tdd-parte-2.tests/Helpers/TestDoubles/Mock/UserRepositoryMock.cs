using tdd_parte_2.tests.Helpers.TestDoubles.Spy;

namespace tdd_parte_2.tests.Helpers.TestDoubles.Mock
{
    internal class UserRepositoryMock : UserRepositorySpy
    {
        private string _expectedUserName;
        private string _expectedPassword;
        private int _expectedCount;

        public UserRepositoryMock(string expectedUserName, string expectedPassword, int expectedCount)
        {
            _expectedUserName = expectedUserName;
            _expectedPassword = expectedPassword;
            _expectedCount = expectedCount;
        }

        public bool Validate()
        {
            return _expectedCount == GetCount() && _expectedUserName == GetLastUsername() && _expectedPassword == GetLastPassword();
        }

    }
}
