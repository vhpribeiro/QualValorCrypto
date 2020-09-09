using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace QualValorCrypto.Infra.UnitOfWorks
{
    public class MongoDbContext : IMongoDbContext
    {
        public IClientSessionHandle Session { get; set; }
        private readonly List<Func<Task>> _comandos;
        private readonly MongoClient _mongoClient;

        public MongoDbContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration.GetValue<string>("Database:Url"));
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