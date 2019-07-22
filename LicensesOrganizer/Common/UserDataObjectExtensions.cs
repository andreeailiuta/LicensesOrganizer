using LicensesOrganizer.DataModels;
using LicensesOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicensesOrganizer.Common
{
    public static class UserDataObjectExtensions
    {
        public static UserGridViewModel ToGridViewModel(this UserDataObject dataObject)
        {
            var userDataGridView = new UserGridViewModel();
            userDataGridView.UserName = dataObject.UserName;
            userDataGridView.FirstName = dataObject.FirstName;
            userDataGridView.LastName = dataObject.LastName;
            userDataGridView.BirthDate = dataObject.BirthDate;
            userDataGridView.Email = dataObject.Email;
            userDataGridView.IsActive = dataObject.IsActive;
            userDataGridView.CreationDate = dataObject.CreationDate;
            userDataGridView.RoleName = dataObject.RoleName;
            userDataGridView.UserID = dataObject.UserID;

            return userDataGridView;
        }

        public static CreateUserViewModel ToCreateUserViewModel(this UserDataObject dataObject)
        {
            var userDataView = new CreateUserViewModel();

            userDataView.UserName = dataObject.UserName;
            userDataView.Password = dataObject.Password;
            userDataView.FirstName = dataObject.FirstName;
            userDataView.LastName = dataObject.LastName;
            userDataView.RoleId = dataObject.RoleID;
            userDataView.BirthDate = dataObject.BirthDate;
            userDataView.Email = dataObject.Email;
            userDataView.IsActive = dataObject.IsActive;
            userDataView.UserID = dataObject.UserID;

            return userDataView;
    
        }

        public static UserDataObject ToUserDataObject(this CreateUserViewModel dataView)
        {
            var userData = new UserDataObject();
            userData.UserID = dataView.UserID;
            userData.UserName = dataView.UserName;
            userData.Password = dataView.Password;
            userData.Email = dataView.Email;
            userData.RoleID = dataView.RoleId;
            userData.FirstName = dataView.FirstName;
            userData.LastName = dataView.LastName;
            userData.IsActive = dataView.IsActive;
            userData.BirthDate = dataView.BirthDate;

            return userData;

        }
    }
}