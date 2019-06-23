using LicensesOrganizer.Infrastructure;
using LicensesOrganizer.Infrastructure.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LicensesOrganizer.AuthenticationFilters
{
    public class BasicAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return; 
            }

            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(cookie.Value);
            var userId = 0;
            if (authTicket == null || authTicket.Expired || !Int32.TryParse(authTicket.UserData, out userId))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var userRepo = new UserRepository();
            var authenticatedUser = userRepo.LoadUserData(userId);

            if(authenticatedUser == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            //Set logged in user in the context to be available later on in the request
            HttpContext.Current.User = new AppPrincipal(authenticatedUser);

        }
        //decizi ce se intampla dupa authentificare.
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if(filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{
                        { "controller", "Login" },
                        { "action", "Index"}
                    });
            }
        }
    }
}