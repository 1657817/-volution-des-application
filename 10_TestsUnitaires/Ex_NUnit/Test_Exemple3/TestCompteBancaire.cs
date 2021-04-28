using NUnit.Framework;
using Exemple3;

namespace Test_Exemple3
{
    [TestFixture]
    public class TestCompteBancaire
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Debit_MontantValide_MAJSolde()
        {
            double soldeDebut = 11.99;
            double montantDebit = 4.55;
            double soldeAttendu = 7.44;

            CompteBancaire compte = new CompteBancaire("Mr. Bryan Walton", soldeDebut);
            compte.Debit(montantDebit);

            double soldeActuel = compte.Solde;

            Assert.AreEqual(soldeAttendu, soldeActuel, "Compte non débité correctement");
        }

        /*[Test]
        public void Debit_MontantNegatif_LeverException()
        {
            double soldeDebut = 11.99;
            double montantDebit = -100;
            CompteBancaire compte = new CompteBancaire("Mr. Bryan Walton", soldeDebut);
            Assert.Throws<System.ArgumentOutOfRangeException>(()=> compte.Debit(montantDebit));
        }*/

        [Test]
        public void Debit_MontantPlusGrandOuNegatif_LeverException()
        {
            double soldeDebut = 11.99;
            double montantDebit = -4;
            CompteBancaire compte = new CompteBancaire("Mr. Bryan Walton", soldeDebut);
            try
            {
                compte.Debit(montantDebit);
            } catch(System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(CompteBancaire.MsgMontantDebitNegatif, e.Message);
            }
            //Assert.Throws<System.ArgumentOutOfRangeException>(() => compte.Debit(montantDebit));
        }
    }
}