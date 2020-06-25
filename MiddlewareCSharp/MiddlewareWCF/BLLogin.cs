using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareWCF
{
    class BLLogin
    {
        internal bool Login(string login, string password)
        {
            UserEntity user = DAO.GetInstance().GetUserByLogin(login);

            if (user == null)
            {
                return false;
            }

            BLPassword blPassword = new BLPassword();
            return blPassword.VerifyPassword(password, user.Password);
        }
    }
}
