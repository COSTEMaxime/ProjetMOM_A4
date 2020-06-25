using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test database connexion
            MiddlewareDbContext db = new MiddlewareDbContext();
            Console.WriteLine(db.UserGroups.FirstOrDefault().UserGroupName);
        }
    }
}
