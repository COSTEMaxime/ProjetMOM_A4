using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserGroupServiceConfiguration : EntityTypeConfiguration<UserGroupServiceEntity>
    {
        public UserGroupServiceConfiguration()
        {
            this.ToTable("tUserGroupService");
            this.HasKey(u => u.UserGroupServiceID);
            this.Property(u => u.UserGroupServiceID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(u => u.ServiceID).IsRequired();
            this.Property(u => u.UserGroupID).IsRequired();
        }
    }
}
