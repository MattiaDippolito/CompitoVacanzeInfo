using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.IO.Ports;

namespace CompitoVacanze
{
    public partial class MainWindow : Window
    {
        CFamiglia famiglia = new CFamiglia();
        CUtente utilizzatore;
        int n_giri = 10;
        SerialPort arduino;
        public MainWindow()
        {
            InitializeComponent();

            famiglia.leggiTutto();
            utilizzatore = new CUtente();

            cmb_diametro.Items.Add(40);
            cmb_diametro.Items.Add(42);
            cmb_diametro.Items.Add(44);
            cmb_diametro.Items.Add(46);
            cmb_diametro.Items.Add(48);
            cmb_diametro.Items.Add(50);

            arduino = new SerialPort();
            arduino.PortName = "COM5";
            arduino.BaudRate = 9600;
        }

        private void btn_avvia_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nome.Text != "" && cmb_diametro.Text !="")
            {
                CUtente u = new CUtente(txt_nome.Text, Convert.ToInt32(cmb_diametro.Text));
                DateTime orarioInizio = DateTime.Now;
                string oraInizio = orarioInizio.ToString();
                u.Ora_inizio = oraInizio;
                famiglia.Aggiungi(u);
                utilizzatore = u;
                txt_nome.Text = "";
                cmb_diametro.Text = "";
                avviso.Content = "Registrazione avvenuta";
                /*arduino.Open();
                arduino.Write("p");
                arduino.Close();*/
            }
            else
            {
                avviso.Content = "COMPILARE TUTTI I CAMPI!";
            }
        }

        private void btn_visualizza_Click(object sender, RoutedEventArgs e)
        {
            famiglia.leggiTutto();
            string str = "";
            for (int i = 0; i < famiglia.Utenti.Count; i++)
            {
                str += famiglia.Utenti.ElementAt(i).Nome + " " + famiglia.Utenti.ElementAt(i).Diametro_ruota.ToString() + " " + famiglia.Utenti.ElementAt(i).M_sessione.ToString() + " " + famiglia.Utenti.ElementAt(i).M_totali.ToString() + " " + famiglia.Utenti.ElementAt(i).Ora_inizio + " " + famiglia.Utenti.ElementAt(i).Ora_fine + "\n";
            }
            txt1.Text = str;
        }

        private void btn_termina_Click_1(object sender, RoutedEventArgs e)
        {
            /*arduino.Open();
            arduino.Write("s");
            arduino.Close();*/
            famiglia.trovaUltimo(utilizzatore.Nome).M_totali = n_giri * 2 * famiglia.trovaUltimo(utilizzatore.Nome).Diametro_ruota + famiglia.trovaPenultimo(utilizzatore.Nome).M_totali;
            famiglia.trovaUltimo(utilizzatore.Nome).M_sessione = 0;
            famiglia.trovaUltimo(utilizzatore.Nome).M_sessione = n_giri * 2 * famiglia.trovaUltimo(utilizzatore.Nome).Diametro_ruota;
            DateTime orarioFine = DateTime.Now;
            string oraFine = orarioFine.ToString();
            famiglia.trovaUltimo(utilizzatore.Nome).Ora_fine = oraFine;
            famiglia.caricaTutto();
        }

        /*private async Task ricevi(SerialPort arduino)
        {
            arduino.Open();
            string s = arduino.ReadLine();
            Console.WriteLine(s);
            arduino.Close();
            n_giri = Convert.ToInt32(s);
        }*/
    }
}
