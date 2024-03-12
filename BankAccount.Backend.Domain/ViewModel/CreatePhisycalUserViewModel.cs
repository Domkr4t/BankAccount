using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class CreatePhisycalUserViewModel
    {
        public string Lastname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string? Photo { get; set; }
        public bool IsStuff { get; set; }
        public int ClientID { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Lastname))
            {
                throw new ArgumentNullException(Lastname, "Укажите фамилию");
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException(Name, "Укажите имя");
            }

            if (string.IsNullOrWhiteSpace(Middlename))
            {
                throw new ArgumentNullException(Middlename, "Укажите отчество");
            }

            if (string.IsNullOrWhiteSpace(Number))
            {
                throw new ArgumentNullException(Number, "Укажите телефон");
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentNullException(Email, "Укажите e-mail");
            }
        }
    }
}
