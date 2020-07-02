using DAL;
using System;

namespace MiddlewareWCF
{
    internal class BLLogout
    {
        internal bool Logout(string login)
        {
            UserEntity user = DAO.GetInstance().GetUserByLogin(login);
            user.Token = "";

           return DAO.GetInstance().SaveChanges();
        }
    }
}