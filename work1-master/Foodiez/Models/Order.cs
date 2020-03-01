using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class Order
    {
        //internal int UnitPrice;
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }


        public int Quantity { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
  
    }
}
