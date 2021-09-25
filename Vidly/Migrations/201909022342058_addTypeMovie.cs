namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTypeMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeMovies",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "TypeMovieId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "TypeMovieId");
            AddForeignKey("dbo.Movies", "TypeMovieId", "dbo.TypeMovies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "TypeMovieId", "dbo.TypeMovies");
            DropIndex("dbo.Movies", new[] { "TypeMovieId" });
            DropColumn("dbo.Movies", "TypeMovieId");
            DropTable("dbo.TypeMovies");
        }
    }
}
