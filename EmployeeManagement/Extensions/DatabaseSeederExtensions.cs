namespace EmployeeManagement.Extensions;

public static class DatabaseSeederExtensions
{
    extension(WebApplication app)
    {
        public async Task SeedDataAsync()
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider
                     .GetRequiredService<EmployeeDbContext>();

            await context.Database.MigrateAsync();

            if (await context.Employees.AnyAsync())
            {
                return;
            }

            List<Employee> employees =
            [
                new() { Name = "abc", Department = "IT" },
                new() { Name = "pqr", Department = "Sales" },
                new() { Name = "xyz", Department = "HR" }
            ];

            await context.Employees.AddRangeAsync(employees);

            await context.SaveChangesAsync();
        }
    }
}