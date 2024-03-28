using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class UserBll
    {
        private UserDAL userDal;

        public UserBll(UserDAL userDal)
        {
            this.userDal = userDal;
        }

       

        public bool DeleteUser(int userID)
        {
            return userDal.DeleteUser(userID);
        }

        public List<User> GetAllUsers()
        {
            return userDal.GetAllUsers();
        }
        public User getUserByID(int ID)
        {
            return userDal.getUserByID(ID);
        }

        public bool Update(User user)
        {
            return userDal.Update(user);
        }

        public bool AddUser(User user)
        {
            return userDal.AddUser(user);
        }
    }

}

