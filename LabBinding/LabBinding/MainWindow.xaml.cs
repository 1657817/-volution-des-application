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

namespace LabBinding
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UserControl ContenuEcran { get; set; }

        private UC_Ecran1 Scr1 = new UC_Ecran1();
        private EC_Ecran2 Scr2 = new EC_Ecran2();
        private UC_EcranAcceuil ScrHome = new UC_EcranAcceuil();

        public MainWindow()
        {
            InitializeComponent();

            ContenuEcran = ScrHome;
            Grid.SetRow(ContenuEcran, 1);
            Grid.SetColumn(ContenuEcran, 0);
            gPrincipal.Children.Add(ContenuEcran);
        }

        private void btnScr1_Click(object sender, RoutedEventArgs e)
        {
            gPrincipal.Children.Remove(ContenuEcran);
            ContenuEcran = Scr1; ;
            Grid.SetRow(ContenuEcran, 1);
            Grid.SetColumn(ContenuEcran, 0);
            gPrincipal.Children.Add(ContenuEcran);
        }

        private void btnScr2_Click(object sender, RoutedEventArgs e)
        {
            gPrincipal.Children.Remove(ContenuEcran);
            ContenuEcran = Scr2;
            Grid.SetRow(ContenuEcran, 1);
            Grid.SetColumn(ContenuEcran, 0);
            gPrincipal.Children.Add(ContenuEcran);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (ContenuEcran != ScrHome)
            {
                gPrincipal.Children.Remove(ContenuEcran);
                ContenuEcran = ScrHome;
                Grid.SetRow(ContenuEcran, 1);
                Grid.SetColumn(ContenuEcran, 0);
                gPrincipal.Children.Add(ContenuEcran);
            }
            else
            {
                MessageBoxResult quitter = MessageBox.Show("Voulez-vous vraiment quitter ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (quitter == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Au revoir", "", MessageBoxButton.OK);
                    Close();
                }
            }
        }
    }
}
