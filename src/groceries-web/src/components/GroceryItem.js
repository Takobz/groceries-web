import React from 'react';
import Card from '@mui/material/Card'
import { CardContent, Checkbox } from '@mui/material';

const GroceryItem = (props) => {
    return (
    <Card sx={{ width: '100%' }}>
        <CardContent>
            {props.name}
            <Checkbox checked={props.checked} onChange={props.onCheck} />
        </CardContent>    
    </Card>
    );
}

export default GroceryItem;