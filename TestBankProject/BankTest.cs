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

        [Test]
        public void EgyenlegFeltolt_NullSzamlaszammal_ArgumentNullExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentNullException>(() => bank.EgyenlegFeltolt(null, 10000));
        }

        [Test]
        public void EgyenlegFeltolt_UresSzamlaszammal_ArgumentExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentException>(() => bank.EgyenlegFeltolt("", 10000));
        }

        [Test]
        public void EgyenlegFeltolt_NemLetezoSzamlaszammal_HibasSzamlaszamExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<HibasSzamlaszamException>(() => bank.EgyenlegFeltolt("4321", 10000));
        }
        [Test]
        public void EgyenlegFeltolt_0Egyenleg_ArgumentExceptiontDob()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            Assert.Throws<ArgumentException>(() => bank.EgyenlegFeltolt("1234", 0));
        }

        [Test]
        public void EgyenlegFeltolt_OsszegFeltoltesEgyszer_EgyenlegMegvaltozik()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            bank.EgyenlegFeltolt("1234", 10000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(10000));
        }

        [Test]
        public void EgyenlegFeltolt_OsszegFeltoltesTobbszor_EgyenlegOsszeadodik()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");

            bank.EgyenlegFeltolt("1234", 10000);
            bank.EgyenlegFeltolt("1234", 20000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(30000));
        }

        [Test]
        public void EgyenlegFeltolt_TobbSzamlaval_JoSzamlaraToltodik()
        {
            bank.UjSzamla("Gipsz Jakab", "1234");
            bank.UjSzamla("Teszt Elek", "4321");
            bank.UjSzamla("Gipsz Jakab", "9876");

            bank.EgyenlegFeltolt("1234", 10000);
            bank.EgyenlegFeltolt("4321", 20000);
            bank.EgyenlegFeltolt("9876", 15000);

            Assert.That(bank.Egyenleg("1234"), Is.EqualTo(10000));
            Assert.That(bank.Egyenleg("4321"), Is.EqualTo(20000));
            Assert.That(bank.Egyenleg("9876"), Is.EqualTo(15000));
        }
    }
}
