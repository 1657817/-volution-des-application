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

namespace Exemple
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txbHorloge.Background = Brushes.BlueViolet;
            txbHorloge.Foreground = Brushes.Gold;
            txbHorloge.Text = DateTime.Now.ToString();

            LinearGradientBrush monPinceau = new LinearGradientBrush();
            monPinceau.GradientStops.Add(new GradientStop(Colors.CadetBlue, 0));
            monPinceau.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
            monPinceau.GradientStops.Add(new GradientStop(Colors.Plum, 1));

            splPrevisions.Background = monPinceau;

            // Liaison de deux contrôle de l'UI
            /*Binding liaison = new Binding("Text");
            liaison.Source = txtValue;
            lblValue.SetBinding(Label.ContentProperty, liaison);*/

            Binding liaison = new Binding("Text")
            {
                Source = txtValue,
            };
            lblValue.SetBinding(Label.ContentProperty, liaison);

            // liaison du bouton btnAccept et du textbox txtTextBtn
            Binding lien = new Binding("Content")
            {
                Source = btnAccept,
            };
            txtTextBtn.SetBinding(TextBox.TextProperty, lien);


        }
    }
}
