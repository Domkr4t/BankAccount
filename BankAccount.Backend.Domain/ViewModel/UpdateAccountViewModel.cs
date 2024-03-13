using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class UpdateAccountViewModel
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public decimal? Balance { get; set; }
        public AccountType? AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int? ClientID { get; set; }
    }
}
