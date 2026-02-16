
using Utilities;

Student student = new Student("Alice", 20);

Console.WriteLine($"Double The Age: {student.DoubleTheAge()}");

ParametersDemo options = new ParametersDemo();

options.Configure(timeout: 10, verbose: true);

int count = 10;

options.SetCount(out count);

// side effect

Console.WriteLine($"Count: {count}");

// params demo

int total = options.ParamsDemo(1, 2, 3);
Console.WriteLine($"Total: {total}");

total = options.ParamsDemo(1, 2, 3, 4, 5);
Console.WriteLine($"Total: {total}");


// var keyword demo
    public abstract class Animal {}
    public class Dog : Animal {}

    // Animal tex = new Dog();
    // Dog bunny = new Dog();
    // var doggo = new Dog();

    // SOLID
    // D - Dependency Inversion Principle
    // left side -> Generalized
    // right side -> Specialized


// Method Overloading
class Logger
{

    public void Log(string message) { }

    public int Log(int message) { return 0; }

}


class ParametersDemo
{
    public void Configure(int timeout = 30, bool verbose = false)
    {
        Console.WriteLine($"Timeout set to: {timeout} seconds");
        Console.WriteLine($"Verbose mode: {verbose}");

    }

    public void SetCount(out int count)
    {
        // database
        // api
        count = 42;
    }


    public int ParamsDemo(params int[] numbers)
    {
        // syntax sugar
        var sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

}