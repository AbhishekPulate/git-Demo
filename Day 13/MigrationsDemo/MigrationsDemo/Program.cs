using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

var _context = new CrmDbContext();
var customers = _context.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Customer ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}");
}
class CrmDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Port=3306;Database=CrmDb;User=root;Password=Root;";

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerType>()
            .HasData(
                new CustomerType { Id = 1, TypeName = "Regular" },
                new CustomerType { Id = 2, TypeName = "Premium" }
            );

        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany()
            .HasForeignKey(o => o.CustomerId);
    }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class CustomerType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = string.Empty;
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}
