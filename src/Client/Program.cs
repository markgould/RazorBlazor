using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Client.Infrastructure;

namespace WebApplication1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<IJsInterop, JsInterop>();
            builder.Services.AddSingleton<IBrowserCookieService, BrowserCookieService>();

            builder.Services.AddTransient<CSRFTokenMessageHandler>();
            builder.Services.AddHttpClient("Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<CSRFTokenMessageHandler>();
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Server"));

            await builder.Build().RunAsync();
        }
    }
}
