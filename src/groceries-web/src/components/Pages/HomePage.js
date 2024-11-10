import React, { useEffect, useState } from 'react'
import GroceriesAPIService from '../../Services/GroceriesAPIService'
import NoCarts from '../Cart/NoCarts'
import AllCarts from '../Cart/AllCarts'
import { Stack } from "@mui/material";
import CurvedButton from "../shared/CurvedButton";
import { useNavigate } from 'react-router-dom';

const HomePage = () => {
    const [carts, setCarts] = useState([]);
    const navigate = useNavigate();

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

    const goToNewCartPage = () => {
        navigate('/new-cart');
    }

    return (
        <Stack spacing={2}>
            {!(carts.length) ? <NoCarts/> : <AllCarts carts={carts} />}
            <div style={{ display: 'flex', justifyContent: 'right' }}>
                <CurvedButton text='Add New Cart' onClick={goToNewCartPage} />
            </div>
        </Stack>
    );
}

export default HomePage