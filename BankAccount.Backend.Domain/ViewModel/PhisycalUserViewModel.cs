using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class PhisycalUserViewModel
    {
        [Display(Name = "ID физ. лица")]
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }
        [Display(Name = "Дата рождения")]
        public string Birthday { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string Number { get; set; }
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Фотография")]
        public string Photo { get; set; }
        [Display(Name = "Является ли сотрудником банка")]
        public bool IsStuff { get; set; }
        [Display(Name = "Является ли должником")]
        public bool IsDebtor { get; set; }
    }
}
