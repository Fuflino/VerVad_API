using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            roleManager.Create(new IdentityRole("Admin"));

            var admin1 = new ApplicationUser
            {
                UserName = "VervadAdmin",
                Email = "Admin@VerVad.dk"
            };
            userManager.Create(admin1, "Admin1234!");
            userManager.AddToRole(admin1.Id, "Admin");

            //Language
            var languageDa = new Language()
            {
                Country = "Dansk",
                ISO = "da",
            };
            var languageEn = new Language()
            {
                Country = "Engelsk",
                ISO = "en",
            };
            var languageDe = new Language()
            {
                Country = "Tysk",
                ISO = "de",
            };         

            //Translations
            var transEn = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "1# No Poverty",
                Language = languageEn,
            };
            var transDk = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "1# Afskaf Fattigdom",
                Language = languageDa,
            };
            var transDe = new TranslationLanguage()
            {
                Description = "TYSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "1# Keine Armut",
                Language = languageDe,
            };
            var transEn1 = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "2# Zero Hunger",
                Language = languageEn,
            };
            var transDk1 = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "2# Stop Sult",
                Language = languageDa,
            };
            var transDe1 = new TranslationLanguage()
            {
                Description = "TYSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "2# Kein Hunger",
                Language = languageDe,
            };

            var fpEn = new TranslationLanguage()
            {
                Description = "ENGELSK - forside beskrivelse: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                              "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                              "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                              "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                              " dolor at commodo.",
                Title = "The Global Goals - for sustainable development",
                Language = languageEn
            };
            var fpDa = new TranslationLanguage()
            {
                Description = "DANSK - forside beskrivelse: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                              "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                              "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                              "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                              " dolor at commodo.",
                Title = "FN's Verdensmål - for bæredygtig udvikling",
                Language = languageDa,
            };
            var fpDe = new TranslationLanguage()
            {
                Description = "TYSK - forside beskrivelse: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                              "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                              "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                              "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                              " dolor at commodo.",
                Title = "Die Globalen Ziele - für nachhaltige entwicklung",
                Language = languageDe,
            };

            var translatedTexts = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDk, transEn, transDe }
            };
            var translatedTexts1 = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDk1, transEn1, transDe1 }
            };
            var fpTranslatedTexts = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { fpEn, fpDa, fpDe }
            };

            context.Texts.Add(translatedTexts1);
            context.Texts.Add(translatedTexts);
            context.Texts.Add(fpTranslatedTexts);

            //Frontpage
            var fp = new FrontPage()
            {
                Id = 1,
                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                Translation = fpTranslatedTexts
            };

            //Artwork
            var artwork = new Artwork()
            {
                Id = 1,
                Artist = "Bart 4c",
                Translation = translatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Landart
            var landart = new LandArt()
            {
                Id = 1,
                Translation = translatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Childrens Texts
            var childrensTexts = new ChildrensText()
            {
                Id = 1,
                Author = "Pippi 8c",
                Translation = translatedTexts
            };

            //AudioVideo
            var audioVideo = new AudioVideo()
            {
                Id = 1,
                AudioURL = "https://www.dropbox.com/s/ewkmod3sbhw71ia/listener%20-%20Wooden%20Heart%20-%2001%20You%20have%20never%20lived%20because%20you%20have%20never%20died.mp3?dl=1",
                VideoURL = "https://www.youtube.com/embed/RpqVmvMCmp0",
                SongTitle = "Bum Bum Bla Bla..",
                SongArtist = "Shakira",
                Translation = translatedTexts1
            };

            //Global Goal
            var gg = new GlobalGoal()
            {
                Id = 1,
                Latitude = 55.572044,
                Longitude = 8.309237,
                Translation = translatedTexts,
                ImgURL = "https://placeimg.com/600/400/nature",
                IsPublished = true,

                ChildrensTexts = new List<ChildrensText> { childrensTexts },
                Artworks = new List<Artwork> { artwork },
                LandArts = new List<LandArt> { landart },
                AudioVideo = audioVideo
            };
            var gg2 = new GlobalGoal()
            {
                Id = 2,
                Latitude = 55.572044,
                Longitude = 8.309237,
                Translation = translatedTexts1,
                ImgURL = "https://placeimg.com/600/400/nature",
                IsPublished = false,

                ChildrensTexts = new List<ChildrensText> { },
                Artworks = new List<Artwork> { },
                LandArts = new List<LandArt> { },
                AudioVideo = null
            };

            context.Languages.Add(languageDa);
            context.Languages.Add(languageEn);
            context.Languages.Add(languageDe);
            context.FrontPage.Add(fp);
            context.Global_Goals.Add(gg);
            context.Global_Goals.Add(gg2);

            base.Seed(context);
        }
    }
}
