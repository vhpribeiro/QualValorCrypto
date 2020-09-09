using System;
using System.Threading.Tasks;

namespace QualValorCrypto.Infra.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        void Rollback();
    }
}