using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Products.Infrastructure.Context;

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

builder.Services.AddDbContext<EntityContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
        o => o.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, table) => $"{ schema}_{ table}"));
});


builder.Services.AddMvc();
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
                               .GetService<EntityContext>().Database;

database.EnsureCreated();

database.Migrate();

app.Run();
