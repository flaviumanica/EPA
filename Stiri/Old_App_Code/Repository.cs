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
            return -1;
        }

        public void StergereArticol(IFake context, int articolID)
        {
             
        }

        public void EditareArticol(IFake context, string titluOld, Articol updatedArticol)
        {
 

        }
 
    }
}