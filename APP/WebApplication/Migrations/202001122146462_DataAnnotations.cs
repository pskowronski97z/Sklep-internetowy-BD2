namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(maxLength: 60, storeType: "nvarchar"),
                        Street = c.String(maxLength: 60, storeType: "nvarchar"),
                        Building = c.String(maxLength: 10, storeType: "nvarchar"),
                        Apartment = c.String(maxLength: 10, storeType: "nvarchar"),
                        PostCode = c.String(maxLength: 10, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Email = c.String(nullable: false, unicode: false),
                        BirthDate = c.DateTime(nullable: false, precision: 0),
                        PhoneNumber = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        BasketValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddressId = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Login = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
                //.Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
