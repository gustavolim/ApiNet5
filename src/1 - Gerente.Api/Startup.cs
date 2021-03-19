using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gerente.Api.ViewModels;
using Gerente.Dominio.Entidades;
using Gerente.Infra.Contexto;
using Gerente.Infra.Interfaces;
using Gerente.Infra.Repositorio;
using Gerente.Servico.DTO;
using Gerente.Servico.Interfaces;
using Gerente.Servico.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Gerente.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region AutoMapper
            var autoMapConfig = new MapperConfiguration(x =>
                {
                    x.CreateMap<Usuario, UsuarioDTO>().ReverseMap();
                    x.CreateMap<CriarUsuarioViewModel, UsuarioDTO>().ReverseMap();
                });

            services.AddSingleton(autoMapConfig.CreateMapper());
            #endregion

            #region InjecaoDepen
            services.AddSingleton(x=> Configuration);
            services.AddDbContext<GerenteContexto>(x => x.UseSqlServer(Configuration["ConnectionStrings:USER_GERENTE"]), ServiceLifetime.Transient);
            services.AddScoped<IUsuarioServico, UsuarioServico>();
            services.AddScoped<IUserRepositorio, UsuarioRepositorio>();
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gerente.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerente.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
