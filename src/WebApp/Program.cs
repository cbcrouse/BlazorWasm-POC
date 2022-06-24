using BlazorPro.BlazorSize;
using Core;
using Core.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Main>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<SideBarService>();
builder.Services.AddMediaQueryService();
builder.Services.AddResizeListener();
builder.Services.AddMudServices();
await builder.Build().RunAsync();