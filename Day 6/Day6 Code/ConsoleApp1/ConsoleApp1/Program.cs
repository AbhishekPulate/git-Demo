using ConsoleApp1;
using GarbageCollectionDemo;
using System.Collections;

namespace Day5
{
    class Program
    {
        public static void Main()
        {
            //ResourceDemo();
            //RecordDemo();
            //SwapDemo();
            //ArrayListDemo();
            CollectionClassesDemo();
        }
        public static void CollectionClassesDemo()
        {
            List<int> marks = new List<int>(10);
            marks.Add(1);
            marks.Add(2);
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");


            marks.AddRange(new int[] { 1, 2, 3 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new int[] { 4, 5, 6 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

            marks.AddRange(new int[] { 7, 8, 9 });
            Console.WriteLine($"Count: {marks.Count}, Capacity: {marks.Capacity}");

           
        }
        private static void ArrayListDemo()
        {
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add(2);
            al.Add(3.4);
            al.Add("Hello");
            al.Add(4);

            int sum = 0;
            foreach (var i in al)
            {
                Console.WriteLine($"item {i}, type: {i.GetType()}");
                sum += (int)i;
                Console.WriteLine($"Sum: {sum}");
            }

        }
        public static void swap<T> ( ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        static void SwapDemo()
        {
            int x = 3, y = 4;
            swap(ref x, ref y);
            Console.WriteLine($"x: {x}, y: {y}");

            String a = "Hello", b = "World";
            swap(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");

            //CTE - Unable to infer type from statement
            // Swap(ref a, ref y);
            //Console.WriteLine($"a: {a}, y: {y}");

        }
        private static void ResourceDemo()
        {
            var res1 = new Resource("Res1");
            var res2 = new Resource("Res2");
            res1 = null;
            res2 = res2;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("GC completed");
        }
        private static void DisposableDemo()
        {
            using(var manager = new FileManager())
            {
                manager.OpenFile("path/to/file.txt");
            }
            using var manager2 = new FileManager();
        }
        private static void RecordDemo()
        {
            var temp1 = new Temp { Id = 1, Name = "Temp1" };
            var temp2 = new Temp { Id = 1, Name = "Temp1" };

            Console.WriteLine(temp1);
            Console.WriteLine(temp2);
            Console.WriteLine(temp1 == temp2);

            var temp3 = temp1 with { Id = 2 };
            Console.WriteLine(temp3);
        }
    }
}