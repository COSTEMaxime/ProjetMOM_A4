namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tUserGroupService", "ServiceID", "dbo.tService");
            DropForeignKey("dbo.tUserGroupService", "UserGroupID", "dbo.tUserGroup");
            DropForeignKey("dbo.tUserGroup", "User_UserID", "dbo.tUser");
            RenameTable(name: "dbo.tService", newName: "Service");
            RenameTable(name: "dbo.tUserGroup", newName: "UserGroup");
            RenameTable(name: "dbo.tUserGroupService", newName: "UserGroupService");
            RenameTable(name: "dbo.tUser", newName: "User");
            RenameColumn(table: "dbo.UserGroup", name: "User_UserID", newName: "User_ID");
            RenameIndex(table: "dbo.UserGroup", name: "IX_User_UserID", newName: "IX_User_ID");
            DropPrimaryKey("dbo.Service");
            DropPrimaryKey("dbo.UserGroup");
            DropPrimaryKey("dbo.UserGroupService");
            DropPrimaryKey("dbo.User");
            DropColumn("dbo.Service", "ServiceID");
            DropColumn("dbo.UserGroup", "UserGroupID");
            DropColumn("dbo.UserGroupService", "UserGroupServiceID");
            DropColumn("dbo.User", "UserID");
            AddColumn("dbo.Service", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserGroup", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserGroupService", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.User", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Service", "ID");
            AddPrimaryKey("dbo.UserGroup", "ID");
            AddPrimaryKey("dbo.UserGroupService", "ID");
            AddPrimaryKey("dbo.User", "ID");
            AddForeignKey("dbo.UserGroupService", "ServiceID", "dbo.Service", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserGroupService", "UserGroupID", "dbo.UserGroup", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserGroup", "User_ID", "dbo.User", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "UserID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserGroupService", "UserGroupServiceID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserGroup", "UserGroupID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Service", "ServiceID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserGroup", "User_ID", "dbo.User");
            DropForeignKey("dbo.UserGroupService", "UserGroupID", "dbo.UserGroup");
            DropForeignKey("dbo.UserGroupService", "ServiceID", "dbo.Service");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.UserGroupService");
            DropPrimaryKey("dbo.UserGroup");
            DropPrimaryKey("dbo.Service");
            DropColumn("dbo.User", "ID");
            DropColumn("dbo.UserGroupService", "ID");
            DropColumn("dbo.UserGroup", "ID");
            DropColumn("dbo.Service", "ID");
            AddPrimaryKey("dbo.User", "UserID");
            AddPrimaryKey("dbo.UserGroupService", "UserGroupServiceID");
            AddPrimaryKey("dbo.UserGroup", "UserGroupID");
            AddPrimaryKey("dbo.Service", "ServiceID");
            RenameIndex(table: "dbo.UserGroup", name: "IX_User_ID", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.UserGroup", name: "User_ID", newName: "User_UserID");
            AddForeignKey("dbo.tUserGroup", "User_UserID", "dbo.tUser", "UserID");
            AddForeignKey("dbo.tUserGroupService", "UserGroupID", "dbo.tUserGroup", "UserGroupID", cascadeDelete: true);
            AddForeignKey("dbo.tUserGroupService", "ServiceID", "dbo.tService", "ServiceID", cascadeDelete: true);
            RenameTable(name: "dbo.User", newName: "tUser");
            RenameTable(name: "dbo.UserGroupService", newName: "tUserGroupService");
            RenameTable(name: "dbo.UserGroup", newName: "tUserGroup");
            RenameTable(name: "dbo.Service", newName: "tService");
        }
    }
}
