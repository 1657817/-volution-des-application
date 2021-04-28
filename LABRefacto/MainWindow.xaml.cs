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

namespace Lab
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            double resultat;
            if (!double.TryParse(txtMaths.Text, out resultat))
            {
                MessageBox.Show("Erreur. Veuillez entrer une valeur numérique!");
                txtMaths.Focus();
                return;
            }
            if (((Convert.ToDouble(txtMaths.Text) > 10))
               || (Convert.ToDouble(txtMaths.Text) < 0))
            {
                MessageBox.Show("Erreur. Veuillez entrer une valeur entre 0 et 10!");
                txtMaths.Focus();
                return;
            }
            if (!double.TryParse(txtInfo.Text, out resultat))
            {
                MessageBox.Show("Erreur. Veuillez entrer une valeur numérique!");
                txtInfo.Focus();
                return;
            }
            if (((Convert.ToDouble(txtInfo.Text) > 10))
                || (Convert.ToDouble(txtMaths.Text) < 0))
            {
                MessageBox.Show("Erreur. Veuillez entrer une valeur entre 0 et 10!");
                txtMaths.Focus();
                return;
            }
            if (rdbPrin.IsChecked == true)
            {
                txbResume.Text = "Matricule: " + txtMat.Text + "\nNom: " + txtNom.Text + "\nMoyenne: "
                  + ((Convert.ToDouble(txtMaths.Text)
                        + Convert.ToDouble(txtInfo.Text) + 1) / 2).ToString();
            }
            else
            {
                txbResume.Text = "Matricule: " + txtMat.Text + "\nNom: " + txtNom.Text + "\nMoyenne: "
                  + ((Convert.ToDouble(txtMaths.Text)
                      + Convert.ToDouble(txtInfo.Text)) / 2).ToString();
            }
        }
    }
}
