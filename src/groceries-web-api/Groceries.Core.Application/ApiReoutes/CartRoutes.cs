using Groceries.Core.Application.Models;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.DTOs.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Groceries.Core.Application.ApiReoutes
{
    public static class CartRoutes
    {
        public static WebApplication MapCartRoutes(this WebApplication app)
        {
            app.MapGet("/api/cart/{cartId}", async (Guid cartId, IConfiguration configuration) => await Task.FromResult($"{nameof(configuration)}"))
                .WithName("GetCart")
                .WithOpenApi();

            app.MapPost("/api/cart", async (CreateCartRequestDTO request, IConfiguration configuration) => 
            {
                return Results.Created($"/api/cart/{Guid.NewGuid()}", new ApiResponse<CreateCartResponseDTO>(new CreateCartResponseDTO()));
            })
            .WithName("AddToCart")
            .WithOpenApi();

            return app;
        }
    }
}
