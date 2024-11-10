import axios from 'axios'
import { CreateCartResponseDTO, GetCartResponseDTO } from '../models/CreateCartModels'

//TODO: To enhance method and validity checks etc.
const GroceriesAPIService = () => {
    const groceriesBaseUrl = process.env.REACT_APP_GROCERIES_WEB_API_BASE_URI;
    const timeout = 1000;

    const getAllCarts = async () => {
        return await axios.get('/api/cart/all' ,{
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Referer': getHost(),
            }
        })
        .then(response => response.data);
    }

    const createCart = async (createCartDTO) => {
        return await axios.post('api/cart', {
                name: createCartDTO.name,
                description: createCartDTO.description,
                groceryItems: []
            }, 
            {
                baseURL: groceriesBaseUrl,
                timeout: timeout,
                headers: {
                    'Content-Type': 'application/json',
                    'Referer': getHost()
                }
            }
        ).then(response => {
            if (response.status === 201) {
                return new CreateCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description
                );
            }
        });
    }

    const getCart = async (cartId) => {
        return await axios.get('api/cart/' + cartId, {
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Referer': getHost(),
            }
        }).then(response => {
            if (response.status === 200) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.groceryItems
                );
            }
        });
    }

    const updateCart = async (cartId, updateCartDTO) => {
        return await axios.put('api/cart/' + cartId, {
            name: updateCartDTO.name,
            description: updateCartDTO.description,
            groceryItems: updateCartDTO.groceryItems
        }, {
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Content-Type': 'application/json',
                'Referer': getHost(),
            }
        }).then(response => {
            if (response.status === 200) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.groceryItems
                );
            }
        });
    }

    const deleteCart = async (cartId) => {
        const isDeleted = true;

        return await axios.delete('api/cart/' + cartId, {
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Referer': getHost(),
            }
        }).then(response => {
            if (response.status === 204) {
                return isDeleted;
            }
            else{
                return !isDeleted;
            }
        });
    }

    const addCartItems = async (addCartItemsDTO) => {
        return await axios.patch('api/cart/' + addCartItemsDTO.cartId + '/items', {
            cartId: addCartItemsDTO.cartId,
            groceryItems: addCartItemsDTO.cartItems
        }, {
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Content-Type': 'application/json',
                'Referer': getHost()
            }
        }).then(response => {
            if (response.status === 200) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.groceryItems
                );
            }
        });
    }

    const copyCart = async (cartId) => {
        return await axios.post('api/cart/' + cartId + '/copy', {}, {
            baseURL: groceriesBaseUrl,
            timeout: timeout,
            headers: {
                'Referer': getHost(),
            }
        }).then(response => {
            if (response.status === 201) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.groceryItems
                );
            }
        });
    }

    return { getAllCarts, createCart, getCart, deleteCart, addCartItems, copyCart }
}

const getHost = () => {
    const { protocol, hostname } = window.location;
    return hostname.includes("localhost") ? '' : `${protocol}//${hostname}`;
};
export default GroceriesAPIService