using LicensesOrganizer.Common;
using LicensesOrganizer.DataModels;
using LicensesOrganizer.Infrastructure.UserRepository;
using LicensesOrganizer.Models;
using System.Linq;
using System.Web.Mvc;

namespace LicensesOrganizer.Controllers
{
    [Route("/users")]
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

            return View(users.Select(x => x.ToGridViewModel()));
        }

        //GET: Create user form
        [HttpGet]
        [Route("{id}")]
        public ActionResult CreateUser(int? id)
        {
            //If no id is passed then we just return the view, meaning it's the create new user form. 
            if(id == null)
            {
                return View();
            }
            //otherwise, load up the user and pass it to the view so it can fill the edit form. 
            else
            {
                var user = _userRepository.LoadUserData(id.Value);
                if(user == null)
                {
                    ModelState.AddModelError("Edit User", $"No user found with id {id.Value}");
                    return View();
                }

                return View(user.ToCreateUserViewModel());
            }

        }


        //POST: Create user form
        [HttpPost]
        public ActionResult SaveUser(CreateUserViewModel model)
        {
            var userData = model.ToUserDataObject();
           
            if (model.IsUpdating)
            {
                userData.LastModifiedBy = this.AppUser.UserData.UserName;
                _userRepository.UpdateUser(userData);
            }
            else
            {
                userData.CreatedBy = this.AppUser.UserData.UserName;
                _userRepository.CreateUser(userData);
            }
           
            

            // If we got this far, something failed, redisplay form

            return RedirectToAction("Index");
        }

        //POST: Delete user
        [HttpGet]
        [Route("{id}")]
        public ActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);


            // If we got this far, something failed, redisplay form

            return RedirectToAction("Index");
        }
    }
}