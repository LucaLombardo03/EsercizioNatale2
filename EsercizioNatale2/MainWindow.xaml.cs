using System;
using System.Collections.Generic;
using System.IO;
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

namespace EsercizioNatale2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file = @"file.txt";

        public MainWindow()
        {
            InitializeComponent();
        }
        double risultato;
        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double n1 = double.Parse(TxtNum1.Text);
                double n2 = double.Parse(TxtNum2.Text);
                
                string operatore = "";
                if (CmbOperazioni.SelectedIndex == 0)
                {
                    operatore = "+";
                    double somma = n1 + n2;
                    risultato = somma;
                    TxtRisultato.Text = $"{somma}";
                }
                if (CmbOperazioni.SelectedIndex == 1)
                {
                    operatore = "-";
                    double sottrazione = n1 - n2;
                    risultato = sottrazione;
                    TxtRisultato.Text = $"{sottrazione}";
                }
                if (CmbOperazioni.SelectedIndex == 2)
                {
                    operatore = "*";
                    double moltiplicazione = n1 * n2;
                    risultato = moltiplicazione;
                    TxtRisultato.Text = $"{moltiplicazione}";
                }
                if (CmbOperazioni.SelectedIndex == 3)
                {
                    operatore = "/";
                    if (n2 == 0)
                    {
                        MessageBox.Show("Non si può dividere per 0");
                        TxtRisultato.Text = "Immpossibile";
                    }
                    else
                    {
                        double divisione = n1 / n2;
                        risultato = divisione;
                        TxtRisultato.Text = $"{divisione}";
                    }
                }
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine($"{n1} {operatore} {n2} = {risultato}");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Devi inserire solo numeri");
            }
            
        }
    }
}
