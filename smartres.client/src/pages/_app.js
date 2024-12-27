import { useState, useEffect } from "react";
import { ThemeProvider } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import theme from "@/styles/theme.js";
import Layout from "../layouts/layout";
import "../styles/globals.css";
import { useRouter } from "next/router";
import LoadingPage from "./LoadingPage"; // Import trang loading

export default function MyApp({ Component, pageProps }) {
  const [mode, setMode] = useState("light");
  const [loading, setLoading] = useState(false); // Thêm state để theo dõi loading
  const router = useRouter();

  useEffect(() => {
    const savedMode = localStorage.getItem("mode");
    if (savedMode) {
      setMode(savedMode);
    } else {
      const prefersDarkMode = window.matchMedia(
        "(prefers-color-scheme: dark)"
      ).matches;
      setMode(prefersDarkMode ? "dark" : "light");
    }

    // Xử lý sự kiện chuyển trang
    const handleStart = () => setLoading(true);
    const handleComplete = () => setLoading(false);

    router.events.on("routeChangeStart", handleStart); // Khi bắt đầu chuyển trang
    router.events.on("routeChangeComplete", handleComplete); // Khi chuyển trang xong
    router.events.on("routeChangeError", handleComplete); // Nếu có lỗi xảy ra

    // Cleanup listener khi component unmount
    return () => {
      router.events.off("routeChangeStart", handleStart);
      router.events.off("routeChangeComplete", handleComplete);
      router.events.off("routeChangeError", handleComplete);
    };
  }, [router]);

  const handleChangeMode = () => {
    const newMode = mode === "light" ? "dark" : "light";
    setMode(newMode);
    localStorage.setItem("mode", newMode);
  };

  if (loading) {
    return <LoadingPage />; // Hiển thị trang loading khi đang chuyển hướng
  }

  return (
    <ThemeProvider theme={theme(mode)}>
      <CssBaseline />
      <Layout changeMode={handleChangeMode}>
        <Component {...pageProps} />
      </Layout>
    </ThemeProvider>
  );
}
