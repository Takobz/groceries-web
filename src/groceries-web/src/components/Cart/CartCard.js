import { Card, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import ShareIcon from '@mui/icons-material/Share';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import DeleteIcon from '@mui/icons-material/Delete';

//TODO Style the card
const CartCard = (props) => {
    return (
        <Card>
            <CardContent>
                <Typography variant='h5'>{props.name}</Typography>
                <Typography variant='body1'>{props.description}</Typography>
            </CardContent>

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