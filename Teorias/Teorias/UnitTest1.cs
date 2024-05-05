using Teorias.ExampleDomain;
using Teorias.Fixtures;

namespace Teorias
{
    public class UnitTest1
    {
        [Fact]
        public void CalculatorSumResultTwo()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            int result = calculator.Sum(1, 1);

            //Assert
            Assert.Equal(2, result);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        public void CalculatorSumResultIsValid(int a, int b, int resultExpected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Sum(a, b);

            //Assert
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [ClassData(typeof(ValuesFixture))]
        public void CalculatorSumResultIsValidWithClassData(int a, int b, int resultExpected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Sum(a, b);

            //Assert
            Assert.Equal(resultExpected, result);
        }

        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 2, 3, 5 };
        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void CalculatorSumResultIsValidWithMemberData(int a, int b, int resultExpected)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Sum(a, b);

            //Assert
            Assert.Equal(resultExpected, result);
        }
    }
}