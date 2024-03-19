using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class LegalUserViewModel
    {
        [Display(Name = "ID юр. лица")]
        public int Id { get; set; }
        [Display (Name = "Название организации")]
        public string OrganizationName { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Полное имя руководителя")]
        public string СhiefFullname { get; set; }
        [Display(Name = "Полное имя бухгалтера")]
        public string AccountantFullname { get; set; }
        [Display(Name = "Форма собственности")]
        public FormOfOwnership FormOfOwnership { get; set; }
    }
}
