import { Box, Stack } from "@mui/material";
import TitleAndDescription from "../shared/TitleAndDescription";
import CurvedButton from "../shared/CurvedButton";
import CartItem from "./CartItem";

const EditCart = (props) => {
    const cart = props.cart

    return (
        <Box sx={{ width: 500 }}>
            <Stack spacing={1}>
                <TitleAndDescription title={cart.name} description={cart.description} />
                {cart.items.map(item => (<CartItem key={item.cartItemId} item={item}/>))}
                <div style={{ display: 'flex', justifyContent: 'right' }}>
                    <CurvedButton text='Add Item' onClick={() => alert()} />
                </div>
            </Stack>
        </Box>
    );
}

export default EditCart