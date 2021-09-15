using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System.Net.Http;
using System.Threading.Tasks;

namespace EnvironmentVariables.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new ProfileApi.ProfileService(builder.Configuration["BackendApi"], new HttpClient()));

            await builder.Build().RunAsync();
        }
    }
}
