using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserGroupConfiguration : EntityTypeConfiguration<UserGroupEntity>
    {
        public UserGroupConfiguration()
        {
            this.ToTable("UserGroup");

            this.HasKey(u => u.ID);
            this.Property(u => u.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.HasIndex(u => u.UserGroupName).IsUnique();
            this.Property(u => u.UserGroupName)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
