using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MiddlewareDbContext : DbContext
    {
        public MiddlewareDbContext() : base("MiddlewareDbContext")
        {
        }

        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserGroupServiceEntity> UserGroupServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserGroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ServiceConfiguration());
            modelBuilder.Configurations.Add(new UserGroupServiceConfiguration());
        }
    }
}
