using AutoFixture;
using FluentAssertions;
using Groceries.Core.Application.Models.DTOs.Requests;
using Groceries.Core.Application.Services;
using Groceries.Core.Domain.Entities;
using Groceries.Infrastructure.Repositories.CommandRepositories;
using Moq;

namespace Groceries.Tests.Unit.ServicesTests
{
    public class CartServiceTests
    {
        private readonly Mock<ICartCommandRepository> _cartCommandRepositoryMock;
        private readonly Fixture _fixture;
        private readonly CartService _sut;

        public CartServiceTests()
        {
            _fixture = new Fixture();
            _cartCommandRepositoryMock = new Mock<ICartCommandRepository>();
            _sut = new CartService(_cartCommandRepositoryMock.Object);
        }

        //TODO: Use CustomFixture
        [Fact]
        public async Task CreateCart_Should_Return_CreateCart_When_Cart_Is_Created()
        {
            //Arrange
            //fix autofixture instantiation
            var cartId = Guid.NewGuid();
            var createCartRequestDTO = _fixture.Build<CreateCartRequestDTO>().Create();
            var cart = CreateCart(createCartRequestDTO.Name);

            _cartCommandRepositoryMock.Setup(x => x.CreateCartAsync(It.Is<Cart>(r => r.Name == createCartRequestDTO.Name)))
                .ReturnsAsync(_fixture.Build<Data.DataModels.Cart>().Create());

            //Act
            var result = await _sut.CreateCart(createCartRequestDTO);

            //Assert
            result.Should().NotBeNull();
        }

        private Cart CreateCart(string name)
        {
            return new Cart(
                name: name,
                description: _fixture.Create<string>(),
                reminder: new Reminder(),
                items: [],
                createdAt: DateTime.Now,
                updatedAt: DateTime.Now
            );
        }
    }
}