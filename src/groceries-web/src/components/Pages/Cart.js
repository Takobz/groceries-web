import { useEffect } from "react";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import { useParams } from "react-router-dom";

const Cart = (props) => {
    const { id } = useParams();

    useEffect(() => {
        async function getCart() {
            await GroceriesAPIService().getCart(id)
                .then((response) => {
                    console.log(response);
                })
                .catch((error) => console.error(error));
        }

        getCart();

        //empty cleanup function
        return () => {
        }
    }, [props.id]);


    return <>I am cart: {props.name}</>
}

export default Cart;