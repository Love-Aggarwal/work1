using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class Menu
    {[Key]
        public int MenuId { get; private  set; }
        [Required(ErrorMessage = "Please enter your price")]
        [Display(Name = "price")]
        [StringLength(50)]
        public int Price { get; set; }
        [Required(ErrorMessage = "Please enter your foodname")]
        [Display(Name = "foodname")]
        [StringLength(50)]
        public string FoodName { get; set; }
        public int FoodId { get; set; }
    }
}
