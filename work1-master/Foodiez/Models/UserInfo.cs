﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiez.Models
{
    public class UserInfo
    {
        [Key]

        public int UserId { get; internal set; }
        //[Required(ErrorMessage = "Please enter your first name")]
        //[StringLength(100)]
        //[Display(Name = "first name")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Please enter your last name")]
        //[StringLength(100)]
        //[Display(Name = "last name")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = "Please enter your username")]
        //[StringLength(100)]
        //[Display(Name = "username")]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(100)]
        [Display(Name = "pasword")]
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
   


    }
}
