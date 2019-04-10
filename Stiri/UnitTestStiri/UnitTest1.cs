using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stiri;
using Stiri.Old_App_Code;
using System;

namespace UnitTestStiri
{
    [TestClass]
    public class UnitTest1
    {
        IFake TestContext = new Stiri.StiriFakeDb();
        string key = "2345";
        int keyAddedArticle = -1; 

      
        // This test checks if an artical is inserted correctly in the db. 
        [TestMethod]  
        public void TestAddArticol()
        { 
            // create our Repository
            Repository repository = new Repository(); 
            string titlu = "Titlul articolului" + key;
            string continut = "Continutul articolului" + key;
            string descriere = "Descriere" + key;
            int categorie = 2;
            string link = "link" + key;
            User user = null;
            DateTime dataPublicare = new DateTime();
            // we've inserted our first article, with a null user, it must return -1
            int result = repository.AdaugareArticol(TestContext, categorie, titlu, continut, descriere, link, dataPublicare, user);
            Assert.IsTrue(result == -1);
            user = new User();
            keyAddedArticle = repository.AdaugareArticol(TestContext, categorie, titlu, continut, descriere, link, dataPublicare, user);
            Assert.IsTrue(keyAddedArticle != -1);
            // now, we want to check every field we filled  
            Assert.IsTrue(TestContext.Articol.Where(a => a.Titlu.Equals(titlu)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Continut.Equals(continut)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Descriere.Equals(descriere)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Categorie.Equals(categorie)).ToList().Count() > 0);  
        }

         

    }
}
