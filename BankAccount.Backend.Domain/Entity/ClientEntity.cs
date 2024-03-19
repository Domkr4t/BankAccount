using BankAccount.Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Backend.Domain.Entity
{
    public class ClientEntity
    {
        [Comment("ID Client")]
        public int Id { get; set; }

        [Comment("Client Type")]
        public ClientType Type { get; set; }
    }
}
