using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public Guid TransactionCode { get; set; }
        [StringLength(120)]
        public string AccountantFullName {  get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int AccountID { get; set; }
    }
}
