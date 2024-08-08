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
                    'Content-Type': 'application/json'
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
            timeout: timeout
        }).then(response => {
            if (response.status === 200) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.items
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
                'Content-Type': 'application/json'
            }
        }).then(response => {
            if (response.status === 200) {
                return new GetCartResponseDTO(
                    response.data.data.cartId,
                    response.data.data.name,
                    response.data.data.description,
                    response.data.data.items
                );
            }
        });
    }

    const deleteCart = async (cartId) => {
        const isDeleted = true;

        return await axios.delete('api/cart/' + cartId, {
            baseURL: groceriesBaseUrl,
            timeout: timeout
        }).then(response => {
            if (response.status === 204) {
                return isDeleted;
            }
            else{
                return !isDeleted;
            }
        });
    }

    return {getAllCarts, createCart, getCart, deleteCart }
}

export default GroceriesAPIService