using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserGroupServiceEntity
    {
        public int UserGroupServiceID { get; set; }
        public int UserGroupID { get; set; }
        public int ServiceID { get; set; }

        public virtual UserGroupEntity UserGroup { get; set; }
        public virtual ServiceEntity Service { get; set; }
    }
}
