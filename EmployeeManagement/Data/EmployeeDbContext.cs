namespace EmployeeManagement.Data;

public class EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();
}
