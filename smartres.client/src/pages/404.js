// pages/404.js
import React from "react";
import { useRouter } from "next/router";
import { Box, Typography, Button } from "@mui/material";
import ErrorIcon from "@mui/icons-material/Error";

const PageNotFound = () => {
  const router = useRouter();

  const handleRedirect = () => {
    router.push("/"); // Chuyển hướng về trang chủ
  };

  return (
    <Box
      sx={{
        height: "80vh",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
        textAlign: "center",
        padding: 4,
        animation: "fadeIn 1s ease-in-out", // Hiệu ứng fade in
        "@keyframes fadeIn": {
          from: { opacity: 0 },
          to: { opacity: 1 },
        },
      }}
    >
      <ErrorIcon sx={{ fontSize: 100, color: "error.main", marginBottom: 2 }} />
      <Typography
        variant="h1"
        sx={{
          fontSize: { xs: "4rem", md: "6rem" },
          fontWeight: "bold",
          textShadow: "2px 2px 4px rgba(0, 0, 0, 0.3)",
        }}
      >
        404
      </Typography>
      <Typography
        variant="h4"
        color="text.secondary"
        sx={{ marginTop: 2, fontSize: { xs: "1rem", md: "1.5rem" } }}
      >
        Oops! Xin lỗi, chúng tôi đang bảo trì...
      </Typography>
      <Typography
        variant="body1"
        color="text.primary"
        sx={{ marginTop: 2, fontSize: { xs: "1rem", md: "1.5rem" } }}
      >
        Thật không may, trang web hiện đang ngừng hoạt động để bảo trì một chút.
        Nhưng chúng tôi đang cố gắng hết sức để khôi phục mọi thứ.
      </Typography>
      <Button
        variant="contained"
        onClick={handleRedirect}
        sx={{
          marginTop: 4,
          padding: "10px 20px",
          fontSize: "1rem",
          backgroundColor: "#FFC107",
          color: "#000",
          boxShadow: "0px 4px 6px rgba(0, 0, 0, 0.2)",
          borderRadius: "50px",
          transition: "transform 0.3s ease, background-color 0.3s ease",
          "&:hover": {
            backgroundColor: "#FFD54F",
            transform: "scale(1.05)",
          },
        }}
      >
        Trở Về Trang Chủ
      </Button>
    </Box>
  );
};

export default PageNotFound;
