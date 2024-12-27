import React, { useState, useEffect } from "react";
import {
  AppBar,
  Box,
  IconButton,
  Badge,
  Toolbar,
  Typography,
  Paper,
  Popover,
  List,
  ListItem,
  ListItemText,
  Divider,
  Avatar,
  Menu,
  MenuItem,
  CircularProgress,
  Tooltip,
  Chip,
  TextField,
  InputAdornment,
  FormControl,
  Button,
  Select,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";
import DeleteIcon from "@mui/icons-material/Delete";
import InfoIcon from "@mui/icons-material/Info";
import MenuIcon from "@mui/icons-material/Menu";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import SearchIcon from "@mui/icons-material/Search";
import MenuIconOpen from "@mui/icons-material/MenuOpen";
import NotificationsIcon from "@mui/icons-material/Notifications";
import CalendarTodayIcon from "@mui/icons-material/CalendarToday";
import RefreshIcon from "@mui/icons-material/Refresh";
import LanguageIcon from "@mui/icons-material/Language";
import CustomSwitch from "./CustomSwitch";
import Calendar from "react-calendar";
import "react-calendar/dist/Calendar.css";
import "./Header.css";
import logo_light_ngang from "../../assets/images/logo/light-ngang.png";
import logo_light_doc from "../../assets/images/logo/light-doc.png";

// Cờ ngôn ngữ
import VietFlag from "../../assets/images/flags/vn-flag.png";
import EnFlag from "../../assets/images/flags/en-flag.png";

const Header = ({ isOpen, isHovered, toggleDrawer, changeMode, theme }) => {
  const [currentTime, setCurrentTime] = useState("");
  const [anchorEl, setAnchorEl] = useState(null);
  const [isCalendarOpen, setIsCalendarOpen] = useState(false);
  const [notificationsAnchorEl, setNotificationsAnchorEl] = useState(null);
  const [languageAnchorEl, setLanguageAnchorEl] = useState(null);
  const [loading, setLoading] = useState(false);

  // Danh sách thông báo mẫu
  const notifications = [
    { title: "Thông báo 1", description: "Mô tả thông báo 1", type: "info" },
    { title: "Thông báo 2", description: "Mô tả thông báo 2", type: "warning" },
    { title: "Thông báo 3", description: "Mô tả thông báo 3", type: "error" },
  ];

  // Hàm để lấy thời gian hiện tại
  const updateTime = () => {
    const now = new Date();
    const formattedTime = now.toLocaleTimeString("vi-VN", {
      hour: "2-digit",
      minute: "2-digit",
      second: "2-digit",
    });
    const formattedDate = now.toLocaleDateString("vi-VN");
    setCurrentTime(`${formattedDate} ${formattedTime}`);
  };

  // Cập nhật giờ mỗi giây
  useEffect(() => {
    updateTime();
    const interval = setInterval(updateTime, 1000);

    return () => clearInterval(interval);
  }, []);

  // Mở/đóng Popover lịch
  const handleCalendarOpen = (event) => {
    setAnchorEl(event.currentTarget);
    setIsCalendarOpen(true);
  };

  const handleCalendarClose = () => {
    setIsCalendarOpen(false);
  };

  // Mở/đóng Popover thông báo
  const handleNotificationsClick = (event) => {
    setNotificationsAnchorEl(event.currentTarget);
  };

  const handleNotificationsClose = () => {
    setNotificationsAnchorEl(null);
  };

  // Mở/đóng menu ngôn ngữ
  const handleLanguageClick = (event) => {
    setLanguageAnchorEl(event.currentTarget);
  };

  const handleLanguageClose = () => {
    setLanguageAnchorEl(null);
  };

  // Hàm refresh trang
  const handleRefresh = () => {
    setLoading(true);
    setTimeout(() => {
      setLoading(false);
      window.location.reload();
    }, 1000);
  };

  const handleGoBack = () => {
    window.history.back(); // Hoặc điều hướng đến trang trước
  };

  // Hàm xử lý khi nhấn nút "Thêm"
  const handleAdd = () => {
    alert("Thêm mới thành công!");
    // Thực hiện logic thêm ở đây (ví dụ: mở form thêm, gọi API...)
  };

  // Hàm xử lý khi nhấn nút "Xóa"
  const handleDelete = () => {
    if (window.confirm("Bạn có chắc muốn xóa không?")) {
      alert("Xóa thành công!");
      // Thực hiện logic xóa ở đây (ví dụ: gọi API xóa...)
    }
  };

  // Hàm xử lý khi nhấn nút "Chi Tiết"
  const handleViewDetails = () => {
    alert("Xem chi tiết!");
    // Thực hiện logic xem chi tiết ở đây (ví dụ: chuyển hướng đến trang chi tiết)
  };
  return (
    <Box
      component="header"
      sx={{
        width: "100%",
        backgroundColor: (theme) => theme.palette.background.paper,
        padding: 2,
        position: "fixed",
        top: 0,
        zIndex: 1201,
        transition: "left 0.3s ease, width 0.3s ease",
      }}
    >
      <AppBar
        position="fixed"
        sx={{
          width: "100%",
          backgroundColor: (theme) => theme.palette.primary.main,
          boxShadow: 3,
          transition: "width 0.3s ease",
        }}
      >
        <Toolbar
          sx={{ paddingLeft: "0 !important", paddingRight: "0 !important" }}
        >
          <Box
            sx={{
              height: 64,
              width: isOpen || isHovered ? "240px" : "64",
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
              transition: "width 0.3s ease-in-out", // Thêm chuyển động cho width
            }}
          >
            <img
              src={
                isOpen || isHovered ? logo_light_ngang.src : logo_light_doc.src
              }
              alt="Logo"
              style={{
                maxWidth: "80%",
                maxHeight: "100%",
                objectFit: "contain",
                transition: "all 0.3s ease-in-out", // Thêm chuyển động cho mọi thay đổi
              }}
            />
          </Box>
          <Tooltip
            title={isOpen || isHovered ? "Thu Gọn Menu" : "Mở Rộng Menu"}
          >
            <IconButton
              color="inherit"
              edge="start"
              sx={{ mr: 2, paddingLeft: "20px" }}
              onClick={toggleDrawer}
            >
              {isOpen || isHovered ? <MenuIconOpen /> : <MenuIcon />}
            </IconButton>
          </Tooltip>

          <Box
            sx={{
              flexGrow: 1,
              display: "flex",
              justifyContent: "center",
              alignItems: "center",
            }}
          >
            {/* Thanh tìm kiếm */}
            <TextField
              sx={{
                width: "100%",
                maxWidth: 400,
                borderRadius: "30px",
                backgroundColor: theme.palette.background.paper,
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
                      sx={{ color: theme.palette.text.primary, fontSize: 28 }}
                    />
                  </InputAdornment>
                ),
              }}
            />
          </Box>

          {/* Hiển thị thời gian hiện tại */}
          <Box sx={{ display: "flex", alignItems: "center", marginRight: 2 }}>
            <Tooltip title="Lịch">
              <Paper
                sx={{
                  padding: "8px 16px",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "center",
                  borderRadius: 2,
                  boxShadow: 3,
                  cursor: "pointer",
                }}
                onClick={handleCalendarOpen}
              >
                <Typography
                  variant="body2"
                  color="text.primary"
                  sx={{ mr: 1, paddingTop: "3px" }}
                >
                  {currentTime}
                </Typography>
                <CalendarTodayIcon />
              </Paper>
            </Tooltip>
            <Popover
              open={isCalendarOpen}
              anchorEl={anchorEl}
              onClose={handleCalendarClose}
              anchorOrigin={{
                vertical: "bottom",
                horizontal: "left",
              }}
              transformOrigin={{
                vertical: "top",
                horizontal: "left",
              }}
            >
              <Calendar />
            </Popover>
          </Box>

          {/* Nút Refresh */}
          <Tooltip title="Tải Lại Trang">
            <IconButton color="inherit" onClick={handleRefresh}>
              {loading ? (
                <CircularProgress size={24} color="inherit" />
              ) : (
                <RefreshIcon />
              )}
            </IconButton>
          </Tooltip>

          {/* Nút Ngôn Ngữ */}
          <Tooltip title="Chọn ngôn ngữ">
            <IconButton color="inherit" onClick={handleLanguageClick}>
              <LanguageIcon />
            </IconButton>
          </Tooltip>
          <Menu
            anchorEl={languageAnchorEl}
            open={Boolean(languageAnchorEl)}
            onClose={handleLanguageClose}
            PaperProps={{
              sx: {
                width: 200,
                boxShadow: "0 4px 12px rgba(0, 0, 0, 0.15)",
                borderRadius: "8px",
              },
            }}
          >
            <MenuItem
              sx={{
                display: "flex",
                alignItems: "center",
                "&:hover": {
                  cursor: "pointer",
                },
              }}
            >
              <Avatar
                src={VietFlag.src}
                sx={{ width: 24, height: 24, mr: 2 }}
              />
              Tiếng Việt
            </MenuItem>
            <Divider sx={{ my: 1 }} /> {/* Kẻ ngăn giữa các mục menu */}
            <MenuItem
              sx={{
                display: "flex",
                alignItems: "center",
                "&:hover": {
                  cursor: "pointer",
                },
              }}
            >
              <Avatar src={EnFlag.src} sx={{ width: 24, height: 24, mr: 2 }} />
              English
            </MenuItem>
          </Menu>

          {/* Thông báo */}

          <Tooltip title="Thông Báo">
            <IconButton color="inherit" onClick={handleNotificationsClick}>
              <Badge badgeContent={3} color="error">
                <NotificationsIcon />
              </Badge>
            </IconButton>
          </Tooltip>
          {/* Popover thông báo */}
          <Popover
            open={Boolean(notificationsAnchorEl)}
            anchorEl={notificationsAnchorEl}
            onClose={handleNotificationsClose}
            anchorOrigin={{
              vertical: "bottom",
              horizontal: "left",
            }}
            transformOrigin={{
              vertical: "top",
              horizontal: "left",
            }}
            className="custom-popover-noti" // Áp dụng className tùy chỉnh
          >
            <Typography
              variant="h6"
              color="text.primary"
              sx={{
                textAlign: "center", // Căn giữa chữ
                fontWeight: "bold", // Làm đậm tiêu đề
                padding: "4px 0", // Khoảng cách trên dưới
                fontSize: "1.2rem", // Kích thước chữ lớn hơn một chút
              }}
            >
              Thông báo
            </Typography>
            <Divider sx={{ marginBottom: 1 }} />
            <List sx={{ maxHeight: 300, overflowY: "auto" }}>
              {notifications.map((notification, index) => (
                <ListItem key={index}>
                  <Avatar
                    sx={{
                      backgroundColor:
                        notification.type === "info"
                          ? theme.palette.info.main
                          : notification.type === "warning"
                            ? theme.palette.warning.main
                            : theme.palette.error.main,
                      width: 30,
                      height: 30,
                    }}
                  >
                    <NotificationsIcon sx={{ color: "white" }} />
                  </Avatar>
                  <ListItemText
                    primary={notification.title}
                    secondary={notification.description}
                    sx={{ marginLeft: 5 }}
                  />
                  <Chip
                    label={notification.type}
                    color={
                      notification.type === "info"
                        ? "info"
                        : notification.type === "warning"
                          ? "warning"
                          : "error"
                    }
                    size="small"
                  />
                </ListItem>
              ))}
            </List>
          </Popover>

          <Tooltip title="Sáng / Tối">
            <Box
              sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
              }}
            >
              <CustomSwitch
                checked={theme.palette.mode === "dark"}
                onChange={changeMode}
              />
            </Box>
          </Tooltip>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default Header;
