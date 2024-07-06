import React, { useEffect, useState } from 'react'
import GroceriesAPIService from '../../Services/GroceriesAPIService'
import axios from 'axios';

const HomePage = () => {
    const [carts, setCarts] = useState([]);

    useEffect(() => {
        function getAllCarts() {

            GroceriesAPIService().getAllCarts()
                .then((response) => setCarts(response.data))
                .catch((error) => console.error(error));
        }

        getAllCarts();
    }, [])

    return (<div>{
        carts.map((cart) => {
            return (<div key={cart.id}>{cart.name}</div>)
        })
    }</div>);
}

export default HomePage