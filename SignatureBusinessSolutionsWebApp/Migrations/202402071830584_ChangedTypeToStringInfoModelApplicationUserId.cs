namespace SignatureBusinessSolutionsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypeToStringInfoModelApplicationUserId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.InformationModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.InformationModels", "ApplicationUserId");
            RenameColumn(table: "dbo.InformationModels", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.InformationModels", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.InformationModels", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InformationModels", new[] { "ApplicationUserId" });
            AlterColumn("dbo.InformationModels", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.InformationModels", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.InformationModels", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.InformationModels", "ApplicationUser_Id");
        }
    }
}
