using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;


namespace BankAccount.Backend.DAL.Repositories
{
    public class LegalUserRepository : IBaseRepository<LegalUserEntity>
    {
        private readonly AppDbContext _appDbContext;

        public LegalUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(LegalUserEntity entity)
        {
            await _appDbContext.LegalUsers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(LegalUserEntity entity)
        {
            _appDbContext.LegalUsers.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<LegalUserEntity> GetAll()
        {
            return _appDbContext.LegalUsers;
        }

        public async Task<LegalUserEntity> Update(LegalUserEntity entity)
        {
            _appDbContext.LegalUsers.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(LegalUserEntity entity)
        {
            _appDbContext.LegalUsers.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
