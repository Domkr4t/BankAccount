
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Enum
{
    public enum FormOfOwnership
    {
        [Display (Name = "Государственная")]
        Public = 0,
        [Display(Name = "Частная")]
        Private = 1,
        [Display(Name = "Иностранное предприятие")]
        ForeignEnterprise = 2,
        [Display(Name = "Смешанная")]
        Mixed = 3,
    }
}
