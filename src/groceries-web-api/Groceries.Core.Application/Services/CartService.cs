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
    }
}
