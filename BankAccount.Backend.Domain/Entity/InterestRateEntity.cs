using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class InterestRateEntity
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Rate { get; set; }
    }
}
