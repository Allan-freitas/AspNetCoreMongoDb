using Angular.Aplicacao.Interfaces;
using Angular.Aplicacao.Interfaces.Usuarios;
using Angular.Aplicacao.Mappings;
using Angular.Aplicacao.Servicos;
using Angular.Aplicacao.Servicos.Usuarios;
using Angular.Dominio.Interfaces.Repositorios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using Angular.Dominio.MongoDefinicoes;
using Angular.Ingra.Data.Repositorio;
using Angular.Ingra.Data.Repositorio.Usuarios;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Angular.Infra.IoC
{
    public static class InjetorDependencias
    {
        public static void Registrar(this IServiceCollection svcCollection, IConfiguration configuration)
        {
            svcCollection.AddAutoMapper(cfg => cfg.AddProfile<AplicacaoMapping>(), AppDomain.CurrentDomain.GetAssemblies());
            svcCollection.Configure<MongoDbDefinicoes>(configuration.GetSection("MongoDbSettings"));
            svcCollection.AddSingleton<IMongoDbDefinicoes>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbDefinicoes>>().Value);            

            svcCollection.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            svcCollection.AddTransient<IRepositorioUsuario, RepositorioUsuario>();            

            svcCollection.AddTransient(typeof(IServicoBase<>), typeof(ServicoBase<>));
            svcCollection.AddScoped(typeof(IAplicacaoBase<,>), typeof(AplicacaoBase<,>));
            svcCollection.AddTransient<IAplicacaoUsuario, AplicacaoUsuario>();            
            svcCollection.AddTransient<IServicoUsuario, ServicoUsuario>();            
        }
    }
}
