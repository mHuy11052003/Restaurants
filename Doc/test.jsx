const menuItems = [
  {
    label: "Dashboard",
    icon: "fas fa-tachometer-alt",
    link: "/dashboard",
  },
  {
    label: "Quản Lý Thực Đơn",
    icon: "fa fa-clipboard",
    children: [
      {
        label: "Quản Lý Món Ăn",
        icon: "fas fa-utensils",
        link: "/quan-ly-mon-an",
      },
      {
        label: "Quản Lý Nhóm Món",
        icon: "fas fa-list",
        link: "/quan-ly-nhom-mon",
      },
      {
        label: "Quản Lý Giá Món",
        icon: "fas fa-money-bill-wave",
        link: "/quan-ly-gia-mon",
      },
      {
        label: "Thực Đơn Theo Thời Gian",
        icon: "fas fa-calendar-alt",
        link: "/quan-ly-menu-theo-thoi-gian",
      },
      {
        label: "Thực Đơn Số và Mã QR",
        icon: "fas fa-qrcode",
        link: "/thuc-don-so",
      },
    ],
  },
  {
    label: "Quản Lý Bàn",
    icon: "fas fa-chair",
    children: [
      {
        label: "Quản Lý Thông Tin Bàn",
        icon: "fas fa-info-circle",
        link: "/table-info",
      },
      { label: "Sơ Đồ Bàn", icon: "fas fa-map", link: "/table-layout" },
      {
        label: "Đặt Bàn Trước",
        icon: "fas fa-calendar-check",
        link: "/table-reservation",
      },
      {
        label: "Thời Gian Sử Dụng Bàn",
        icon: "fas fa-clock",
        link: "/table-usage-time",
      },
    ],
  },
  {
    label: "Quản Lý Sự Kiện",
    icon: "fas fa-gift",
    children: [
      {
        label: "Tạo Sự Kiện",
        icon: "fas fa-calendar-plus",
        link: "/event-create",
      },
      {
        label: "Quản Lý Đặt Chỗ",
        icon: "fas fa-users",
        link: "/event-booking",
      },
      {
        label: "Quản Lý Ngân Sách",
        icon: "fas fa-money-bill-alt",
        link: "/event-budget",
      },
      {
        label: "Quản Lý Khuyến Mãi",
        icon: "fas fa-gift",
        link: "/event-promotion",
      },
      {
        label: "Lịch Sự Kiện",
        icon: "fas fa-calendar-alt",
        link: "/event-calendar",
      },
      {
        label: "Thống Kê Sự Kiện",
        icon: "fas fa-chart-line",
        link: "/event-statistics",
      },
    ],
  },
  {
    label: "Quản Lý Nhân Viên",
    icon: "fas fa-users-cog",
    children: [
      {
        label: "Quản Lý Thông Tin Nhân Viên",
        icon: "fas fa-id-card-alt",
        link: "/employee-info",
      },
      {
        label: "Phân Công Công Việc",
        icon: "fas fa-tasks",
        link: "/employee-task",
      },
      {
        label: "Quản Lý Lương và Phụ Cấp",
        icon: "fas fa-dollar-sign",
        link: "/employee-salary",
      },
      {
        label: "Hiệu Suất Công Việc",
        icon: "fas fa-chart-line",
        link: "/employee-performance",
      },
      {
        label: "Vắng Mặt và Nghỉ Phép",
        icon: "fas fa-calendar-times",
        link: "/employee-leave",
      },
      {
        label: "Chính Sách Nhà Hàng",
        icon: "fas fa-gavel",
        link: "/employee-policy",
      },
    ],
  },
  {
    label: "Quản Lý Khách Hàng",
    icon: "fas fa-users",
    children: [
      {
        label: "Quản Lý Thông Tin Khách Hàng",
        icon: "fas fa-id-card",
        link: "/customer-info",
      },
      {
        label: "Lịch Sử Giao Dịch",
        icon: "fas fa-history",
        link: "/customer-transactions",
      },
      {
        label: "Khách Hàng Thân Thiết",
        icon: "fas fa-gift",
        link: "/loyalty-program",
      },
      {
        label: "Đánh Giá và Phản Hồi Khách Hàng",
        icon: "fas fa-comment-dots",
        link: "/customer-feedback",
      },
      {
        label: "Khuyến Mãi và Giảm Giá",
        icon: "fas fa-tags",
        link: "/customer-promotions",
      },
      {
        label: "Thông Báo và Khuyến Nghị",
        icon: "fas fa-bell",
        link: "/customer-notifications",
      },
    ],
  },
  {
    label: "Quản Lý Đơn Hàng và Thanh Toán",
    icon: "fas fa-cash-register",
    children: [
      {
        label: "Quản Lý Đơn Hàng",
        icon: "fas fa-box-open",
        link: "/order-management",
      },
      {
        label: "Quản Lý Thanh Toán",
        icon: "fas fa-credit-card",
        link: "/payment-management",
      },
      {
        label: "Báo Cáo Doanh Thu",
        icon: "fas fa-chart-line",
        link: "/revenue-report",
      },
      {
        label: "Chỉnh Sửa Đơn Hàng",
        icon: "fas fa-edit",
        link: "/edit-order",
      },
      {
        label: "Quản Lý Mã Giảm Giá",
        icon: "fas fa-tags",
        link: "/discount-management",
      },
    ],
  },
  {
    label: "Báo Cáo và Phân Tích",
    icon: "fas fa-chart-line",
    children: [
      {
        label: "Báo Cáo Doanh Thu",
        icon: "fas fa-dollar-sign",
        link: "/report/revenue",
      },
      {
        label: "Báo Cáo Chi Phí",
        icon: "fas fa-credit-card",
        link: "/report/expenses",
      },
      {
        label: "Báo Cáo Tình Hình Nhân Sự",
        icon: "fas fa-users",
        link: "/report/staff-performance",
      },
      {
        label: "Báo Cáo Hài Lòng Khách Hàng",
        icon: "fas fa-smile",
        link: "/report/customer-satisfaction",
      },
      {
        label: "Báo Cáo Sự Kiện",
        icon: "fas fa-calendar-alt",
        link: "/report/events",
      },
      {
        label: "Báo Cáo Marketing",
        icon: "fas fa-bullhorn",
        link: "/report/marketing",
      },
      {
        label: "Dự Báo Doanh Thu",
        icon: "fas fa-chart-bar",
        link: "/report/revenue-forecast",
      },
      {
        label: "Báo Cáo Lợi Nhuận",
        icon: "fas fa-piggy-bank",
        link: "/report/profit",
      },
    ],
  },
  {
    label: "Quảng Cáo Marketing",
    icon: "fas fa-bullhorn",
    children: [
      {
        label: "Quản Lý Chiến Dịch",
        icon: "fas fa-ad",
        link: "/campaign-management",
      },
      {
        label: "Email Marketing",
        icon: "fas fa-envelope-open-text",
        link: "/email-marketing",
      },
      {
        label: "SMS Marketing",
        icon: "fas fa-sms",
        link: "/sms-marketing",
      },
      {
        label: "Quản Lý Mạng Xã Hội",
        icon: "fas fa-share-alt",
        link: "/social-media-management",
      },
      {
        label: "Khuyến Mãi và Mã Giảm Giá",
        icon: "fas fa-tags",
        link: "/promotion-coupons",
      },
      {
        label: "Báo Cáo Marketing",
        icon: "fas fa-chart-line",
        link: "/marketing-reports",
      },
    ],
  },

  {
    label: "Quản Lý Hệ Thống",
    icon: "fas fa-cogs",
    children: [
      {
        label: "Quản Lý Tài Khoản Người Dùng",
        icon: "fas fa-users-cog",
        link: "/user-management",
      },
      {
        label: "Phân Quyền và Vai Trò",
        icon: "fas fa-user-shield",
        link: "/role-permission",
      },
      {
        label: "Cài Đặt Hệ Thống",
        icon: "fas fa-tools",
        link: "/system-settings",
      },
    ],
  },
];
