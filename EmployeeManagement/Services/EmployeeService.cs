namespace EmployeeManagement.Services;

public class EmployeeService(IEmployeeRepository repo) : IEmployeeService
{
    public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync()
    {
        return await repo.GetAll();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await repo.GetById(id);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        return await repo.Add(employee);
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        return await repo.Delete(id);
    }
}