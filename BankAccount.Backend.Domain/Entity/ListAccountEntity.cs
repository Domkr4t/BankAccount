namespace BankAccount.Backend.Domain.Entity
{
    public class ListAccountEntity
    {
        public int Id { get; set; }
        public List<AccountEntity> Account { get; set;}
        public List<TypeListUserEntity> TypeListUser { get; set;}
    }
}
