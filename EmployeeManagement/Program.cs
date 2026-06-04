var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmployeeDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddKeyedScoped<IEmployeeService, EmployeeService>("employee");

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(
        "fixed",
        options =>
        {
            options.PermitLimit = 10;
            options.Window = TimeSpan.FromMinutes(1);
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRateLimiter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
await app.SeedDataAsync();

app.Run();