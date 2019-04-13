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
        int keyAddedCategory = -1;

        [TestMethod]  
        public void suiteTestArticle()
        {
            TestAddArticol();
            TestEditArticol();
            TestDeleteArticol();
        }
        [TestMethod]
        public void suiteTestCategorie()
        {
            TestInsertCategorie();
            TestDeleteCategorie();
        }

        // TDD - We must implement a method named AdaugareCategorie in Repository class that must add a new category in the db.        
       public void TestInsertCategorie()
        {   
            // create our Repository
            Repository repository = new Repository();
            string categoryName = "FirstCategory";
            keyAddedCategory = repository.AdaugareCategorie(TestContext, categoryName);
            // After we added a category, we must check if the category is in the db.
            // We search for the category name and we expect to have a category having that name.
            Assert.IsTrue(TestContext.Categorii.Where(a => a.Nume.Equals(categoryName)).ToList().Count() == 1);
            Console.WriteLine(keyAddedCategory);
            Assert.IsTrue(keyAddedCategory >= 0);
            
        }

         
        public void TestDeleteCategorie()
        {
            // create our Repository
            Repository repository = new Repository();  
            repository.StergereCategorie(TestContext, keyAddedCategory);
            Assert.IsFalse(TestContext.Categorii.Any(a => a.Id == keyAddedCategory));

        }


        // This test checks if an artical is inserted correctly in the db. 
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

        // we want to check if the article added earlier can be retrieved and updated.
        
        public void TestEditArticol()
        {
            // create our Repository
            Repository repository = new Repository();
            // We retrieve the article added earlier.
            Articol articol = TestContext.Articol.FirstOrDefault(a => a.Titlu.Contains("Titlul articolului" + key));
            string newKey = "000";
            string oldTitle = articol.Titlu;
            articol.Titlu = articol.Titlu + newKey;
            articol.Continut = articol.Continut + newKey;
            articol.Descriere = articol.Descriere + newKey;
            articol.Categorie = 2;
            articol.Link = articol.Link + newKey;
            repository.EditareArticol(TestContext, oldTitle, articol);
            // we check every single field we've just updated
            Assert.IsTrue(TestContext.Articol.Where(a => a.Titlu.Equals(articol.Titlu)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Continut.Equals(articol.Continut)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Descriere.Equals(articol.Descriere)).ToList().Count() > 0);
            Assert.IsTrue(TestContext.Articol.Where(a => a.Categorie.Equals(articol.Categorie)).ToList().Count() > 0); 

        }

        // we've just added an article, but we must delete it, in order to check the correctness of the delete feature, and also to clean the db.
         
        public void TestDeleteArticol()
        {
            // create our Repository
            Repository repository = new Repository(); 
            repository.StergereArticol(TestContext, keyAddedArticle); 
            Assert.IsFalse(TestContext.Articol.Any(a => a.Id == keyAddedArticle));

        }

    }
}
