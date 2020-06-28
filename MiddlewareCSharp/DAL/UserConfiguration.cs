using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            this.ToTable("User");
            this.HasKey(u => u.ID);
            this.Property(u => u.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.HasIndex(u => u.Login).IsUnique();
            this.Property(u => u.Login)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);

            this.Property(u => u.Email)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(100);

            this.Property(u => u.Password)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(150);

            this.Property(u => u.LastConnexion).HasColumnType("datetime2");
        }
    }
}
