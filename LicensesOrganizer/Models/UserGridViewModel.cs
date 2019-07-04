using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensesOrganizer.Models
{
    public class UserGridViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }       
        public string RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}