using System;
using System.Collections.Generic;
using Foundation.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NetworkEdition.Application.CommandHandlers;
using NetworkEdition.Application.Queries;
using NetworkEdition.Domain.NetworkAggregate;
using NetworkEdition.Infrastructure;
using Network = NetworkEdition.Infrastructure.PersistenceModels.Network;

namespace NetworkEdition.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new OpenApiInfo
                             {
                                 Title = "NetworkEdition.API",
                                 Version = "v1"
                             });
            });

            services.AddCors(opt => opt.AddPolicy("name",
                                                  builder => builder.AllowAnyOrigin()
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod()));

            services
                .AddSingleton<IDictionary<NetworkIdentifier, Network>>(new Dictionary<NetworkIdentifier, Network>());
            services.AddSingleton<INetworkRepository, NetworkRepository>();
            services.AddSingleton<INetworkQueries, NetworkQueries>();
            services.AddSingleton<IRelayQueries, RelayQueries>();
            services.AddSingleton<ICommandDispatcher>(provider =>
            {
                var networkRepository = provider.GetService<INetworkRepository>() ??
                                        throw new NullReferenceException("No network repository is registered.");

                return new CommandDispatcher(new CreateNetworkHandler(networkRepository),
                                             new DeleteNetworkHandler(networkRepository),
                                             new ChangeNameHandler(networkRepository));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetworkEdition.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("name");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}