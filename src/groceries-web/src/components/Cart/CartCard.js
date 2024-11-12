import { Card, CardActionArea, CardActions, CardContent, IconButton, Typography } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import ShareIcon from '@mui/icons-material/Share';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import DeleteIcon from '@mui/icons-material/Delete';
import { useNavigate } from "react-router-dom";
import ConfirmModal from "../shared/ConfirmModal";
import React from 'react';
import Messages from "../../Helpers/applicationConstantMessages";
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import InfoModal from "../shared/InfoModal";

const CartCard = (props) => {
    const navigate = useNavigate();
    const [isModalConfirmOpen, setIsModalConfirmOpen] = React.useState(false);
    const [modalTitle, setModalTitle] = React.useState('');
    const [modalDescription, setModalDescription] = React.useState('');
    const [isErrorModalOpen, setIsErrorModalOpen] = React.useState(false);

    const handleCardClick = () => {
        navigate('/cart/' + props.cartId);
    }

    const handleDeleteCartClick = () => {
        setIsModalConfirmOpen(true); 
        setModalTitle('Delete Cart');
        setModalDescription(Messages.deleteCart);
    }

    const handleConfirmDelete = () => {
        GroceriesAPIService().deleteCart(props.cartId)
            .then((response) => {
                if (response === true) {
                    setIsModalConfirmOpen(false);
                    navigate(0);
                }
                else{
                    setIsModalConfirmOpen(false);
                    setModalTitle('Error');
                    setModalDescription(Messages.deleteCartError);
                    setIsErrorModalOpen(true);
                }
            });
    }

    const handleCopyCartClick = () => {
        GroceriesAPIService().copyCart(props.cartId)
            .then((response) => {
                if (response && response.cartId){
                    navigate('/cart/' + response.cartId);
                }
                else {
                    setIsModalConfirmOpen(false);
                    setModalTitle('Error');
                    setModalDescription(Messages.copyCartError);
                    setIsErrorModalOpen(true);
                }
            });
    }

    const handleModalClose = () => {
        setIsModalConfirmOpen(false);
        setIsErrorModalOpen(false);
    }

    return (
        <>
            <Card sx={{ minWidth: { xs: 300, sm: 500 } }}>
                <CardActionArea onClick={() => handleCardClick()}>
                    <CardContent>
                        <Typography variant='h5'>{props.name}</Typography>
                        <Typography variant='body1'>{props.description}</Typography>
                    </CardContent>
                </CardActionArea>

                <CardActions>
                    {
                    // <IconButton aria-label="edit-cart">
                    //     <EditIcon />
                    // </IconButton>
                    // <IconButton aria-label="share-cart">
                    //     <ShareIcon />
                    // </IconButton>
                    }
                    <IconButton 
                        aria-label="duplicate-cart"
                        onClick={handleCopyCartClick}>
                        <ContentCopyIcon />
                    </IconButton>
                    <IconButton
                        aria-label="delete-cart"
                        onClick={handleDeleteCartClick}>
                        <DeleteIcon />
                    </IconButton>
                </CardActions>
            </Card>

            <ConfirmModal 
                isOpen={isModalConfirmOpen} 
                onConfirmClose={handleModalClose} 
                onCancel={handleModalClose}
                onConfirm={handleConfirmDelete}
                title={modalTitle}
                description={modalDescription} />

            <InfoModal
                isOpen={isErrorModalOpen}
                onConfirmClose={handleModalClose}
                onCancel={handleModalClose}
                title={modalTitle}
                description={modalDescription} />
        </>
    );
}

export default CartCard;