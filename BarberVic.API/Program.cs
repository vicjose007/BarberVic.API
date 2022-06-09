using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using BarberVic.API.IoC;
using BarberVic.Application.IoC;
using BarberVic.Domain.IoC;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApiRegistry();
builder.Services.AddAppRegistry(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddModelRegistry();
builder.Services.AddDomainRegistry();

string myAppDbContextConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BarberVicDbContext>(op => op.UseSqlServer(myAppDbContextConnection),
    ServiceLifetime.Transient);

builder.Services.AddControllers(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation();


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
