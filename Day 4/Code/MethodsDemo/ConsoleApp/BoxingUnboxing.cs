using System;
using System.Numerics;
namespace ConsoleApp
{
    class BoxingUnboxing
    {
        public void BoxingUnboxingDemo()
        {
            int a = 10;
            BigInteger bigInt = a; // Boxing
            Console.WriteLine("Boxed value: " + bigInt); // Output: Boxed value: 10
            int unboxed = (int)bigInt;
            Console.WriteLine("Unboxed value: " + unboxed); // Output: Unboxed value: 10
        }
    }
}