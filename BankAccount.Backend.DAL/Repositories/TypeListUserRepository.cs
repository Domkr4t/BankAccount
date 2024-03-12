using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class TypeListUserRepository : IBaseRepository<TypeListUserEntity>
    {
        private readonly AppDbContext _appDbContext;

        public TypeListUserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(TypeListUserEntity entity)
        {
            await _appDbContext.TypeListUsers.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(TypeListUserEntity entity)
        {
            _appDbContext.TypeListUsers.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<TypeListUserEntity> GetAll()
        {
            return _appDbContext.TypeListUsers;
        }

        public async Task<TypeListUserEntity> Update(TypeListUserEntity entity)
        {
            _appDbContext.TypeListUsers.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(TypeListUserEntity entity)
        {
            _appDbContext.TypeListUsers.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
