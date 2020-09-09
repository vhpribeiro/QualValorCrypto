using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using QualValorCrypto.Aplicacao.CryptoMoedas.Comandos;
using QualValorCrypto.Aplicacao.CryptoMoedas.Consultas;
using QualValorCrypto.Aplicacao.CryptoMoedas.InterfaceRepositorios;
using QualValorCrypto.Infra;
using QualValorCrypto.Infra.Repositorios;
using QualValorCrypto.Infra.UnitOfWorks;

namespace QualValorCrypto.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddScoped<IMongoDbContext, MongoDbContext>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<ICryptoMoedaRepositorio, CryptoMoedaRepositorio>();
            services.TryAddScoped<IConsultaDeCryptoMoeda, ConsultaDeCryptoMoeda>();
            services.TryAddScoped<IControleDeCryptoMoeda, ControleDeCryptoMoeda>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}