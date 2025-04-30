using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Exception.ExceptionBase;
using CashFlow.Infrastructure.DataAccess;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {

        Validate(request);

        var dbContext = new CashFlowDbContext();

        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Title = request.Title,
            Description = request.Description,
            PaymentType = (Domain.Enums.PaymentType)request.PaymentType
        };

        dbContext.Expenses.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);
        
        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}