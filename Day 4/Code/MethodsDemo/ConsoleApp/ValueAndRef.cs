using System;
class ValueAndRef
{
    public void valueAndRef()
    {
        int a = 10;
        int b = a;
        Console.WriteLine("a: " + a); // Output: a: 10
        Console.WriteLine("b: " + b); // Output: b: 10
        ValueAndRef vf = new ValueAndRef();
        Console.WriteLine("vf: " + vf); 
    }
}