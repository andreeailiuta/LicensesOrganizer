using LicensesOrganizer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace LicensesOrganizer.Infrastructure
{
    public class AppPrincipal : IPrincipal
    {
        public AppPrincipal(UserDataObject userData)
        {
            UserData = userData;
        }

        public IIdentity Identity => new GenericIdentity(UserData.Email);

        public UserDataObject UserData { get; }

        public bool IsInRole(string role)
        {
            return UserData.RoleName.CompareTo(role) == 0;
        }

    }
}