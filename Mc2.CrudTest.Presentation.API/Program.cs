using Mc2.CrudTest.Application;
using Mc2.CrudTest.Infrastructure;
using Mc2.CrudTest.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddMediatR(typeof(SaveCustomerCommand));

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurInfrastractureServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RKsample API", Version = "v1" });
    c.EnableAnnotations();
});

//var config = new AutoMapper.MapperConfiguration(cfg =>
//{
//    cfg.AddProfile(new AutoMapperConfig());
//});
//var mapper = config.CreateMapper();
//builder.Services.AddSingleton(mapper);

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
