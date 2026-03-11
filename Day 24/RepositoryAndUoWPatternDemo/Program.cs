

var context = new DatabaseContext();

var customer5 = context.Customers.GetById(5);

customer5.Name = "Zia";

Console.WriteLine($"Customer 5 Name: {customer5.Name}");

var customer6 = new Customer {};

context.Customers.Add(customer6);

context.Customers.Remove(3);

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public partial class DatabaseContext
{
    public List<Customer> Customers { get; set; } = new();
}

public class CustomerRepository
{
    private readonly DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.FirstOrDefault(c => c.Id == id);
    }

    public void Remove(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }
    }
}


namespace DesignPatternsDemo.Infrastructure;

public class UnitOfWork
{
    private readonly DatabaseContext _context;

    public CustomerRepository Customers { get; }
    public CustomerRepository Order { get; }

    public UnitOfWork()
    {
        _context = new DatabaseContext();
        Customers = new CustomerRepository(_context);
    }

    public void Commit()
    {
        Console.WriteLine("Changes committed to database.");
    }
}