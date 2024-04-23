global using Microsoft.AspNetCore.SignalR;
global using System.Reflection;
global using AvnRepository;
global using Microsoft.EntityFrameworkCore;
global using RepositoryDemo.Client.Models;
global using System.Data.SqlClient;
global using Dapper;
global using Dapper.Contrib.Extensions;
global using System.Data;
using RepositoryDemo.Components;
using RepositoryDemo.Data;
using Microsoft.AspNetCore.ResponseCompression;
using RepositoryDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<MemoryRepository<Customer>>(x =>
    new MemoryRepository<Customer>("Id"));

builder.Services.AddTransient<RepositoryDemoContext, RepositoryDemoContext>();
builder.Services.AddTransient<EFRepository<Customer, RepositoryDemoContext>>();

builder.Services.AddTransient<DapperRepository<Customer>>(s =>
    new DapperRepository<Customer>(
        builder.Configuration.GetConnectionString("RepositoryDemoConnectionString")));

builder.Services.AddControllers();

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseResponseCompression();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RepositoryDemo.Client._Imports).Assembly);

app.MapHub<DataSyncHub>("/DataSyncHub");

app.Run();
