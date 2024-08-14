using AutoMapper;
using Groceries.Core.Application.Filters;
using Groceries.Core.Application.Models;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.DTOs.Response;
using Groceries.Core.Application.Services;

namespace Groceries.Core.Application.ApiReoutes
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
                //Add validation
                //Code too optimistic think about failure scenarios
                var cartResponse = await cartService.CreateCartAsync(request);
                var cartResponseDTO = mapper.Map<CreateCartResponseDTO>(cartResponse);
                return Results.Created($"/api/cart/{cartResponseDTO.CartId}", new ApiResponse<CreateCartResponseDTO>(cartResponseDTO));
            })
            .AddEndpointFilter<CreateCartValidationFilter>()
            .WithName("CreateCart")
            .WithOpenApi();

            app.MapPut("/api/cart/{cartId}", async (Guid cartId, UpdateCartRequestDTO updateCartDTO, ICartService cartService) => {

                return await Task.FromResult(Results.Ok());
            })
            .AddEndpointFilter<UpdateCartValidationFilter>()
            .WithName("UpdateCart")
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

            return app;
        }
    }
}
