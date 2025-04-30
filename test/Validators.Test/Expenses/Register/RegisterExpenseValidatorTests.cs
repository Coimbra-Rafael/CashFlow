using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

using CommonTestUtilities.Requests;

namespace Validators.Tests.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        //arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();

        //act
        var result = validator.Validate(request);

       //assert

        Assert.True(result.IsValid);
    }
}
