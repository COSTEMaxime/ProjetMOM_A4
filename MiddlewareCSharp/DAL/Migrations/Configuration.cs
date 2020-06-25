namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MiddlewareDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DAL.MiddlewareDbContext";
        }

        protected override void Seed(DAL.MiddlewareDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            UserGroupEntity adminGroup = new UserGroupEntity { UserGroupName = "admin" };
            context.UserGroups.Add(adminGroup);
            context.SaveChanges();

            ServiceEntity serviceDecrypt = new ServiceEntity { ServiceName = "ServiceDecrypt" };
            context.Services.Add(serviceDecrypt);
            context.SaveChanges();

            UserGroupServiceEntity adminDecrypt = new UserGroupServiceEntity { ServiceID = serviceDecrypt.ServiceID, UserGroupID = adminGroup.UserGroupID };
            context.UserGroupServices.Add(adminDecrypt);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
