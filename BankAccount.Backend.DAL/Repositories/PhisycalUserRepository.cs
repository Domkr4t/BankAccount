using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class PhisycalUserRepository : IBaseRepository<PhisycalUserEntity>
    {
        private readonly AppDbContext _appDbContext;

        public PhisycalUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(PhisycalUserEntity entity)
        {
            await _appDbContext.PhisycalUsers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(PhisycalUserEntity entity)
        {
            _appDbContext.PhisycalUsers.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<PhisycalUserEntity> GetAll()
        {
            return _appDbContext.PhisycalUsers;
        }

        public async Task<PhisycalUserEntity> Update(PhisycalUserEntity entity)
        {
            _appDbContext.PhisycalUsers.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(PhisycalUserEntity entity)
        {
            _appDbContext.PhisycalUsers.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
