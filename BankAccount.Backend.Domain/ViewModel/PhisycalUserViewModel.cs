﻿using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class PhisycalUserViewModel
    {
        [Display(Name = "Фамилия")]
        public string Lastname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        public string Number { get; set; }
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
        [Display(Name = "Фотография")]
        public string Photo { get; set; }
        [Display(Name = "Является ли сотрудником банка")]
        public bool IsStuff { get; set; }
    }
}