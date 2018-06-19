namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (N'The Matrix', 1, N'1999-03-31 00:00:00', N'2018-06-18 00:00:00', 8)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (N'Aliens', 1, N'1986-07-18 00:00:00', N'2018-06-16 00:00:00', 11)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (N'Snatch', 2, N'2001-01-19 00:00:00', N'2018-06-02 00:00:00', 4)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (N'Spirited Away', 3, N'2003-03-28 00:00:00', N'2018-06-07 00:00:00', 10)");
            Sql("INSERT INTO [dbo].[Movies] ([Name], [GenreId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (N'Amélie', 4, N'2002-02-08 00:00:00', N'2018-06-22 00:00:00', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
