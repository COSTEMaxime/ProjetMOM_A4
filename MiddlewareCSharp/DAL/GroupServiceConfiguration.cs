using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class GroupServiceConfiguration : EntityTypeConfiguration<GroupServiceEntity>
    {
        public GroupServiceConfiguration()
        {
            this.ToTable("GroupService");
            this.HasKey(u => u.ID);
            this.Property(u => u.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(u => u.ServiceID).IsRequired();
            this.Property(u => u.GroupID).IsRequired();
        }
    }
}
