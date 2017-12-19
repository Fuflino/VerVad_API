namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgUrl = c.String(nullable: false),
                        Artist = c.String(),
                        TranslationId = c.Int(nullable: false),
                        GlobalGoalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GlobalGoals", t => t.GlobalGoalId)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .Index(t => t.TranslationId)
                .Index(t => t.GlobalGoalId);
            
            CreateTable(
                "dbo.GlobalGoals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        ImgURL = c.String(nullable: false),
                        TranslationId = c.Int(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .Index(t => t.TranslationId);
            
            CreateTable(
                "dbo.AudioVideos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TranslationId = c.Int(nullable: false),
                        AudioURL = c.String(),
                        VideoURL = c.String(),
                        SongArtist = c.String(),
                        SongTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .ForeignKey("dbo.GlobalGoals", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.TranslationId);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TranslationLanguages",
                c => new
                    {
                        LanguageISO = c.String(nullable: false, maxLength: 128),
                        TranslationId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.LanguageISO, t.TranslationId })
                .ForeignKey("dbo.Languages", t => t.LanguageISO)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .Index(t => t.LanguageISO)
                .Index(t => t.TranslationId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ISO = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ISO);
            
            CreateTable(
                "dbo.ChildrensTexts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TranslationId = c.Int(nullable: false),
                        Author = c.String(),
                        GlobalGoalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .ForeignKey("dbo.GlobalGoals", t => t.GlobalGoalId)
                .Index(t => t.TranslationId)
                .Index(t => t.GlobalGoalId);
            
            CreateTable(
                "dbo.LandArts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgUrl = c.String(nullable: false),
                        TranslationId = c.Int(nullable: false),
                        GlobalGoalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .ForeignKey("dbo.GlobalGoals", t => t.GlobalGoalId)
                .Index(t => t.TranslationId)
                .Index(t => t.GlobalGoalId);
            
            CreateTable(
                "dbo.FrontPage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgURL = c.String(nullable: false),
                        TranslationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Translations", t => t.TranslationId)
                .Index(t => t.TranslationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FrontPage", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.Artworks", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.GlobalGoals", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.LandArts", "GlobalGoalId", "dbo.GlobalGoals");
            DropForeignKey("dbo.LandArts", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.ChildrensTexts", "GlobalGoalId", "dbo.GlobalGoals");
            DropForeignKey("dbo.ChildrensTexts", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.AudioVideos", "Id", "dbo.GlobalGoals");
            DropForeignKey("dbo.AudioVideos", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.TranslationLanguages", "TranslationId", "dbo.Translations");
            DropForeignKey("dbo.TranslationLanguages", "LanguageISO", "dbo.Languages");
            DropForeignKey("dbo.Artworks", "GlobalGoalId", "dbo.GlobalGoals");
            DropIndex("dbo.FrontPage", new[] { "TranslationId" });
            DropIndex("dbo.LandArts", new[] { "GlobalGoalId" });
            DropIndex("dbo.LandArts", new[] { "TranslationId" });
            DropIndex("dbo.ChildrensTexts", new[] { "GlobalGoalId" });
            DropIndex("dbo.ChildrensTexts", new[] { "TranslationId" });
            DropIndex("dbo.TranslationLanguages", new[] { "TranslationId" });
            DropIndex("dbo.TranslationLanguages", new[] { "LanguageISO" });
            DropIndex("dbo.AudioVideos", new[] { "TranslationId" });
            DropIndex("dbo.AudioVideos", new[] { "Id" });
            DropIndex("dbo.GlobalGoals", new[] { "TranslationId" });
            DropIndex("dbo.Artworks", new[] { "GlobalGoalId" });
            DropIndex("dbo.Artworks", new[] { "TranslationId" });
            DropTable("dbo.FrontPage");
            DropTable("dbo.LandArts");
            DropTable("dbo.ChildrensTexts");
            DropTable("dbo.Languages");
            DropTable("dbo.TranslationLanguages");
            DropTable("dbo.Translations");
            DropTable("dbo.AudioVideos");
            DropTable("dbo.GlobalGoals");
            DropTable("dbo.Artworks");
        }
    }
}
