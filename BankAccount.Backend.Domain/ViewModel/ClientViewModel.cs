using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.Domain.ViewModel
{
    public class ClientViewModel
    {
        public List<LegalUserEntity>? LegalUsers { get; set; }
        public PhisycalUserViewModel? PhisycalUser { get; set;}
    }
}
