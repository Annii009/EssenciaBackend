using Essencia.Backend.Repositories;
using Essencia.Backend.Services;
using Essencia.Backend.Dtos; 
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("CadenaConexionEssencia");
builder.Services.AddScoped<IProductosFloristeriaRepository, ProductosFloristeriaRepository>();
builder.Services.AddScoped<ProductosFloristeriaService>();
builder.Services.AddScoped<IIngredientesCafeteriaRepository, IngredientesCafeteriaRepository>();
builder.Services.AddScoped<IngredientesCafeteriaService>();

builder.Services.AddScoped<IProductosCafeteriaRepository, ProductosCafeteriaRepository>();
builder.Services.AddScoped<ProductosCafeteriaService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

