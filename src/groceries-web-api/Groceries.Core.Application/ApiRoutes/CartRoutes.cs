using AutoMapper;
using Groceries.Core.Application.Filters;
using Groceries.Core.Application.Models;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.DTOs.Response;
using Groceries.Core.Application.Services;

namespace Groceries.Core.Application.ApiRoutes
{
    public static class CartRoutes
    {
        public static WebApplication MapCartRoutes(this WebApplication app)
        {
            app.MapGet("/api/cart/{cartId}", async (Guid cartId, ICartService cartService, IMapper mapper) => 
            {
                var cartResponse = await cartService.GetCartAsync(cartId);
                if (cartResponse == null)
                {
                    return Results.NotFound();
                }
                
                var cartResponseDTO = mapper.Map<CartResponseDTO>(cartResponse);
                return Results.Ok(new ApiResponse<CartResponseDTO>(cartResponseDTO));
            })
            .AddEndpointFilter<ReadCartValidationFilter>()
            .WithName("GetCart")
            .WithOpenApi();

            app.MapGet("/api/cart/all", async (ICartService cartService, IMapper mapper) => 
            {
                var cartResponses = await cartService.GetAllCartsAsync();
                var cartResponseDTOs = cartResponses.Select(cartResponse => mapper.Map<CartResponseDTO>(cartResponse));
                return Results.Ok(new ApiResponseCollection<CartResponseDTO>(cartResponseDTOs));
            })
            .WithName("GetAllCarts")
            .WithOpenApi();

            app.MapPost("/api/cart", async (CreateCartRequestDTO request, ICartService cartService, IMapper mapper) => 
            {
                var cartResponse = await cartService.CreateCartAsync(request);
                var cartResponseDTO = mapper.Map<CreateCartResponseDTO>(cartResponse);
                return Results.Created($"/api/cart/{cartResponseDTO.CartId}", new ApiResponse<CreateCartResponseDTO>(cartResponseDTO));
            })
            .AddEndpointFilter<CreateCartValidationFilter>()
            .WithName("CreateCart")
            .WithOpenApi();

            //Think about what you want Update to do.
            app.MapPut("/api/cart/{cartId}", async (Guid cartId, UpdateCartRequestDTO updateCartDTO, ICartService cartService, IMapper mapper) => 
            {
                var updateResponse = await cartService.UpdateCartAsync(cartId, updateCartDTO);
                var updatedCart = mapper.Map<CartResponseDTO>(updateResponse);
                return await Task.FromResult(Results.Ok(new ApiResponse<CartResponseDTO>(updatedCart)));
            })
            .AddEndpointFilter<UpdateCartValidationFilter>()
            .WithName("UpdateCart")
            .WithOpenApi();

            app.MapPut("/api/cart/{cartId}/details", async (Guid cartId, UpdateCartDetailsRequestDTO updateCartDetailsDTO, ICartService cartService, IMapper mapper) => 
            {
                var updateResponse = await cartService.UpdateCartDetailsAsync(cartId, updateCartDetailsDTO);
                if (updateResponse == null)
                {
                    return Results.NotFound();
                }

                var updatedCart = mapper.Map<CartResponseDTO>(updateResponse);
                return await Task.FromResult(Results.Ok(new ApiResponse<CartResponseDTO>(updatedCart)));
            })
            .AddEndpointFilter<UpdateCartDetailsValidationFilter>()
            .WithName("UpdateCartDetails")
            .WithOpenApi();

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

            app.MapDelete("/api/cart/{cartId}", async (Guid cartId, ICartService cartService) => {
                var deleteResponse = await cartService.DeleteCartAsync(cartId);
                if (deleteResponse.IsDeleted) 
                {
                    return Results.NoContent();
                }
                else if (!deleteResponse.IsCartFound)
                {
                    return Results.NotFound();
                }

                return Results.BadRequest();
            })
            .AddEndpointFilter<DeleteCartValidationFilter>()
            .WithName("DeleteCart")
            .WithOpenApi();

            app.MapPost("/api/cart/{cartId}/copy", async (Guid cartId, ICartService cartService, IMapper mapper) => 
            {
                var copyResponse = await cartService.CopyCartAsync(cartId);
                if (copyResponse == null)
                {
                    return Results.NotFound();
                }

                var copiedCart = mapper.Map<CartResponseDTO>(copyResponse);
                return await Task.FromResult(Results.Created($"/api/cart/{copiedCart.CartId}", new ApiResponse<CartResponseDTO>(copiedCart)));
            })
            .AddEndpointFilter<CopyCartValidationFilter>()
            .WithName("CopyCart")
            .WithOpenApi();

            return app;
        }
    }
}
