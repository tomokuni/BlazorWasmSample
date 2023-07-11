using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Toolbelt.Blazor.Extensions.DependencyInjection;
using MudBlazor.Services;
using Radzen;

using BlazorApp;


namespace BlazorApp;
public class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    // 👇 and add this line to register a "PWA updater" service to a DI container.
    builder.Services.AddPWAUpdater();

    // MudBlazor
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
    builder.Services.AddMudServices();

    // Radzeb
		builder.Services.AddScoped<DialogService>();
		builder.Services.AddScoped<NotificationService>();
		builder.Services.AddScoped<TooltipService>();
		builder.Services.AddScoped<ContextMenuService>();

    await builder.Build().RunAsync();
  }
}
