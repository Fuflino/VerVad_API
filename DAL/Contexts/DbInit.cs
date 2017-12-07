using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class DbInit : CreateDatabaseIfNotExists<GlobalGoalContext>
    {
        protected override void Seed(GlobalGoalContext context)
        {
            //Language
            var LanguageDA = new Language()
            {
                Country = "Dansk",
                ISO = "da",
            };
            var LanguageEN = new Language()
            {
                Country = "Engelsk",
                ISO = "en",
            };

            var LanguageDE = new Language()
            {
                Country = "Tysk",
                ISO = "de",
            };

            context.Languages.Add(LanguageDA);
            context.Languages.Add(LanguageEN);
            context.Languages.Add(LanguageDE);

            //Translations
            var transEN = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "The Global Goals - The Wadden Sea",
                Language = LanguageEN,
            };

            var transDK = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Verdensmål ved Vadehavet",
                Language = LanguageDA,
            };

            var transDE = new TranslationLanguage()
            {
                Description = "TYSK Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Welt Ziele eller noget..",
                Language = LanguageDE,
            };

            var transEN1 = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "The Global Goals - The Wadden Sea",
                Language = LanguageEN,
            };

            var transDK1 = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Verdensmål ved Vadehavet",
                Language = LanguageDA,
            };

            var transDE1 = new TranslationLanguage()
            {
                Description = "TYSK Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Welt Ziele eller noget..",
                Language = LanguageDE,
            };

            var TranslatedTexts = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDK, transEN, transDE }
            };
            var TranslatedTexts1 = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDK1, transEN1, transDE1 }
            };
            context.Texts.Add(TranslatedTexts1);
            context.Texts.Add(TranslatedTexts);

            //Frontpage
            FrontPage fp = new FrontPage()
            {
                Id = 1,
                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                Translation = TranslatedTexts
            };
            context.FrontPage.Add(fp);

            //Artwork
            var Artwork = new Artwork()
            {
                Id = 1,
                Artist = "Bart 4c",
                Translation = TranslatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Landart
            var Landart = new LandArt()
            {
                Id = 1,
                Translation = TranslatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Childrens Texts
            var ChildrensTexts = new ChildrensText()
            {
                Id = 1,
                Author = "Pippi 8c",
                Translation = TranslatedTexts
            };

            //AudioVideo
            var audioVideo = new AudioVideo()
            {
                Id = 1,
                AudioURL = "https://www.dropbox.com/s/ewkmod3sbhw71ia/listener%20-%20Wooden%20Heart%20-%2001%20You%20have%20never%20lived%20because%20you%20have%20never%20died.mp3?dl=1",
                VideoURL = "https://www.youtube.com/embed/RpqVmvMCmp0",
                SongTitle = "Bum Bum Bla Bla..",
                SongArtist = "Shakira",
                Translation = TranslatedTexts1
            };

            //Global Goal
            var GG = new GlobalGoal()
            {
                Id = 1,
                Latitude = 12.3045,
                Longitude = 34.5566,
                Translation = TranslatedTexts,
                ImgURL = "https://placeimg.com/600/400/nature",
                IsPublished = true,

                ChildrensTexts = new List<ChildrensText> { ChildrensTexts },
                Artworks = new List<Artwork> { Artwork },
                LandArts = new List<LandArt> { Landart },
                AudioVideo = null
            };
            var GG2 = new GlobalGoal()
            {
                Id = 2,
                Latitude = 25.2145,
                Longitude = 56.5586,
                Translation = TranslatedTexts1,
                ImgURL = "https://placeimg.com/600/400/nature",
                IsPublished = false,

                ChildrensTexts = new List<ChildrensText> { },
                Artworks = new List<Artwork> { },
                LandArts = new List<LandArt> { },
                AudioVideo = audioVideo
            };

            context.Global_Goals.Add(GG);
            context.Global_Goals.Add(GG2);

            base.Seed(context);
        }
    }
}
