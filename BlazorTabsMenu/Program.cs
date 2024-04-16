using BlazorTabsMenu.Client.Pages;
using BlazorTabsMenu.Components;
using BlazorTabsMenu.Models;
using BlazorTabsMenu.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IDataDictionaryItemService<DataDictionaryItem>, DataDictionaryItemService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ICountryService, CountryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorTabsMenu.Client._Imports).Assembly);

app.Run();
