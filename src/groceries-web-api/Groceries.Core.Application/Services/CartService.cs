using AutoMapper;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.ServiceModels;
using Groceries.Core.Domain.Entities;
using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Repositories.CommandRepositories;

namespace Groceries.Core.Application.Services
{
    public interface ICartService 
    {
        Task<CartResponse> CreateCartAsync(CreateCartRequestDTO createCartRequestDTO);
        Task<CartResponse?> GetCartAsync(Guid cartId);
        Task<IEnumerable<CartResponse>> GetAllCartsAsync();
        Task<DeleteCartResponse> DeleteCartAsync(Guid id);
        Task<CartResponse?> UpdateCartAsync(UpdateCartRequestDTO updateCartRequestDTO);
    }

    public class CartService : ICartService
    {
        private readonly ICartCommandRepository _cartCommandRepository;
        private readonly IQueryRepository<Groceries.Data.DataModels.Cart> _cartQueryRepository;
        private readonly ILogger<CartService> _logger;
        private readonly IMapper _mapper;

        public CartService(
            ICartCommandRepository cartCommandRepository,
            IQueryRepository<Groceries.Data.DataModels.Cart> cartQueryRepository,
            ILogger<CartService> logger,
            IMapper mapper)
        {
            _cartCommandRepository = cartCommandRepository;
            _cartQueryRepository = cartQueryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CartResponse> CreateCartAsync(CreateCartRequestDTO createCartRequestDTO)
        {
            var createdAt = DateTime.UtcNow;
            var cartItems = createCartRequestDTO.GroceryItems.Select(groceryItem => new GroceryItem(
                groceryItem.Name,
                groceryItem.Description,
                groceryItem.Category,
                groceryItem.Price,
                groceryItem.ImageUrl,
                createdAt,
                createdAt)).ToList();

            var cart = new Cart(
                createCartRequestDTO.Name,
                createCartRequestDTO.Description,
                new Reminder(),
                cartItems,
                createdAt,
                createdAt);

            var createdCart = await _cartCommandRepository.CreateCartAsync(cart);

            _logger.LogInformation("Cart with id: {cartId}  and name {cartName} created successfully", cart.Id, cart.Name);
            return _mapper.Map<CartResponse>(createdCart);
        }

        public async Task<CartResponse?> GetCartAsync(Guid cartId)
        {
            var cart = await _cartQueryRepository.GetByIdAsync(cartId);
            return cart == null ? null : _mapper.Map<CartResponse>(cart);
        }

        public async Task<IEnumerable<CartResponse>> GetAllCartsAsync()
        {
            var carts = await _cartQueryRepository.GetAllAsync();
            return carts == null || !carts.Any() ? [] : carts.Select(_mapper.Map<CartResponse>);
        }

        public async Task<CartResponse?> UpdateCartAsync(UpdateCartRequestDTO updateCartRequestDTO){
            var cartToUpdate = await _cartQueryRepository.GetByIdAsync(updateCartRequestDTO.Id);
            if (cartToUpdate == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", updateCartRequestDTO.Id);
                return null;
            }

            var updatedAt = DateTime.UtcNow;
            var cartItems = updateCartRequestDTO.GroceryItems.Select(groceryItem => new GroceryItem(
                groceryItem.Name,
                groceryItem.Description,
                groceryItem.Category,
                groceryItem.Price,
                groceryItem.ImageUrl,
                groceryItem.CreatedAt,
                updatedAt)).ToList();

            var cartToUpdateEntity = new Cart(
                updateCartRequestDTO.Id,
                updateCartRequestDTO.Name,
                updateCartRequestDTO.Description,
                new Reminder(), //no Reminder logic atm
                cartItems,
                cartToUpdate.CreatedAt,
                updatedAt);

            var updatedCart = await _cartCommandRepository.UpdateCartAsync(cartToUpdateEntity);
            return _mapper.Map<CartResponse>(updatedCart);
        }

        public async Task<DeleteCartResponse> DeleteCartAsync(Guid id)
        {
            var cartToDelete = await _cartQueryRepository.GetByIdAsync(id);
            if (cartToDelete == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
                return new DeleteCartResponse(isDeleted: false, isCartFound: false);
            }

            await _cartQueryRepository.DeleteByIdAsync(cartToDelete);
            return new DeleteCartResponse(isDeleted: true, isCartFound: true);
        }
    }
}
