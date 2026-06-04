namespace EmployeeManagement.Repository;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> GetAll();

    Task<Employee?> GetById(int id);

    Task<Employee> Add(Employee employee);

    Task<bool> Delete(int id);
}
