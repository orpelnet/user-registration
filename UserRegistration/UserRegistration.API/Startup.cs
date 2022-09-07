using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using UsuariosRegistration.API.Usuarios.Infrastructure;
using UsuariosRegistration.API.Usuarios.Domain.Repositories;
using UsuariosRegistration.API.Usuarios.Service;
using UserRegistration.API.Escolaridades.Service;
using UserRegistration.API.Escolaridades.Domain.Repositories;
using UserRegistration.API.Escolaridades.Infrastructure;

namespace UsuariosRegistration.API
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddHttpContextAccessor();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEscolaridadeService, EscolaridadeService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();

            services.AddRouting();

            services.AddCors();

            services.AddControllers();

            services.AddMvc()
                .AddJsonOptions(o => o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}