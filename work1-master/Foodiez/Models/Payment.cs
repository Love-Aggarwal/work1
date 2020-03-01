using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class Payment
    {[Key]
        public int PaymentId { get; private set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }
        public string PaymentType { get; set; }
    }
}
