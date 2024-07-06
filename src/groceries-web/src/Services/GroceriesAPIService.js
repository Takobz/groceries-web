import axios from 'axios'

//TODO: figure what's up with environment vars
const GroceriesAPIService = () => {
    const getAllCarts = async () => {
        return await axios.get('/api/cart/all' ,{
            baseURL: process.env.GROCERIES_WEB_API_BASE_URI,
            timeout: 1000,
        })
        .then(response => response.data);
    }

    return {getAllCarts}
}

export default GroceriesAPIService