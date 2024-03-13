using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Backend.Domain.Entity
{
    public class AccountEntity
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string AccountNumber { get; set; }
        [Column(TypeName = "BIGINT")]
        public long CreatedAt { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }
        public virtual List<PaymentEntity> Payments { get; set; }
    }
}
