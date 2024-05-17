import { Box } from "@mui/material";
import React  from "react";
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';

const NewCartPage = () => {
    return (
        <Box sx={{ height: '100vh', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <ShoppingCartIcon sx={{ fontSize: 100 }} />
            <ShoppingCartIcon sx={{ fontSize: 100 }} />
            <ShoppingCartIcon sx={{ fontSize: 100 }} />
        </Box>
    );
}

export default NewCartPage;