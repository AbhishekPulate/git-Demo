class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
}

public partial class DatabaseContext
{
    public List<Order> Orders { get; set; } = new();
}

class OrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders;
    }

    public Order? GetById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

    public void Remove(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }
    }
}

public class UnitOfWork
{
    private readonly DatabaseContext _context;

    public CustomerRepository Customers { get; }
    public OrderRepository Orders { get; }

    public UnitOfWork()
    {
        _context = new DatabaseContext();
        Customers = new CustomerRepository(_context);
        Orders = new OrderRepository(_context);
    }

    public void SaveChanges()
    {
        lock (_context)
        {
            using var transaction = new TransactionScope();
            
            // Simulate saving changes to the database.
            // In a real application, this would involve committing a transaction
            // and persisting changes to the database.

        }
        // In a real application, this would persist changes to the database.
        // Here, it's just a placeholder to demonstrate the concept.
    }

    public void Commit()
    {
        SaveChanges();
    }
}