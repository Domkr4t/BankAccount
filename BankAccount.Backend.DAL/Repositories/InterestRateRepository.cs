using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;


namespace BankAccount.Backend.DAL.Repositories
{
    public class InterestRateRepository : IBaseRepository<InterestRateEntity>
    {
        private readonly AppDbContext _appDbContext;

        public InterestRateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(InterestRateEntity entity)
        {
            await _appDbContext.InterestRates.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(InterestRateEntity entity)
        {
            _appDbContext.InterestRates.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<InterestRateEntity> GetAll()
        {
            return _appDbContext.InterestRates;
        }

        public async Task<InterestRateEntity> Update(InterestRateEntity entity)
        {
            _appDbContext.InterestRates.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(InterestRateEntity entity)
        {
            _appDbContext.InterestRates.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
