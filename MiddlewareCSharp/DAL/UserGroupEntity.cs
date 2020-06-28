using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserGroupEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual GroupEntity Group { get; set; }
    }
}
