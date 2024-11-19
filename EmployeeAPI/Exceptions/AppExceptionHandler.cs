using EmployeeAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                             Exception exception,
                                             CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is EmployeeNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Employee Not Found Please Enter Valid Input";
            }
            else if(exception is EmployeesNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Employees Not Found Please Enter Valid Input";
            }
            else if (exception is ValidationException) // Validation Exception Handled By This else if Condition
            {
                response.StatusCode = StatusCodes.Status400BadRequest;
                response.ExceptionMessage = exception.Message;
                response.Title = "Invalid User Input!";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something Went Wrong, Try Again!";
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
