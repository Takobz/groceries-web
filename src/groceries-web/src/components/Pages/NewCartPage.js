import { Box, Stack } from "@mui/material";
import React  from "react";
import TitleAndDescription from "../shared/TitleAndDescription";
import TextInput from "../shared/TextInput";
import CurvedButton from "../shared/CurvedButton";
import GroceriesAPIService from "../../Services/GroceriesAPIService";

const NewCartPage = () => {
    const [cartName, setCartName] = React.useState('');
    const [cartDescription, setCartDescription] = React.useState('');

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
        
        GroceriesAPIService().createCart(createCart)
            .then((response) => console.log(response))
            .catch((error) => console.error(error));
    }

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
