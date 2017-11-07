using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class DbInit : DropCreateDatabaseAlways<GlobalGoalContext>
    {
        protected override void Seed(GlobalGoalContext context)
        {            
            ////Frontpage
            //FrontPage fp = new FrontPage()
            //{
            //    Id = 1,
            //    ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
            //    Title_Da = "VerVad Titel Dansk",
            //    Description_Da = "Projekt Beskrivelse",
            //    Title_En = "VerVad Title English",
            //    Description_En = "Project Description English"
            //};

            ////Global Goal
            //GlobalGoal gg = new GlobalGoal()
            //{
            //    Id = 1,
            //    ImgURL = "https://placeimg.com/500/300/nature",
            //    Description_Da = "Beskrivelse Dansk",
            //    Description_En = "Description English",
            //    //Coordinates
            //    Coordinates = new Coordinates()
            //    {
            //        Id = 1,
            //        Longitude = "1.1",
            //        Latitude = "1.1"
            //    },
            //    //Video and Audio
            //    MusicVideo = new MusicVideo
            //    {
            //        Id = 1,
            //        AudioURL = "https://www.dropbox.com/s/ewkmod3sbhw71ia/listener%20-%20Wooden%20Heart%20-%2001%20You%20have%20never%20lived%20because%20you%20have%20never%20died.mp3?dl=1",
            //        VideoURL = "https://www.youtube.com/embed/3BMgV8jj9IU"
            //    },
            //    //Land Art
            //    LandArt = new List<LandArt>()
            //    {
            //        new LandArt()
            //        {
            //            Id = 1,
            //            ImgURL = "https://placeimg.com/500/300/nature"
            //        },
            //        new LandArt()
            //        {
            //            Id = 2,
            //            ImgURL = "https://placeimg.com/500/300/nature"
            //        }
            //    },
            //    //Childrens Expressions
            //    ChildrensExpressions = new ChildrensExpressions()
            //    {
            //        //Artwork
            //        Id = 1,
            //        Artworks = new List<Artwork>()
            //        {
            //            new Artwork()
            //            {
            //                Id = 1,
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            },
            //             new Artwork()
            //            {
            //                Id = 2,
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            }
            //        },
            //        //Sculptures
            //        Sculptures = new List<Sculptures>()
            //        {
            //            new Sculptures()
            //            {
            //                Id = 1,
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            },
            //            new Sculptures()
            //            {
            //                Id = 2,
            //                ImgURL = "https://placeimg.com/500/300/nature"
            //            }
            //        },
            //        //Texts
            //        Texts = new List<Texts>()
            //        {
            //            new Texts()
            //            {
            //                Id = 1,
            //                Title_Da = "Titel til tekst Dansk",
            //                Text_Da = "Tekst Dansk",
            //                Title_En = "Title for text English",
            //                Text_En = "Text English"
            //            },
            //            new Texts()
            //            {
            //                Id = 2,
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

            base.Seed(context);
        }
    }
}
