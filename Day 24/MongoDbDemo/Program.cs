using MongoDB.Driver;

// Replace with your credentials and server details
string username = "sa";
string password = "p@ssw0rd";

// 1. Create the credential object
var credentials = MongoCredential.CreateCredential("testdb", username, password);

// 2. Create the settings object and add credentials
var settings = new MongoClientSettings
{
    Credential = credentials,
    Server = new MongoServerAddress("localhost", 27017)
};

// 3. Create the MongoClient with the settings
var client = new MongoClient(settings);
var database = client.GetDatabase("testdb");
Console.WriteLine("Connection successful!");

// customer collection

var collection = database.GetCollection<Customer>("customers");

collection.InsertOne(new Customer
{
    Name = "John Doe",
    Age = 30,
    Email = "john.doe@example.com"
});

// Read data

var customers = collection.Find(_ => true).ToList();

foreach (var customer in customers)
{
    Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
}

class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}