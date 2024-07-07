import { Box, Stack } from "@mui/material";
import React  from "react";
import TitleAndDescription from "../shared/TitleAndDescription";
import TextInput from "../shared/TextInput";
import CurvedButton from "../shared/CurvedButton";

const NewCartPage = () => {
    const handleSaveClick = () => {
        //handle change. Maybe look at your post here: 
        //https://letspretend.netlify.app/blog/passing-data-around-in-reactJs
    }

    return (
        <Box sx={{ height: '100vh', display: 'flex', justifyContent: 'center' }}>
            <Stack spacing={1}>
                <TitleAndDescription title='Create New Cart' description='Create a new cart to start adding items to it.' />
                <TextInput isRequired={true} label='Cart Name' />

                <TitleAndDescription title='Add Description' description='A mini description of what the cart is for' />
                <TextInput isRequired={true} label='Cart Description' />

                <div style={{ display: 'flex', justifyContent: 'right' }}>
                    <CurvedButton text='Save' onClick={() => alert('Saved')}/>
                </div>
            </Stack>
        </Box>
    );
}

export default NewCartPage;
