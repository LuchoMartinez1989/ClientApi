using Application;
using Persistense;
using Shared;
using WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Rerencia a metodo de aplication
builder.Services.AddApplicationLayer(builder.Configuration);

// envio de configuracion del Api
builder.Services.AddPersistenseInfraestructure(builder.Configuration);

//Agrega el proyecto Shared
builder.Services.AddSharedInfraestructure(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//configure personalized errors
app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
