using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Enum
{
    public enum Gender
    {
        [Display (Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1
    }
}
