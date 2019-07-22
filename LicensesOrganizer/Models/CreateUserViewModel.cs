using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicensesOrganizer.Models
{

    public class CreateUserViewModel
    {
        public int UserID { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Role")]
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Birthdate ")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }
        public bool IsUpdating => UserID != 0;
    }
}