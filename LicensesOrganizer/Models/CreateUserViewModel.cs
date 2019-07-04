using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicensesOrganizer.Models
{
    [Bind(Exclude = "UserID")]
    public class CreateUserViewModel
    {
       
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}