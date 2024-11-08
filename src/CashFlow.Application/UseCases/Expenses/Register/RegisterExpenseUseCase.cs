﻿using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

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
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty) {
            throw new ArgumentException("The title is required");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (result > 0) {
            throw new ArgumentException("Expenses cannot be for the future");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if (!paymentTypeIsValid) { 
            throw new ArgumentException($"Invalid payment type {request.PaymentType}");
        }
    }
}
