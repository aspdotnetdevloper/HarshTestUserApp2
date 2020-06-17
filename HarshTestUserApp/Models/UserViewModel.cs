using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HarshTestUserApp.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "First Name"), Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Incorrect email format.")]
        public string Email { get; set; }
    }
}