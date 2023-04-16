using Dapr.Client;
using Web.HttpAggregator.Abstraction.Services;
using Web.HttpAggregator.Api.Helpers;
using Web.HttpAggregator.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddHttpAggregatorApi();

builder.Services.AddSingleton<IBasketService, BasketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpAggregatorApi();

app.Run();