using AutoMapper;
using Categories.API.Services;
using Categories.API.Services.Interfaces;
using Infrastructure.Abstractions.Repositories;
using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Products.API.Services;
using Products.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<ProductContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        o => o.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, table) => $"{ schema}_{ table}"));
});

builder.Services.AddMvc();

builder.Services.AddScoped<IProductApiService, ProductApiService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryApiService, CategoryApiService>();

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

var database = builder.Services.BuildServiceProvider()
                               .GetService<ProductContext>().Database;

database.Migrate();

app.Run();
