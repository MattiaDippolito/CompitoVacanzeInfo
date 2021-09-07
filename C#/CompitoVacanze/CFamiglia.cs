using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CompitoVacanze
{
    class CFamiglia
    {
        List<CUtente> utenti;
        public List<CUtente> Utenti
        {
            get { return utenti; }
            set { utenti = value; }
        }
        public CFamiglia()
        {
            utenti = new List<CUtente>();
        }
        public void Aggiungi(CUtente u)
        {
            utenti.Add(u);
        }
        public CUtente ElementAt(int i)
        {
            return utenti.ElementAt(i);
        }
        public void RimuoviUtente(CUtente u)
        {
            bool eliminato = false;
            for (int i = 0; i < utenti.Count && !eliminato; i++)
            {
                if (utenti[i] == u)
                {
                    utenti.RemoveAt(i);
                    eliminato = true;
                }
            }
        }
        public string toCSV()
        {
            string s = "";
            for (int i = 0; i < utenti.Count; i++)
            {
                s += utenti[i].toCSV() + "\n";
            }
            return s;
        }
        public CUtente trovaUtente(string nome)
        {
            CUtente u = new CUtente();
            bool trovato = false;
            for (int i = 0; i < utenti.Count && !trovato; i++)
            {
                if (utenti[i].Nome == nome)
                {
                    return utenti[i];
                }
            }
            return u;
        }
        public void fromCSV(string riga)
        {
            CUtente u = new CUtente();
            u.fromCSV(riga);
            utenti.Add(u);
        }
        public void caricaTutto()
        {
            string temp = "";
            for (int i = 0; i < utenti.Count; i++)
            {
                temp += utenti.ElementAt(i).toCSV() + "\n";
            }
            File.WriteAllText("F:\\Compito_vacanze_info\\Utenti.txt", temp);
        }
        public void leggiTutto()
        {
            List<CUtente> _utenti = new List<CUtente>();
            using (StreamReader sr = File.OpenText("F:\\Compito_vacanze_info\\Utenti.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    CUtente temp = new CUtente();
                    temp.fromCSV(s);
                    _utenti.Add(temp);
                }
            }
            utenti = _utenti;
        }

        public CUtente trovaUltimo(string nome)
        {
            CUtente u = new CUtente();
            int pos = 0;
            for(int i = 0; i < utenti.Count; i++)
            {
                if (utenti[i].Nome == nome)
                {
                    pos = i;
                }
            }
            return utenti[pos];
        }

        public CUtente trovaPenultimo(string nome)
        {
            List<CUtente> temp = new List<CUtente>();
            for (int i = 0; i < utenti.Count; i++)
            {
                if (utenti[i].Nome == nome)
                {
                    temp.Add(utenti[i]);
                }
            }
            if (temp.Count == 1)
                return temp[0];
            else
                return temp[temp.Count-2];
        }
    }
}
