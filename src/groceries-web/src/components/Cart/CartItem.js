import { Box, Card, CardContent, IconButton, Stack, Typography } from "@mui/material";

const CartItem = (props) => {
    return (<>
        <Card sx={{ display: 'flex' }}>
            <CardContent>
                <Typography>Name</Typography>
            </CardContent>
            <div sx={{ display: 'flex', justifyContent: 'right' }}>
                <Typography>Test</Typography>
            </div>
        </Card>
    </>)

}

export default CartItem;