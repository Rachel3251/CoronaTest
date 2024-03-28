﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;
//using System.Configuration;
//#pragma warning disable CS0436



namespace DAL
{
    public interface IUserRepository
    {
        public interface IUserRepository
        {
            IEnumerable<User> GetAllUsers();
            User GetUserById(int userId);
            void AddUser(User user);
            void UpdateUser(User user);
            void DeleteUser(int userId);
        }
    }
}