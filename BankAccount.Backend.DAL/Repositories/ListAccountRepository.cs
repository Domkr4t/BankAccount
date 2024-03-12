using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class ListAccountRepository : IBaseRepository<ListAccountEntity>
    {
        private readonly AppDbContext _appDbContext;

        public ListAccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(ListAccountEntity entity)
        {
            await _appDbContext.ListAccounts.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(ListAccountEntity entity)
        {
            _appDbContext.ListAccounts.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<ListAccountEntity> GetAll()
        {
            return _appDbContext.ListAccounts;
        }

        public async Task<ListAccountEntity> Update(ListAccountEntity entity)
        {
            _appDbContext.ListAccounts.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(ListAccountEntity entity)
        {
            _appDbContext.ListAccounts.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
