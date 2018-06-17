namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MemershipTypes", newName: "MembershipTypes");
            DropForeignKey("dbo.Customers", "MemershipType_Id", "dbo.MemershipTypes");
            DropIndex("dbo.Customers", new[] { "MemershipType_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MemershipType_Id", newName: "MembershipTypeId");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MemershipType_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MemershipType_Id");
            AddForeignKey("dbo.Customers", "MemershipType_Id", "dbo.MemershipTypes", "Id");
            RenameTable(name: "dbo.MembershipTypes", newName: "MemershipTypes");
        }
    }
}
