using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class UpdateLegalUserViewModel
    {
        public int Id { get; set; }
        public string? OrganizationName { get; set; }
        public string? Address { get; set; }
        public string? СhiefFullname { get; set; }
        public string? AccountantFullname { get; set; }
        public FormOfOwnership? FormOfOwnership { get; set; }
    }
}
