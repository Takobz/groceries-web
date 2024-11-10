import { Box, Modal, Stack } from "@mui/material"
import CurvedButton from "./CurvedButton"
import TitleAndDescription from "./TitleAndDescription"

const style = {
    position: 'absolute',
    top: '30%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
};

const InfoModal = (props) => {
    return (
        <Modal
            aria-labelledby="confirm-modal-title"
            aria-describedby="confirm-modal-description"
            open={props.isOpen}
            onClose={props.onConfirmClose}>
            <Box sx={style}>
                <Stack spacing={2}>
                    <TitleAndDescription title={props.title} description={props.description} />
                    <div style={{ display: 'flex', justifyContent: 'right', gap: '10px' }}>
                        <CurvedButton onClick={props.onCancel} text='Close' />
                    </div>
                </Stack>
            </Box>
        </Modal>
    );
}

export default InfoModal;