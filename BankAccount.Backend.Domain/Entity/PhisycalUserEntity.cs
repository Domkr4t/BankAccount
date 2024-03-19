using BankAccount.Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Backend.Domain.Entity
{
    public class PhisycalUserEntity
    {
        [Comment("Individual ID")]
        public int Id {  get; set; }

        [Comment("Lastname of individual")]
        [StringLength(40)]
        public string Lastname { get; set; }

        [Comment(" Name of individual")]
        [StringLength(40)]
        public string Name { get; set; }

        [Comment("Middlename of individual")]
        [StringLength(40)]
        public string Middlename { get; set; }

        [Comment("Date of birth of the individual")]
        [Column (TypeName = "DATE")]
        public DateTime Birthday { get; set; }

        [Comment("Address of the individual")]
        [StringLength(200)]
        public string? Address { get; set; }

        [Comment("Number of the individual")]
        [StringLength(10)]
        public string Number { get; set; }

        [Comment("Email of the individual")]
        [StringLength(50)]
        public string Email { get; set; }

        [Comment("Gender of the individual")]
        public Gender Gender { get; set; }

        [Comment("Photo of the individual")]
        public string? Photo { get; set; }

        [Comment("The individual is an employee of the bank")]
        public bool IsStuff { get; set; }

        [Comment("Is an individual a debtor")]
        public bool IsDebtor { get; set; }

        [Comment("Client ID that is assigned to an individual")]
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }
    }
}
