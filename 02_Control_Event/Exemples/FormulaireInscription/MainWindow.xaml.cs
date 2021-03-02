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

namespace FormulaireInscription
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

        private void TxtNom_Focus(object sender, RoutedEventArgs e)
        {
            txtNom.Focus();
        }

        private void txtPrenom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text == String.Empty)
            {
                MessageBox.Show("Veuillez saisir un nom", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNom.Focus();
            }
        }

        private void txtCourriel_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtCourriel.Text = String.Empty;
            txtCourriel.Foreground = Brushes.Blue;
        }

        private void txtCourriel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!validerAdresseCourriel(txtCourriel.Text))
            {
                MessageBox.Show("L'adrese courriel doit respecter le format \"a@a.a\"", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCourriel.Text = "exemple@email.com";
                txtCourriel.Focus();
            }
        }

        private bool validerAdresseCourriel(string adresse)
        {
            // Validation de l'adresse courriel si elle respecte le format a@a.a
            string[] pg = adresse.Split('@');

            if (pg.Length == 1 || pg[0] == "" || pg[1] == "")
            {
                return false;
            }

            string[] pd = pg[1].Split('.');

            if (pd.Length != 2 || pd[0] == "" || pd[1] == "")
            {
                return false;
            }

            return true;
        }

        private void btnCopier_Click(object sender, RoutedEventArgs e)
        {
            if (lsbInit.SelectedItems.Count < 2 || lsbInit.SelectedItems.Count > 4)
            {
                MessageBox.Show("Le nombre d'élément sélectionné doit être entre 2 et 4", "ERREUR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                foreach (object o in lsbInit.SelectedItems)
                {
                    lsbFin.Items.Add(o.ToString().Split(':')[1].TrimStart());
                }
            }
        }

        private void btnVider_Click(object sender, RoutedEventArgs e)
        {
            lsbFin.Items.Clear();
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder res = new StringBuilder();

            res.Append("Prénom et nom : " + txtPrenom.Text + " " + txtNom.Text).AppendLine();
            res.Append("Date de naissance : " + cld1.SelectedDate).AppendLine();
            res.Append("Email : " + txtCourriel.Text).AppendLine();
            if (cboRegion.SelectedIndex != -1) res.Append("Région : " + cboRegion.SelectedItem.ToString().Split(':')[1].TrimStart()).AppendLine();

            res.Append("Statut professionel : ");
            if (chk1.IsChecked == true) res.Append(chk1.Content + " ");
            if (chk2.IsChecked == true) res.Append(chk2.Content + " ");
            if (chk3.IsChecked == true) res.Append(chk3.Content + " ");
            res.AppendLine();

            res.Append("État matrimonial : ");
            if (rdb1.IsChecked == true) res.Append(rdb1.Content + " ");
            if (rdb2.IsChecked == true) res.Append(rdb2.Content + " ");
            if (rdb3.IsChecked == true) res.Append(rdb3.Content + " ");
            res.AppendLine();

            foreach (object o in lsbFin.SelectedItems)
            {
                res.Append(o.ToString().Split(':')[1].TrimStart()).AppendLine();
            }

            MessageBox.Show(res.ToString(), "Validation des données", MessageBoxButton.OK);
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            txtPrenom.Text = String.Empty;
            txtNom.Text = String.Empty;

            cboRegion.SelectedIndex = -1;
            txtCourriel.Text = "exemple@email.com";
            chk1.IsChecked = false;
            chk2.IsChecked = false;
            chk3.IsChecked = false;

            rdb1.IsChecked = false;
            rdb2.IsChecked = false;
            rdb3.IsChecked = false;

            lsbFin.Items.Clear();
            lsbInit.SelectedItems.Clear();
        }
    }
}
