﻿using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisterExpense Execute(RequestRegisterExpense request)
    {
        Validate(request);
        return new ResponseRegisterExpense();   
    }

    private void Validate(RequestRegisterExpense request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
