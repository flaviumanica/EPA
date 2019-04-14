using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stiri.Old_App_Code
{
    public class Repository
    {
        public int AdaugareArticol(IFake context, int ID_Categorie, string titlu, string continut, string descriere, string link, DateTime dataPublicare, User user)
        {
            if(user == null)
            {
                return -1;
            }
            Articol art = new Articol()
            {
                Titlu = titlu,
                Continut = continut,
                Descriere = descriere,
                Categorie = ID_Categorie,
                Link = link,
                User = user,
                Data_Publicare = dataPublicare

            };

            context.Articol.Add(art);
            context.SaveChanges();
            int IDUL = art.Id;
            return IDUL;
        }

        public void StergereArticol(IFake context, int articolID)
        {
            Articol art = context.Articol.FirstOrDefault(a => a.Id == articolID);
            context.Articol.Remove(art);
            
            context.SaveChanges();
        }

        public void EditareArticol(IFake context, string titluOld, Articol updatedArticol)
        {
            Articol articol = context.Articol.FirstOrDefault(a => a.Titlu.Contains(titluOld));
            articol.Titlu = updatedArticol.Titlu;
            articol.Continut = updatedArticol.Continut;
            articol.Descriere = updatedArticol.Descriere;
            articol.Categorie = updatedArticol.Categorie;
            articol.Link = updatedArticol.Link;
            context.SaveChanges();

        }

        public int AdaugareCategorie(IFake context, string categorie)
        {
            int ID_Categorie;
            Categorii cat = new Categorii()
            {
                Nume = categorie
            };
            context.Categorii.Add(cat);
            context.SaveChanges();
            ID_Categorie = cat.Id;
            return ID_Categorie;
        }
        public void StergereCategorie(IFake context, int categorieId)
        {
            Categorii categorie = context.Categorii.FirstOrDefault(a => a.Id == categorieId);
            context.Categorii.Remove(categorie); 
            context.SaveChanges();
        }
    }
}