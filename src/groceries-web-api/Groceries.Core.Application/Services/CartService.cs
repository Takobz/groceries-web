using AutoMapper;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.ServiceModels;
using Groceries.Core.Domain.Entities;
using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Repositories.CommandRepositories;
using Groceries.Core.Application.Helpers;

namespace Groceries.Core.Application.Services
{
    public interface ICartService 
    {
        Task<CartResponse> CreateCartAsync(CreateCartRequestDTO createCartRequestDTO);
        Task<CartResponse?> GetCartAsync(Guid cartId);
        Task<IEnumerable<CartResponse>> GetAllCartsAsync();
        Task<DeleteCartResponse> DeleteCartAsync(Guid id);
        Task<CartResponse?> UpdateCartAsync(Guid id, UpdateCartRequestDTO updateCartRequestDTO);
        Task<CartResponse?> AddItemsToCartAsync(Guid id, AddItemsToCartRequestDTO addItemsToCartRequestDTO);
        Task<CartResponse?> CopyCartAsync(Guid id);
        Task<CartResponse?> UpdateCartDetailsAsync(Guid id, UpdateCartDetailsRequestDTO updateCartDetailsRequestDTO);
        Task<DeleteCartItemResponse> RemoveItemFromCartAsync(Guid id, Guid itemId);
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

            _logger.LogInformation("Cart with id: {cartId}  and name {cartName} created successfully", createdCart.Id, createdCart.Name);
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

        public async Task<CartResponse?> AddItemsToCartAsync(Guid id, AddItemsToCartRequestDTO addCartItemRequestDTO)
        {
            var cart = await _cartQueryRepository.GetByIdAsync(id);
            if (cart == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
                return null;
            }

            var itemCreatedAt = DateTime.UtcNow;
            var cartItems = addCartItemRequestDTO.GroceryItems.Select(groceryItem => new GroceryItem(
                groceryItem.Name,
                groceryItem.Description,
                groceryItem.Category,
                groceryItem.Price,
                groceryItem.ImageUrl,
                itemCreatedAt,
                itemCreatedAt)).ToList();

            var cartToUpdateEntity = new Cart(
                cart.Id,
                cart.Name,
                cart.Description,
                new Reminder(), //no Reminder logic atm
                cartItems,
                cart.CreatedAt,
                itemCreatedAt); 

            await _cartCommandRepository.UpdateCartAsync(cartToUpdateEntity);
            var patchedCart = await _cartQueryRepository.GetByIdAsync(id);
            return _mapper.Map<CartResponse>(patchedCart);           
        }

        public async Task<CartResponse?> UpdateCartAsync(Guid id, UpdateCartRequestDTO updateCartRequestDTO){
            var cartToUpdate = await _cartQueryRepository.GetByIdAsync(id);
            if (cartToUpdate == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
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

            await _cartCommandRepository.DeleteByIdAsync(cartToDelete);
            return new DeleteCartResponse(isDeleted: true, isCartFound: true);
        }

        public async Task<CartResponse?> CopyCartAsync(Guid id)
        {
            var cartToCopy = await _cartQueryRepository.GetByIdAsync(id);
            if (cartToCopy == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
                return null;
            }

            var createdAt = DateTime.UtcNow;
            var cartItems = cartToCopy.GroceryItems.Select(groceryItem => new GroceryItem(
                groceryItem.Name,
                groceryItem.Description,
                groceryItem.Category,
                groceryItem.Price,
                groceryItem.ImageUrl,
                createdAt,
                createdAt)).ToList();

            var copiedCart = new Cart(
                $"{cartToCopy.Name} - Copy",
                cartToCopy.Description,
                new Reminder(),
                cartItems,
                createdAt,
                createdAt);

            var createdCart = await _cartCommandRepository.CreateCartAsync(copiedCart);
            return _mapper.Map<CartResponse>(createdCart);
        }

        public async Task<CartResponse?> UpdateCartDetailsAsync(Guid id, UpdateCartDetailsRequestDTO updateCartDetailsRequestDTO)
        {
            var cartToUpdate = await _cartQueryRepository.GetByIdAsync(id);
            if (cartToUpdate == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
                return null;
            }

            var cartEntity = new Cart(
                cartToUpdate.Id,
                updateCartDetailsRequestDTO.Name,
                updateCartDetailsRequestDTO.Description,
                new Reminder(),
                cartToUpdate.GroceryItems.Select(x => x.ToGroceryItem()).ToList(),
                cartToUpdate.CreatedAt,
                DateTime.UtcNow);

            var updatedCart = await _cartCommandRepository.UpdateCartAsync(cartEntity);

            return _mapper.Map<CartResponse>(updatedCart);
        }

        public async Task<DeleteCartItemResponse> RemoveItemFromCartAsync(Guid id, Guid itemId)
        {
            var cart = await _cartQueryRepository.GetByIdAsync(id);
            if (cart == null)
            {
                _logger.LogWarning("Cart with id: {cartId} not found", id);
                return new DeleteCartItemResponse(isCartItemDeleted: false, isCartFound: false);
            }

            var itemToDelete = cart.GroceryItems.FirstOrDefault(x => x.Id == itemId);
            if (itemToDelete == null)
            {
                _logger.LogWarning("Item with id: {itemId} not found in cart with id: {cartId}", itemId, id);
                return new DeleteCartItemResponse(isCartItemDeleted: false, isCartFound: true);
            }

            cart.GroceryItems.Remove(itemToDelete);
            
            //Fix the bug here doesn't update the cart
            var cartEntity = new Cart(
                cart.Id,
                cart.Name,
                cart.Description,
                new Reminder(),
                cart.GroceryItems.Where(x => x.Id != itemId).Select(x => x.ToGroceryItem()).ToList(),
                cart.CreatedAt,
                DateTime.UtcNow);

            await _cartCommandRepository.UpdateCartAsync(cartEntity);
            return new DeleteCartItemResponse(isCartItemDeleted: true, isCartFound: true);
        }
    }
}
