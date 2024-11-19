using EmployeeAPI.Exceptions;
using EmployeeAPI.Models;
using EmployeeAPI.Repositories;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _empRepository;
        public EmployeeService(IRepository<Employee> empRepository)
        {
            _empRepository = empRepository;
        }
        public Guid AddEmployee(Employee employee)
        {
            _empRepository.Add(employee);
            return employee.Id;
        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = _empRepository.GetById(id);
            if (employee == null)
                throw new EmployeeNotFoundException($"Employee Not Found with Given Id : {id}");
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            var employees = _empRepository.GetAll().ToList();
            if (employees.Count == 0)
                throw new EmployeesNotFoundException("Employees Not Found");
            return employees;
        }
    }
}
