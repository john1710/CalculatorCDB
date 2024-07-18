using API.Data.Inputs;
using FluentValidation;

namespace API.Validations
{
    public class CalculateCDBQueryValidator : AbstractValidator<CalculateCDBQuery>
    {
        public CalculateCDBQueryValidator()
        {
            RuleFor(p => p.Months).GreaterThan(1).WithMessage("a quantidade de meses precisa ser maior que 1");
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("o valor precisa ser maior que 0");
        }
    }
}
