using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using VerVad_API.Helpers;
using VerVad_API.Models;

namespace VerVad_API.Tests.Unit_tests
{
    /// <summary>
    /// Summary description for ObjectToDTOTest
    /// </summary>
    [TestClass]
    public class ObjectToDTOTest
    {
        private GlobalGoalChildrensHelper _childrensHelper = new GlobalGoalChildrensHelper();
        private FrontPageHelper _frontPageHelper = new FrontPageHelper();
        private GlobalGoalHelper _globalGoalHelper = new GlobalGoalHelper();

        private GlobalGoal _globalGoalwithChildren;
        private GlobalGoal _globalGoalNoChildren;
        private FrontPage _frontPage;

        private Translation translatedTexts;
        private Translation translatedTexts1;

        private TranslationLanguage transDK;
        private TranslationLanguage transDK1;
        private TranslationLanguage transEN;
        private TranslationLanguage transEN1;
        private TranslationLanguage transDE;
        private TranslationLanguage transDE1;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DTOConversionTest()
        {

            var danishGlobalGoalDTONoChildren = _globalGoalHelper.GetGlobalGoalDTO("da", _globalGoalNoChildren);
            var englishGlobalGoalDTONoChildren = _globalGoalHelper.GetGlobalGoalDTO("en", _globalGoalNoChildren);

            var danishGlobalGoalDTOWithChildren = _globalGoalHelper.GetGlobalGoalDTO("da", _globalGoalwithChildren);
            var englishGlobalGoalDTOWithChildren = _globalGoalHelper.GetGlobalGoalDTO("en", _globalGoalwithChildren);

            var frontPageDTO = _frontPageHelper.GetFrontPageDTO("en", _frontPage);

            Assert.IsNotNull(danishGlobalGoalDTOWithChildren);
            Assert.IsNotNull(englishGlobalGoalDTONoChildren);

            Assert.AreNotEqual(_globalGoalwithChildren, danishGlobalGoalDTOWithChildren);
            Assert.AreNotEqual(danishGlobalGoalDTONoChildren, englishGlobalGoalDTONoChildren);

            Assert.AreEqual(danishGlobalGoalDTONoChildren.AudioVideo, null);

            Assert.IsInstanceOfType(englishGlobalGoalDTOWithChildren, typeof(DTOGlobalGoal));
            Assert.IsTrue(frontPageDTO.ImgUrl != null);

            Assert.AreEqual(frontPageDTO.ImgUrl, "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg");

        }
        [TestInitialize]
        public void InitializeTest()
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

            //Translations
            transEN = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "The Global Goals - The Wadden Sea",
                Language = LanguageEN,
            };

            transDK = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Verdensmål ved Vadehavet",
                Language = LanguageDA,
            };

            transDE = new TranslationLanguage()
            {
                Description = "TYSK Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Welt Ziele eller noget..",
                Language = LanguageDE,
            };

            transEN1 = new TranslationLanguage()
            {
                Description = "ENGELSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "The Global Goals - The Wadden Sea",
                Language = LanguageEN,
            };

            transDK1 = new TranslationLanguage()
            {
                Description = "DANSK: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Verdensmål ved Vadehavet",
                Language = LanguageDA,
            };

            transDE1 = new TranslationLanguage()
            {
                Description = "TYSK Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non scelerisque nibh. Vestibulum ante ipsum " +
                "primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vel purus ultricies mauris fringilla rhoncus." +
                "Duis a vehicula nunc, a sagittis leo. Etiam tempor faucibus orci ac cursus. Vestibulum ante ipsum primis in faucibus" +
                "orci luctus et ultrices posuere cubilia Curae; Sed vestibulum neque vitae nisi blandit commodo.Maecenas varius," +
                " dolor at commodo.",
                Title = "Welt Ziele",
                Language = LanguageDE,
            };

            translatedTexts = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDK, transEN, transDE }
            };
            translatedTexts1 = new Translation()
            {
                TranslatedTexts = new List<TranslationLanguage> { transDK1, transEN1, transDE1 }
            };

            //Frontpage
            _frontPage = new FrontPage()
            {
                Id = 1,
                ImgURL = "http://res.cloudinary.com/bjoernebanden/image/upload/v1509645764/1920-x-1080-nationalpark-vadehavet-kort_arxf8u.jpg",
                Translation = translatedTexts
            };

            //Artwork
            var Artwork = new Artwork()
            {
                Id = 1,
                Artist = "Bart 4c",
                Translation = translatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Landart
            var Landart = new LandArt()
            {
                Id = 1,
                Translation = translatedTexts,
                ImgUrl = "https://placeimg.com/600/400/nature"

            };

            //Childrens Texts
            var ChildrensTexts = new ChildrensText()
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
            _globalGoalwithChildren = new GlobalGoal()
            {
                Id = 1,
                Latitude = 55.572044,
                Longitude = 8.309237,
                Translation = translatedTexts,
                ImgURL = "https://placeimg.com/600/400/nature",
                IsPublished = true,

                ChildrensTexts = new List<ChildrensText> { ChildrensTexts },
                Artworks = new List<Artwork> { Artwork },
                LandArts = new List<LandArt> { Landart },
                AudioVideo = audioVideo
            };
            _globalGoalNoChildren = new GlobalGoal()
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
        }
    }
}
