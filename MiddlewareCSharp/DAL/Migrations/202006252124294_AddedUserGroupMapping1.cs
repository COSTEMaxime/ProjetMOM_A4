namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserGroupMapping1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGroup", "Service_ID", "dbo.GroupService");
            DropIndex("dbo.UserGroup", new[] { "Service_ID" });
            DropColumn("dbo.UserGroup", "Service_ID");
            CreateIndex("dbo.UserGroup", "GroupID");
            AddForeignKey("dbo.UserGroup", "GroupID", "dbo.Group", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGroup", "Service_ID", c => c.Int());
            DropForeignKey("dbo.UserGroup", "GroupID", "dbo.Group");
            DropIndex("dbo.UserGroup", new[] { "GroupID" });
            CreateIndex("dbo.UserGroup", "Service_ID");
            AddForeignKey("dbo.UserGroup", "Service_ID", "dbo.GroupService", "ID");
        }
    }
}
