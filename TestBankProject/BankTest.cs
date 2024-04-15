using BankProject;

namespace TestBankProject
{
    internal class BankTest
    {
        [Test]
        public void UjSzamla_LetrehozottSzamlaEgyenlege0()
        {
            Bank bank = new Bank();
            bank.UjSzamla("Gipsz Jakab", "1234");
            Assert.That(bank.Egyenleg("1234"), Is.Zero);
        }
    }
}
