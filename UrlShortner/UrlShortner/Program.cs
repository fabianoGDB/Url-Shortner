using Microsoft.EntityFrameworkCore;
using NetcodeHub.Packages.Extensions.Clipboard;
using UrlShortner.Components;
using UrlShortner.Data;
using UrlShortner.Repository;
using UrlShortner.Services;
using UrlShortner.UrlHelpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AppDbContext>(option => 
option.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlHelper, UrlHelper>();
builder.Services.AddScoped<IUrlServices, UrlServices>();
builder.Services.AddNetcodeHubClipboardService();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/{shortcode}", async (string shortcode, IUrlServices urlServices) =>
{
    var result = await urlServices.GetOriginalUrlAsync(shortcode);
    return result == string.Empty ? Results.NotFound() : Results.Redirect(result);
});

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
