
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

// register DbContext and CustomerService
builder.Services.AddScoped<CrmDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Add Sql Server
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CrmDbConnection")));

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();