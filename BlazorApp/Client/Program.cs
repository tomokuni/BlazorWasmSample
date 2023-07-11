using BlazorApp;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor.Services;

using Radzen;

namespace BlazorApp;
public class Program
{
  public static async Task Main(string[] args)
  {
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

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
