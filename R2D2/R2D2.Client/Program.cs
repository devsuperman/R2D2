using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using R2D2.Client.Services;
using Dominio.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ITareasRepository, TareasService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

await builder.Build().RunAsync();
