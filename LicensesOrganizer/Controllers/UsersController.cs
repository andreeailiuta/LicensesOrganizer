using LicensesOrganizer.DataModels;
using LicensesOrganizer.Infrastructure.UserRepository;
using LicensesOrganizer.Models;
using System.Linq;
using System.Web.Mvc;

namespace LicensesOrganizer.Controllers
{
    public class UsersController : BaseController
    {
        private IUserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {
            var users = _userRepository.GetUsers();

            return View(users.Select(x => new UserGridViewModel()
            {
                CreationDate = x.CreationDate,
                Email = x.Email,               
                RoleName = x.RoleName,
                UserID = x.UserID,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                IsActive = x.IsActive

            }));
        }

        //GET: Create user form
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }


        //POST: Create user fom
        [HttpPost]
        public ActionResult SaveUser(CreateUserViewModel model)
        {
            var userData = new UserDataObject();
           

            userData.UserName = model.UserName;
            userData.Password = model.Password;
            userData.FirstName = model.FirstName;
            userData.LastName = model.LastName;
            userData.RoleID = model.RoleId;
            userData.BirthDate = model.BirthDate;
            userData.Email = model.Email;
            userData.IsActive = model.IsActive;
            userData.CreatedBy = this.AppUser.UserData.UserName;
            userData.RoleID = model.RoleId;

            _userRepository.CreateUser(userData);

            // If we got this far, something failed, redisplay form

            return RedirectToAction("Index");
        }

    }

}