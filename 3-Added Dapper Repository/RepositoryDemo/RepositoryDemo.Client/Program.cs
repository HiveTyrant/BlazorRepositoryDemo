global using System.Net.Http.Json;
global using Newtonsoft.Json;
global using System.Net;
global using System.Linq.Expressions;
global using AvnRepository;
global using RepositoryDemo.Client.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RepositoryDemo.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient 
    { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<CustomerRepository>();


await builder.Build().RunAsync();
