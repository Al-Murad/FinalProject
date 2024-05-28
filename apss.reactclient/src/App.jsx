
import { Box } from '@mui/material';
import { Routes, Route } from 'react-router-dom';
//import NavBarComponent from './components/NavBarComponent';
import HomeComponent from './views/HomeComponent';
import './App.css'
import NavBarComponent from './components/NavBarComponent';
import ProductList from './views/ProductList';
import BikeCreateForm from './views/BikeCreateForm';
import PartEditForm from './views/PartEditForm';


function App() {
  return (
      <>
          { <NavBarComponent></NavBarComponent> }
          
          <Box sx={{ px: 2, py: 1 }}>
              <Routes>
                  <Route path="/" element={<HomeComponent />} />
                  <Route path="/Bikes" element={<ProductList />} />
                  <Route path="/bike-create" element={<BikeCreateForm />} />
                  <Route path="/part-edit/:id" element={<PartEditForm />} />
              </Routes>
          </Box>
    </>
  )
}

export default App
