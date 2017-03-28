namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenresAfterRebase : DbMigration
    {
        public override void Up()
        {
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Jazz')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Rock')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Blues')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Classic')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Pop')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(6, 'Eletronic Music')");
            this.Sql("INSERT INTO Genres(Id, Name) VALUES(7, 'Gospel')");
        }
        
        public override void Down()
        {
            this.Sql("DELETE FROM Genres WHERE Id = 1");
            this.Sql("DELETE FROM Genres WHERE Id = 2");
            this.Sql("DELETE FROM Genres WHERE Id = 3");
            this.Sql("DELETE FROM Genres WHERE Id = 4");
            this.Sql("DELETE FROM Genres WHERE Id = 5");
            this.Sql("DELETE FROM Genres WHERE Id = 6");
            this.Sql("DELETE FROM Genres WHERE Id = 7");
        }
    }
}
