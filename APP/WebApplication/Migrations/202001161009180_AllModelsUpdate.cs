namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllModelsUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        AmountInBasket = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomerId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        HireDate = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Single(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        Password = c.String(nullable: false, unicode: false),
                        Login = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => new { t.LastName, t.FirstName }, name: "IX_LastFirstName")
                .Index(t => t.AddressId)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Baskets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Baskets", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "Login" });
            DropIndex("dbo.Employees", new[] { "AddressId" });
            DropIndex("dbo.Employees", "IX_LastFirstName");
            DropIndex("dbo.Baskets", new[] { "CustomerId" });
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Baskets");
        }
    }
}
