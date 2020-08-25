using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;

namespace QualValorCrypto.TesteDeIntegracao.Base
{
    public class SetupParaTesteDeIntegracao<TStartup> : IDisposable where TStartup : class 
    {
        private const string NomeDoAmbiente = "Integracao";

        private readonly WebApplicationFactory<TStartup> _servidor;

        public WebApplicationFactory<TStartup> WebApplicationFactory => _servidor ?? ConfigureWebApplicationFactory();

        public SetupParaTesteDeIntegracao()
        {
            _servidor = ConfigureWebApplicationFactory();
        }
        public void Dispose()
        {
            _servidor.Dispose();
        }

        private static WebApplicationFactory<TStartup> ConfigureWebApplicationFactory()
        {
            return new WebApplicationFactory<TStartup>().WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment(NomeDoAmbiente);
                builder.ConfigureServices(services => services.AddScoped<ICryptoMoedaRepositorio, MockRepositorioTeste>());
            });
        }
    }
}