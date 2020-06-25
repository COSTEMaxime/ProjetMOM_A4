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
            this.ToTable("tService");
            this.HasKey(s => s.ServiceID);
            this.Property(s => s.ServiceID)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            this.Property(s => s.ServiceName).IsRequired();
        }
    }
}
