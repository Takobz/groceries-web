import axios from 'axios'
import { CreateCartResponseDTO } from '../models/CreateCartModels'

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
                return response.data;
                //fix this
                return new CreateCartResponseDTO(
                    response.data.cartId,
                    response.data.name,
                    response.data.description
                );
            }
        });
    }

    return {getAllCarts, createCart}
}

export default GroceriesAPIService