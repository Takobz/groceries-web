import React, { useEffect, useState } from 'react'
import GroceriesAPIService from '../../Services/GroceriesAPIService'
import NoCarts from '../Cart/NoCarts'

const HomePage = () => {
    const [carts, setCarts] = useState([]);

    useEffect(() => {
        async function getAllCarts() {

            await GroceriesAPIService().getAllCarts()
                .then((response) => setCarts(response.data))
                .catch((error) => console.error(error));
        }

        getAllCarts();
    }, [])


    return (<>{
        carts != [] ? <NoCarts/>
        : <div>{
            carts.map((cart) => {
                return (<div key={cart.cartId}>{cart.name}</div>);
            })
        }</div>
    }</>)
}

export default HomePage