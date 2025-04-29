using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using InventoryManagmentSystem.Features.ProductManagement.AddProduct;
using InventoryManagmentSystem.Shared.Data;
using InventoryManagmentSystem.Shared.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ApplecationDBContext>(
    option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetionString"));
    }
);
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<ITransactionRecord, TransactionRecord>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();