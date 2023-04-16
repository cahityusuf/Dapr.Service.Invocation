using Basket.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.AddBasketApi();

var app = builder.Build();

app.UseBasketApi();

app.Run();
