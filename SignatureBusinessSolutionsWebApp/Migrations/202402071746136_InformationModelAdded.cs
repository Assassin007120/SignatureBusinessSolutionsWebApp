namespace SignatureBusinessSolutionsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InformationModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        TelNo = c.String(),
                        CellNo = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        AddressLine3 = c.String(),
                        AddressCode = c.String(),
                        PostalAddress1 = c.String(),
                        PostalAddress2 = c.String(),
                        PostalCode = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InformationModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.InformationModels", new[] { "ApplicationUser_Id" });
            DropTable("dbo.InformationModels");
        }
    }
}
