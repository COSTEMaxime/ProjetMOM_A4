namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserGroupMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGroupService", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.UserGroupService", "UserGroupID", "dbo.UserGroup");
            DropForeignKey("dbo.UserGroup", "User_ID", "dbo.User");
            DropIndex("dbo.UserGroup", new[] { "UserGroupName" });
            DropIndex("dbo.UserGroup", new[] { "User_ID" });
            DropIndex("dbo.UserGroupService", new[] { "UserGroupID" });
            DropIndex("dbo.UserGroupService", new[] { "ServiceID" });
            RenameColumn(table: "dbo.UserGroup", name: "User_ID", newName: "UserID");
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GroupService",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.ServiceID);
            
            AddColumn("dbo.UserGroup", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.UserGroup", "Service_ID", c => c.Int());
            AlterColumn("dbo.UserGroup", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGroup", "UserID");
            CreateIndex("dbo.UserGroup", "Service_ID");
            AddForeignKey("dbo.UserGroup", "Service_ID", "dbo.GroupService", "ID");
            AddForeignKey("dbo.UserGroup", "UserID", "dbo.User", "ID", cascadeDelete: true);
            DropColumn("dbo.UserGroup", "UserGroupName");
            DropTable("dbo.UserGroupService");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserGroupService",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserGroupID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.UserGroup", "UserGroupName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropForeignKey("dbo.UserGroup", "UserID", "dbo.User");
            DropForeignKey("dbo.UserGroup", "Service_ID", "dbo.GroupService");
            DropForeignKey("dbo.GroupService", "ServiceID", "dbo.Service");
            DropForeignKey("dbo.GroupService", "GroupID", "dbo.Group");
            DropIndex("dbo.GroupService", new[] { "ServiceID" });
            DropIndex("dbo.GroupService", new[] { "GroupID" });
            DropIndex("dbo.UserGroup", new[] { "Service_ID" });
            DropIndex("dbo.UserGroup", new[] { "UserID" });
            AlterColumn("dbo.UserGroup", "UserID", c => c.Int());
            DropColumn("dbo.UserGroup", "Service_ID");
            DropColumn("dbo.UserGroup", "GroupID");
            DropTable("dbo.GroupService");
            DropTable("dbo.Group");
            RenameColumn(table: "dbo.UserGroup", name: "UserID", newName: "User_ID");
            CreateIndex("dbo.UserGroupService", "ServiceID");
            CreateIndex("dbo.UserGroupService", "UserGroupID");
            CreateIndex("dbo.UserGroup", "User_ID");
            CreateIndex("dbo.UserGroup", "UserGroupName", unique: true);
            AddForeignKey("dbo.UserGroup", "User_ID", "dbo.User", "ID");
            AddForeignKey("dbo.UserGroupService", "UserGroupID", "dbo.UserGroup", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserGroupService", "ServiceID", "dbo.Service", "ID", cascadeDelete: true);
        }
    }
}
