namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false),
                        FieldName1 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName2 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName3 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName4 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName5 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName6 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName7 = c.String(maxLength: 50, storeType: "nvarchar"),
                        FieldName8 = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        Name = c.String(nullable: false, unicode: false),
                        Description = c.String(unicode: false),
                        CategoryId = c.Int(nullable: false),
                        FieldValue1 = c.Single(),
                        FieldValue2 = c.Single(),
                        FieldValue3 = c.Single(),
                        FieldValue4 = c.Single(),
                        FieldValue5 = c.String(unicode: false),
                        FieldValue6 = c.String(unicode: false),
                        FieldValue7 = c.String(unicode: false),
                        FieldValue8 = c.String(unicode: false),
                        AmountInStore = c.Int(nullable: false),
                        ProducerName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.Price)
                .Index(t => t.Name)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "Price" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
