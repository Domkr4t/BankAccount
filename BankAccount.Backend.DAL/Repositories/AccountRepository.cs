using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class AccountRepository : IBaseRepository<AccountEntity>
    {
        private readonly AppDbContext _appDbContext;

        public AccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(AccountEntity entity)
        {
            await _appDbContext.Accounts.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(AccountEntity entity)
        {
            _appDbContext.Accounts.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<AccountEntity> GetAll()
        {
            return _appDbContext.Accounts;
        }

        public async Task<AccountEntity> Update(AccountEntity entity)
        {
            _appDbContext.Accounts.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(AccountEntity entity)
        {
            _appDbContext.Accounts.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
