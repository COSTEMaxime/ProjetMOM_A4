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
            context.UserGroups.Add(new UserGroupEntity { UserGroupName = "admin" });
            context.SaveChanges();

            context.Services.Add(new ServiceEntity { ServiceName = "ServiceDecrypt" });
            context.SaveChanges();

            context.UserGroupServices.Add(new UserGroupServiceEntity
            {
                ServiceID = context.Services.First().ServiceID,
                UserGroupID = context.UserGroups.First().UserGroupID
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
