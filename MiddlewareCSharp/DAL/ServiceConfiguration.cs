using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ServiceConfiguration : EntityTypeConfiguration<ServiceEntity>
    {
        public ServiceConfiguration()
        {
            this.ToTable("Service");
            this.HasKey(s => s.ID);
            this.Property(s => s.ID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(s => s.ServiceName).IsRequired();
        }
    }
}
