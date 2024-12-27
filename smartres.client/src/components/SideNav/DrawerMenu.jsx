import React, { useState } from "react";
import {
  Drawer,
  Box,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Avatar,
  IconButton,
  Typography,
  Popover,
  MenuItem,
  Divider,
  TextField,
  InputAdornment,
} from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import {
  Dashboard as DashboardIcon,
  AccountBox as AccountBoxIcon,
  Settings as SettingsIcon,
} from "@mui/icons-material";
import AccountCircleIcon from "@mui/icons-material/AccountCircle";
import ExitToAppIcon from "@mui/icons-material/ExitToApp";
import SearchIcon from "@mui/icons-material/Search";
import LockIcon from "@mui/icons-material/Lock";

const DrawerMenu = ({
  isOpen,
  isHovered,
  handleMouseEnter,
  handleMouseLeave,
  openPopover,
  handleClick,
  handleClose,
  anchorEl,
}) => {
  return (
    <Drawer
      sx={{
        width: isOpen || isHovered ? 240 : 64,
        flexShrink: 0,
        "& .MuiDrawer-paper": {
          width: isOpen || isHovered ? 240 : 64,
          boxSizing: "border-box",
          transition: "width 0.4s ease",
          display: "flex",
          flexDirection: "column",
          overflow: "hidden",
          paddingTop: "64px", // Thêm padding để đẩy nội dung xuống
          backgroundColor: (theme) => theme.palette.background.paper,
        },
      }}
      variant="permanent"
      anchor="left"
      open={isOpen || isHovered}
      onMouseEnter={handleMouseEnter}
      onMouseLeave={handleMouseLeave}
    >
      <Box sx={{}}>
        {/* Thanh tìm kiếm */}
        <TextField
          sx={{
            width: "100%",

            borderRadius: "30px",
            backgroundColor: (theme) => theme.palette.background.paper,
            "& .MuiOutlinedInput-root": {
              "& fieldset": {
                border: "none",
              },
              "&:hover fieldset": {
                borderColor: "none",
              },
              "&.Mui-focused fieldset": {
                borderColor: "none",
              },
            },
          }}
          placeholder="Tìm kiếm..."
          InputProps={{
            startAdornment: (
              <InputAdornment position="start">
                <SearchIcon
                  sx={{
                    color: (theme) => theme.palette.text.primary,
                    fontSize: 28,
                  }}
                />
              </InputAdornment>
            ),
          }}
        />
      </Box>
      <List sx={{ flexGrow: 1, transition: "width 0.4s ease" }}>
        <ListItem button>
          <ListItemIcon>
            <DashboardIcon
              sx={{ color: (theme) => theme.palette.primary.main }}
            />
          </ListItemIcon>
          <ListItemText primary={isOpen || isHovered ? "Dashboard" : ""} />
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <AccountBoxIcon
              sx={{ color: (theme) => theme.palette.primary.main }}
            />
          </ListItemIcon>
          <ListItemText primary={isOpen || isHovered ? "Profile" : ""} />
        </ListItem>
        <ListItem button>
          <ListItemIcon>
            <SettingsIcon
              sx={{ color: (theme) => theme.palette.primary.main }}
            />
          </ListItemIcon>
          <ListItemText primary={isOpen || isHovered ? "Settings" : ""} />
        </ListItem>
      </List>

      <List
        sx={{
          position: "fixed",
          padding: 1,
          bottom: 0,
          width: isOpen || isHovered ? "239px" : "63px",
          backgroundColor: (theme) => theme.palette.background.paper,
          borderTop: "0.5px solid #ccc ",
          transition: "width 0.1s ease",
        }}
      >
        <ListItem
          button
          sx={{
            display: "flex",
            justifyContent: isOpen || isHovered ? "flex-start" : "center",
            alignItems: "center",
            padding: 1,
          }}
        >
          <ListItemIcon sx={{ display: "flex", justifyContent: "center" }}>
            <Avatar alt="HN" src="" />
          </ListItemIcon>
          {(isOpen || isHovered) && (
            <Box
              sx={{ display: "flex", flexDirection: "column", marginLeft: 1 }}
            >
              <Typography variant="body2">Huy Nguyen</Typography>
              <Typography variant="body2" color="textSecondary">
                Quản Trị Viên
              </Typography>
            </Box>
          )}
          {(isOpen || isHovered) && (
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
          width: "240px",
          boxShadow: "0 2px 10px rgba(0, 0, 0, 0.1)", // Thêm bóng đổ
          borderRadius: "8px", // Viền bo tròn
        }}
      >
        <Box sx={{}}>
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
            <Typography sx={{ fontWeight: 500 }}>Đổi Mật Khẩu</Typography>{" "}
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
  );
};

export default DrawerMenu;
