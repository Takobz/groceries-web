using Groceries.Core.Application.ApiReoutes;
using Groceries.Core.Application.Extensions;
using Groceries.Core.Application.Services;
using Groceries.Infrastructure.Extensions;
using Groceries.Infrastructure.Repositories.DbContexts;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresOptions = new PostgresOptions()
{
    Database = Environment.GetEnvironmentVariable("PGDB") ?? throw new InvalidOperationException("Database Name Needed"),
    Username = Environment.GetEnvironmentVariable("PGUSER") ?? throw new InvalidOperationException("Database User Needed"),
    Password = Environment.GetEnvironmentVariable("PGPASSWORD") ?? throw new InvalidOperationException("Database Password Needed"),
    Host = Environment.GetEnvironmentVariable("PGHOST") ?? throw new InvalidOperationException("Database Host Needed"),
    Port = Environment.GetEnvironmentVariable("PGPORT") ?? "5432"
};

builder.Services.AddPostgresDbContext(postgresOptions);
builder.Services.AddRepositories();

builder.Services.AddRepositoryModelMapping();
builder.Services.AddApplicationModelMappings();

builder.Services.AddTransient<ICartService, CartService>();

builder.Services.AddDatabaseMigrations();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//API Routes
app.MapCartRoutes();

app.Run();
