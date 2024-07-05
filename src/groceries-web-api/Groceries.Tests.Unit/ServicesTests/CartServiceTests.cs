using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Models.ServiceModels;
using Groceries.Core.Application.Services;
using Groceries.Core.Domain.Entities;
using Groceries.Core.Domain.Repositories;
using Groceries.Infrastructure.Repositories.CommandRepositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Groceries.Tests.Unit.ServicesTests
{
    #pragma warning disable CS8600
    public class CartServiceTests
    {
        private readonly Mock<ICartCommandRepository> _cartCommandRepositoryMock;
        private readonly Mock<IQueryRepository<Data.DataModels.Cart>> _cartQueryRepositoryMock;
        private readonly Mock<ILogger<CartService>> _cartServiceLoggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Fixture _fixture;
        private readonly CartService _sut;

        public CartServiceTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _cartCommandRepositoryMock = new Mock<ICartCommandRepository>();
            _cartQueryRepositoryMock = new Mock<IQueryRepository<Data.DataModels.Cart>>();
            _mapperMock = new Mock<IMapper>();
            _cartServiceLoggerMock = new Mock<ILogger<CartService>>();

            _sut = new CartService(
                _cartCommandRepositoryMock.Object,
                _cartQueryRepositoryMock.Object, 
                _cartServiceLoggerMock.Object, 
                _mapperMock.Object);
        }

        //TODO: Use CustomFixture
        [Fact]
        public async Task CreateCart_Should_Return_CreateCart_When_Cart_Is_Created()
        {
            //Arrange
            var cartId = Guid.NewGuid();
            var createCartRequestDTO = _fixture.Build<CreateCartRequestDTO>().Create();

            var creactedCart = _fixture.Build<Data.DataModels.Cart>()
                .With(x => x.Id, cartId)
                .Create();

            var cartResponse = _fixture.Build<CartResponse>()
                .With(x => x.CartId, cartId)
                .Create();

            _mapperMock.Setup(x => x.Map<CartResponse>(creactedCart)).Returns(cartResponse);
            _cartCommandRepositoryMock.Setup(x => x.CreateCartAsync(It.Is<Cart>(r => r.Name == createCartRequestDTO.Name)))
                .ReturnsAsync(creactedCart);

            //Act
            var result = await _sut.CreateCartAsync(createCartRequestDTO);

            //Assert
            result.Should().NotBeNull();
            result.CartId.Should().Be(cartId);
        }

        [Fact]
        public async Task GetCart_Should_Return_CartResponse_When_Cart_Exists()
        {
            //Arrange
            var cartId = Guid.NewGuid();
            var cart = _fixture.Build<Data.DataModels.Cart>()
                .With(x => x.Id, cartId)
                .Create();

            var cartResponse = _fixture.Build<CartResponse>()
                .With(x => x.CartId, cartId)
                .Create();

            _mapperMock.Setup(x => x.Map<CartResponse>(cart)).Returns(cartResponse);
            _cartQueryRepositoryMock.Setup(x => x.GetByIdAsync(cartId)).ReturnsAsync(cart);

            //Act
            var result = await _sut.GetCartAsync(cartId);

            //Assert
            result.Should().NotBeNull();
            result!.CartId.Should().Be(cartId);
        }

        [Fact]
        public async Task GetCart_Should_Return_No_CartResponse_When_Cart_Does_Not_Exist()
        {
            //Arrange
            var cartId = Guid.NewGuid();
            var cart = _fixture.Build<Data.DataModels.Cart>()
                .With(x => x.Id, cartId)
                .Create();

            var cartResponse = _fixture.Build<CartResponse>()
                .With(x => x.CartId, cartId)
                .Create();

            _mapperMock.Setup(x => x.Map<CartResponse>(cart)).Returns(cartResponse);
            _cartQueryRepositoryMock.Setup(x => x.GetByIdAsync(cartId)).ReturnsAsync((Data.DataModels.Cart)null);

            //Act
            var result = await _sut.GetCartAsync(cartId);

            //Assert
            result.Should().BeNull();
        }
    }
}