import React from 'react';
import './styles/App.css';
import Header from './components/shared/Header';
import Box from '@mui/material/Box';
import { BrowserRouter as Router, Switch, Route, createBrowserRouter, createRoutesFromElements, RouterProvider } from 'react-router-dom';
import HomePage from './components/Pages/HomePage';

function App() {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path="/" element={ <Home />}/>
    )
  );

  //fix this
  return (
    <>
      <Header />
      <div className='center-element'>
        <RouterProvider router={router} />
      </div>
    </>
  );
}

export default App;
