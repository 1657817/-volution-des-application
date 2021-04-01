using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
// Bibliothèque pour la gestion des données des étudiants
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Ex_LiveCharts.WPF
{
    public class Bilan
    {
        private const string NOM_FICHIER = "BilanActivites.json";

        private string mois;
        private double chiffreAffaire;
        private double tauxMarge;
        private double margeBrute;

        public string Mois
        {
            get
            {
                return mois;
            }
            set
            {
                this.mois = value;
            }
        }
        public double ChiffreAffaire
        {
            get
            {
                return chiffreAffaire;
            }
            set
            {
                this.chiffreAffaire = value;
            }
        }
        public double TauxMarge
        {
            get
            {
                return tauxMarge;
            }
            set
            {
                this.tauxMarge = value;
            }
        }
        public double MargeBrute
        {
            get
            {
                return margeBrute;
            }
            set
            {
                this.margeBrute = value;
            }
        }

        public static void ChargerFichier()
        {
            StreamReader fichierBilan;
            string json;

            fichierBilan = new StreamReader(File.OpenRead(NOM_FICHIER));

            json = fichierBilan.ReadLine();

            fichierBilan.Close(); // On doit fermer le fichier(streamReader) après la lecture

            MainWindow.bilan = JsonConvert.DeserializeObject<ObservableCollection<Bilan>>(json);
        }

    }
}
