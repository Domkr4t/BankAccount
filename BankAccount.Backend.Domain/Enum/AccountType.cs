using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Enum
{
    public enum AccountType
    {
        [Display(Name = "Дебитный")]
        Debit = 0,
        [Display(Name = "Кредитный")]
        Сredit = 1,
        [Display(Name = "Сберегательный")]
        Saving = 2
    }
}
