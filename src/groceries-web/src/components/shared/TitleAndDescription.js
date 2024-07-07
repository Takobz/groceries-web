import { Typography } from "@mui/material";

const TitleAndDescription = ({ title, description }) => {
    return (
        <>
            <Typography sx={{ fontWeight: 'bold' }} variant='h4'>{title}</Typography>
            <Typography variant='body1'>{description}</Typography>
        </>
    );
}

export default TitleAndDescription;