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

namespace LAB_CTRL_EVENT
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

        private void btnGras_Click(object sender, RoutedEventArgs e)
        {
            if (txtText.FontWeight == FontWeights.Bold)
            {
                txtText.FontWeight = FontWeights.Normal;
                btnGras.Background = Brushes.LightGray;
            } else
            {
                txtText.FontWeight = FontWeights.Bold;
                btnGras.Background = Brushes.Orange;
            }
        }

        private void btnItalique_Click(object sender, RoutedEventArgs e)
        {
            if (txtText.FontStyle == FontStyles.Italic)
            {
                txtText.FontStyle = FontStyles.Normal;
                btnItalique.Background = Brushes.LightGray;
            }
            else
            {
                txtText.FontStyle = FontStyles.Italic;
                btnItalique.Background = Brushes.Orange;
            }
        }

        private void btnEffacerArriere_Click(object sender, RoutedEventArgs e)
        {
            if (txtText.Text != "")
            {
                txtText.Text =  txtText.Text.Remove(txtText.Text.Length - 1, 1);
            }
        }

        private void btnViderChamp_Click(object sender, RoutedEventArgs e)
        {
            txtText.Clear();
        }

        private void txtText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtText.Text != "")
            {
                btnEffacerArriere.IsEnabled = true;
                btnViderChamp.IsEnabled = true;
            }
            else
            {
                btnEffacerArriere.IsEnabled = false;
                btnViderChamp.IsEnabled = false;
            }
        }
    }
}
