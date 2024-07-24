import { createTheme, ThemeProvider } from "@mui/material"
import Button from "@mui/material/Button"

const curvedButtonTheme = createTheme({
    components: {
        MuiButton: {
            styleOverrides: {
                root: {
                    borderRadius: '20px',
                }
            }
        }
    }
});

const CurvedButton = (props) => {
    return (
        <ThemeProvider theme={curvedButtonTheme}>
            <Button 
            sx={{
                background: '#000',
                '&:hover':{
                    background: '#82817d'
                }
            }}
            variant="contained" color="primary"
            onClick={props.onClick}>
                {props.text}
            </Button>
        </ThemeProvider>
    );
}

export default CurvedButton;