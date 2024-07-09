import { Box, Stack } from "@mui/material";
import React  from "react";
import TitleAndDescription from "../shared/TitleAndDescription";
import TextInput from "../shared/TextInput";
import CurvedButton from "../shared/CurvedButton";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import { useNavigate } from "react-router-dom";

const NewCartPage = () => {
    const [cartName, setCartName] = React.useState('');
    const [cartDescription, setCartDescription] = React.useState('');
    const navigate = useNavigate();

    const handleCartNameChange = (event) => {
        event.preventDefault();
        setCartName(event.target.value);
    }

    const handleDescriptionChange = (event) => {
        event.preventDefault();
        setCartDescription(event.target.value);
    }

    const handleSaveClick = () => {
        var createCart = {
            name: cartName,
            description: cartDescription
        }
        
        //TODO: Figure out what's up here.
        //TODO: Add Error modals ?
        GroceriesAPIService().createCart(createCart)
            .then((response) => {
                if (response){
                    navigate('/cart/' + response.cartId);
                }
            })
            .catch((error) => console.error(error));
    }

    //TODO: Add spiner
    return (
        <Box sx={{ height: '100vh', display: 'flex', justifyContent: 'center' }}>
            <Stack spacing={1}>
                <TitleAndDescription title='Create New Cart' description='Create a new cart to start adding items to it.' />
                <TextInput value={cartName} onChange={handleCartNameChange} isRequired={true} label='Cart Name' />

                <TitleAndDescription title='Add Description' description='A mini description of what the cart is for' />
                <TextInput value={cartDescription} onChange={handleDescriptionChange} isRequired={true} label='Cart Description' />
                
                <div style={{ display: 'flex', justifyContent: 'right' }}>
                    <CurvedButton text='Save' onClick={() => handleSaveClick()}/>
                </div>
            </Stack>
        </Box>
    );
}

export default NewCartPage;
