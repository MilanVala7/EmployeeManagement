namespace EmployeeManagement.Repository;

public class EmployeeRepository(EmployeeDbContext db) : IEmployeeRepository
{
    public async Task<IReadOnlyList<Employee>> GetAll()
    {
        return await db.Employees.ToListAsync();
    }

    public async Task<Employee?> GetById(int id)
    {
        return await db.Employees.FindAsync(id);
    }

    public async Task<Employee> Add(Employee e)
    {
        db.Employees.Add(e);
        await db.SaveChangesAsync();

        return e;
    }

    public async Task<bool> Delete(int id)
    {
        var e = await db.Employees.FindAsync(id);

        if (e is null)
            return false;

        db.Employees.Remove(e);
        await db.SaveChangesAsync();

        return true;
    }
}