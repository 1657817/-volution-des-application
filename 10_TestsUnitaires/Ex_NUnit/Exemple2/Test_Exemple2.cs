using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Exemple2
{
    [TestFixture]
    public class Test_Exemple2
    {
        List<Employe> li;

        [Test]
        public void VerifierDetails()
        {
            Program pObj = new Program();
            li = pObj.LesEmployes();

            foreach (var x in li)
            {
                Assert.IsNotNull(x.Id);
                Assert.IsNotNull(x.Nom);
                Assert.IsNotNull(x.Salaire);
                Assert.IsNotNull(x.Genre);
            }
        }

        [Test]
        public void TesterLogin()
        {
            Program pObj = new Program();
            string x = pObj.Login("Ajit", "1234");
            string y = pObj.Login("", "");
            string z = pObj.Login("Admin", "Admin");

            Assert.AreEqual("L'identifiant ou le mot de passe ne doit pas être vide.", y);
            Assert.AreEqual("Bienvenue Admin.", z);
            Assert.AreEqual("Identifiant ou mot de passe incorrecte.", x);
        }

        [Test]
        public void getDetailsEmployes()
        {
            Program pObj = new Program();
            var p = pObj.GetDetails(100);

            foreach (var x in p)
            {
                Assert.AreEqual(x.Id, 100);
                Assert.AreEqual(x.Nom, "Jacques");
            }
        }
    }
}
