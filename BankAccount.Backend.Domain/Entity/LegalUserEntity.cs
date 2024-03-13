using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Backend.Domain.Entity
{
    public class LegalUserEntity
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string OrganizationName { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(120)]
        public string СhiefFullname { get; set; }
        [StringLength(120)]
        public string AccountantFullname { get; set; }
        public FormOfOwnership FormOfOwnership { get; set; }
        public int ClientID {  get; set; }
        public ClientEntity? Client { get; set; }
    }
}
