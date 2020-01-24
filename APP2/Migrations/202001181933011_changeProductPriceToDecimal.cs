namespace ShopLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeProductPriceToDecimal : DbMigration
    {
        public override void Up()
        {
        //    DropIndex("dbo.Products", new[] { "Price" });
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        //    CreateIndex("dbo.Products", "Price");
        }
        
        public override void Down()
        {
         //   DropIndex("dbo.Products", new[] { "Price" });
            AlterColumn("dbo.Products", "Price", c => c.Single(nullable: false));
        //    CreateIndex("dbo.Products", "Price");
        }
    }
}
