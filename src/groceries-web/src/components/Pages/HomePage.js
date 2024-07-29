import React, { useEffect, useState } from 'react'
import GroceriesAPIService from '../../Services/GroceriesAPIService'
import NoCarts from '../Cart/NoCarts'
import CartCard from '../Cart/CartCard';

const HomePage = () => {
    const [carts, setCarts] = useState([]);

    useEffect(() => {
        async function getAllCarts() {

            await GroceriesAPIService().getAllCarts()
                .then((response) => setCarts(response.data))
                .catch((error) => console.error(error));
        }

        getAllCarts();

        //empty cleanup function
        return () => {
        }
    }, []);

    return (<>{
        !(carts.length) ? <NoCarts/>
        : <ul>{
            carts.map((cart) => {
                return (
                <li key={cart.cartId}>
                    <CartCard name={cart.name} description={cart.description} />
                </li>);
            })
        }</ul>
    }</>)
}

export default HomePage