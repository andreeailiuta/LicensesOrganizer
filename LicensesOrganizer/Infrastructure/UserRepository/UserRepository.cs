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


                        userData.Roles = new List<string>();
                        reader.NextResult();
                        while (reader.Read())
                        {
                            userData.Roles.Add(reader["RoleName"].ToString());
                        }

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
                        reader.Read();

                        var userData = new UserDataObject();
                        userData.CreatedBy = reader["CreatedBy"].ToString();
                        userData.CreationDate = (DateTime)reader["CreationDate"];
                        userData.Email = reader["Email"].ToString();
                        userData.LastModifiedBy = reader["LastModifiedBy"] == DBNull.Value ? null : reader["LastModifiedBy"].ToString();
                        userData.UserID = Convert.ToInt32(reader["UserId"]);
                        userData.UserName = reader["UserName"].ToString();

                        return userData;
                    }
                }
            }
        }
    }
}