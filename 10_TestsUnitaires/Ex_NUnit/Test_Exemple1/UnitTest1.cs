using NUnit.Framework;
using System.Diagnostics;
using System.IO;
using System;

namespace Test_Exemple1
{
    public class Tests
    {
        private const string ChaineAttendue = "Exemple de l'utilisation de NUnit";
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine("Méthode setup");
        }

        [Test]
        public void Test1()
        {
            var sw = new StringWriter(); // Using system.io

            Console.SetOut(sw); // using System;
            Exemple1.Program.Main();

            var resultat = sw.ToString().Trim();

            Debug.WriteLine("Résultat : " + resultat);
            Debug.WriteLine("Chaine Attendue : " + ChaineAttendue);

            Assert.AreEqual(ChaineAttendue, resultat);
        }
    }
}