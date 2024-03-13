using BankAccount.Backend.Domain.Response;
using BankAccount.Backend.Domain.ViewModel;

namespace BankAccount.Backend.Services.Interfaces
{
    public interface IBankService
    {
        Task<IBankResponse<CreateLegalUserViewModel>> CreateLegalUser(CreateLegalUserViewModel model);
        Task<IBankResponse<LegalUserViewModel>> DeleteLegalUser(int id);
        Task<IBankResponse<UpdateLegalUserViewModel>> UpdateLegalUser(UpdateLegalUserViewModel model);
        Task<IBankResponse<IEnumerable<LegalUserViewModel>>> GetAllLegalUsers();
        Task<IBankResponse<UpdateLegalUserViewModel>> PatchLegalUser(UpdateLegalUserViewModel model);

        Task<IBankResponse<ClientViewModel>> GetOneClient(int id);

        Task<IBankResponse<CreateAccountViewModel>> CreateAccount(CreateAccountViewModel model);
        Task<IBankResponse<AccountViewModel>> DeleteAccount(int id);
        Task<IBankResponse<UpdateAccountViewModel>> UpdateAccount(UpdateAccountViewModel model);
        Task<IBankResponse<IEnumerable<AccountViewModel>>> GetAllAccount();
        Task<IBankResponse<UpdateAccountViewModel>> PatchAccount(UpdateAccountViewModel model);
    }
}
