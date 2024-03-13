using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class PhisycalUserEntity
    {
        public int Id {  get; set; }
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
        public bool IsDebtor { get; set; }
        public int ClientID { get; set; }
        public ClientEntity? Client { get; set; }
    }
}
