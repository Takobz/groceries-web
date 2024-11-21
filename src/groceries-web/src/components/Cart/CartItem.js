import { Box, Card, CardContent, IconButton, Typography } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const CartItem = (props) => {
    const item = props.item;

    return (
        <Card sx={{
            display: 'flex',
            alignItems: 'baseline',
            flexDirection: 'row',
            width: '100%',
        }}>
            <CardContent>
                <Typography>{item.name}</Typography>
            </CardContent>
            <Box sx={{ ml: 'auto' }}>
                {
                    // <IconButton aria-label="edit-cart">
                    // <EditIcon />
                    // </IconButton>
                }
                <IconButton 
                    aria-label="delete-cart"
                    onClick={props.onDelete}>
                    <DeleteIcon />
                </IconButton>
            </Box>
        </Card>
    );
}

export default CartItem;