using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
