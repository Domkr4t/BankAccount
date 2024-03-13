using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;
using BankAccount.Backend.Domain.Response;
using BankAccount.Backend.Domain.ViewModel;
using BankAccount.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Xml.Linq;

namespace BankAccount.Backend.Services.Implementations
{
    public class BankService : IBankService
    {
        private readonly IBaseRepository<LegalUserEntity> _legalUserRepository;
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        private readonly IBaseRepository<ClientEntity> _clientRepository;

        public BankService(IBaseRepository<LegalUserEntity> legalUserRepository, IBaseRepository<AccountEntity> accountRepository, IBaseRepository<ClientEntity> clientRepository)
        {
            _legalUserRepository = legalUserRepository;
            _accountRepository = accountRepository;
            _clientRepository = clientRepository;
        }

        public async Task<IBankResponse<CreateAccountViewModel>> CreateAccount(CreateAccountViewModel model)
        {
            try
            {
                var client = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.ClientID);

                if (client == null)
                {
                    return new BankResponse<CreateAccountViewModel>
                    {
                        Description = $"Клиент c ID {model.ClientID} не существует",
                        StatusCode = StatusCode.ClientNotFound
                    };
                }

                var account = await _accountRepository.GetAll().FirstOrDefaultAsync(x => x.AccountNumber == model.AccountNumber);

                if (account != null)
                {
                    return new BankResponse<CreateAccountViewModel>
                    {
                        Description = $"Счет с номером {model.AccountNumber} существует",
                        StatusCode = StatusCode.AccountAlreadyExists
                    };
                }

                account = new AccountEntity
                {
                    AccountNumber = model.AccountNumber,
                    CreatedAt = DateTime.Now,
                    Balance = model.Balance,
                    AccountType = model.AccountType,
                    CreditLimit = model.CreditLimit,
                    ClientID = model.ClientID,
                    Client = client,
                };

                await _accountRepository.Create(account);

                return new BankResponse<CreateAccountViewModel>
                {
                    Description = $"Счет с номером {account.AccountNumber} создан",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<CreateAccountViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<CreateLegalUserViewModel>> CreateLegalUser(CreateLegalUserViewModel model)
        {
            try
            {
                var legalUser = await _legalUserRepository.GetAll().FirstOrDefaultAsync(x => x.OrganizationName == model.OrganizationName);

                if (legalUser != null)
                {
                    return new BankResponse<CreateLegalUserViewModel>
                    {
                        Description = $"Юридическое лицо с наименованием {model.OrganizationName} уже существует",
                        StatusCode = StatusCode.LegalClientAlreadyExists
                    };
                }

                var client = new ClientEntity
                {
                    Type = ClientType.Legal
                };

                await _clientRepository.Create(client);

                legalUser = new LegalUserEntity
                {
                    OrganizationName = model.OrganizationName,
                    Address = model.Address,
                    СhiefFullname = model.СhiefFullname,
                    AccountantFullname = model.AccountantFullname,
                    FormOfOwnership = model.FormOfOwnership,
                    ClientID = client.Id,
                    Client = client,
                };

                await _legalUserRepository.Create(legalUser);

                return new BankResponse<CreateLegalUserViewModel>
                {
                    Description = $"Юридическое лицо с наименованием {legalUser.OrganizationName} создано",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<CreateLegalUserViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<AccountViewModel>> DeleteAccount(int id)
        {
            try
            {
                var account = await _accountRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (account == null)
                {
                    return new BankResponse<AccountViewModel>
                    {
                        Description = $"Счет с ID {id} не существует",
                        StatusCode = StatusCode.AccountNotFound
                    };
                }

                await _accountRepository.Delete(account);

                return new BankResponse<AccountViewModel>
                {
                    Description = $"Счет с ID {id} удален",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<AccountViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<LegalUserViewModel>> DeleteLegalUser(int id)
        {
            try
            {
                var legalUser = await _legalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (legalUser == null)
                {
                    return new BankResponse<LegalUserViewModel>
                    {
                        Description = $"Юридическое лицо с ID {id} не существует",
                        StatusCode = StatusCode.LegalClientNotFound
                    };
                }

                await _legalUserRepository.Delete(legalUser);

                return new BankResponse<LegalUserViewModel>
                {
                    Description = $"Юридическое лицо с ID {id} удалено",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex) 
            {
                return new BankResponse<LegalUserViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<IEnumerable<AccountViewModel>>> GetAllAccount()
        {
            try
            {
                var accounts = await _accountRepository.GetAll().Select(x => new AccountViewModel
                {
                    Id = x.Id,
                    AccountNumber = x.AccountNumber,
                    CreatedAt = x.CreatedAt,
                    Balance = x.Balance,
                    AccountType = x.AccountType,
                    CreditLimit = x.CreditLimit,
                    ClientID = x.ClientID,
                }).ToListAsync();

                return new BankResponse<IEnumerable<AccountViewModel>>
                {
                    Data = accounts,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<IEnumerable<AccountViewModel>>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<IEnumerable<LegalUserViewModel>>> GetAllLegalUsers()
        {
            try
            {
                var legalUsers = await _legalUserRepository.GetAll().Select(x => new LegalUserViewModel
                {
                    Id = x.Id,
                    OrganizationName = x.OrganizationName,
                    Address = x.Address,
                    СhiefFullname = x.СhiefFullname,
                    AccountantFullname = x.AccountantFullname,
                    FormOfOwnership = x.FormOfOwnership,
                }).ToListAsync();

                return new BankResponse<IEnumerable<LegalUserViewModel>>
                {
                    Data = legalUsers,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<IEnumerable<LegalUserViewModel>>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<UpdateAccountViewModel>> PatchAccount(UpdateAccountViewModel model)
        {
            try
            {
                var account = await _accountRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (account == null)
                {
                    return new BankResponse<UpdateAccountViewModel>
                    {
                        Description = $"Счет с ID {model.Id} не существует",
                        StatusCode = StatusCode.AccountNotFound
                    };
                }

                account.AccountNumber = model.AccountNumber == null ? account.AccountNumber : model.AccountNumber;
                account.Balance = model.Balance == null ? account.Balance : model.Balance.Value;
                account.AccountType = model.AccountType == null ? account.AccountType : model.AccountType.Value;
                account.CreditLimit = model.CreditLimit == null ? account.CreditLimit : model.CreditLimit.Value;

                await _accountRepository.Update(account);

                
                return new BankResponse<UpdateAccountViewModel>
                {
                    Description = $"Счет с ID {model.Id} изменен",
                    StatusCode = StatusCode.Ok
                };
                
            }
            catch (Exception ex)
            {
                return new BankResponse<UpdateAccountViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<UpdateLegalUserViewModel>> PatchLegalUser(UpdateLegalUserViewModel model)
        {
            try
            {
                var legalUser = await _legalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (legalUser == null)
                {
                    return new BankResponse<UpdateLegalUserViewModel>
                    {
                        Description = $"Юридическое лицо с ID {model.Id} не существует",
                        StatusCode = StatusCode.LegalClientNotFound
                    };
                }

                legalUser.OrganizationName = legalUser.OrganizationName == null ? legalUser.OrganizationName : model.OrganizationName;
                legalUser.Address = legalUser.Address == null ? legalUser.Address : model.Address;
                legalUser.СhiefFullname = legalUser.СhiefFullname == null ? legalUser.СhiefFullname : model.СhiefFullname;
                legalUser.AccountantFullname = legalUser.AccountantFullname == null ? legalUser.AccountantFullname : model.AccountantFullname;
                legalUser.FormOfOwnership = legalUser.FormOfOwnership == null ? legalUser.FormOfOwnership : model.FormOfOwnership.Value;

                await _legalUserRepository.Update(legalUser);

                return new BankResponse<UpdateLegalUserViewModel>
                {
                    Description = $"Юридическое лицо с ID {model.Id} изменено",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<UpdateLegalUserViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<UpdateAccountViewModel>> UpdateAccount(UpdateAccountViewModel model)
        {
            try
            {
                var account = await _accountRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (account == null)
                {
                    return new BankResponse<UpdateAccountViewModel>
                    {
                        Description = $"Счет с ID {model.Id} не существует",
                        StatusCode = StatusCode.AccountNotFound
                    };
                }

                account.AccountNumber = model.AccountNumber;
                account.Balance = model.Balance.Value;
                account.AccountType = model.AccountType.Value;
                account.CreditLimit = model.CreditLimit.Value;

                await _accountRepository.Update(account);


                return new BankResponse<UpdateAccountViewModel>
                {
                    Description = $"Счет с ID {model.Id} изменен",
                    StatusCode = StatusCode.Ok
                };

            }
            catch (Exception ex)
            {
                return new BankResponse<UpdateAccountViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<UpdateLegalUserViewModel>> UpdateLegalUser(UpdateLegalUserViewModel model)
        {
            try
            {
                var legalUser = await _legalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (legalUser == null)
                {
                    return new BankResponse<UpdateLegalUserViewModel>
                    {
                        Description = $"Юридическое лицо с ID {model.Id} не существует",
                        StatusCode = StatusCode.LegalClientNotFound
                    };
                }

                legalUser.OrganizationName =  model.OrganizationName;
                legalUser.Address =  model.Address;
                legalUser.СhiefFullname = model.СhiefFullname;
                legalUser.AccountantFullname = model.AccountantFullname;
                legalUser.FormOfOwnership = model.FormOfOwnership.Value;

                await _legalUserRepository.Update(legalUser);

                return new BankResponse<UpdateLegalUserViewModel>
                {
                    Description = $"Юридическое лицо с ID {model.Id} изменено",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<UpdateLegalUserViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
