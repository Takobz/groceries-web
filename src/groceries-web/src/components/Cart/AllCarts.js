import { Stack } from "@mui/material";
import CartCard from "./CartCard";

const AllCarts = (props) => {

    return (
        <Stack spacing={2}>
            {props.carts.map((cart) => (
                <CartCard cartId={cart.cartId} key={cart.cartId} name={cart.name} description={cart.description} />
            ))}
        </Stack>
    );
}

export default AllCarts;