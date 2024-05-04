using Bogus;
using Domain.Models;

namespace tdd_parte_2.tests.Helpers.Fixture
{
    internal class UserModelFixture
    {
        public static UserModel GetUserModelValid()
        {
            var faker = new Faker<UserModel>();
            faker.RuleFor(x => x.Username, r => r.Random.String(5));
            faker.RuleFor(x => x.Password, r => r.Random.String(5));
            return faker;
        }
    }
}
