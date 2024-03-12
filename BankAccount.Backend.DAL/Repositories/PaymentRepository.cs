using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.Domain.Entity;

namespace BankAccount.Backend.DAL.Repositories
{
    public class PaymentRepository : IBaseRepository<PaymentEntity>
    {
        private readonly AppDbContext _appDbContext;

        public PaymentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(PaymentEntity entity)
        {
            await _appDbContext.Payments.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(PaymentEntity entity)
        {
            _appDbContext.Payments.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<PaymentEntity> GetAll()
        {
            return _appDbContext.Payments;
        }

        public async Task<PaymentEntity> Update(PaymentEntity entity)
        {
            _appDbContext.Payments.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Attach(PaymentEntity entity)
        {
            _appDbContext.Payments.Attach(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
