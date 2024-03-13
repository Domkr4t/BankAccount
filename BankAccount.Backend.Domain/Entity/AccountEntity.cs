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
        public int? CreditLimit { get; set; }
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }
        public virtual List<PaymentEntity> Payments { get; set; }
    }
}
