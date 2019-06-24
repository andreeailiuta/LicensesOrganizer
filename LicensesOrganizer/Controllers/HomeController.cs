using LicensesOrganizer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicensesOrganizer.Controllers
{
    public class HomeController : BaseController
    {
        //GET: Home
        [HttpGet]
        [AddUserRolesToViewBag]
        public ActionResult Index()
        {
            ViewBag.LoggedInUserName = AppUser.UserData.UserName;
            return View();
        }
    }
}