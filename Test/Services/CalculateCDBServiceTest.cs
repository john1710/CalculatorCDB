using API.Data.Inputs;
using API.Services;
using API.Validations;
using FluentValidation;

namespace Test.Services
{
    public class CalculateCDBServiceTest
    {

        private IValidator<CalculateCDBQuery>? validator;


        [Theory]
        [InlineData(2, 300, 304.54, 305.86)]
        [InlineData(24, 8000, 9724.67, 10090.51)]
        [InlineData(8, 4650.35, 4949.67, 5024.51)]
        [InlineData(48, 6800000, 10215468.31, 10818198.02)]
        public async void CalculatorCDBService_Should_Pass_With_Valid_Arguments(int months, decimal amount, decimal netAmount, decimal grossAmount)
        {
            //arrange
            validator = new CalculateCDBQueryValidator();

            var service = new CalculatorCDBService(validator);

            //act

            var result = await service.CalculateCDB(new CalculateCDBQuery() { Amount = amount, Months = months });

            //assert
            Assert.Equal(netAmount, result.NetAmount);
            Assert.Equal(grossAmount, result.GrossAmount);
        }


        [Theory]
        [InlineData(0, 300)]
        [InlineData(24, -45)]
        [InlineData(-3, 4650.35)]
        [InlineData(48, 0.9)]
        [InlineData(-50, 0.9)]
        [InlineData(-1, -1)]
        public async void CalculatorCDBService_Should_Fail_With_Invalid_Arguments(int months, decimal amount)
        {
            //arrange
            validator = new CalculateCDBQueryValidator();
            var query = new CalculateCDBQuery() { Amount = amount, Months = months };
            var service = new CalculatorCDBService(validator);
            Func<Task> act = () => service.CalculateCDB(query);
            //act
            await Assert.ThrowsAsync<ValidationException>(act);
        }

    }
}
