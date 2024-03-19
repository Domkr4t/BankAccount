using BankAccount.Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Entity
{
    public class PaymentEntity
    {
        [Comment("Transaction ID")]
        public int Id { get; set; }

        [Comment("Transaction code")]
        public Guid TransactionCode { get; set; }

        [Comment("Full name of the accountant who performed the transaction")]
        [StringLength(120)]
        public string AccountantFullName {  get; set; }

        [Comment("Transaction amount")]
        public decimal Amount { get; set; }

        [Comment("Payment Status")]
        public PaymentStatus PaymentStatus { get; set; }

        [Comment("ID of the account for which the transaction was performed")]
        public int AccountID { get; set; }
    }
}
