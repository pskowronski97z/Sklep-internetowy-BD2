namespace ShopLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureIdadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PictureId", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PictureId");
        }
    }
}
