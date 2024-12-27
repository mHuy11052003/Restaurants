import { useState } from "react";
import { Box, Container } from "@mui/material";
import { useTheme } from "@mui/material/styles";
import DrawerMenu from "../components/SideNav/DrawerMenu"; // Import DrawerMenu
import Header from "../components/Header/Header"; // Import Header
import Footer from "../components/Footer/Footer"; // Import Footer component

export default function Layout({ children, changeMode }) {
  const [isOpen, setOpen] = useState(true); // Điều khiển trạng thái của Sidenav (mở/thu gọn)
  const [isHovered, setIsHovered] = useState(false); // Trạng thái hover
  const [openPopover, setOpenPopover] = useState(false);
  const [anchorEl, setAnchorEl] = useState(null);

  const theme = useTheme(); // Lấy theme hiện tại (sáng/tối)

  // Hàm để thay đổi trạng thái Drawer khi nhấn nút
  const toggleDrawer = () => {
    setOpen((prev) => !prev); // Đảo trạng thái mở rộng/thu gọn
  };

  // Hàm để xử lý khi hover vào và ra
  const handleMouseEnter = () => {
    if (!isOpen) {
      // Nếu không mở rộng, khi hover vào thì mở rộng
      setIsHovered(true);
    }
  };

  const handleMouseLeave = () => {
    if (!isOpen) {
      // Nếu không mở rộng, khi bỏ chuột thì thu gọn
      setIsHovered(false);
    }
  };

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
    setOpenPopover(true);
  };

  const handleClose = () => {
    setOpenPopover(false);
  };

  return (
    <Box sx={{ display: "flex", height: "100vh" }}>
      {/* Sidenav */}
      {/* Sidenav (Drawer) */}
      <DrawerMenu
        isOpen={isOpen}
        toggleDrawer={toggleDrawer}
        isHovered={isHovered}
        handleMouseEnter={handleMouseEnter}
        handleMouseLeave={handleMouseLeave}
        openPopover={openPopover}
        handleClick={handleClick}
        handleClose={handleClose}
        anchorEl={anchorEl}
      />

      <Header
        isOpen={isOpen}
        isHovered={isHovered}
        toggleDrawer={toggleDrawer}
        changeMode={changeMode}
        theme={theme}
      />

      {/* Main Content */}
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          padding: 2,
          backgroundColor: (theme) => theme.palette.background.default, // Sử dụng background từ theme
          minHeight: "80vh",
          width: `calc(100% - ${isOpen || isHovered ? 240 : 64}px)`, // Điều chỉnh độ rộng khi thu gọn
          marginTop: "64px", // Cung cấp không gian cho header cố định
        }}
      >
        <Container
          maxWidth="xl"
          sx={{ transition: "left 0.3s ease, width 0.3s ease" }}
        >
          {children}
        </Container>
      </Box>

      <Footer isOpen={isOpen} isHovered={isHovered} />
    </Box>
  );
}
