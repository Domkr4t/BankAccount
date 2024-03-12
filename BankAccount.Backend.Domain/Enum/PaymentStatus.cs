using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Enum
{
    public enum PaymentStatus
    {
        [Display (Name = "Создан")]
        Created = 0,
        [Display(Name = "Отправлен")]
        Sent = 1,
        [Display(Name = "Принят")]
        Accepted = 2,
        [Display(Name = "Проведен")]
        CarriedOut = 3,
        [Display(Name = "Отвергнут")]
        Rejected = 4,
        [Display(Name = "Обработка приостановлена")]
        ProcessingSuspended = 5,
        [Display(Name = "Недостаточно средств на счет")]
        InsufficientFundsInTheAccount = 6,
    }
}
