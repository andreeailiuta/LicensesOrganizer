using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LicensesOrganizer.DataModels;
using LicensesOrganizer.Models;

namespace LicensesOrganizer.Infrastructure.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public void CreateUser(string usernNme, string password)
        {
            throw new NotImplementedException();
        }

        public UserDataObject LoadUserData(int userId)
        {
            // return new UserDataObject() { Email = "andreea@xxx.com", UserID = 1, UserName = "Andreea" };
            using (SqlConnection connection = DBConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.LoadUSerData";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();

                        var userData = new UserDataObject();
                        userData.CreatedBy = reader["CreatedBy"].ToString();
                        userData.CreationDate = (DateTime)reader["CreationDate"];
                        userData.Email = reader["Email"].ToString();
                        userData.LastModifiedBy = reader["LastModifiedBy"] == DBNull.Value ? null : reader["LastModifiedBy"].ToString();
                        userData.UserID = Convert.ToInt32(reader["UserId"]);
                        userData.UserName = reader["UserName"].ToString();
                        userData.RoleID = Convert.ToInt32(reader["RoleID"]);
                        userData.RoleName = reader["RoleName"].ToString();
                        userData.FirstName = reader["FirstName"].ToString();
                        userData.LastName = reader["LastName"].ToString();
                        userData.BirthDate = (DateTime)reader["BirthDate"];
                        userData.IsActive = Convert.ToBoolean(reader["IsActive"]);

                        return userData;
                    }
                }
            }
        }

        public UserDataObject VerifyLogin(string userName, string password)
        {
            //return new UserDataObject();
            using (SqlConnection connection = DBConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.VerifyLogin";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                       if( reader.Read())
                        {
                            var userData = new UserDataObject();
                            userData.CreatedBy = reader["CreatedBy"].ToString();
                            userData.CreationDate = (DateTime)reader["CreationDate"];
                            userData.Email = reader["Email"].ToString();
                            userData.LastModifiedBy = reader["LastModifiedBy"] == DBNull.Value ? null : reader["LastModifiedBy"].ToString();
                            userData.UserID = Convert.ToInt32(reader["UserId"]);
                            userData.UserName = reader["UserName"].ToString();
                            userData.FirstName = reader["FirstName"].ToString();
                            userData.LastName = reader["LastName"].ToString();
                            userData.BirthDate = (DateTime)reader["BirthDate"];
                            userData.IsActive = Convert.ToBoolean(reader["IsActive"]);
                            return userData;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<UserDataObject> GetUsers()
        {
            var userList = new List<UserDataObject>();
            using (SqlConnection connection = DBConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.GetUsers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var userViewModel = new UserDataObject();
                            userViewModel.CreationDate = (DateTime)reader["CreationDate"];
                            userViewModel.Email = reader["Email"].ToString();
                            userViewModel.UserID = Convert.ToInt32(reader["UserId"]);
                            userViewModel.UserName = reader["UserName"].ToString();
                            userViewModel.RoleID = Convert.ToInt32(reader["RoleID"]);
                            userViewModel.RoleName = reader["RoleName"].ToString();
                            userViewModel.FirstName = reader["FirstName"].ToString();
                            userViewModel.LastName = reader["LastName"].ToString();
                            userViewModel.BirthDate = (DateTime)reader["BirthDate"];
                            userViewModel.IsActive = Convert.ToBoolean(reader["IsActive"]);

                            userList.Add(userViewModel);
                        }                        
                    }
                }
            }
            return userList;
        }

        public void CreateUser(UserDataObject userData)
        {
            
            //return new UserDataObject();
            using (SqlConnection connection = DBConnectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.CreateUser";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", userData.UserName);
                    command.Parameters.AddWithValue("@Password", userData.Password);
                    command.Parameters.AddWithValue("@FirstName", userData.FirstName);
                    command.Parameters.AddWithValue("@LastName", userData.LastName);
                    command.Parameters.AddWithValue("@BirthDate", userData.BirthDate);
                    command.Parameters.AddWithValue("@Email", userData.Email);
                    command.Parameters.AddWithValue("@CreatedBy", userData.CreatedBy);
                    command.Parameters.AddWithValue("@IsActive", userData.IsActive);
                    command.Parameters.AddWithValue("@RoleId", userData.RoleID);
                    command.ExecuteNonQuery();
                }
               
            }
        }
    }
}