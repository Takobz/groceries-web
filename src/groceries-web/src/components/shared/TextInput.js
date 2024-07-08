import { TextField } from "@mui/material";

const TextInput = (props) => {
    return (
        <>
            <TextField value={props.value} onChange={props.onChange} required={props.isRequired} label={props.label} variant="outlined"/>
        </>);
}

export default TextInput;