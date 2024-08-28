import { Modal } from "@mui/material";

const AddCartItem = (props) => {

    return (
        <Modal
            open={props.isOpen}
            onClose={props.closeModal}>
            <p>Hi</p>
        </Modal>
    )
}

export default AddCartItem;