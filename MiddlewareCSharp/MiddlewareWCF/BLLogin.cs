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
        internal string Token { get; private set; }

        internal bool Login(string login, string password)
        {
            UserEntity user = DAO.GetInstance().GetUserByLogin(login);

            if (user == null)
            {
                return false;
            }

            BLPassword blPassword = new BLPassword();
            if (blPassword.VerifyPassword(password, user.Password))
            {
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                Token = Convert.ToBase64String(time.Concat(key).ToArray());

                user.Token = Token;
                return DAO.GetInstance().SaveChanges();
            }
            else
            {
                return false;
            }
        }
    }
}
