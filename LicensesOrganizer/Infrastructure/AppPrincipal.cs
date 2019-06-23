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
        private UserDataObject _userData;

        public AppPrincipal(UserDataObject userData)
        {
            _userData = userData;
        }

        public IIdentity Identity => new GenericIdentity(_userData.Email);

        public UserDataObject UserData => _userData;

        public bool IsInRole(string role)
        {
            return _userData.Roles.IndexOf(role) >= 0;
        }

    }
}