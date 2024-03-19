using BankAccount.Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Backend.Domain.Entity
{
    public class LegalUserEntity
    {
        [Comment("Legal entity ID")]
        [Key, ForeignKey("Client")]
        public int Id { get; set; }

        [Comment("Name of the organization of the legal entity")]
        [StringLength(100)]
        public string OrganizationName { get; set; }

        [Comment("Address of the legal entity")]
        [StringLength(200)]
        public string Address { get; set; }

        [Comment("The full name of the organization's leader ")]
        [StringLength(120)]
        public string СhiefFullname { get; set; }

        [Comment("The full name of the organization's accountant")]
        [StringLength(120)]
        public string AccountantFullname { get; set; }

        [Comment("Form of ownership of the organization")]
        public FormOfOwnership FormOfOwnership { get; set; }

        [Comment("Client ID assigned to a legal entity")]
        public virtual ClientEntity Client { get; set; }
    }
}
