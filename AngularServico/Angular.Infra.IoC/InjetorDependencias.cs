using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Authorities;
using Angular.Aplicacao.Interfaces.Usuarios;
using Angular.Aplicacao.Mappings;
using Angular.Aplicacao.Servicos;
using Angular.Aplicacao.Servicos.Authorities;
using Angular.Aplicacao.Servicos.Usuarios;
using Angular.Aplicacao.Validators.Usuarios;
using Angular.Dominio.Interfaces.Repositorios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using Angular.Dominio.MongoDefinicoes;
using Angular.Ingra.Data.Repositorio;
using Angular.Ingra.Data.Repositorio.Usuarios;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            svcCollection.AddControllers().AddFluentValidation();
            svcCollection.AddTransient<IValidator<UserForRegisterDTO>, UserForRegisterDTOValidator>();

            svcCollection.AddAutoMapper(cfg => cfg.AddProfile<AplicacaoMapping>(), AppDomain.CurrentDomain.GetAssemblies());
            svcCollection.Configure<MongoDbDefinicoes>(configuration.GetSection("MongoDbSettings"));
            svcCollection.AddSingleton<IMongoDbDefinicoes>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbDefinicoes>>().Value);            

            svcCollection.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            svcCollection.AddTransient<IRepositorioUsuario, RepositorioUsuario>();              

            svcCollection.AddTransient(typeof(IServicoBase<>), typeof(ServicoBase<>));            
            svcCollection.AddTransient<IAplicacaoUsuario, AplicacaoUsuario>();            
            svcCollection.AddTransient<IAplicacaoAuthorities, AplicacaoAuthorities>();                   
            svcCollection.AddTransient<IServicoUsuario, ServicoUsuario>();       
            svcCollection.AddTransient<IServicoAuthorities, ServicoAuthorities>();       
        }
    }
}
