using Groceries.Core.Application.ApiReoutes;
using Groceries.Core.Application.Extensions;
using Groceries.Core.Application.Services;
using Groceries.Infrastructure.Extensions;
using Groceries.Infrastructure.Repositories.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresOptions = new PostgresOptions();
builder.Configuration.GetSection(PostgresOptions.PostgresOption).Bind(postgresOptions);
builder.Services.AddPostgresDbContext(postgresOptions);
builder.Services.AddRepositories();

builder.Services.AddRepositoryModelMapping();
builder.Services.AddApplicationModelMappings();

builder.Services.AddTransient<ICartService, CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//API Routes
app.MapCartRoutes();

app.Run();
