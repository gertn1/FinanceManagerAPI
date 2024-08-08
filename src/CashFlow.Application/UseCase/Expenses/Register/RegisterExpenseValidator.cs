using CashFlow.Communication.Request;
using FluentValidation;

namespace CashFlow.Application.UseCase.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("The title is required");
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero");
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expenses cannot be for the future");
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Paymente Type is not valid"); 
        }

    }
}
