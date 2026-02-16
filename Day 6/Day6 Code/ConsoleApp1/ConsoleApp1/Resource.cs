using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Resource
    {
        public string Name { get; set; }
        public Resource(string name)
        {
            Name = name;
            Console.WriteLine($"{Name} Created");
        }
        ~Resource() 
        {
            Console.WriteLine($"{Name} destroyed by GC");
        }
    }
}
