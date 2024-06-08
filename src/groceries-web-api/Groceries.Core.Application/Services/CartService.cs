using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.ServiceModels;
using Groceries.Infrastructure.Repositories.CommandRepositories;

namespace Groceries.Core.Application.Services
{
    public interface ICartService 
    {
        Task<CartResponse> CreateCart(CreateCartRequestDTO createCartRequestDTO);
    }

    public class CartService : ICartService
    {
        private readonly ICartCommandRepository _cartCommandRepository;

        public CartService(ICartCommandRepository cartCommandRepository)
        {
            _cartCommandRepository = cartCommandRepository;
        }

        public async Task<CartResponse> CreateCart(CreateCartRequestDTO createCartRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}