using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensesOrganizer.DataModels
{
    public class UserDataObject
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public List<string> Roles { get; set; } 
    }
}