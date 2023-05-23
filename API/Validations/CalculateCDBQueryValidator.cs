using API.Models;
using FluentValidation;

namespace API.Validations
{
    public class CalculateCDBQueryValidator : AbstractValidator<CalculateCDBQuery>
    {
        public CalculateCDBQueryValidator()
        {
            RuleFor(p => p.Months).GreaterThanOrEqualTo(1).WithMessage("a quantidade de meses precisa ser maior que 0");
            RuleFor(p => p.Amount).GreaterThanOrEqualTo(1).WithMessage("o valor precisa ser maior que 0");
        }
    }
}
