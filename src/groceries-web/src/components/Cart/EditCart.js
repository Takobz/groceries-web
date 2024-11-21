import * as React from 'react';
import { Box, Stack } from "@mui/material";
import CurvedButton from "../shared/CurvedButton";
import CartItem from "./CartItem";
import AddCartItem from "./AddCartItem";
import EditableTitleAndDescription from "../shared/EditableTitleAnDescription";
import CartItemsList from "./CartItemsList";

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
        setOpenAddItemModal(false);
    }

    const onCartItemsUpdate = (updatedCartItems) => {
        setCart({
            ...cart,
            items: updatedCartItems
        });
    }

    return (
        <>
            <Box sx={{ width: 500, minWidth: { xs: '90%', sm: 500 }}}>
                <Stack spacing={1}>
                    <EditableTitleAndDescription entityId={cart.cartId} title={cart.name} description={cart.description} />
                    <CartItemsList onCartItemsUpdate={onCartItemsUpdate} cart={cart} cartId={cart.cartId} />
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