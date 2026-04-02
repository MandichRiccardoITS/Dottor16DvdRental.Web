using Dottor16DvdRental.Web.Components;
using Dottor16DvdRental.Web.services.ActorsServices;
using Dottor16DvdRental.Web.services.FilmsServices;
using Dottor16DvdRental.Web.services.CategoriesServices;
using Dottor16DvdRental.Web.services.JoinTables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IActorsServices, ActorsServices>();
builder.Services.AddScoped<IFilmsServices, FilmsServices>();
builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();

builder.Services.AddScoped<FilmActor>();
builder.Services.AddScoped<FilmCategory>();

// traduce in automatico da snake_casing a PascalCasing nelle query al db
// in modo che non serve fare snake_casing as PascalCasing
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
