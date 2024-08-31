import React from 'react';
import Box from '@mui/material/Box';
import { AppBar, Toolbar, Typography } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Button from '@mui/material/Button';

const Header = () => {
    const onGroceriesClick = () => {
        window.location.href = '/';
    }

    return (
    <Box sx={{ flexGrow: 1, mb: 2 }}>
        <AppBar sx={{ bgcolor: "white" }} position="static">
            <Toolbar>
                <IconButton
                    size="large"
                    color="inherit"
                    aria-labelledby="menu"
                    sx={{ mr: 2, color: "black" }}>
                    <MenuIcon />
                </IconButton>
                <Button onClick={() => onGroceriesClick()} variant="text" size='large' sx={{ color: "black" }}>
                    <Typography variant='h6' sx={{ fontWeight: 'bold' }}>
                        Groceries
                    </Typography>
                </Button>
                <Box sx={{ flexGrow: 1 }} />
                <AccountCircle sx={{ color: "black" }}/>
            </Toolbar>
        </AppBar>
    </Box>
    );
}

export default Header;