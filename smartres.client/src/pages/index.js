// pages/index.js
import React from "react";
import Breadcrumb from "../components/Breadcrumb";
import { Container, Typography } from "@mui/material";

const HomePage = () => {
  return (
    <Container sx={{ padding: "20px" }}>
      {/* Breadcrumb */}
      <Breadcrumb />

      <Typography variant="h4" gutterBottom>
        Chào mừng đến với trang chủ
      </Typography>

      <Typography variant="body1">
        Đây là nội dung của trang chủ. Bạn có thể thêm nội dung ở đây.
      </Typography>
    </Container>
  );
};

export default HomePage;
