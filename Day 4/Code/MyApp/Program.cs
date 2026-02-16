using System;
class Program
{
    static void Main(string[] args)
    {
        int a = 5;

        //Increment value by reference
        increment(ref a);
        Console.WriteLine("Value of a: "+a);
    }
    public static int increment(ref int a)
    {
        a++;
        return a;
    }
}