using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }

        public int CategoryId { get; set; }
        //public int GetFoodById {get;set;}
        public Category Category { get; set; }

    }
}
