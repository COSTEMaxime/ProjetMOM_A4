namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tService",
                c => new
                    {
                        ServiceID = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.tUserGroup",
                c => new
                    {
                        UserGroupID = c.Int(nullable: false, identity: true),
                        UserGroupName = c.String(nullable: false, maxLength: 50, unicode: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.UserGroupID)
                .ForeignKey("dbo.tUser", t => t.User_UserID)
                .Index(t => t.UserGroupName, unique: true)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.tUserGroupService",
                c => new
                    {
                        UserGroupServiceID = c.Int(nullable: false, identity: true),
                        UserGroupID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserGroupServiceID)
                .ForeignKey("dbo.tService", t => t.ServiceID, cascadeDelete: true)
                .ForeignKey("dbo.tUserGroup", t => t.UserGroupID, cascadeDelete: true)
                .Index(t => t.UserGroupID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.tUser",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 150, unicode: false),
                        Token = c.String(),
                        LastConnexion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tUserGroup", "User_UserID", "dbo.tUser");
            DropForeignKey("dbo.tUserGroupService", "UserGroupID", "dbo.tUserGroup");
            DropForeignKey("dbo.tUserGroupService", "ServiceID", "dbo.tService");
            DropIndex("dbo.tUser", new[] { "Login" });
            DropIndex("dbo.tUserGroupService", new[] { "ServiceID" });
            DropIndex("dbo.tUserGroupService", new[] { "UserGroupID" });
            DropIndex("dbo.tUserGroup", new[] { "User_UserID" });
            DropIndex("dbo.tUserGroup", new[] { "UserGroupName" });
            DropTable("dbo.tUser");
            DropTable("dbo.tUserGroupService");
            DropTable("dbo.tUserGroup");
            DropTable("dbo.tService");
        }
    }
}
