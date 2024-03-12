using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;


namespace BankAccount.Backend.Domain.ViewModel
{
    public class PaymentViewModel
    {
        [Display (Name = "Код платежа")]
        public Guid TransactionCode { get; set; }
        [Display(Name = "Сумма платежа")]
        public float Amount { get; set; }
        [Display(Name = "Статус платежа")]
        public PaymentStatus PaymentStatus { get; set; }
        [Display(Name = "Плательщик")]
        public int AccountID { get; set; }
    }
}
