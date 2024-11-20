using AutoMapper;
using Groceries.Core.Application.Filters;
using Groceries.Core.Application.Models;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.DTOs.Response;
using Groceries.Core.Application.Services;

namespace Groceries.Core.Application.ApiRoutes
{
    public static class CartItemsRoutes
    {
       public static WebApplication MapCartItemsRoutes(this WebApplication app)
       {
            app.MapPatch("/api/cart/{cartId}/items", async (Guid cartId, AddItemsToCartRequestDTO addItemsDTO, ICartService cartService, IMapper mapper) => 
            {
                var addItemsResponse = await cartService.AddItemsToCartAsync(cartId, addItemsDTO);
                if (addItemsResponse == null)
                {
                    return Results.NotFound();
                }

                var updatedCart = mapper.Map<CartResponseDTO>(addItemsResponse);
                return await Task.FromResult(Results.Ok(new ApiResponse<CartResponseDTO>(updatedCart)));
            })
            .AddEndpointFilter<AddItemsToCartValidationFilter>()
            .WithName("AddItemsToCart")
            .WithOpenApi();

            app.MapDelete("/api/cart/{cartId}/items/{cartItemId}", async (Guid cartId, Guid cartItemId, ICartService cartService, IMapper mapper) => 
            {
                var removeItemResponse = await cartService.RemoveItemFromCartAsync(cartId, cartItemId);
                if (!removeItemResponse.IsCartFound)
                {
                    return Results.NotFound();
                }

                if (!removeItemResponse.IsCartItemDeleted || !removeItemResponse.IsCartItemFound)
                {
                    return Results.BadRequest();
                }

                return Results.NoContent();
            })
            .AddEndpointFilter<RemoveItemFromCartValidationFilter>()
            .WithName("RemoveItemFromCart")
            .WithOpenApi();

            return app;
       }
    }
}