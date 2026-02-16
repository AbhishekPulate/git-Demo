using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo1
{ 
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public decimal OrderAmount { get; set; }
    }

}
