import React, { useState } from "react";
import { styled, alpha } from "@mui/material/styles";
import {
  AppBar,
  Box,
  Toolbar,
  IconButton,
  Typography,
  InputBase,
  Badge,
  MenuItem,
  Menu,
  Drawer,
  List,
  ListItem,
  ListItemText,
  ListItemIcon,
  Avatar,
  Popover,
  Divider,
} from "@mui/material";
import {
  Menu as MenuIcon,
  Mail as MailIcon,
  Notifications as NotificationsIcon,
  MoreVert as MoreIcon,
  Dashboard as DashboardIcon,
  Settings as SettingsIcon,
  AccountBox as AccountBoxIcon,
} from "@mui/icons-material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import LockIcon from "@mui/icons-material/Lock";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import SearchIcon from "@mui/icons-material/Search";

const Search = styled("div")(({ theme }) => ({
  position: "relative",
  borderRadius: theme.shape.borderRadius,
  backgroundColor: alpha(theme.palette.common.white, 0.15),
  "&:hover": {
    backgroundColor: alpha(theme.palette.common.white, 0.25),
  },
  marginRight: theme.spacing(2),
  marginLeft: 0,
  width: "100%",
  [theme.breakpoints.up("sm")]: {
    marginLeft: theme.spacing(3),
    width: "auto",
  },
}));

const SearchIconWrapper = styled("div")(({ theme }) => ({
  padding: theme.spacing(0, 2),
  height: "100%",
  position: "absolute",
  pointerEvents: "none",
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
  color: "inherit",
  "& .MuiInputBase-input": {
    padding: theme.spacing(1, 1, 1, 0),
    paddingLeft: `calc(1em + ${theme.spacing(4)})`,
    transition: theme.transitions.create("width"),
    width: "100%",
    [theme.breakpoints.up("md")]: {
      width: "20ch",
    },
  },
}));

