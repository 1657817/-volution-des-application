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

namespace LABREFACTORISATION
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum SESSION { Principale, Rattrapage }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            if (!ValiderEntreeMaths(txtMaths.Text) || !ValiderEntreeInfo(txtInfo.Text))
            {
                return;
            }
            double noteInfo = Convert.ToDouble(txtInfo.Text);
            double noteMath = Convert.ToDouble(txtMaths.Text);

            if (rdbPrin.IsChecked == true)
            {
                txbResume.Text = "Matricule: " + txtMat.Text + "\nNom: " + txtNom.Text + "\nMoyenne: "
                  + MoyennePrincipale(noteInfo, noteMath).ToString();
            }
            else
            {
                txbResume.Text = "Matricule: " + txtMat.Text + "\nNom: " + txtNom.Text + "\nMoyenne: "
                  + MoyenneRattrapage(noteInfo, noteMath).ToString();
            }
        }

        private bool ValiderEntreeMaths(string valEntree)
        {
            double noteMath;
            if (double.TryParse(valEntree, out noteMath))
            {
                if ((noteMath > 10) || (noteMath < 0))
                {
                    MessageBox.Show("Erreur. Veuillez entrer une valeur entre 0 et 10!");
                    txtMaths.Focus();
                    return false;
                }
                return true;
            }
            MessageBox.Show("Erreur. Veuillez entrer une valeur numérique!");
            txtMaths.Focus();
            return false;
        }

        private bool ValiderEntreeInfo(string valEntree)
        {
            double noteInfo;
            if (double.TryParse(valEntree, out noteInfo))
            {
                if ((noteInfo > 10) || (noteInfo < 0))
                {
                    MessageBox.Show("Erreur. Veuillez entrer une valeur entre 0 et 10!");
                    txtMaths.Focus();
                    return false;
                }
                return true;
            }
            MessageBox.Show("Erreur. Veuillez entrer une valeur numérique!");
            txtMaths.Focus();
            return false;
        }

        private double MoyennePrincipale(double noteInfo, double noteMath)
        {
            return (noteInfo + noteMath + 1) / 2;
        }

        private double MoyenneRattrapage(double noteInfo, double noteMath)
        {
            return (noteInfo + noteMath) / 2;
        }
    }
}
