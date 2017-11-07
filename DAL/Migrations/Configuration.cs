namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Contexts.GlobalGoalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Contexts.GlobalGoalContext context)
        {
            ////Frontpage
            //FrontPage fp = new FrontPage()
            //{
            //    ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
            //    Title_Da = "VerVad Titel Dansk",
            //    Description_Da = "Projekt Beskrivelse Dansk",
            //    Title_En = "VerVad Title English",
            //    Description_En = "Project Description English"
            //};

            ////Global Goal
            //GlobalGoal gg = new GlobalGoal()
            //{
            //    ImgURL = "https://placeimg.com/500/300/nature",
            //    Title_Da = "VerVad Titel Dansk",
            //    Description_Da = "Beskrivelse Dansk",
            //    Title_En = "VerVad Title English",
            //    Description_En = "Description English",
            //    //Coordinates
            //    Coordinates = new Coordinates()
            //    {
            //        Longitude = "1.1",
            //        Latitude = "1.1"
            //    },
            //    //Video and Audio
            //    MusicVideo = new MusicVideo
            //    {
            //        AudioURL = "https://www.dropbox.com/s/ewkmod3sbhw71ia/listener%20-%20Wooden%20Heart%20-%2001%20You%20have%20never%20lived%20because%20you%20have%20never%20died.mp3?dl=1",
            //        VideoURL = "https://www.youtube.com/embed/3BMgV8jj9IU"
            //    },
            //    //Land Art
            //    LandArt = new List<LandArt>()
            //    {
            //        new LandArt()
            //        {
            //            ImgURL = "https://placeimg.com/500/300/nature"
            //        },
            //        new LandArt()
            //        {
            //            ImgURL = "https://placeimg.com/500/300/nature"
            //        }
            //    },
            //    //Childrens Expressions
            //    ChildrensExpressions = new ChildrensExpressions()
            //    {
            //        //Artwork
            //        Artworks = new List<Artwork>()
            //        {
            //            new Artwork()
            //            {
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            },
            //             new Artwork()
            //            {
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            }
            //        },
            //        //Sculptures
            //        Sculptures = new List<Sculptures>()
            //        {
            //            new Sculptures()
            //            {
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            },
            //            new Sculptures()
            //            {
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            }
            //        },
            //        //Texts
            //        Texts = new List<Texts>()
            //        {
            //            new Texts()
            //            {
            //                Title_Da = "Titel til tekst Dansk",
            //                Text_Da = "Tekst Dansk",
            //                Title_En = "Title for text English",
            //                Text_En = "Text English"
            //            },
            //            new Texts()
            //            {
            //                Title_Da = "Titel til tekst Dansk",
            //                Text_Da = "Tekst Dansk",
            //                Title_En = "Title for text English",
            //                Text_En = "Text English"
            //            }
            //        }
            //    }
            //};

            //context.Global_Goal.Add(gg);
            //context.Front_Page.Add(fp);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:"
                      , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: \"{0}\", Error: \"{1}\""
                         , ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw new DbEntityValidationException(string.Format("Validation errors\r\n{0}"
                 , outputLines.ToString()), dbValEx);
            }
        }
    }
}
