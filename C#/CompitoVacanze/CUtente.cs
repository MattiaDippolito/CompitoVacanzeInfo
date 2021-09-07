using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze
{
    public class CUtente
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int m_totali;
        public int M_totali
        {
            get { return m_totali; }
            set { m_totali = value; }
        }

        private int m_sessione;
        public int M_sessione
        {
            get { return m_sessione; }
            set { m_sessione = value; }
        }

        private int diametro_ruota;
        public int Diametro_ruota
        {
            get { return diametro_ruota; }
            set { diametro_ruota = value; }
        }

        private string ora_inizio;
        public string Ora_inizio
        {
            get { return ora_inizio; }
            set { ora_inizio = value; }
        }

        private string ora_fine;
        public string Ora_fine
        {
            get { return ora_fine; }
            set { ora_fine = value; }
        }

        public CUtente(string _nome, int _diametro)
        {
            nome = _nome;
            diametro_ruota = _diametro;
            m_totali = 0;
            m_sessione = 0;
            ora_inizio = "";
            ora_fine = "";
        }

        public CUtente()
        {
            nome = "";
            diametro_ruota = 0;
            m_sessione = 0;
            m_totali = 0;
        }

        public string toCSV()
        {
            return nome + ";" + Convert.ToString(m_totali) + ";" + Convert.ToString(m_sessione) + ";" + Convert.ToString(diametro_ruota) + ";" + ora_inizio + ";" + ora_fine;
        }

        public void fromCSV(string riga)
        {
            string[] campi = riga.Split(';');
            if (campi[0] != "")
            {
                nome = campi[0];
                m_totali = Convert.ToInt32(campi[1]);
                m_sessione = Convert.ToInt32(campi[2]);
                diametro_ruota = Convert.ToInt32(campi[3]);
                ora_inizio = campi[4];
                ora_fine = campi[5];
            }
        }
    }
}
