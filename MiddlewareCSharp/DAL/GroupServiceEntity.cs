using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GroupServiceEntity
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int ServiceID { get; set; }

        public virtual GroupEntity Group { get; set; }
        public virtual ServiceEntity Service { get; set; }
    }
}
