import * as React from 'react';
import { Box, Stack } from "@mui/material";
import TitleAndDescription from "../shared/TitleAndDescription";
import CurvedButton from "../shared/CurvedButton";
import CartItem from "./CartItem";
import AddCartItem from "./AddCartItem";


const EditCart = (props) => {
    const [cart, setCart] = React.useState(props.cart)
    const [openAddItemModal, setOpenAddItemModal] = React.useState(false);

    const closeModal = () => {
        setOpenAddItemModal(false);
    }

    const openModal = () => {
        setOpenAddItemModal(true);
    }

    const onCartUpdate = (updatedCart) => {
        setCart(updatedCart);
        console.log(updatedCart);
        setOpenAddItemModal(false);
    }

    return (
        <>
            <Box sx={{ width: 500 }}>
                <Stack spacing={1}>
                    <TitleAndDescription title={cart.name} description={cart.description} />
                    {cart.items.map(item => (<CartItem key={item.cartItemId} item={item} />))}
                    <div style={{ display: 'flex', justifyContent: 'right' }}>
                        <CurvedButton text='Add Item' onClick={openModal} />
                    </div>
                </Stack>
            </Box>
            
            <AddCartItem cartId={cart.cartId} onCartUpdate={onCartUpdate} closeModal={closeModal} isOpen={openAddItemModal}/>
        </>

    );
}

export default EditCart