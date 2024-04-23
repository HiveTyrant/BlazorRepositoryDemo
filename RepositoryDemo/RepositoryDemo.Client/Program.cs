global using Microsoft.AspNetCore.SignalR.Client;
global using BlazorDB;
global using System.Net.Http.Json;
global using Newtonsoft.Json;
global using System.Net;
global using System.Linq.Expressions;
global using AvnRepository;
global using RepositoryDemo.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RepositoryDemo.Client.Services;
using RepositoryDemo.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{ BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<CustomerRepository>();

builder.Services.AddBlazorDB(options =>
{
    options.Name = "RepositoryDemo";
    options.Version = 1;

    // List all your entities here, but as StoreSchema objects
    options.StoreSchemas = new List<StoreSchema>()
    {
        new StoreSchema()
        {
            Name = "Customer",      // Name of entity
            PrimaryKey = "Id",      // Primary Key of entity
            PrimaryKeyAuto = true,  // Whether or not the Primary key is generated
            Indexes = new List<string> { "Id" }
        },
        new StoreSchema()
        {
            Name = $"Customer{Globals.LocalTransactionsSuffix}",
            PrimaryKey = "Id",
            PrimaryKeyAuto = true,
            Indexes = new List<string> { "Id" }
        },
        new StoreSchema()
        {
            Name = $"Customer{Globals.KeysSuffix}",
            PrimaryKey = "Id",
            PrimaryKeyAuto = true,
            Indexes = new List<string> { "Id" }
        }
    };
});

builder.Services.AddScoped<CustomerIndexedDBRepository>();
builder.Services.AddScoped<CustomerIndexedDBSyncRepository>();

await builder.Build().RunAsync();
