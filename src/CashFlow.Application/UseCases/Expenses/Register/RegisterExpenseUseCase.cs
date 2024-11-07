using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisterExpense Execute(RequestRegisterExpense request)
    {
        // to do validations
        return new ResponseRegisterExpense();   
    }
}
