import CartItem from "./CartItem";
import React from "react";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import ConfirmModal from "../shared/ConfirmModal";
import Messages from "../../Helpers/applicationConstantMessages";

const CartItemsList = (props) => {
    const [cartItems, setCartItems] = React.useState(props.items);
    const [isModalConfirmOpen, setIsModalConfirmOpen] = React.useState(false);
    const cartId = props.cartId;
    const [cartItemToDeleteId, setCartItemToDeleteId] = React.useState('');

    const handleModalClose = () => {
        setCartItemToDeleteId('');
        setIsModalConfirmOpen(false);
    }

    const handleOnCartItemDelete = (cartItemId) => {
        setCartItemToDeleteId(cartItemId);
        setIsModalConfirmOpen(true);
    }

    const handleConfirmDelete = (cartId, cartItemId) => {
        GroceriesAPIService().deleteCartItem(cartId, cartItemId)
        .then((response) => {
            if (response){
                const updatedCartItems = cartItems.filter(item => item.cartItemId !== cartItemId);
                setCartItems({ ...cartItems, items: updatedCartItems });
            }
        });
    }

    return (
        <>
            {

            }
            {cartItems && cartItems.length ? cartItems.map(item => (
                <CartItem 
                    key={item.cartItemId} 
                    item={item}
                    onDelete={() => handleOnCartItemDelete(item.cartItemId)}/>
                )) : <></>
            }

            <ConfirmModal 
                isOpen={isModalConfirmOpen} 
                onConfirmClose={handleModalClose} 
                onCancel={handleModalClose}
                onConfirm={() => handleConfirmDelete(cartId, cartItemToDeleteId)}
                title={'Delete Item'}
                description={Messages.deleteItem}
            />
        </>
    );
}

export default CartItemsList;