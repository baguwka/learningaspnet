namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movienowhavegenreid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AddColumn("dbo.Movies", "Genre_Id1", c => c.Short());
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Short(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id1");
            AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            AlterColumn("dbo.Movies", "Genre_Id", c => c.Short());
            DropColumn("dbo.Movies", "Genre_Id1");
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
