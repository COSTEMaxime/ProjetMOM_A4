using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    internal class BLRegister
    {
        internal bool IsLoginUsed(string login)
        {
            return (DAO.GetInstance().GetUserByLogin(login) != null);
        }

        internal bool Register(string login, string password, string email, List<string> groups)
        {
            BLPassword blPassword = new BLPassword();
            string passwordHash = blPassword.Hash(password);
            List<UserGroupEntity> userGroups = DAO.GetInstance().GetGroupsFromListStr(groups);

            UserEntity newUser = new UserEntity
            {
                Login = login,
                Email = email,
                Password = passwordHash,
                Groups = userGroups
            };

            return DAO.GetInstance().AddUser(newUser);
        }
    }
}
