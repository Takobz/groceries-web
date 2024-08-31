import { TextField } from "@mui/material";

const NumberInput = (props) => {
    return (
        <>
            <TextField type="number" value={props.value} onChange={props.onChange} required={props.isRequired} label={props.label} variant="outlined" />
        </>);
}

export default NumberInput;