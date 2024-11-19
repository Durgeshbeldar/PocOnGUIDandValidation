using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _empService = employeeService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            var employee = _empService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            var employees = _empService.GetEmployees(); 
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Add(Employee newEmployee)
        {
            
            if (!ModelState.IsValid)  // Validation Check
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                // This Will Handled The Exception Related to Validation
                throw new ValidationException($"{errors}");
            }
            var addedEmpId = _empService.AddEmployee(newEmployee);
            return Ok($"Employee is Added and the Id is : {addedEmpId}");
        }
    }
}
