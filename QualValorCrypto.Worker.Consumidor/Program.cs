using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QualValorCrypto.Infra.Mensageria.RabbitMq;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Infra.Repositorios;

namespace QualValorCrypto.Worker.Consumidor
{
    class Program
    {
        public static IConfigurationRoot Configuration;
        
        static void Main(string[] args)
        {
            Console.WriteLine("******* Recebendo mensagens **********");

            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            Configuration = builder.Build();
            
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IControleDeCryptoMoeda, ControleDeCryptoMoeda>()
                .AddScoped<ICryptoMoedaRepositorio, CryptoMoedaRepositorio>()
                .AddScoped<IConfiguration>()
                .BuildServiceProvider();

            var consumidorRabbitMq = new ClienteRabbitMq(serviceProvider.GetService<IControleDeCryptoMoeda>());
            consumidorRabbitMq.Consumir();

            Console.ReadKey();
        }
    }
}