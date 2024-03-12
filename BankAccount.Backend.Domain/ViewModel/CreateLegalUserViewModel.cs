using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class CreateLegalUserViewModel
    {
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string СhiefFullname { get; set; }
        public string AccountantFullname { get; set; }
        public FormOfOwnership FormOfOwnership { get; set; }
        public int ClientID { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(OrganizationName)) 
            {  
                throw new ArgumentNullException(OrganizationName, "Укажите название организации");
            }
            if (string.IsNullOrWhiteSpace(Address))
            {
                throw new ArgumentNullException(Address, "Укажите адрес");
            }
            if (string.IsNullOrWhiteSpace(СhiefFullname))
            {
                throw new ArgumentNullException(СhiefFullname, "Укажите полное имя руководителя");
            }
            if (string.IsNullOrWhiteSpace(AccountantFullname))
            {
                throw new ArgumentNullException(AccountantFullname, "Укажите полное имя бухгалтера");
            }

        }

    }
}
