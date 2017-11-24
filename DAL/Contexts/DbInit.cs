﻿using DAL.Entities;
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
            //Frontpage
            var LanguageDA = new Language()
            {
                Country = "Danmark",
                ISO = "da",

            };
            var LanguageEN = new Language()
            {
                Country = "England",
                ISO = "en",
            };

            context.Languages.Add(LanguageDA);
            context.Languages.Add(LanguageEN);


            var transEN = new TranslationLanguage()
            {
                Description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "The Global Goals - Wadden Sea",
                Language = LanguageEN,
            };
            var transDK = new TranslationLanguage()
            {

                Description = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Verdensmål ved Vadehavet",
                Language = LanguageDA,
            };

            var TranslatedTexts = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDK, transEN }
            };
            context.Texts.Add(TranslatedTexts);

            FrontPage fp = new FrontPage()
            {
                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                Translation = TranslatedTexts,


            };
            context.FrontPage.Add(fp);
            //Artwork

            var Artwork = new Artwork()
            {
                Artist = "Bart 4c",
                Translation = TranslatedTexts,
                ImageUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

            };

            //Sculptures

            var Sculptures = new Sculpture()
            {
                Artist = "Lisa 5c",
                Translation = TranslatedTexts,
                ImageUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

            };

            //Landart

            var Landart = new LandArt()
            {
                Translation = TranslatedTexts,
                ImageUrl = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg"

            };

            //Childrens Texts

            var ChildrensTexts = new ChildrensText()
            {
                Author = "Lisa 8c",
                Translation = TranslatedTexts,

            };

            //Global Goal

            var GG = new GlobalGoal()
            {
                Latitude = "12.3045",
                Longitude = "34.5566",
                Translation = TranslatedTexts,
                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",

                ChildrensTexts = new List<ChildrensText> { ChildrensTexts },
                Artworks = new List<Artwork> { Artwork },
                Sculptures = new List<Sculpture> { Sculptures },
                LandArts = new List<LandArt> { Landart },
               
                AudioURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                VideoURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                SongTitle = "Bum Bum Bla Bla..",
                SongArtist = "Shakira",
                AudioDescription = "Audio Description",
                AudioTitle = "Audio Title",

            };
            context.Global_Goals.Add(GG);

            base.Seed(context);
        }
    }
}
