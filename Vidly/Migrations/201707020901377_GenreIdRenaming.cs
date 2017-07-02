namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreIdRenaming : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id1" });
            RenameColumn(table: "dbo.Movies", name: "Genre_Id1", newName: "GenreId");
            AlterColumn("dbo.Movies", "GenreId", c => c.Short(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_Id", c => c.Short(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Short());
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id1");
            CreateIndex("dbo.Movies", "Genre_Id1");
            AddForeignKey("dbo.Movies", "Genre_Id1", "dbo.Genres", "Id");
        }
    }
}
