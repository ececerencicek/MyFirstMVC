namespace MyFirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DuzeltmeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category_Id" });
            DropColumn("dbo.Categories", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Category_Id", c => c.Int());
            CreateIndex("dbo.Categories", "Category_Id");
            AddForeignKey("dbo.Categories", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
