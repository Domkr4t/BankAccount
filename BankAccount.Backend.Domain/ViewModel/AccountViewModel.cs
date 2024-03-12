using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class AccountViewModel
    {
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Balance { get; set; }
        public int AccountTypeID { get; set; }
    }
}
