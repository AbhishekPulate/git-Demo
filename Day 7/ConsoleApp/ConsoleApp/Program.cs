using DelegatesDemo1;
using System.Collections.Generic;

namespace DelegatesDemo;

class Program
{
    static void Main(string[] args)
    {

        var customers = new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Abhishek" },
                new Customer { CustomerId = 2, CustomerName = "DInesh" },
                new Customer { CustomerId = 3, CustomerName = "Yash" }
            };

        var orders = new List<Order>
            {
                new Order { OrderId = 101, CustomerId = 1, OrderAmount = 2500 },
                new Order { OrderId = 102, CustomerId = 1, OrderAmount = 1500 },
                new Order { OrderId = 103, CustomerId = 2, OrderAmount = 3000 },
                new Order { OrderId = 104, CustomerId = 2, OrderAmount = 2000 },
                new Order { OrderId = 105, CustomerId = 2, OrderAmount = 1000 }
            };

        // LINQ Group Join
        var CustomerResult =
            from c in customers
            join o in orders on c.CustomerId equals o.CustomerId into orderGroup
            select new
            {
                CustomerName = c.CustomerName,
                Orders = orderGroup,
                OrderCount = orderGroup.Count(),
                TotalValue = orderGroup.Sum(x => x.OrderAmount)
            };

        
        foreach (var item in CustomerResult)
        {
            Console.WriteLine($"Customer: {item.CustomerName}, Total Orders: {item.OrderCount}, Total Order Value: {item.TotalValue}");
        }

       
      




        //DelegatesDemoApp app = new DelegatesDemoApp();
        ////app.Run();
        ////app.LambdaExpressionDemo();
        ////app.HigherOrderFunctionDemo();
        //Button button = new Button();

        //button.OnClick += () => Console.WriteLine("Bill Rings!");

        //// Subscriber Electricity Board
        //button.OnClick += () => Console.WriteLine("Charge for Electricity!");
        //button.OnClick += () => Console.WriteLine("third!");
        //button.OnClick += () => Console.WriteLine("Fourth!");

        //// Raise Event
        //button.Click();
    }
}
public class OnClickEventArgs : EventArgs
{
    public string ButtonName { get; set; }
}
// Publisher
public class Button
{
    public delegate void OnClickHandler();
    public event OnClickHandler OnClick;

    // Informing subscribers that the button was clicked

    public void Click()
    {
        OnClick?.Invoke();
    }
}

//void Add(int a, int b)
// delegate void MathOperation(int a, int b);
//int Add(int a, int b)
delegate int MathOperation(int a, int b);

// Generic Delegate

// delegate TResult GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);

delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);

class DelegatesDemoApp
{

    public void HigherOrderFunctionDemo()
    {
        var result = CalculateArea(AreaOfRectangle);
        Console.WriteLine($"Area: {result}");
    }
    int CalculateArea(Func<int, int, int> areaFunction)
    {
        return areaFunction(5, 10);
    }
    int AreaOfRectangle(int length, int width)
    {
        return length * width;
    }
    int AreaOfTriangle(int baseLength, int height)
    {
        return (baseLength * height) / 2; 
    }
    public void LambdaExpressionDemo()
    {
        Func<int, int> f;
        f = (int x) => x * x;
        var result = f(5);
        Console.WriteLine($"result: {result}");
    }
    public void AnonymousMethodDemo()
    {
        MathOperation operation = delegate (int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
            return a + b;
        };
        operation(5, 3);
    }
    void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public void Run()
    {
        // MathOperation operation = Add;
        // GenericTwoParameterFunction<int, int, int> genericOperation = Add;
        Func<int, int, int> genericOperation = Add;

        Action<string> action = PrintMessage;
        action("Hello from Action delegate!");

        Predicate<int> predicate = IsEven;
        int testNumber = 4;

        Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

        return;

        Func<string, string, string> stringOperation = Concatenate;

        var x = stringOperation("Hello, ", "World!");
        Console.WriteLine($"Concatenation result: {x}");

        // Multicast delegate: adding more methods to the invocation list
        genericOperation += Subtract;
        genericOperation += Multiply;
        genericOperation += Divide;

        genericOperation -= Subtract; // Removing the Subtract method from the invocation list

        var result = genericOperation(5, 3);
        Console.WriteLine($"Final result: {result}");
    }

    public string Concatenate(string a, string b)
    {
        string result = a + b;
        Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
        return result;
    }

    public int Add(int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        Console.WriteLine($"The product of {a} and {b} is: {a * b}");
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b != 0)
        {
            Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
            return a / b;
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        return 0;
    }
}