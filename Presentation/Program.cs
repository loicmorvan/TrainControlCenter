using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped(_ => new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });

            builder.Services
                .AddHttpClient("Backend",
                    client =>
                    {
                        var networkEditionUrl = builder.Configuration["network-edition-url"];
                        if (string.IsNullOrEmpty(networkEditionUrl)) throw new Exception();

                        client.BaseAddress = new Uri(networkEditionUrl);
                    });

            await builder.Build().RunAsync();
        }
    }
}