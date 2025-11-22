using Essencia.Backend.Data;
using Essencia.Backend.Repositories;
using Essencia.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Essencia.Backend.DTOs; 
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("CadenaConexionEssencia");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IProductoFloristeriaRepository, ProductoFloristeriaRepository>();
builder.Services.AddScoped<ProductoFloristeriaService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();