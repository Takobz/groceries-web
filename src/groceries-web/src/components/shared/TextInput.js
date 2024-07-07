import { TextField } from "@mui/material";

const TextInput = (props) => {
    return (
        <>
            <TextField required={props.isRequired} label={props.label} variant="outlined"/>
        </>);
}

export default TextInput;