using Persistence;
using Application;
using Core.Security;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSecurityServices();

builder.Services.AddApplicationServices();
builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = "localhost:6379");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureCustomExceptionMiddleware();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
