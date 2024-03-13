using BankAccount.Backend.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Backend.Domain.Entity
{
    public class PhisycalUserEntity
    {
        public int Id {  get; set; }

        [StringLength(40)]
        public string Lastname { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Middlename { get; set; }
        [Column (TypeName = "BIGINT")]
        public long Birthday { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string? Photo { get; set; }
        public bool IsStuff { get; set; }
        public bool IsDebtor { get; set; }
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }
    }
}
