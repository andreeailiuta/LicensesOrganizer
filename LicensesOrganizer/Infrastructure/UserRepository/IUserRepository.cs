using LicensesOrganizer.DataModels;
using LicensesOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensesOrganizer.Infrastructure.UserRepository
{
    public interface IUserRepository
    {
        void CreateUser(string usernNme, string password);
        UserDataObject VerifyLogin(string userName, string password);
        UserDataObject LoadUserData(int userID);

    }
}
