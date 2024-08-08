import React, { useEffect, useState } from 'react'
import GroceriesAPIService from '../../Services/GroceriesAPIService'
import NoCarts from '../Cart/NoCarts'
import AllCarts from '../Cart/AllCarts'

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
        : <AllCarts carts={carts} />
    }</>)
}

export default HomePage