const PrimarySearchAppBar = () => {
  const [isOpen, setIsOpen] = useState(false); // Trạng thái của Drawer
  const [anchorEl, setAnchorEl] = useState(null);
  const [mobileMoreAnchorEl, setMobileMoreAnchorEl] = useState(null);
  const [openPopover, setOpenPopover] = useState(false);

  // Hàm toggle cho Drawer để mở và thu gọn
  const toggleDrawer = () => {
    setIsOpen((prevState) => !prevState); // Đảo ngược trạng thái của isOpen
  };

  const handleMenuClose = () => {
    handleMobileMenuClose();
  };

  const handleMobileMenuClose = () => {
    setMobileMoreAnchorEl(null);
  };

  const handleMobileMenuOpen = (event) => {
    setMobileMoreAnchorEl(event.currentTarget);
  };

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
    setOpenPopover(true);
  };

  const handleClose = () => {
    setOpenPopover(false);
  };

  const menuId = "primary-search-account-menu";
  const mobileMenuId = "primary-search-account-menu-mobile";

  const renderMobileMenu = (
    <Menu
      anchorEl={mobileMoreAnchorEl}
      anchorOrigin={{
        vertical: "top",
        horizontal: "right",
      }}
      id={mobileMenuId}
      keepMounted
      transformOrigin={{
        vertical: "top",
        horizontal: "right",
      }}
      open={Boolean(mobileMoreAnchorEl)}
      onClose={handleMobileMenuClose}
    >
      <MenuItem>
        <IconButton size="large" aria-label="show 4 new mails" color="inherit">
          <Badge badgeContent={4} color="error">
            <MailIcon />
          </Badge>
        </IconButton>
        <p>Messages</p>
      </MenuItem>
      <MenuItem>
        <IconButton
          size="large"
          aria-label="show 17 new notifications"
          color="inherit"
        >
          <Badge badgeContent={17} color="error">
            <NotificationsIcon />
          </Badge>
        </IconButton>
        <p>Notifications</p>
      </MenuItem>
    </Menu>
  );

  return (
    <Box sx={{ flexGrow: 1 }}>
      {/* AppBar */}
      <AppBar position="fixed">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="open drawer"
            sx={{ mr: 2 }}
            onClick={toggleDrawer} // Gọi hàm toggleDrawer để mở và thu gọn
          >
            <MenuIcon />
          </IconButton>
          <Typography
            variant="h6"
            noWrap
            component="div"
            sx={{ display: { xs: "none", sm: "block" } }}
          >
            SMARTRES
          </Typography>

          <Box sx={{ flexGrow: 1 }} />
          <Box sx={{ display: { xs: "none", md: "flex" } }}>
            <IconButton size="large" color="inherit">
              <Badge badgeContent={0} color="error">
                <MailIcon />
              </Badge>
            </IconButton>
            <IconButton size="large" color="inherit">
              <Badge badgeContent={0} color="error">
                <NotificationsIcon />
              </Badge>
            </IconButton>
          </Box>
          <Box sx={{ display: { xs: "flex", md: "none" } }}>
            <IconButton
              size="large"
              aria-label="show more"
              aria-controls={mobileMenuId}
              aria-haspopup="true"
              onClick={handleMobileMenuOpen}
              color="inherit"
            >
              <MoreIcon />
            </IconButton>
          </Box>
        </Toolbar>
      </AppBar>

      {/* Sidenav (Drawer) */}
      <Drawer
        sx={{
          width: isOpen ? 250 : 50,
          flexShrink: 0,
          "& .MuiDrawer-paper": {
            width: isOpen ? 250 : 50,
            boxSizing: "border-box",
            marginTop: "64px", // Đảm bảo Drawer nằm dưới AppBar
            transition: "width 0.3s ease",
            display: "flex",
            flexDirection: "column", // Sắp xếp các phần tử theo cột
          },
        }}
        variant="permanent"
        anchor="left"
        open={isOpen}
      >
        <Box sx={{ padding: 0 }}>
          {isOpen ? (
            <Box
              sx={{ paddingTop: 2, display: "flex", justifyContent: "center" }}
            >
              <StyledInputBase
                placeholder="Search in menu…"
                inputProps={{ "aria-label": "search" }}
                sx={{
                  border: "1px solid #ccc", // Thêm viền xung quanh
                  borderRadius: "4px", // Bo tròn góc của viền
                  padding: "8px 12px", // Khoảng cách giữa viền và nội dung bên trong
                  width: "80%", // Đảm bảo độ rộng chiếm hết container
                  "&:focus": {
                    borderColor: "#1976d2", // Màu viền khi focus
                    outline: "none", // Bỏ outline mặc định của trình duyệt
                  },
                }}
              />
            </Box>
          ) : (
            <Box>
              <ListItemIcon>
                <SearchIcon />
              </ListItemIcon>
            </Box>
          )}
        </Box>
        <List sx={{ flexGrow: 1 }}>
          <ListItem button>
            <ListItemIcon>
              <DashboardIcon />
            </ListItemIcon>
            <ListItemText primary={isOpen ? "Dashboard" : ""} />
          </ListItem>
          <ListItem button>
            <ListItemIcon>
              <AccountBoxIcon />
            </ListItemIcon>
            <ListItemText primary={isOpen ? "Profile" : ""} />
          </ListItem>
          <ListItem button>
            <ListItemIcon>
              <SettingsIcon />
            </ListItemIcon>
            <ListItemText primary={isOpen ? "Settings" : ""} />
          </ListItem>
        </List>
        <List
          sx={{
            position: "fixed",
            padding: 1,
            bottom: 0,
            width: isOpen ? 250 : 50,
          }}
        >
          <ListItem
            button
            sx={{
              display: "flex",
              justifyContent: "flex-start", // Chỉnh sửa lại căn chỉnh cho phần tử
              padding: 1,
            }}
          >
            <ListItemIcon>
              <Avatar alt="HN" src="" />
            </ListItemIcon>
            {isOpen && (
              <Box
                sx={{
                  display: "flex",
                  flexDirection: "column",
                  marginLeft: 1, // Điều chỉnh khoảng cách giữa Avatar và văn bản
                }}
              >
                <Typography variant="body2">Huy Nguyen</Typography>
                <Typography variant="body2" color="textSecondary">
                  Quản Trị Viên
                </Typography>
              </Box>
            )}
            {isOpen && (
              <IconButton onClick={handleClick} sx={{ marginLeft: "auto" }}>
                <MoreVertIcon />
              </IconButton>
            )}
          </ListItem>
        </List>
        {/* Popover for 3 dots menu */}
        <Popover
          open={openPopover}
          anchorEl={anchorEl}
          onClose={handleClose}
          anchorOrigin={{
            vertical: "top",
            horizontal: "left",
          }}
          transformOrigin={{
            vertical: "top",
            horizontal: "right",
          }}
          sx={{
            padding: "10px",
            marginTop: "10px",
            width: "300px",
            boxShadow: "0 2px 10px rgba(0, 0, 0, 0.1)", // Thêm bóng đổ
            borderRadius: "8px", // Viền bo tròn
          }}
        >
          <Box sx={{ width: "100%" }}>
            <MenuItem
              onClick={handleClose}
              sx={{
                display: "flex",
                alignItems: "center",
                padding: 2,
                borderRadius: "6px", // Viền bo tròn cho mỗi mục
                transition: "background-color 0.3s ease", // Thêm hiệu ứng khi hover
                "&:hover": {
                  backgroundColor: "#f4f6f8", // Màu nền khi hover
                  color: "#000", // Chuyển màu chữ thành đen khi hover
                },
              }}
            >
              <AccountCircleIcon sx={{ marginRight: 1, color: "#1976d2" }} />{" "}
              {/* Thêm màu icon */}
              <Typography sx={{ fontWeight: 500 }}>
                Chỉnh Sửa Tài Khoản
              </Typography>{" "}
              {/* Tăng trọng số font */}
            </MenuItem>
            <MenuItem
              onClick={handleClose}
              sx={{
                display: "flex",
                alignItems: "center",
                padding: 2,
                borderRadius: "6px", // Viền bo tròn cho mỗi mục
                transition: "background-color 0.3s ease", // Thêm hiệu ứng khi hover
                "&:hover": {
                  backgroundColor: "#f4f6f8", // Màu nền khi hover
                  color: "#000", // Chuyển màu chữ thành đen khi hover
                },
              }}
            >
              <LockIcon sx={{ marginRight: 1, color: "#f57c00" }} />{" "}
              {/* Thêm màu icon */}
              <Typography sx={{ fontWeight: 500 }}>
                Đổi Mật Khẩu
              </Typography>{" "}
              {/* Tăng trọng số font */}
            </MenuItem>
            <Divider sx={{ my: 1, borderColor: "#e0e0e0" }} />{" "}
            {/* Thêm màu cho divider */}
            <MenuItem
              onClick={handleClose}
              sx={{
                display: "flex",
                alignItems: "center",
                justifyContent: "flex-end",
                fontSize: "12px", // Font nhỏ cho "Đăng Xuất"
                padding: 2,
                borderRadius: "6px", // Viền bo tròn cho mục này
                transition: "background-color 0.3s ease", // Thêm hiệu ứng khi hover
                "&:hover": {
                  backgroundColor: "#f4f6f8", // Màu nền khi hover
                  color: "#000", // Chuyển màu chữ thành đen khi hover
                },
              }}
            >
              <ExitToAppIcon sx={{ marginRight: 1, color: "#d32f2f" }} />{" "}
              {/* Thêm màu cho icon */}
              <Typography sx={{ fontWeight: 500 }}>Đăng Xuất</Typography>{" "}
              {/* Tăng trọng số font */}
            </MenuItem>
          </Box>
        </Popover>
      </Drawer>
    </Box>
  );
};

export default PrimarySearchAppBar;
