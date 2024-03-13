using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Enum
{
    public enum ClientType
    {
        [Display (Name = "Юридическое лицо")]
        Legal = 0,
        [Display(Name = "Физическое лицо")]
        Phisycal = 1,
    }
}
