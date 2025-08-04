namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingLists", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingLists", "Category");
        }
    }
}
