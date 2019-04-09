using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

/// <summary>
/// Summary description for TextRank
/// </summary>
namespace Text_Rank
{
    public struct VType
    {
        public String prop;
        public ArrayList cuvinte;
        public double scor;
        public int id;
    }
    public class VertexType
    {
        public String prop;
        public ArrayList cuvinte;
        public Double scor;
        public int id;
    }
    public class Graf
    {
        public List<VType> V = new List<VType>();
        public double[,] E;
        public int numVerts;
    }
    public struct outputType
    {
        public String sentence;
        public ArrayList tokens;
    }

    public class TextRank
    {
        static ArrayList prepozitii;
        static ArrayList cuvinte;
        //Numarul de propozitii extrase
        static int nrPropozitiiDeExtras;
        //Factorul de amortizare (intre 0 si 1)
        static double d;
        //Propozitiile din text
        static ArrayList propozitiileDinText;
        //Cuvintele din text
        static ArrayList cuvinteleDinPropozitii;
        public static Graf graf;

        //Articol sumarizat
        static String articolRezumat;
        //pragul de convergenta
        static double delta;

        public TextRank(){}

        public static void init()
        {
            prepozitii = new ArrayList();
            cuvinte = new ArrayList();
            propozitiileDinText = new ArrayList();
            cuvinteleDinPropozitii = new ArrayList();
            nrPropozitiiDeExtras = 3;
            d = 0.85;
            graf = new Graf();
            articolRezumat = "";
            delta = 0.001;
        }

        public static string get_summary(string articleOfText)
        {
            init();
            incarcaPrepozitii();
            citesteText(articleOfText);
            return run(articleOfText);
        }

        public static void incarcaPrepozitii()
        {
            TextReader txt;
            txt = File.OpenText("C:\\Users\\Andreea\\Desktop\\New Folder\\Stiri\\App_Code\\prepozitii.txt");

            string prep;
            prep = txt.ReadLine();
            while (prep != null)
            {
                prepozitii.Add(prep.ToLower());
                prep = txt.ReadLine();
            }
        }

        public static void citesteText(String articleOfText)
        {
            string text = articleOfText;
            string copy = text;
            string[] prop = text.Split(new Char[] { '.', '!', '?', ';', '\\', '\r', '\n' },
                                StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < prop.Length; i++)
            {
                string propoz = "";
                string x = copy.Substring(copy.IndexOf(prop[i]) + prop[i].Length, 1);
                propoz = prop[i] + x;
                propozitiileDinText.Add(propoz);
            }

            for (int j = 0; j < prop.Length; j++)
            {
                cuvinte = new ArrayList();
                string[] cuvi = prop[j].Split(new char[] { ',', ':', '\"', ' ', ')', '(', '\r', '/', '|', '\'' },
                                StringSplitOptions.RemoveEmptyEntries);

                foreach (string cuv in cuvi)
                {
                    if (!prepozitii.Contains(cuv.ToLower()))
                    {
                        if (contineCifre(cuv) == false)
                            cuvinte.Add(cuv);
                    }
                }

                cuvinteleDinPropozitii.Add(cuvinte);
            }
        }

        public static bool contineCifre(String cuv)
        {
            if (cuv.Contains('0'))
            {
                return true;
            }
            if (cuv.Contains('1'))
            {
                return true;
            }
            if (cuv.Contains('2'))
            {
                return true;
            }
            if (cuv.Contains('3'))
            {
                return true;
            }
            if (cuv.Contains('4'))
            {
                return true;
            }
            if (cuv.Contains('5'))
            {
                return true;
            }
            if (cuv.Contains('6'))
            {
                return true;
            }
            if (cuv.Contains('7'))
            {
                return true;
            }
            if (cuv.Contains('8'))
            {
                return true;
            }
            if (cuv.Contains('9'))
            {
                return true;
            }
            return false;
        }

        public static string run(String article)
        {
            // Construieste graful
            setareGraf(article);
            // Claseaza propozitiile
            itereaza(0, true);
            articolRezumat = extrageRezumat(nrPropozitiiDeExtras);
            return articolRezumat;
            //articolRezumat = extrageRezumat(nrPropozitiiDeExtras);
            //return articolRezumat;
        }

        public static void setareGraf(String article) //constructia grafului
        {
            List<outputType> x = procesareText(article, propozitiileDinText, cuvinteleDinPropozitii);
            int idx = 0;
            foreach (outputType y in x)
            {
                VType z = new VType();
                z.prop = y.sentence;
                z.cuvinte = y.tokens;
                z.id = idx;
                idx++;
                graf.V.Add(z);
            }

            graf.numVerts = graf.V.Count;

            graf.E = new double[graf.numVerts, graf.numVerts];

            for (int i = 0; i < graf.numVerts; i++)
            {
                for (int j = 0; j < graf.numVerts; j++)
                {
                    graf.E[i, j] = 1;
                }
            }

            //Initializez scorurile nodurilor
            for (int iIndex = 0; iIndex < graf.V.Count; iIndex++)
            {
                VertexType vertex = new VertexType();
                vertex.prop = graf.V[iIndex].prop;
                vertex.cuvinte = graf.V[iIndex].cuvinte;
                vertex.scor = 1;
                vertex.id = iIndex;
                VertexType Si = new VertexType();
                Si = vertex;

                //adaug muchie intre fiecare propozitie din graf
                for (int j = 0; j < graf.numVerts; j++)
                {
                    if (j != iIndex) //nu adaug muchie intre aceeasi prop
                    {
                        VType Sj = new VType();
                        Sj = graf.V[j];
                        graf.E[iIndex, j] = scorSimilaritate(Si, Sj);
                    }
                }
            }
        }

