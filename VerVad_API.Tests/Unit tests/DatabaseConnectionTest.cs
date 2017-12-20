using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using System.Collections.Generic;
using DAL.Contexts;
using DAL.Interfaces;
using DAL.Facade;
using VerVad_API.Helpers;

namespace VerVad_API.Tests.DTO_Unit_tests
{
    [TestClass]
    public class UnitTest1
    {
        private FrontPage frontPageDb = new FrontPage();
        private List<GlobalGoal> globalGoalDbList = new List<GlobalGoal>();

        private IGGAndAVRepository<GlobalGoal, int> _globalGoalRepo = new Facade().GetGlobalGoalRepository();
        private IFrontPageRepository<FrontPage, int> _frontPageRepo = new Facade().GetFrontPageRepository();




        
        [TestMethod]
        public void DbConnectionTest()
        {
            Assert.IsNotNull(frontPageDb);
            Assert.IsNotNull(frontPageDb.Translation.TranslatedTexts);
            Assert.IsNotNull(globalGoalDbList);
            Assert.IsNotNull(globalGoalDbList[0].Translation.TranslatedTexts);
            Assert.IsTrue(globalGoalDbList[0].Translation.TranslatedTexts.Count > 0);
            CollectionAssert.AllItemsAreUnique(globalGoalDbList);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            globalGoalDbList = _globalGoalRepo.ReadAll();
            frontPageDb = _frontPageRepo.Read(1);
        }
    }
}
