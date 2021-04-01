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
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int NumeroCoup { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty((sender as Button).Content.ToString()))
            {
                if (NumeroCoup % 2 == 0)
                {
                    (sender as Button).Content = "O";
                    bool g = verifierGagner("O");
                    if (g)
                    {
                        MessageBox.Show("Yes le joueur O à gagné", "Félicitations", MessageBoxButton.OK);
                        this.Close();
                    }
                    tb1.Text = "Joueur X";
                    NumeroCoup++;
                } else
                {
                    (sender as Button).Content = "X";
                    (sender as Button).Foreground = Brushes.Red;
                    bool g = verifierGagner("X");
                    if (g)
                    {
                        MessageBox.Show("Yes le joueur X à gagné", "Félicitations", MessageBoxButton.OK);
                        this.Close();
                    }
                    tb1.Text = "Joueur O";
                    NumeroCoup++;
                }

                if (NumeroCoup == 9 && verifierGagner("O") == false && verifierGagner("X") == false)
                {
                    MessageBox.Show("Égalité!");
                    this.Close();
                }
            }
        }

        private bool verifierGagner(string joueur)
        {
            bool gagner = true;

            // Vérifier les lignes horizontales
            if (btn1.Content == btn2.Content && btn2.Content == btn3.Content && btn3.Content.ToString() == joueur ||
                btn4.Content == btn5.Content && btn5.Content == btn6.Content && btn6.Content.ToString() == joueur ||
                btn7.Content == btn8.Content && btn8.Content == btn9.Content && btn9.Content.ToString() == joueur)
            {
                return gagner;
            }
            
            // Vérifier les lignes verticales
            else
            if (btn1.Content == btn4.Content && btn4.Content == btn7.Content && btn7.Content.ToString() == joueur ||
                btn2.Content == btn5.Content && btn5.Content == btn8.Content && btn8.Content.ToString() == joueur ||
                btn3.Content == btn6.Content && btn6.Content == btn9.Content && btn9.Content.ToString() == joueur)
            {
                return gagner;
            }
            
            // Vérifier la diagonale principale
            else
            if (btn1.Content == btn5.Content && btn5.Content == btn9.Content && btn9.Content.ToString() == joueur)
            {
                return gagner;
            }
            // Vérifier la diagonale secondaire
            else
            if (btn7.Content == btn5.Content && btn5.Content == btn3.Content && btn7.Content.ToString() == joueur)
            {
                return gagner;
            }

            switch (true)
            {
                case ((btn1.Content == btn2.Content) && (btn2.Content == btn3.Content) && (btn3.Content.ToString() == joueur)):
                    break;
            }

            return false;
        }
    }
}
