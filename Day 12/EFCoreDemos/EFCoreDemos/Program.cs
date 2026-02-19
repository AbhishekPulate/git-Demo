
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

CrmContext _context = new CrmContext();

var customers = _context.Customers
    .Where(e => e.Age > 20)
    .AsEnumerable();
// .ToList();
// Deffered and Immediate execution in EF Core.
// if we remove ToList then it will convert to Enumerable so we can access in for loop otherwise it will be present in query format only.
// AsEnumerable is more efficient than ToList because it does not create a new list in memory, it just returns an IEnumerable that can be enumerated.

//customers.Add(new Customer { Name = "Tushar", Age = 33 });

//_context.SaveChanges();
var abhi = _context.Customers.FirstOrDefault(c => c.Name == "Abhishek");
if (abhi != null) abhi.Age = 331;

_context.SaveChanges();

foreach (var c in customers)
{
    Console.WriteLine($"Id: {c.Id} Customer: {c.Name}, Age: {c.Age}");
}

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Product { get; set; }

    [Required]
    [Precision(18, 2)]
    public decimal Price { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Order> Orders { get; set; }
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
        modelBuilder.Entity<Student>()
            .HasKey(s => s.RollNo);
    }


}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
class Student
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Subject { get; set; }
}
