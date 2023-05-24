using API.Data.Inputs;
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
            while(months > 0)
            {
                result *= (1 + (TB_PERCENT * CDI_PERCENT));
                months--;
            }

            var tax = GetCalculateTax(query.Months, result - query.Amount); //valor do imposto calculado sobre o lucro

            return new CalculatedCDB() {
                GrossAmount = Math.Round(result, 2),
                NetAmount = Math.Round(result-tax, 2)
            };
        }

        private decimal GetCalculateTax(int months, decimal amount)
        {
            if (months <= 6)
                return amount * 0.225m;
            else if (months <= 12)
                return amount * 0.2m;
            else if (months <= 24)
                return amount * 0.175m;
            else
                return amount * 0.15m;
        }
    }
}
