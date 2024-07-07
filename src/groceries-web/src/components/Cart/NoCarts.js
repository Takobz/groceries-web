import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { Stack, Typography } from '@mui/material';
import { Box } from '@mui/system';
import CurvedButton from '../shared/CurvedButton';
import { useNavigate } from 'react-router-dom';

const NoCarts = () => {
    const navigate = useNavigate();

    const handleCreateCart = () => {
        navigate('/new-cart');
    }

    return(<>
        <Box sx={{ height: '100vh', display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <Stack alignItems='center' spacing={2}>
                <ShoppingCartIcon sx={{ fontSize: 100 }} />
                <Typography sx={{ fontWeight: 'bold' }} variant='h4'>No Cart Is Filled</Typography>
                <CurvedButton text='Create Cart' onClick={() => handleCreateCart()}/>
            </Stack>
        </Box>
    </>);
}

export default NoCarts;