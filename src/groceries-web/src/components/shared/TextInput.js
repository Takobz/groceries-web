import { TextField } from "@mui/material";

const TextInput = (props) => {
    return (
        <>
            <TextField 
                value={props.value} 
                onChange={props.onChange ? props.onChange : () => {}}
                onBlur={props.onBlur ? props.onBlur : () => {}}   
                required={props.isRequired ?? false} 
                label={props.label} 
                variant="outlined"/>
        </>);
}

export default TextInput;