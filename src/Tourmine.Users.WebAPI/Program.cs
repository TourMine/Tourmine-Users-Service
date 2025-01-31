using Microsoft.EntityFrameworkCore;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.UseCases;
using Tourmine.Users.Domain.Interfaces.Repositories;
using Tourmine.Users.Infrastructure;
using Tourmine.Users.Infrastructure.Context;
using Tourmine.Users.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os necess�rios para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no swagger
builder.Services.AddSwaggerGen();  // Adiciona o swagger

// Usecase 
builder.Services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
builder.Services.AddScoped<IGetByIdUseCase, GetByUseCase>();

// Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add Mediator DI
builder.Services.AddMediatR(cfg 
    => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Settings.ConnectionString));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(); // Habilita a interface gr�fica do Swagger UI
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
