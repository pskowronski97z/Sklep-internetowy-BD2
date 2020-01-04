namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressesAndClients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(unicode: false),
                        Street = c.String(unicode: false),
                        Building = c.String(unicode: false),
                        Apartment = c.String(unicode: false),
                        PostCode = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(unicode: false),
                    LastName = c.String(unicode: false),
                    Email = c.String(unicode: false),
                    BirthDate = c.DateTime(nullable: false, precision: 0),
                    PhoneNumber = c.String(unicode: false),
                    BasketValue = c.Single(nullable: false),
                    AddressId = c.Int(nullable: false),
                    Password = c.String(unicode: false),
                    Login = c.String(unicode: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                ;

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
       
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
