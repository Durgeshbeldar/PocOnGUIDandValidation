using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        public Guid AddEmployee(Employee employee);
        public Employee GetEmployeeById(Guid id);
        public List<Employee> GetEmployees();
    }
}
