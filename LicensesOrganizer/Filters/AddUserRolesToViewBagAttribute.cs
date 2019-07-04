using LicensesOrganizer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LicensesOrganizer.Filters
{
    public class AddUserRolesToViewBagAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controller = filterContext.Controller as BaseController;
            if(controller == null)
            {
                return;
            }
            controller.ViewBag.UserRole = controller.AppUser.UserData.RoleName;
        }
    }
}