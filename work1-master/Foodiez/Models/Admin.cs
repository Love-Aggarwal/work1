using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class Admin
    {
        [Key]
        public int AdminId{get;set;}
        [Required(ErrorMessage = "Please enter your user name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "password")]
        public string Password { get; set; }

        public int MenuId{ get; set; }
        public Menu Menu { get; set; }

    }
}
