using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAO
    {
        private static DAO instance = null;
        private readonly MiddlewareDbContext dbContext;

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

        public List<GroupEntity> GetGroupsFromListStr(List<string> groups)
        {
            List<GroupEntity> userGroups = new List<GroupEntity>();

            foreach (string groupName_ in groups)
            {
                GroupEntity group = dbContext.Groups.Where(g => g.GroupName == groupName_).FirstOrDefault();

                if (group != null) { userGroups.Add(group); }
            }

            return userGroups;
        }

        public bool AddUserToGroups(UserEntity user, List<GroupEntity> groups)
        {
            bool success = true;
            foreach(GroupEntity group in groups)
            {
                dbContext.UserGroups.AddOrUpdate(new UserGroupEntity() { UserID = user.ID, GroupID = group.ID });
                if (!SaveChanges()) { success = false; }
            }

            return success;
        }

        public bool AddUser(UserEntity newUser)
        {
            dbContext.Users.Add(newUser);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
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

        public ICollection<GroupServiceEntity> GetServicesFromGroup(GroupEntity group)
        {
            return dbContext.UserGroupServices.Where(u => u.GroupID == group.ID).ToList();
        }
    }
}
