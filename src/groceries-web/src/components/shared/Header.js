import React from 'react';
import Box from '@mui/material/Box';
import { AppBar, Toolbar, Typography } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import { useNavigate } from 'react-router-dom';

const Header = () => {
    //TODO: Add Navigation back to home page.

    return (
    <Box sx={{ flexGrow: 1 }}>
        <AppBar sx={{ bgcolor: "white" }} position="static">
            <Toolbar>
                <IconButton
                    size="large"
                    color="inherit"
                    aria-labelledby="menu"
                    sx={{ mr: 2, color: "black" }}>
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1, color: "black" }}>
                    Groceries
                </Typography>
                <AccountCircle sx={{ color: "black" }}/>
            </Toolbar>
        </AppBar>
    </Box>
    );
}

export default Header;