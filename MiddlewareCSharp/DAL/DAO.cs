using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAO
    {
        private static DAO instance = null;
        private MiddlewareDbContext dbContext;

        private DAO()
        {
            dbContext = new MiddlewareDbContext();
        }

        public static DAO GetInstance()
        {
            if (instance == null)
            {
                instance = new DAO();
            }

            return instance;
        }

        public UserEntity GetUserByLogin(string login)
        {
            return dbContext.Users.Where(u => u.Login == login).FirstOrDefault();
        }

        public List<UserGroupEntity> GetGroupsFromListStr(List<string> groups)
        {
            List<UserGroupEntity> userGroups = new List<UserGroupEntity>();

            foreach (string group in groups)
            {
                UserGroupEntity userGroup = dbContext.UserGroups.Where(g => g.UserGroupName == group).FirstOrDefault();

                if (userGroup != null) { userGroups.Add(userGroup); }
            }

            return userGroups;
        }

        public bool AddUser(UserEntity newUser)
        {
            dbContext.Users.Add(newUser);
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                // log error
                return false;
            }

            return true;
        }
    }
}
