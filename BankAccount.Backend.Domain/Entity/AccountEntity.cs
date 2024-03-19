using BankAccount.Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Backend.Domain.Entity
{
    public class AccountEntity
    {
        [Comment("ID Account")]
        public int Id { get; set; }

        [Comment("Account number")]
        [StringLength(40)]
        public string AccountNumber { get; set; }

        [Comment("Date of account creation")]
        [Column(TypeName = "BIGINT")]
        public long CreatedAt { get; set; }

        [Comment("Account balance")]
        public decimal Balance { get; set; }

        [Comment("Account type")]
        public AccountType AccountType { get; set; }

        [Comment("Credit limit")]
        public int? CreditLimit { get; set; }

        [Comment("Account owner ID")]
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }

        [Comment("Payments on this account")]
        public virtual List<PaymentEntity> Payments { get; set; }
    }
}
