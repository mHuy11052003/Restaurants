// components/Breadcrumb.js
import React from "react";
import { Breadcrumbs, Link, Typography } from "@mui/material";
import { useRouter } from "next/router";
import NavigateNextIcon from "@mui/icons-material/NavigateNext";

const Breadcrumb = () => {
  const router = useRouter();
  const { pathname } = router;

  // Tách đường dẫn thành các phần (split by '/')
  const pathSegments = pathname.split("/").filter((segment) => segment);

  return (
    <Breadcrumbs
      separator={<NavigateNextIcon fontSize="small" />}
      aria-label="breadcrumb"
      sx={{ marginTop: 2, marginBottom: 2 }}
    >
      {/* Trang chủ */}
      <Link color="inherit" href="/">
        Trang chủ
      </Link>

      {/* Duyệt qua các phần của URL và hiển thị */}
      {pathSegments.map((segment, index) => {
        const path = `/${pathSegments.slice(0, index + 1).join("/")}`;

        return index === pathSegments.length - 1 ? (
          <Typography key={path} color="text.primary">
            {segment}
          </Typography>
        ) : (
          <Link key={path} color="inherit" href={path}>
            {segment}
          </Link>
        );
      })}
    </Breadcrumbs>
  );
};

export default Breadcrumb;
