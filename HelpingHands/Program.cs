using System.Net.Http;
using HelpingHands.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelpingHands.Data;
using Microsoft.AspNetCore.Identity;
using HelpingHands;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HelpingHandsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HelpingHandsContext") ?? throw new InvalidOperationException("Connection string 'HelpingHandsContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

var app = builder.Build();



// ADD FAKE DATA DO DATABASE WITH FAKER.DATA:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Seed.Initialize(services);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
