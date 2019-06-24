using LicensesOrganizer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicensesOrganizer.Controllers
{
    public abstract class BaseController : Controller
    {
        public AppPrincipal AppUser => this.User as AppPrincipal;

        public BaseController()
        {
            //ViewBag.UserRoles = AppUser.UserData.Roles;
        }
    }
}