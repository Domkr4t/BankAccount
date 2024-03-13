using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int ClientID { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(AccountNumber))
            {
                throw new ArgumentNullException(AccountNumber, "Укажите номер счета");
            }
        }
    }
}
