//namespace DAL.Migrations
//{
//    using DAL.Entities;
//    using System;
//    using System.Collections.Generic;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Contexts.GlobalGoalContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = true;
//        }

//        protected override void Seed(DAL.Contexts.GlobalGoalContext context)
//        {
//            var LanguageDA = new Language()
//            {
//                Country = "Danmark",
//                ISO = "da",

//            };
//            var LanguageEN = new Language()
//            {
//                Country = "England",
//                ISO = "en",
//            };

//            context.Languages.Add(LanguageDA);
//            context.Languages.Add(LanguageEN);


//            var frontPageTransEN = new TranslationLanguage()
//            {
//                Description = "This is a description",
//                Title = "This is a Title",
//                Language = LanguageEN,
//            };
//            var frontPageTransDK = new TranslationLanguage()
//            {
//                Description = "Dette er en beskrivelse",
//                Title = "Dette er en titel",
//                Language = LanguageDA,
//            };

//            var TranslatedTexts = new Translation()
//            {
//                TranslatedTexts = new List<TranslationLanguage> { frontPageTransDK, frontPageTransEN }
//            };
//            context.Texts.Add(TranslatedTexts);

//            FrontPage fp = new FrontPage()
//            {
//                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
//                Translation = TranslatedTexts,


//            };

//            //Artwork

//            var Artwork = new Artwork()
//            {
//                Translation = TranslatedTexts,
//                ImgUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

//            };

//            //Sculptures

//            var Sculptures = new Sculpture()
//            {
//                Translation = TranslatedTexts,
//                ImgUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

//            };

//            //Landart

//            var Landart = new LandArt()
//            {
//                Translation = TranslatedTexts,
//                ImgUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

//            };

//            //Childrens Texts

//            var ChildrensTexts = new ChildrensText()
//            {
//                Translation = TranslatedTexts,

//            };

//            //Global Goal

//            var GG = new GlobalGoal()
//            {
//                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
//                LandArts = new List<LandArt> { Landart },
//                Artworks = new List<Artwork> { Artwork },
//                Sculptures = new List<Sculpture> { Sculptures },
//                AudioURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
//                Latitude = 12.3045,
//                Longitude = 34.5566,
//                Translation = TranslatedTexts,
//                VideoURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
//                ChildrensTexts = new List<ChildrensText> { ChildrensTexts }

//            };
//            context.Global_Goals.Add(GG);

//            base.Seed(context);
//        }
//    }
//}
