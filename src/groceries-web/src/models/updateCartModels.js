class addCartItemsRequestDTO {
    constructor(
        cartId,
        cartItems
    ) {
        this.cartId = cartId;
        if (this.cartItemsAreAddCartItemDTO(cartItems)) {
            this.cartItems = cartItems;
        }
        else {
            throw new Error('cartItems are invalid');
        }
    }

    cartItemsAreAddCartItemDTO(cartItems) {
        return Array.isArray(cartItems) &&
         cartItems.every(cartItem => cartItem instanceof addCartItemRequestDTO);
    }
}

class addCartItemRequestDTO {
    constructor(
        name,
        description,
        category,
        price,
    ) {
        this.name = name;
        this.description = description;
        this.category = category;
        this.price = Number(price);
    }
}



export { addCartItemsRequestDTO, addCartItemRequestDTO }