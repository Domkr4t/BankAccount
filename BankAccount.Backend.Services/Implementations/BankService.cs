using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Domain.Enum;
using BankAccount.Backend.Domain.Extentions;
using BankAccount.Backend.Domain.Response;
using BankAccount.Backend.Domain.ViewModel;
using BankAccount.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Backend.Services.Implementations
{
    public class BankService : IBankService
    {
        private readonly IBaseRepository<LegalUserEntity> _legalUserRepository;
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        private readonly IBaseRepository<ClientEntity> _clientRepository;
        private readonly IBaseRepository<PhisycalUserEntity> _phisycalUserRepository;

        public BankService(IBaseRepository<LegalUserEntity> legalUserRepository, IBaseRepository<AccountEntity> accountRepository, IBaseRepository<ClientEntity> clientRepository, IBaseRepository<PhisycalUserEntity> phisycalUserRepository)
        {
            _legalUserRepository = legalUserRepository;
            _accountRepository = accountRepository;
            _clientRepository = clientRepository;
            _phisycalUserRepository = phisycalUserRepository;
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

                long unixTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                account = new AccountEntity
                {
                    AccountNumber = model.AccountNumber,
                    CreatedAt = unixTime,
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

        public async Task<IBankResponse<CreatePhisycalUserViewModel>> CreatePhisycalUser(CreatePhisycalUserViewModel model)
        {
            try
            {
                var phisycalUser = await _phisycalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Number == model.Number);

                var phisycalUserFullname = string.Join(" ",
                        new List<string>()
                        {
                        model.Lastname,
                        model.Name,
                        model.Middlename
                        }
                    );

                if (phisycalUser != null)
                {
                    return new BankResponse<CreatePhisycalUserViewModel>
                    {
                        Description = $"Физическое лицо {phisycalUserFullname} уже существует",
                        StatusCode = StatusCode.PhisycalClientAlreadyExists
                    };
                }

                var client = new ClientEntity
                {
                    Type = ClientType.Phisycal
                };

                await _clientRepository.Create(client);

                phisycalUser = new PhisycalUserEntity
                {
                    Lastname = model.Lastname, 
                    Name = model.Name,
                    Middlename = model.Middlename,
                    Birthday = model.Birthday.Date,
                    Address = model.Address,
                    Number = model.Number,
                    Email = model.Email,
                    Gender = model.Gender,
                    Photo = model.Photo,
                    IsStuff = model.IsStuff,
                    IsDebtor = false,
                    ClientID = client.Id,
                    Client = client,
                };

                await _phisycalUserRepository.Create(phisycalUser);

                return new BankResponse<CreatePhisycalUserViewModel>
                {
                    Description = $"Физическое лицо {phisycalUserFullname} создано",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<CreatePhisycalUserViewModel>
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
                var legalClient = await _legalUserRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                var client = await _clientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (client == null || legalClient == null)
                {
                    return new BankResponse<LegalUserViewModel>
                    {
                        Description = $"Юридического лица с ID {id} не существует.",
                        StatusCode = StatusCode.LegalClientNotFound,
                    };
                }

                await _legalUserRepository.Delete(legalClient);
                await _clientRepository.Delete(client);

                return new BankResponse<LegalUserViewModel>
                {
                    Description = $"Юридическое лицо с ID {id} удалено.",
                    StatusCode = StatusCode.Ok,
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

        public async Task<IBankResponse<PhisycalUserViewModel>> DeletePhisycalUser(int id)
        {
            try
            {
                var phisycalUser = await _phisycalUserRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                var client = await _clientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (client == null || phisycalUser == null)
                {
                    return new BankResponse<PhisycalUserViewModel>
                    {
                        Description = $"Физического лица с ID {id} не существует.",
                        StatusCode = StatusCode.PhisycalClientNotFound,
                    };
                }

                await _phisycalUserRepository.Delete(phisycalUser);
                await _clientRepository.Delete(client);

                return new BankResponse<PhisycalUserViewModel>
                {
                    Description = $"Физическое лицо с ID {id} удалено.",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<PhisycalUserViewModel>
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
                    ClientID = x.ClientID
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

        public async Task<IBankResponse<IEnumerable<PhisycalUserViewModel>>> GetAllPhisycalUsers()
        {
            try
            {
                var phisycalUsers = await _phisycalUserRepository.GetAll().Select(x => new PhisycalUserViewModel
                {
                    Id = x.Id,
                    Lastname = x.Lastname,
                    Name = x.Name,
                    Middlename = x.Middlename,
                    Birthday = x.Birthday.ToString("dd/MM/yyyy"),
                    Address = x.Address,
                    Number = x.Number,
                    Email = x.Email,
                    Gender = x.Gender.GetDisplayName(),
                    Photo = x.Photo,
                    IsStuff = x.IsStuff,
                    IsDebtor = x.IsDebtor,
                    ClientID = x.ClientID,
                }).ToListAsync();

                return new BankResponse<IEnumerable<PhisycalUserViewModel>>
                {
                    Data = phisycalUsers,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<IEnumerable<PhisycalUserViewModel>>
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

        public async Task<IBankResponse<UpdatePhisycalUserViewModel>> PatchPhisycalUser(UpdatePhisycalUserViewModel model)
        {
            try
            {
                var phisycalUser = await _phisycalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (phisycalUser == null)
                {
                    return new BankResponse<UpdatePhisycalUserViewModel>
                    {
                        Description = $"Физическое лицо с ID {model.Id} не существует",
                        StatusCode = StatusCode.PhisycalClientNotFound
                    };
                }

                phisycalUser.Lastname = phisycalUser.Lastname == null ? phisycalUser.Lastname : model.Lastname;
                phisycalUser.Name = phisycalUser.Name == null ? phisycalUser.Name : model.Name;
                phisycalUser.Middlename = phisycalUser.Middlename == null ? phisycalUser.Middlename : model.Middlename;
                phisycalUser.Birthday = phisycalUser.Birthday == null ? phisycalUser.Birthday.Date : model.Birthday.Value.Date;
                phisycalUser.Address = phisycalUser.Address == null ? phisycalUser.Address : model.Address;
                phisycalUser.Number = phisycalUser.Number == null ? phisycalUser.Number : model.Number;
                phisycalUser.Email = phisycalUser.Email == null ? phisycalUser.Email : model.Email;
                phisycalUser.Gender = phisycalUser.Gender == null ? phisycalUser.Gender : model.Gender.Value;
                phisycalUser.Photo = phisycalUser.Photo == null ? phisycalUser.Photo : model.Photo;
                phisycalUser.IsStuff = phisycalUser.IsStuff == null ? phisycalUser.IsStuff : model.IsStuff.Value;
                phisycalUser.IsDebtor = phisycalUser.IsDebtor == null ? phisycalUser.IsDebtor : model.IsDebtor.Value;
                phisycalUser.ClientID = phisycalUser.ClientID == null ? phisycalUser.ClientID : model.ClientID.Value;

                await _phisycalUserRepository.Update(phisycalUser);

                return new BankResponse<UpdatePhisycalUserViewModel>
                {
                    Description = $"Физическое лицо с ID {model.Id} изменено",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<UpdatePhisycalUserViewModel>
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

        public async Task<IBankResponse<UpdatePhisycalUserViewModel>> UpdatePhisycalUser(UpdatePhisycalUserViewModel model)
        {
            try
            {
                var phisycalUser = await _phisycalUserRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);

                if (phisycalUser == null)
                {
                    return new BankResponse<UpdatePhisycalUserViewModel>
                    {
                        Description = $"Физическое лицо с ID {model.Id} не существует",
                        StatusCode = StatusCode.PhisycalClientNotFound
                    };
                }

                phisycalUser.Lastname = model.Lastname;
                phisycalUser.Name = model.Name;
                phisycalUser.Middlename = model.Middlename;
                phisycalUser.Birthday = model.Birthday.Value.Date;
                phisycalUser.Address = model.Address;
                phisycalUser.Number = model.Number;
                phisycalUser.Email = model.Email;
                phisycalUser.Gender = model.Gender.Value;
                phisycalUser.Photo = model.Photo;
                phisycalUser.IsStuff = model.IsStuff.Value;
                phisycalUser.IsDebtor = model.IsDebtor.Value;
                phisycalUser.ClientID = model.ClientID.Value;

                await _phisycalUserRepository.Update(phisycalUser);

                return new BankResponse<UpdatePhisycalUserViewModel>
                {
                    Description = $"Физическое лицо с ID {model.Id} изменено",
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BankResponse<UpdatePhisycalUserViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBankResponse<ClientViewModel>> GetOneClient(int id)
        {
            try
            {
                var client = await _clientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (client == null)
                {
                    return new BankResponse<ClientViewModel>
                    {
                        Description = $"Клиента с Id = {id} не существует",
                        StatusCode = StatusCode.ClientNotFound,
                    };
                }

                if (client.Type == ClientType.Phisycal)
                {
                    var phisycalClient = await _phisycalUserRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                    if (phisycalClient == null)
                    {
                        return new BankResponse<ClientViewModel>
                        {
                            Description = $"Физического лица с Id = {id} не существует",
                            StatusCode = StatusCode.PhisycalClientNotFound,
                        };
                    }

                    var clientFullname = string.Join(" ",
                        new List<string>()
                        {
                        phisycalClient.Lastname.ToLower(),
                        phisycalClient.Name.ToLower(),
                        phisycalClient.Middlename.ToLower()
                        }
                    );

                    var legalUserClient = await _legalUserRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.СhiefFullname.ToLower() == clientFullname);

                    var phisycalClientViewModel = new PhisycalUserViewModel
                    {
                        Id = phisycalClient.Id,
                        Lastname = phisycalClient.Lastname,
                        Name = phisycalClient.Name,
                        Middlename = phisycalClient.Middlename,
                        Birthday = phisycalClient.Birthday.ToString("dd/MM/yyyy"),
                        Address = phisycalClient.Address,
                        Number = phisycalClient.Number,
                        Gender = phisycalClient.Gender.GetDisplayName(),
                        Photo = phisycalClient.Photo,
                        IsStuff = phisycalClient.IsStuff,
                        IsDebtor = phisycalClient.IsDebtor,
                        ClientID = phisycalClient.ClientID,
                    };

                    LegalUserViewModel legalUserViewModel = null;

                    if (legalUserClient != null)
                    {
                        legalUserViewModel = new LegalUserViewModel
                        {
                            Id = legalUserClient.Id,
                            OrganizationName = legalUserClient.OrganizationName,
                            Address = legalUserClient.Address,
                            СhiefFullname = legalUserClient.СhiefFullname,
                            AccountantFullname = legalUserClient.AccountantFullname,
                            FormOfOwnership = legalUserClient.FormOfOwnership,
                            ClientID = legalUserClient.ClientID,
                        };
                    }

                    var clientViewModel = new ClientViewModel()
                    {
                        LegalUser = legalUserViewModel,
                        PhisycalUser = phisycalClientViewModel,
                    };

                    return new BankResponse<ClientViewModel>
                    {
                        Data = clientViewModel,
                        StatusCode = StatusCode.Ok,
                    };
                }
                else
                {
                    var legalUser = await _legalUserRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.Id == id);

                    if (legalUser == null)
                    {
                        return new BankResponse<ClientViewModel>
                        {
                            Description = $"Юридического лица с Id = {id} не существует",
                            StatusCode = StatusCode.LegalClientNotFound,
                        };
                    }

                    var clientFullname = legalUser.СhiefFullname.Split(" ");

                    var phisycalUser = await _phisycalUserRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.Lastname.ToLower() == clientFullname[0].ToLower() && x.Name.ToLower() == clientFullname[1].ToLower() &&
                            x.Middlename.ToLower() == clientFullname[2].ToLower());

                    var legalClientViewModel = new LegalUserViewModel()
                    {
                        Id = legalUser.Id,
                        OrganizationName = legalUser.OrganizationName,
                        Address = legalUser.Address,
                        СhiefFullname = legalUser.СhiefFullname,
                        AccountantFullname = legalUser.AccountantFullname,
                        FormOfOwnership = legalUser.FormOfOwnership,
                        ClientID = legalUser.ClientID,
                    };

                    PhisycalUserViewModel phisycalUserViewModel = null;
                    if (phisycalUser != null)
                    {
                        phisycalUserViewModel = new PhisycalUserViewModel
                        {
                            Id = phisycalUser.Id,
                            Lastname = phisycalUser.Lastname,
                            Name = phisycalUser.Name,
                            Middlename = phisycalUser.Middlename,
                            Birthday = phisycalUser.Birthday.ToString("dd/MM/yyyy"),
                            Address = phisycalUser.Address,
                            Number = phisycalUser.Number,
                            Gender = phisycalUser.Gender.GetDisplayName(),
                            Photo = phisycalUser.Photo,
                            IsStuff = phisycalUser.IsStuff,
                            IsDebtor = phisycalUser.IsDebtor,
                            ClientID = phisycalUser.ClientID,
                        };
                    }

                    var clientViewModel = new ClientViewModel()
                    {
                        LegalUser = legalClientViewModel,
                        PhisycalUser = phisycalUserViewModel,
                    };

                    return new BankResponse<ClientViewModel>
                    {
                        Data = clientViewModel,
                        StatusCode = StatusCode.Ok,
                    };
                }
            }
            catch (Exception exception)
            {
                return new BankResponse<ClientViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
