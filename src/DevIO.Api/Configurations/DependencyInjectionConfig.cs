using DevIO.Data.Repository;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Notifications;
using DevIO.Domain.Services;

namespace DevIO.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Injeção Data

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            #endregion

            #region Injeção Domain

            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<INotificador, Notificador>();

            #endregion

            return services;
        }
    }
}
