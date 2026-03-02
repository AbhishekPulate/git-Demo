// CrmDbContext

using Microsoft.EntityFrameworkCore;

public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
}
public class CustomerService : ICustomerService
{
    private readonly CrmDbContext dbContext;

    public CustomerService(CrmDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return dbContext.Customers.ToList();
    }
}