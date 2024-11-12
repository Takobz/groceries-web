import { Box, Modal, Stack } from "@mui/material"
import CurvedButton from "./CurvedButton"
import TitleAndDescription from "./TitleAndDescription"

const style = {
    position: 'absolute',
    top: '30%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: { xs: 200, sm: 500 },
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const ConfirmModal = (props) => {
    return (
        <Modal
            sx={{ minWidth: { xs: 200, sm: 500 } }}
            aria-labelledby="confirm-modal-title"
            aria-describedby="confirm-modal-description"
            open={props.isOpen}
            onClose={props.onConfirmClose}>
            <Box sx={style}>
                <Stack spacing={2}>
                    <TitleAndDescription title={props.title} description={props.description} />
                    <div style={{ display: 'flex', justifyContent: 'right', gap: '10px' }}>
                        <CurvedButton onClick={props.onConfirm} text='Confirm' />
                        <CurvedButton onClick={props.onCancel} text='Cancel' />
                    </div>
                </Stack>
            </Box>
        </Modal>
    );
}

export default ConfirmModal;