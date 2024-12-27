import React from "react";
import { Button, Typography, Box, Container, Paper } from "@mui/material";

const SessionExpired = () => {
  const handleLoginAgain = () => {
    // Điều hướng hoặc gọi API để đăng nhập lại
    window.location.href = "/login";
  };

  const handleGoHome = () => {
    // Điều hướng về trang chính
    window.location.href = "/";
  };

  return (
    <Container
      maxWidth="sm"
      sx={{
        height: "80vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Paper
        elevation={3}
        sx={{
          padding: "32px",
          textAlign: "center",
          borderRadius: "8px",
        }}
      >
        <Typography
          variant="h4"
          gutterBottom
          sx={{
            fontWeight: "bold",
          }}
        >
          Phiên làm việc đã hết hạn
        </Typography>
        <Typography
          variant="body1"
          gutterBottom
          sx={{
            marginBottom: "24px",
          }}
        >
          Vì lý do bảo mật, phiên làm việc của bạn đã hết hạn. <br />
          Vui lòng đăng nhập lại để tiếp tục.
        </Typography>
        <Box sx={{ display: "flex", justifyContent: "center", gap: 2 }}>
          <Button
            variant="contained"
            color="primary"
            onClick={handleLoginAgain}
            sx={{
              marginTop: 4,
              marginRight: 4,
              padding: "10px 20px",
              fontSize: "1rem",
              boxShadow: "0px 4px 6px rgba(0, 0, 0, 0.2)",
              borderRadius: "50px",
              transition: "transform 0.3s ease, background-color 0.3s ease",
              "&:hover": {
                backgroundColor: "#FFD54F",
                transform: "scale(1.05)",
              },
            }}
          >
            Đăng Nhập Lại
          </Button>
          <Button
            variant="outlined"
            color="secondary"
            onClick={handleGoHome}
            sx={{
              marginTop: 4,
              marginLeft: 4,
              padding: "10px 20px",
              fontSize: "1rem",
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
      </Paper>
    </Container>
  );
};

export default SessionExpired;
