using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class ClientRepository : IBaseRepository<ClientEntity>
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(ClientEntity entity)
        {
            await _appDbContext.Clients.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(ClientEntity entity)
        {
            _appDbContext.Clients.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<ClientEntity> GetAll()
        {
            return _appDbContext.Clients;
        }

        public async Task<ClientEntity> Update(ClientEntity entity)
        {
            _appDbContext.Clients.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(ClientEntity entity)
        {
            _appDbContext.Clients.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
