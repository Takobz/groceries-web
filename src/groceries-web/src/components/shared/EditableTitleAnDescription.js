
import GroceriesAPIService from "../../Services/GroceriesAPIService";
import EditIcon from '@mui/icons-material/Edit';
import TextInput from "../shared/TextInput";
import { Typography, IconButton } from "@mui/material";
import React from "react";

const EditableTitleAndDescription = ({ entityId, title, description }) => {
    const [isTitleInEditMode, setIsTitleInEditMode] = React.useState(false);
    const [isDescriptionInEditMode, setIsDescriptionInEditMode] = React.useState(false);
    const [stateTitle, setTitle] = React.useState(title);
    const [stateDescription, setDescription] = React.useState(description);

    const onTitleBlur = (event) => {
        setIsTitleInEditMode(false);
        setTitle(event.target.value);
        GroceriesAPIService().updateCartDetails(entityId, stateTitle, stateDescription)
            .then((response) => {
                if (!response) {
                    setTitle(title);
                }
            });
    }

    const onDescriptionBlur = (event) => {
        setIsDescriptionInEditMode(false);
        setDescription(event.target.value);
        GroceriesAPIService().updateCartDetails(entityId, stateTitle, stateDescription)
            .then((response) => {
                if (!response) {
                    setTitle(description);
                }
            });
    }

    const onTitleChange = (event) => {
        setTitle(event.target.value);
    }

    const onDescriptionChange = (event) => {
        setDescription(event.target.value);
    }

    return (
        <>
            <div style={{ display: 'flex', alignItems: 'center' }}>
                {isTitleInEditMode ?
                    <TextInput
                        value={stateTitle}
                        label='CartName'
                        isRequired={true}
                        onBlur={onTitleBlur}
                        onChange={onTitleChange}
                    /> :
                    <>
                        <Typography sx={{ fontWeight: 'bold' }} variant='h4'>{stateTitle}</Typography>
                        <IconButton onClick={() => setIsTitleInEditMode(true)}>
                            <EditIcon />
                        </IconButton>
                    </>
                }
            </div>
            <div style={{ display: 'flex', alignItems: 'center' }}>
                {isDescriptionInEditMode ?
                    <TextInput
                        value={stateDescription}
                        label='Description'
                        isRequired={true}
                        onBlur={onDescriptionBlur}
                        onChange={onDescriptionChange}
                    /> :
                    <>
                        <Typography variant='body1'>{stateDescription}</Typography>
                        <IconButton onClick={() => setIsDescriptionInEditMode(true)}>
                            <EditIcon />
                        </IconButton>
                    </>
                }
            </div>
        </>
    );
}

export default EditableTitleAndDescription;