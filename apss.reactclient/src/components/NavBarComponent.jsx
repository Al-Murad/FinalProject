import {
  Box,
  Typography,
  AppBar,
  Toolbar,
  IconButton,
  Button,
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Drawer,
  Divider
  
} from "@mui/material";
import { styled } from '@mui/material/styles';
import MenuIcon from "@mui/icons-material/Menu";
import { useState } from "react";
import CommuteIcon from "@mui/icons-material/Commute";
import MopedIcon from '@mui/icons-material/Moped';
function NavBarComponent() {
  const [open, setOpen] = useState(false);
  const toggleDrawer = (newOpen) => () => {
    console.log(newOpen);
    setOpen(newOpen);
  };
  const DrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    background: '#3F51B5',
    color:'#000',
      // necessary for content to be below app bar
    ...theme.mixins.toolbar,
    justifyContent: 'flex-start',
  }));
  
  return (
    <>
      <Box sx={{ p: 0, m: 0 }}>
        <AppBar position="static">
          <Toolbar>
            <IconButton
              size="large"
              edge="start"
              color="inherit"
              sx={{ mr: 1 }}
              onClick={toggleDrawer(true)}
            >
              <MenuIcon />
            </IconButton>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1}}>
              APSS RectJS Client
            </Typography>
            <Button href="/" color="inherit">
              Home
            </Button>
            <Button color="inherit">Login</Button>
          </Toolbar>
        </AppBar>
      </Box>
      <Drawer  open={open}
          onClose={toggleDrawer(false)}>
            
        <Box
          role="presentation"
          sx={{ width: 256 }}
         
        >
            <DrawerHeader color="primary">
            <Typography variant="h6" component="div" sx={{ flexGrow: 1, color:'white'  }}>
              APSS Menu
            </Typography>
            </DrawerHeader>
       <Divider />
          <List>
            <ListItem key={0}>
              <ListItemButton>
                <ListItemIcon>
                  <CommuteIcon />
                </ListItemIcon>
                <ListItemText primary={"Car service"} />
              </ListItemButton>
            </ListItem>
            <ListItem key={1}>
              <ListItemButton>
                <ListItemIcon>
                  <MopedIcon />
                </ListItemIcon>
                <ListItemText primary={"Bike service"} />
              </ListItemButton>
            </ListItem>
          </List>
        </Box>
      </Drawer>
    </>
  );
}

export default NavBarComponent;
