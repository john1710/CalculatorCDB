using API.Interfaces.Services;
using API.Models;
using FluentValidation;

namespace API.Services
{
    public class CalculatorCDBService : ICalculatorCDBService
    {
        private const decimal TB_PERCENT = 1.08m;
        private const decimal CDI_PERCENT = 0.009m;

        private readonly IValidator<CalculateCDBQuery> validator;

        public CalculatorCDBService(IValidator<CalculateCDBQuery> validator)
        {
            this.validator = validator;
        }

        public async Task<CalculatedCDB> CalculateCDB(CalculateCDBQuery query)
        {

            await validator.ValidateAndThrowAsync(query);

            var result = query.Amount;
            var months  = query.Months;
            var tax = 0m;
            while(months > 0)
            {
                result = result * (1 + (TB_PERCENT * CDI_PERCENT));
                months--;
            }

            var profit = result - query.Amount;

            if (query.Months <= 6)
                tax = profit * 0.225m;
            else if (query.Months <= 12)
                tax = profit * 0.2m;
            else if (query.Months <= 24)
                tax = profit * 0.175m;
            else
                tax = profit * 0.15m;

            return new CalculatedCDB() {
                GrossAmount = Math.Round(result, 2),
                NetAmount = Math.Round(result-tax, 2)
            };
        }
    }
}
