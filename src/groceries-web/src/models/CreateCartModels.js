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

export { CreateCartResponseDTO, CreateCartRequestDTO }