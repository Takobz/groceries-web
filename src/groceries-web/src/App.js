import React from 'react';
import './styles/App.css';
import Header from './components/shared/Header';
import Box from '@mui/material/Box';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import HomePage from './components/Pages/HomePage';
import NewCartPage from './components/Pages/NewCartPage';
import Cart from './components/Pages/Cart';

function App() {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <HomePage />
    },
    {
      path: '/new-cart',
      element: <NewCartPage />
    },
    {
      path: '/cart/:id',
      element: <Cart />
    }
  ]);

  return (
    <>
      <Header />
      <Box sx={{ display: 'flex', justifyContent: 'center'}}>
        <RouterProvider router={router} />
      </Box>
    </>
  );
}

export default App;
