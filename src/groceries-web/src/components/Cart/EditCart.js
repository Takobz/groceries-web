import { Box, Stack } from "@mui/material";
import TitleAndDescription from "../shared/TitleAndDescription";
import CurvedButton from "../shared/CurvedButton";
import CartItem from "./CartItem";
import AddCartItem from "./AddCartItem";
import { useState } from "react";

const EditCart = (props) => {
    const cart = props.cart
    const [openAddItemModal, setOpenAddItemModal] = useState(false);

    const closeModal = () => {
        setOpenAddItemModal(false);
    }

    const openModal = () => {
        setOpenAddItemModal(true);
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
            
            <AddCartItem closeModal={closeModal} isOpen={openAddItemModal}/>
        </>

    );
}

export default EditCart