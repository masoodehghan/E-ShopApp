using Microsoft.AspNetCore.Http.HttpResults;
using ShopApp.Api;
using ShopApp.Application.Services;
using ShopApp.Contracts.Products;
using ShopApp.Infrustructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
            .AddInfrustructure(builder.Configuration)
            .AddPresentaion()
            .AddApplication();
            
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.MapPost("sdf", (ProductDeleteRequest request) => "saodif");

app.Run();
