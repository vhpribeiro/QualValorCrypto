using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualValorCrypto.Infra.Repositorios;

namespace QualValorCrypto.Infra.Mensageria.RabbitMq
{
    public class ClienteRabbitMqFactory
    {
        public static IConfiguration Configuration { get; set; }
        
        public static ClienteRabbitMq Criar()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IControleDeCryptoMoeda, ControleDeCryptoMoeda>()
                .AddScoped<ICryptoMoedaRepositorio, CryptoMoedaRepositorio>()
                .AddScoped(_ => Configuration)
                .BuildServiceProvider();
            
            return new ClienteRabbitMq(serviceProvider.GetService<IControleDeCryptoMoeda>());
        }
    }
}