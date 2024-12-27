import { createTheme } from "@mui/material/styles";

// Tạo theme với hai chế độ sáng/tối
const getDesignTokens = (mode) => ({
  palette: {
    mode, // 'light' hoặc 'dark'
    ...(mode === "light"
      ? {
          // Cấu hình cho chế độ sáng (Light Mode)
          primary: {
            main: "#FF7F50", // Cam san hô: Màu chính cho các yếu tố chính
          },
          secondary: {
            main: "#FF6347", // Cam cà chua: Màu phụ cho các yếu tố phụ
          },
          background: {
            default: "#FFF7E6", // Nền chính: Cam nhạt
            paper: "#FFF7E6", // Nền cho các thẻ: Cam nhạt
          },
          text: {
            primary: "#212529", // Màu chữ chính: Đen nhạt
            secondary: "#6C757D", // Màu chữ phụ: Xám nhạt
          },
          divider: "#CED4DA", // Màu đường phân cách: Xám nhạt
          action: {
            active: "#FF7F50", // Màu của các hành động (hover, focus, v.v.)
            hover: "rgba(255, 127, 80, 0.08)", // Màu khi hover trên các thành phần
            selected: "rgba(255, 127, 80, 0.16)", // Màu khi thành phần được chọn
          },
          // Các màu khác có thể cần tùy chỉnh thêm
          error: {
            main: "#DC3545", // Màu lỗi: Đỏ
          },
          success: {
            main: "#28A745", // Màu thành công: Xanh lá
          },
          warning: {
            main: "#FFC107", // Màu cảnh báo: Vàng
          },
          info: {
            main: "#17A2B8", // Màu thông tin: Xanh dương
          },
        }
      : {
          // Cấu hình cho chế độ tối (Dark Mode)
          primary: {
            main: "#FF8A65", // Cam san hô: Màu chính
          },
          secondary: {
            main: "#FF6B6B", // Đỏ nhạt: Màu phụ
          },
          background: {
            default: "#212529", // Nền chính: Xám đen
            paper: "#212529", // Nền cho các thẻ: Xám tối
          },
          text: {
            primary: "#E0E0E0", // Màu chữ chính: Trắng sáng
            secondary: "#B0B3B8", // Màu chữ phụ: Xám nhạt
          },
          divider: "#3A3B3C", // Màu đường phân cách: Xám tối
          action: {
            active: "#FF6347", // Màu của các hành động (hover, focus, v.v.)
            hover: "rgba(255, 99, 71, 0.08)", // Màu khi hover trên các thành phần
            selected: "rgba(255, 99, 71, 0.16)", // Màu khi thành phần được chọn
          },
          // Các màu khác có thể cần tùy chỉnh thêm
          error: {
            main: "#DC3545", // Màu lỗi: Đỏ
          },
          success: {
            main: "#28A745", // Màu thành công: Xanh lá
          },
          warning: {
            main: "#FFC107", // Màu cảnh báo: Vàng
          },
          info: {
            main: "#17A2B8", // Màu thông tin: Xanh dương
          },
        }),
  },
  typography: {
    fontFamily: '"Roboto", "Helvetica", "Arial", sans-serif',
    fontSize: 12,
    h1: { fontSize: "2.2rem" },
    h2: { fontSize: "2rem" },
    h3: { fontSize: "1.8rem" },
    h4: { fontSize: "1.6rem" },
    h5: { fontSize: "1.4rem" },
    h6: { fontSize: "1.2rem" },
  },
  components: {
    MuiButton: {
      styleOverrides: {
        root: {
          textTransform: "none", // Không in hoa chữ
          borderRadius: 4, // Bo góc nút
        },
      },
    },
    MuiTextField: {
      styleOverrides: {
        root: {
          margin: "10px 0",
        },
      },
    },
    MuiCard: {
      styleOverrides: {
        root: {
          borderRadius: 8,
        },
      },
    },
  },
  shape: {
    borderRadius: 10,
  },
  spacing: 4,
  breakpoints: {
    values: {
      xs: 0,
      sm: 600,
      md: 900,
      lg: 1200,
      xl: 1536,
    },
  },
});

export default function createAppTheme(mode) {
  return createTheme(getDesignTokens(mode));
}
