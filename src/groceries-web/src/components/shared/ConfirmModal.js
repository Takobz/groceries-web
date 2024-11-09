import { Box, Modal, Stack } from "@mui/material"
import { CurvedButton } from "./CurvedButton"
import { TitleAndDescription } from "./TitleAndDescription"

const ConfirmModal = (props) => {
    return (
        <Modal
            aria-labelledby="confirm-modal-title"
            aria-describedby="confirm-modal-description"
            open={props.isOpen}
            onClose={props.onConfirmClose}>
            <Box sx={style}>
                <Stack spacing={2}>
                    <TitleAndDescription title={props.title} description={props.description} />
                    //will need to move this to the right
                    <CurvedButton onClick={props.onConfirm}>Confirm</CurvedButton>
                    <CurvedButton onClick={props.onCancel}>Cancel</CurvedButton>
                </Stack>
            </Box>
        </Modal>
    );
}

export default ConfirmModal;