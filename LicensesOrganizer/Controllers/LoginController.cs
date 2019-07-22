using LicensesOrganizer.Infrastructure.UserRepository;
using LicensesOrganizer.Models;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace LicensesOrganizer.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;

        public LoginController()
        {
            _userRepository = new UserRepository();
        }

        // GET: Login
        [HttpGet]
        [AllowAnonymous]
        [OverrideAuthentication]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [OverrideAuthentication]
        public ActionResult Index(LoginModel model)
        {
            var authenticatedUser = _userRepository.VerifyLogin(model.UserName, model.Password);
            if (authenticatedUser == null)
            {
                //return new HttpUnauthorizedResult("Username or password is incorrect");
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View(model);
            }

            // Create the authentication ticket with custom user data.
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    model.UserName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    true,
                    authenticatedUser.UserID.ToString(),
                    FormsAuthentication.FormsCookiePath);
            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);
            // Create the cookie.
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}