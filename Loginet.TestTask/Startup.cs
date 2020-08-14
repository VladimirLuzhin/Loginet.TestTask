using System;
using AutoMapper;
using Loginet.TestTask.Album;
using Loginet.TestTask.Core.HttpClients;
using Loginet.TestTask.Middlewares;
using Loginet.TestTask.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Loginet.TestTask
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
            services.AddControllers()
                .AddXmlDataContractSerializerFormatters()
                .AddNewtonsoftJson();

            services.AddHttpClient<JsonPlaceholderHttpClient>(options =>
            {
                options.BaseAddress = new Uri(Configuration.GetSection("Config")["RemoteRepositoryUrl"]);
                options.Timeout = TimeSpan.FromSeconds(10);
            });

            services.AddAlbumDependencies();
            services.AddUserDependencies();
            
            services.AddAutoMapper((provider, expression) =>
            {
                expression.AddAlbumMapping();
                expression.AddUserMapping();
            }, Array.Empty<Type>());
            
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loginet Test Api");
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}