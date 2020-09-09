using System;
using System.Threading.Tasks;

namespace QualValorCrypto.Infra.UnitOfWorks
{
    public interface IMongoDbContext
    {
        Task<int> SaveChanges();
        void Dispose();
        Task AddCommand(Func<Task> func);
    }
}