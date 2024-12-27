import React from "react";
import { Box, Typography } from "@mui/material";

import "../styles/LoadingPage.css";

const Loader = () => {
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
      <div className="loader">
        <div className="tall-stack">
          <div className="butter falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="pancake falling-element"></div>
          <div className="plate">
            <div className="plate-bottom"></div>
            <div className="shadow"></div>
          </div>
        </div>
      </div>
      <Typography
        variant="h6"
        sx={{
          marginTop: 10,
          fontSize: { xs: "1rem", md: "1.5rem" },
        }}
      >
        Hệ thống đang xử lý, xin chờ trong giây lát...
      </Typography>
    </Box>
  );
};

export default Loader;
