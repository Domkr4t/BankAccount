using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class ClientEntity
    {
        public int Id { get; set; }
        public ClientType Type { get; set; }
    }
}
