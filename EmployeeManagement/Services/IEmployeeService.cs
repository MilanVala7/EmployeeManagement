namespace EmployeeManagement.Services;

public interface IEmployeeService
{
    Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(int id);

    Task<Employee> AddEmployeeAsync(Employee employee);

    Task<bool> DeleteEmployeeAsync(int id);
}
