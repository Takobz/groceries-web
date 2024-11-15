
import * as React from 'react';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';
import { Stack } from '@mui/material';
import TitleAndDescription from '../shared/TitleAndDescription';
import TextInput from '../shared/TextInput';
import CurvedButton from '../shared/CurvedButton';
import NumberInput from '../shared/NumberInput';
import GroceriesAPIService from '../../Services/GroceriesAPIService';
import { addCartItemsRequestDTO, addCartItemRequestDTO } from '../../models/updateCartModels'

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

//TODO: Add Quantity field
const AddCartItem = (props) => {
    const [itemName, setItemName] = React.useState('');
    const [itemDescription, setItemDescription] = React.useState('');
    const [itemCategory, setItemCategory] = React.useState('');
    const [itemPrice, setItemPrice] = React.useState(0);

    const handleAddItem = () => {
        var addItemsDTO = new addCartItemsRequestDTO(
            props.cartId, 
            [
                new addCartItemRequestDTO(
                    itemName,
                    itemDescription,
                    itemCategory,
                    itemPrice
                )
            ]
        )

        GroceriesAPIService().addCartItems(addItemsDTO)
            .then((response) => {
                props.onCartUpdate(response);
                setItemName('');
                setItemDescription('');
                setItemCategory('');
                setItemPrice(0);
            }); 
    }

    return (
        <Modal
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description"
            open={props.isOpen}
            onClose={props.closeModal}>
            <Box sx={{ ...style, width: { xs: '70%', sm: 400 } }}>
            <Stack spacing={1}>
                <TitleAndDescription title='Item Name' description='Name of the item' />
                <TextInput value={itemName} onChange={(event) => setItemName(event.target.value)} isRequired={true} label='Name' />

                <TitleAndDescription title='Item Description' description='Description of the item' />
                <TextInput value={itemDescription} onChange={(event) => setItemDescription(event.target.value)} isRequired={true} label='Description' />

                <TitleAndDescription title='Item Category' description='Category of the item' />
                <TextInput value={itemCategory} onChange={(event) => setItemCategory(event.target.value)} isRequired={false} label='Category' />

                <TitleAndDescription title='Add Item' description='Price of the item' />
                <NumberInput value={itemPrice} onChange={(event) => setItemPrice(event.target.value)} isRequired={true} label='Price' />

                <CurvedButton text='Add Item' onClick={() => handleAddItem()} />
            </Stack>
            </Box>
        </Modal>
        )
}

export default AddCartItem;