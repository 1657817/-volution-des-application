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
using System.Collections.ObjectModel;

namespace LabBinding
{
    /// <summary>
    /// Logique d'interaction pour UC_Ecran1.xaml
    /// </summary>
    public partial class UC_Ecran1 : UserControl
    {
        public ObservableCollection<Etudiant> etudiants = new ObservableCollection<Etudiant>();

        public UC_Ecran1()
        {
            InitializeComponent();
        }
    }
}
