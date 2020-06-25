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
            this.ToTable("tUserGroup");

            this.HasKey(u => u.UserGroupID);
            this.Property(u => u.UserGroupID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.HasIndex(u => u.UserGroupName).IsUnique();
            this.Property(u => u.UserGroupName)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
