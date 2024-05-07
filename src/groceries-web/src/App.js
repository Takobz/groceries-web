import React from 'react';
import './styles/App.css';
import Header from './components/shared/Header';
import Box from '@mui/material/Box';

function App() {
  return (
    <>
      <Header />
      <div className='center-element'>
        <Box component="main" sx={{ p: 3 }}>
          <div>
            <p>
              Edit <code>src/App.js</code> and save to reload.
            </p>
            <a href="https://reactjs.org" target="_blank" rel="noopener noreferrer">
              Learn React
            </a>
          </div>
        </Box>
      </div>
    </>
    
  );
}

export default App;
