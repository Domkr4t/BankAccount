using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class LegalUserEntity
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string Address { get; set; }
        public string СhiefFullname { get; set; }
        public string AccountantFullname { get; set; }
        public FormOfOwnership FormOfOwnership { get; set; }
        public int ClientID {  get; set; }
        public ClientEntity? Client { get; set; }
    }
}
