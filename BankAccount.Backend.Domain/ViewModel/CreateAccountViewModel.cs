using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class CreateAccountViewModel
    {
        public string AccountNumber { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int ClientID { get; set; }
    }
}
