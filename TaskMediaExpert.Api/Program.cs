using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TaskMediaExpert.Application.Interface;
using TaskMediaExpert.Application.Repository;
using MediatR;
using System.Reflection;
using TaskMediaExpert.Application.CQRS.Product.Command;
using TaskMediaExpert.Domain.Entity;
using TaskMediaExpert.Application.CQRS.Product.Query;
using TaskMediaExpert.Infrastructure.Models;
using TaskMediaExpert.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskMediaExpert", Version = "v1" });
});

builder.Services.AddHttpContextAccessor();


builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>))
    .AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IRequestHandler<AddProductCommand, Product>, AddProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllProductQuery, IEnumerable<ProductModel>>, GetAllProductQueryHandler>();
builder.Services.AddScoped<IRequestHandler<GetPageableProductQuery, PaginationResponse<IEnumerable<ProductModel>>>, GetPageableProductQueryHandler>();

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
