using Essencia.Backend.Repositories;
using Essencia.Backend.Services;
using Essencia.Backend.Dtos;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Repositorios
builder.Services.AddScoped<IProductosFloristeriaRepository, ProductosFloristeriaRepository>();
builder.Services.AddScoped<IIngredientesCafeteriaRepository, IngredientesCafeteriaRepository>();
builder.Services.AddScoped<IProductosCafeteriaRepository, ProductosCafeteriaRepository>();
builder.Services.AddScoped<IAlergenosCafeteriaRepository, AlergenosCafeteriaRepository>();
builder.Services.AddScoped<IMesasRepository, MesasRepository>();
builder.Services.AddScoped<IPedidosRepository, PedidosRepository>();
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();


// Servicios
builder.Services.AddScoped<IProductosFloristeriaService, ProductosFloristeriaService>();
builder.Services.AddScoped<IIngredientesCafeteriaService, IngredientesCafeteriaService>();
builder.Services.AddScoped<IProductosCafeteriaService, ProductosCafeteriaService>();
builder.Services.AddScoped<IAlergenosCafeteriaService, AlergenosCafeteriaService>();
builder.Services.AddScoped<IMesasService, MesasService>();
builder.Services.AddScoped<IPedidosService, PedidosService>();
builder.Services.AddScoped<IDetallePedidoService, DetallePedidoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
