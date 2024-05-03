import react from 'react';
import { Box } from '@mui/material';
import { Routes, Route } from 'react-router-dom';
import NavBarComponent from './components/NavBarComponent';
import HomeComponent from './components/HomeComponent';
import './App.css'

function App() {
  return (
      <>
          <NavBarComponent></NavBarComponent>
          <Box sx={{ px: 2, py: 1 }}>
              <Routes>
                  <Route path="/" element={<HomeComponent />} />

              </Routes>
          </Box>
    </>
  )
}

export default App
