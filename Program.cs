global using tech_store.Services.CatalogsService;
global using tech_store.Services.ProductsService;
global using tech_store.Dtos;
global using tech_store.Dtos.Books;
global using tech_store.Dtos.Catalogs;
global using tech_store.Dtos.Orders;
global using tech_store.Dtos.Products;
global using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tech_store.DbModels;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICatalogsService, CatalogsService>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<TechStoreContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
});

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

app.MapControllers();

app.Run();
