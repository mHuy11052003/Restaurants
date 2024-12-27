namespace SmartRes.Server.Shared.Utilities
{
	public class Type
	{
		// Enum cho trạng thái đơn hàng
		public enum OrderStatus
		{
			Pending = 1,     // Đang chờ xử lý
			Confirmed = 2,   // Đã xác nhận
			Shipped = 3,     // Đã gửi
			Delivered = 4,   // Đã giao
			Canceled = 5     // Đã hủy
		}

		// Enum cho trạng thái thanh toán
		public enum PaymentStatus
		{
			Pending = 1,     // Đang chờ thanh toán
			Paid = 2,        // Đã thanh toán
			Failed = 3,      // Thanh toán thất bại
			Refunded = 4     // Đã hoàn tiền
		}

		// Enum cho trạng thái người dùng
		public enum UserStatus
		{
			Active = 1,      // Người dùng hoạt động
			Inactive = 2,    // Người dùng không hoạt động
			Banned = 3,     // Người dùng bị cấm
			PendingApproval = 4 // Người dùng đang chờ duyệt
		}

		// Enum cho trạng thái kho
		public enum InventoryStatus
		{
			InStock = 1,     // Còn hàng
			OutOfStock = 2,  // Hết hàng
			LowStock = 3,    // Sắp hết hàng
			Discontinued = 4 // Ngừng sản xuất
		}

		// Enum cho trạng thái của một yêu cầu hỗ trợ
		public enum SupportTicketStatus
		{
			Open = 1,        // Mở
			InProgress = 2,  // Đang xử lý
			Resolved = 3,    // Đã giải quyết
			Closed = 4       // Đã đóng
		}

		// Enum cho trạng thái của một món ăn (trong nhà hàng)
		public enum DishStatus
		{
			Available = 1,   // Có sẵn
			Unavailable = 2, // Không có sẵn
			OutOfStock = 3   // Hết hàng
		}

		// Enum cho trạng thái của một sản phẩm trong giỏ hàng
		public enum CartItemStatus
		{
			Added = 1,       // Đã thêm vào giỏ hàng
			Removed = 2,     // Đã xóa khỏi giỏ hàng
			Purchased = 3    // Đã mua
		}

		// Enum cho trạng thái của một công việc
		public enum TaskStatus
		{
			NotStarted = 1,  // Chưa bắt đầu
			InProgress = 2,  // Đang tiến hành
			Completed = 3,   // Đã hoàn thành
			OnHold = 4       // Tạm dừng
		}

		// Enum cho trạng thái của một đánh giá
		public enum ReviewStatus
		{
			Pending = 1,     // Đang chờ duyệt
			Approved = 2,    // Được duyệt
			Rejected = 3     // Bị từ chối
		}

		// Enum cho trạng thái của một sự kiện
		public enum EventStatus
		{
			Upcoming = 1,    // Sắp diễn ra
			Ongoing = 2,     // Đang diễn ra
			Completed = 3,   // Đã hoàn thành
			Canceled = 4     // Đã hủy
		}

		// Enum cho trạng thái của một nhà cung cấp
		public enum SupplierStatus
		{
			Active = 1,      // Nhà cung cấp hoạt động
			Inactive = 2,    // Nhà cung cấp không hoạt động
			Suspended = 3,   // Nhà cung cấp bị đình chỉ
			Terminated = 4   // Nhà cung cấp đã chấm dứt hợp đồng
		}
	}
}
