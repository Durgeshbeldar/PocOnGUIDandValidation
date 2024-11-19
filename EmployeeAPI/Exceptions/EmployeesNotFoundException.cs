namespace EmployeeAPI.Exceptions
{
    public class EmployeesNotFoundException : Exception
    {
        public EmployeesNotFoundException(string message) : base(message) { }
    }
}
