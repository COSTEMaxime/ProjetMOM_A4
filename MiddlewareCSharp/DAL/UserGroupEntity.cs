using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserGroupEntity
    {
        public int UserGroupID { get; set; }
        public string UserGroupName { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<UserGroupServiceEntity> Services { get; set; }
    }
}
