using System.Threading.Tasks;

namespace QualValorCrypto.Infra.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoDbContext _mongoDbContext;

        public UnitOfWork(IMongoDbContext mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
        }
        
        public void Dispose()
        {
            _mongoDbContext.Dispose();
        }

        public async Task<bool> Commit()
        {
            var changeAmount = await _mongoDbContext.SaveChanges();

            return changeAmount > 0;
        }

        public void Rollback()
        {
            //
        }
    }
}