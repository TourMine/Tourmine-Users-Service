using Microsoft.EntityFrameworkCore;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.UseCases;
using Tourmine.Users.Domain.Interfaces.Repositories;
using Tourmine.Users.Infrastructure;
using Tourmine.Users.Infrastructure.Context;
using Tourmine.Users.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permitir o front-end Angular
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Usecases 
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

// Configure o middleware do CORS antes dos controllers
app.UseCors("AllowAngular");

// Configure o HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