        public static List<outputType> procesareText(String article, ArrayList userTokens, ArrayList userTokensSplit)
        {
            return iesireProcesare(article, userTokens, userTokensSplit);
        }

        public static List<outputType> iesireProcesare(String article, ArrayList userTokens, ArrayList userTokensSplit)
        {
            List<outputType> output = new List<outputType>();
            ArrayList tokens = new ArrayList();
            tokens = userTokens;
            for (var i = 0; i < tokens.Count; i++)
            {
                ArrayList tokenizedSentence = new ArrayList();
                int idx = 0;
                //pun toate cuvintele din prop i in tokenizedSentence
                foreach (ArrayList vec in userTokensSplit) 
                {
                    if (idx == i)
                    {
                        tokenizedSentence = vec;
                    }
                    idx++;
                }

                outputType x = new outputType();
                x.sentence = tokens[i].ToString();
                x.tokens = tokenizedSentence;
                output.Add(x);
            }
            return output;
        }

        public static double scorSimilaritate(VertexType Si, VType Sj)
        {

            ArrayList Si_tokens = Si.cuvinte;
            ArrayList Sj_tokens = Sj.cuvinte;
            ArrayList cuvComune = new ArrayList();

            for (int j = 0; j < Sj_tokens.Count; j++)
            {
                if (Si_tokens.Contains(Sj_tokens[j]))
                {
                    cuvComune.Add(Sj_tokens[j]);
                }

            }
            double nrCuvinteTotale = Math.Log(Si.cuvinte.Count) + Math.Log(Sj.cuvinte.Count);
            int nrCuvinteComune = cuvComune.Count;

            return nrCuvinteComune / nrCuvinteTotale;
        }

        public static void itereaza(double iterations, bool itereazaAgain)
        {
            for (int index = 0; index < graf.V.Count; index++)
            {
                VType vertex = new VType();
                vertex = graf.V[index];
                double score_0 = vertex.scor;
                ArrayList vertexNeighbors = new ArrayList();
                for (int j = 0; j < graf.numVerts; j++)
                {
                    //pune scorul de sim intre prop curenta si toate prop
                    vertexNeighbors.Add(graf.E[index, j]);
                }
                double muchiiVi = 0;
                for (int neighborIndex = 0; neighborIndex < vertexNeighbors.Count; neighborIndex++)
                {
                    var neighbor = vertexNeighbors[neighborIndex]; // scorul vecin
                    var wji = graf.E[index, neighborIndex];// scorul dintre prop si restul prop
                    ArrayList outNeighbors = new ArrayList();
                    for (int i = 0; i < graf.numVerts; i++)
                    {
                        outNeighbors.Add(graf.E[neighborIndex, i]);
                    }
                    //Suma scorurilor peste toate muchiile asoc cu Vj
                    double muchiiVj = 1; 
                    for (int outIndex = 0; outIndex < outNeighbors.Count; outIndex++)
                    {
                        muchiiVj += (double)outNeighbors[outIndex];
                    }
                    double WSVertex = graf.V[neighborIndex].scor; // WS(Vj)
                    //Suma pentru toate muchiile asoc cu Vi
                    muchiiVi += (wji / muchiiVj) * WSVertex; 
                }
                double score_1 = (1 - d) + d * muchiiVi; // WS(Vi)
                // Update pe scorul din nod
                VType v = new VType();
                v.scor = score_1;
                v.prop = graf.V[index].prop;
                v.cuvinte = graf.V[index].cuvinte;
                graf.V[index] = v;
                // Verific daca continui
                if (Math.Abs(score_1 - score_0) <= delta)
                {
                    itereazaAgain = false;
                }
            }
            if (itereazaAgain == true)
            {
                iterations += 1;
                itereaza(iterations, itereazaAgain);
            }
            else
            {

                // 
            }
            return;
        }

        public static String extrageRezumat(int N)
        {
            List<VType> sentences = new List<VType>();
            
            for (int index = 0; index < graf.V.Count; index++)
            {
                VType cv = new VType();
                cv = graf.V[index];
                cv.id = index;
                sentences.Add(cv);
            }

            //Sortez propozitiile in functie de scor
            int sw;
            do
            {
                sw = 0;
                for (int i = 0; i < sentences.Count - 1; i++)
                {
                    if (sentences[i].scor < sentences[i + 1].scor)
                    {
                        VType x = new VType();
                        x = sentences[i];
                        sentences[i] = sentences[i + 1];
                        sentences[i + 1] = x;
                        sw = 1;
                    }

                }
            }
            while (sw == 1);

            //retin doar N propozitii pentru a le afisa
            List<VType> sentencesN = new List<VType>();
            for (int i = 0; i < N; i++)
            {
                sentencesN.Add(sentences[i]);
            }

            //ordonez cele N propozitii dupa aparitia lor in text
            do
            {
                sw = 0;
                for (int i = 0; i < sentencesN.Count - 1; i++)
                {
                    if (sentencesN[i].id > sentencesN[i + 1].id)
                    {
                        VType x = new VType();
                        x = sentencesN[i];
                        sentencesN[i] = sentencesN[i + 1];
                        sentencesN[i + 1] = x;
                        sw = 1;
                    }

                }
            }
            while (sw == 1);

            //compun rezumatul 
            String summary = sentencesN[0].prop;
            for (var i = 1; i < N; i++)
            {
                summary += " " + sentencesN[i].prop;
            }
            return summary;
        }

    }
}