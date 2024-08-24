import { useEffect, useState } from "react";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import { useParams } from "react-router-dom";
import EditCart from "../Cart/EditCart";

const Cart = (props) => {
    const { id } = useParams();
    const [cart, setCart] = useState({})

    useEffect(() => {
        async function getCart() {
            await GroceriesAPIService().getCart(id)
                .then((response) => {
                    setCart(response)
                })
                .catch((error) => console.error(error));
        }

        getCart();

        //empty cleanup function
        return () => {
        }
    }, [props.id]);


    return (<EditCart cart={cart} />);
}

export default Cart;