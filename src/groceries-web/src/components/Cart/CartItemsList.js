import CartItem from "./CartItem";
import React from "react";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import ConfirmModal from "../shared/ConfirmModal";
import Messages from "../../Helpers/applicationConstantMessages";

const CartItemsList = (props) => {
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
            setIsModalConfirmOpen(false);
            setCartItemToDeleteId('');
            if (response){
                const updatedCartItems = props.cart.items.filter(item => item.cartItemId !== cartItemId);
                props.onCartItemsUpdate(updatedCartItems);
            }
        });
    }

    return (
        <>
            {props.cart.items && props.cart.items.length ? props.cart.items.map(item => (
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