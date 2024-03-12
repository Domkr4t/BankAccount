using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public Guid TransactionCode { get; set; }
        public float Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int AccountID { get; set; }
        public ListAccountEntity? Account { get; set; }
    }
}
