import React from "react";
import { Box, Typography, Link, IconButton } from "@mui/material";
import {
  LinkedIn as LinkedInIcon,
  GitHub as GitHubIcon,
} from "@mui/icons-material";

const Footer = ({ isOpen, isHovered }) => {
  return (
    <Box
      component="footer"
      sx={{
        width: `calc(100% - ${isOpen || isHovered ? 240 : 64}px)`,
        backgroundColor: (theme) => theme.palette.background.default, // Màu nền tối hơn để làm nổi bật nội dung
        padding: 1,
        position: "fixed",
        bottom: 0,
        left: `${isOpen || isHovered ? 240 : 64}px`,
        transition: "left 0.3s ease, width 0.3s ease",
      }}
    >
      <Box
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          flexWrap: "wrap",
        }}
      >
        {/* Bản quyền và thông tin liên hệ */}
        <Typography
          variant="body2"
          color="text.secondary"
          sx={{ textAlign: "left" }}
        >
          © 2024 Nguyễn Minh Huy. All rights reserved.
        </Typography>

        {/* Các liên kết hỗ trợ */}
        <Box sx={{ display: "flex", gap: 2 }}>
          <Link
            href="/docs"
            color="inherit"
            sx={{
              display: "flex",
              alignItems: "center",
              fontWeight: 600,
              paddingRight: 5,
              letterSpacing: "0.5px",
              "&:hover": {
                color: (theme) => theme.palette.primary.main, // Hiệu ứng hover với màu chủ đạo
              },
            }}
          >
            Chính Sách Nhà Hàng
          </Link>
          <Link
            href="/support"
            color="inherit"
            sx={{
              display: "flex",
              alignItems: "center",
              fontWeight: 600,
              letterSpacing: "0.5px",
              paddingRight: 5,
              "&:hover": {
                color: (theme) => theme.palette.primary.main, // Hiệu ứng hover với màu chủ đạo
              },
            }}
          >
            Hỗ Trợ
          </Link>
        </Box>
      </Box>
    </Box>
  );
};

export default Footer;
