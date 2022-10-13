using ClientApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUrl = builder.Configuration.GetSection("BaseUrl").Value;
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

await builder.Build().RunAsync();
