import React from "react";
import { Box, Typography, Button } from "@mui/material";
import { useRouter } from "next/router";
import NoEncryptionGmailerrorredIcon from "@mui/icons-material/NoEncryptionGmailerrorred";

const ForbiddenPage = () => {
  const router = useRouter();

  const handleGoBack = () => {
    router.push("/"); // Điều hướng về trang chủ hoặc trang khác bạn muốn
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
      <NoEncryptionGmailerrorredIcon
        sx={{ fontSize: 100, color: "error.main", marginBottom: 2 }}
      />
      <Typography
        variant="h1"
        sx={{
          fontSize: { xs: "4rem", md: "6rem" },
          fontWeight: "bold",
          textShadow: "2px 2px 4px rgba(0, 0, 0, 0.3)",
        }}
      >
        403
      </Typography>
      <Typography
        variant="h6"
        sx={{
          marginTop: 2,
          fontSize: { xs: "1rem", md: "1.5rem" },
        }}
      >
        Bạn không có quyền truy cập vào trang này.
      </Typography>
      <Button
        variant="contained"
        onClick={handleGoBack}
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
        Quay về trang chủ
      </Button>
    </Box>
  );
};

export default ForbiddenPage;
