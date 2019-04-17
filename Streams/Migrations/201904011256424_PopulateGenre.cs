namespace Streams.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'History')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Romence')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Sci-fi')");
            
        }
        
        public override void Down()
        {
        }
    }
}
