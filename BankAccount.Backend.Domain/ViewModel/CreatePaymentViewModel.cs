using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class CreatePaymentViewModel
    {
        public float Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int AccountID { get; set; }
    }
}
