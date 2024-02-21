using Microsoft.EntityFrameworkCore;
using Dominio.Interfaces;
using R2D2.Components;
using R2D2.Services;
using R2D2.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddScoped<ITareasRepository, TareasRepository>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});

builder.Services.AddDbContext<Contexto>(options =>
    options.UseNpgsql(ConnectionHelper.GetConnectionString(builder.Configuration)));

var portVar = Environment.GetEnvironmentVariable("PORT");

if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(port);
    });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(R2D2.Client._Imports).Assembly);

app.Run();
