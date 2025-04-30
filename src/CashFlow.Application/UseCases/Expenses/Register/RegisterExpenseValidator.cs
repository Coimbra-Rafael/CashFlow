using CashFlow.Communication.Requests;
using CashFlow.Exception;

using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title)
            .NotEmpty().WithMessage(ResourceErroMessages.TITLE_REQUIRED);

        RuleFor(expense => expense.Amount)
            .GreaterThan(0).WithMessage(ResourceErroMessages.AMOUNT_MUST_BE_GREATER_THEN_ZERO);

        RuleFor(expense => expense.Date)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErroMessages.EXPENSES_CANNOT_OR_THE_FUTURE);

        RuleFor(expense => expense.PaymentType)
            .IsInEnum().WithMessage(ResourceErroMessages.PAYMENT_TYPE_INVALID);
    }
}
