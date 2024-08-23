import { Card, CardActionArea, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import ShareIcon from '@mui/icons-material/Share';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from "react-router-dom";

//TODO Style the card
const CartCard = (props) => {
    const navigate = useNavigate();

    const handleCardClick = () => {
        navigate('/cart/' + props.cartId);
    }

    return (
        <Card sx={{ minWidth: 500 }}>
            <CardActionArea onClick={() => handleCardClick()}>
                <CardContent>
                    <Typography variant='h5'>{props.name}</Typography>
                    <Typography variant='body1'>{props.description}</Typography>
                </CardContent>
            </CardActionArea>

            <CardActions>
                <IconButton aria-label="edit-cart">
                    <EditIcon />
                </IconButton>
                <IconButton aria-label="share-cart">
                    <ShareIcon />
                </IconButton>
                <IconButton aria-label="duplicate-cart">
                    <ContentCopyIcon />
                </IconButton>
                <IconButton aria-label="delete-cart">
                    <DeleteIcon />
                </IconButton>
            </CardActions>
        </Card>
    );
}

export default CartCard;