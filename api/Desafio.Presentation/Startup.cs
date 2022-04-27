using Desafio.Application.IoC;
using Desafio.Application.Mappings;
using Desafio.InfraStructure.Context;
using Desafio.Presentation.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using AuthConfiguration = Desafio.Presentation.Configuration;

namespace Desafio.Presentation
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
            DependencyResolver.Register(services);

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
                loggingBuilder.AddDebug();
            });

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))
                    .EnableSensitiveDataLogging(true), ServiceLifetime.Transient);

            services.AddAutoMapper(Assembly.GetAssembly(typeof(EntityToModelMap)));

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Api para desafio Toro Investimentos", Version = "v1" });
            });

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("ApiPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });


            services.AddTransient<TokenService>();

            var key = Encoding.ASCII.GetBytes(AuthConfiguration.JwtKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio");
                }
            );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("ApiPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}