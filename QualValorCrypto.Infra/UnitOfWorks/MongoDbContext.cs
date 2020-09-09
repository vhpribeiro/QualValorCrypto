using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualValorCrypto.Infra.UnitOfWorks
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly List<Func<Task>> _comandos;

        public MongoDbContext()
        {
            _comandos = new List<Func<Task>>();
        }

        public async Task<int> SaveChanges()
        {
            foreach (var comando in _comandos)
                await comando();

            _comandos.Clear();
            return _comandos.Count;;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
        public Task AddCommand(Func<Task> func)
        {
            _comandos.Add(func);
            return Task.CompletedTask;
        }
    }
}