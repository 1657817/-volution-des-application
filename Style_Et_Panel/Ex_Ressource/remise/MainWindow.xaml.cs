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
using System.Diagnostics;

namespace Ex_Ressource
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbLignes.Items.Add(StackPanelPrincipal.FindResource("strApp1").ToString());
            lbLignes.Items.Add(StackPanelPrincipal.FindResource("strWin2").ToString());
            lbLignes.Items.Add(StackPanelPrincipal.FindResource("strWin3").ToString());

        }

        private void MenuItemQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe");
        }

        private void MenuItemDessiner_Click(object sender, RoutedEventArgs e)
        {
            Toile tb = new Toile();
            tb.Show();
        }

        private void MenuItemCanvas_Click(object sender, RoutedEventArgs e)
        {
            Panneau pn = new Panneau();
        }

        private void MenuItemDockPanel_Click(object sender, RoutedEventArgs e)
        {
            Quai quai = new Quai();
            quai.Show();
        }
    }
}
