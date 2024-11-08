﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpense request)
    {
        try
        {
            var response = new RegisterExpenseUseCase().Execute(request);
            return Created(string.Empty, Response);
        }
        catch (ErrorOnValidationException ex) 
        {
            var errorResponse = new ResponseErrorJson(ex.Errors);
            
            return BadRequest(errorResponse);
        }
        catch 
        {
            var errorResponse = new ResponseErrorJson("unknown error");

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
