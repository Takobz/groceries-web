import React from 'react';
import Box from '@mui/material/Box';
import { AppBar, Toolbar, Typography } from '@mui/material';
import AccountCircle from '@mui/icons-material/AccountCircle';

Header = () => {
    return (
    <Box sx={{ flexGrow: 1 }}>
        <AppBar position="static">
            <Toolbar>
                <IconButton
                    size="large"
                    edge="strat"
                    color="inherit"
                    aria-labelledby="menu"
                    sx={{ mr: 2 }}>
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    Groceries
                </Typography>
                <AccountCircle />
            </Toolbar>
        </AppBar>
    </Box>
    );
}

export default Header;