using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class GroupConfiguration : EntityTypeConfiguration<GroupEntity>
    {
        public GroupConfiguration()
        {
            this.ToTable("Group");
            this.HasKey(g => g.ID);
            this.Property(g => g.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(g => g.GroupName)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
