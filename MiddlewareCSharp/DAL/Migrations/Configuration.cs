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
            UserGroupEntity adminGroup = new UserGroupEntity { ID = 0, UserGroupName = "admin"};
            context.UserGroups.AddOrUpdate(adminGroup);
            context.SaveChanges();

            ServiceEntity serviceDecrypt = new ServiceEntity { ID = 0, ServiceName = "serviceDecrypt"};
            context.Services.AddOrUpdate(serviceDecrypt);
            context.SaveChanges();

            UserGroupServiceEntity adminDecrypt = new UserGroupServiceEntity { ID = 0, ServiceID = serviceDecrypt.ID, UserGroupID = adminGroup.ID };
            context.UserGroupServices.AddOrUpdate(adminDecrypt);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
