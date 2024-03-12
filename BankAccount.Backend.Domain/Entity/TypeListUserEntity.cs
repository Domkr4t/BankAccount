using BankAccount.Backend.Domain.Enum;

namespace BankAccount.Backend.Domain.Entity
{
    public class TypeListUserEntity
    {
        public int Id { get; set; }
        public TypeUser TypeUser { get; set; }
        public List<ClientEntity> User { get; set; }
    }
}
