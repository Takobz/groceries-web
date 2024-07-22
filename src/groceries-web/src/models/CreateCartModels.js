class CreateCartResponseDTO {
    constructor(cartId, name, description){
        this.cartId = cartId;
        this.name = name;
        this.description = description;
    }
}

class CreateCartRequestDTO {
    constructor(name, description){
        this.name = name;
        this.description = description;
    }
}

class GetCartResponseDTO {
    constructor(cartId, name, description, items){
        this.cartId = cartId;
        this.name = name;
        this.description = description;

        this.items = items ? items.map(item => {
            return new GetCartItemResponseDTO(
                item.cartItemId,
                item.name,
                item.description,
                item.category,
                item.price,
                item.imageUrl);
        }) : [];
    }
}

class GetCartItemResponseDTO{
    constructor(
        cartItemId,
        name,
        description,
        category,
        price,
        imageUrl){
        this.cartItemId = cartItemId;
        this.name = name;
        this.description = description;
        this.category = category;
        this.price = price;
        this.imageUrl = imageUrl;
    }
}

export { CreateCartResponseDTO, CreateCartRequestDTO, GetCartResponseDTO, GetCartItemResponseDTO }