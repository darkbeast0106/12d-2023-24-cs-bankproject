using BankProject;

namespace TestBankProject
{
    internal class BankTest
    {
        Bank bank;

        // Setup - minden teszteset előtt lefut egyszer | TearDown - minden teszteset után
        [SetUp]
        public void Setup()
        {
            bank = new Bank();
        }

        [Test]
        public void UjSzamla_ErvenyesAdatokkal_Egyenlege0()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");
            Assert.That(bank.Egyenleg("1234"), Is.Zero);
        }

        [Test]
        public void UjSzamla_NullNevvel_ArgumentNullExceptiontDob()
        {
            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla(null, "4321"));
        }

        [Test]
        public void UjSzamla_NullSzamlaszammal_ArgumentNullExceptiontDob()
        {
            Assert.Throws<ArgumentNullException>(() => bank.UjSzamla("Teszt Elek", null));

        }

        [Test]
        public void UjSzamla_UresNevvel_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => bank.UjSzamla("", "4321"));
        }

        [Test]
        public void UjSzamla_UresSzamlaszammal_ArgumentExceptiontDob()
        {
            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", ""));

        }

        [Test]
        public void UjSzamla_LetezoSzamlaszammal_ArgumentExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");
            Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", "1234"));

        }

        [Test]
        public void UjSzamla_LetezoNevvel_NemDobKivetelt()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");
            Assert.DoesNotThrow(() => bank.UjSzamla("Gipsz Jakab", "4321"));

        }
    }
}
