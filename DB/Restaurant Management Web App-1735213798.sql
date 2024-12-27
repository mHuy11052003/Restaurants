CREATE TABLE [Restaurants] (-- Tên nhà hàng
 [name] nvarchar(255) DEFAULT '255', -- Địa chỉ nhà hàng
 [location] nvarchar(255) DEFAULT '255', -- Số điện thoại liên hệ
 [contact_number] nvarchar(15) DEFAULT '15', -- Địa chỉ email
 [email] nvarchar(255) DEFAULT '255', -- Giờ mở cửa
 [opening_hours] nvarchar(100) DEFAULT '100', -- Loại ẩm thực
 [cuisine_type] nvarchar(100) DEFAULT '100', -- Đánh giá của nhà hàng
 [rating] float(53), -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái nhà hàng
 [status] tinyint, -- Địa chỉ website
 [website] nvarchar(255) DEFAULT '255', -- ID quản lý nhà hàng
 [manager_id_fk] uniqueidentifier, -- Sức chứa của nhà hàng
 [seating_capacity] int, -- Mã định danh của nhà hàng
 [restaurant_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mô tả nhà hàng
 [description] nvarchar(255), -- Khóa chính
 PRIMARY KEY ([restaurant_id]));


CREATE TABLE [Menus] (-- Tên menu, không có giá trị mặc định
 [menu_name] nvarchar(255), -- Mô tả menu
 [description] nvarchar(MAX), -- Thời gian tạo menu
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật menu
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái menu (hoạt động hay không)
 [status] tinyint, -- Xác định menu có phải là đặc biệt không
 [is_special] bit, -- Khoảng giá của menu
 [price_range] nvarchar(50) DEFAULT '50', -- Loại menu (ví dụ: chính, phụ)
 [menu_type] nvarchar(50) DEFAULT '10', -- URL ảnh của menu
 [image_url] nvarchar(255), -- Thời gian bắt đầu menu có sẵn
 [available_from] datetime, -- Thời gian kết thúc menu có sẵn
 [available_to] datetime, -- ID người tạo menu
 [created_by] uniqueidentifier, -- Mã định danh của menu
 [menu_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- ID nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- ID người cập nhật menu
 [updated_by] uniqueidentifier, -- Khóa chính
 PRIMARY KEY ([menu_id]),);


CREATE TABLE [MenuItems] (-- Mã định danh của món ăn
 [item_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- ID menu (khóa ngoại)
 [menu_id_fk] uniqueidentifier, -- Tên món ăn
 [item_name] nvarchar(255) NOT NULL, -- Mô tả món ăn
 [description] nvarchar(MAX), -- Giá món ăn
 [price] decimal(18, 2) NOT NULL, -- Sử dụng decimal(18,2) thay vì decimal(18,0) cho giá trị có phần thập phân.
 -- Trạng thái món ăn (có sẵn hay không)
 [is_available] bit, -- Thời gian tạo món ăn
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật món ăn
 [updated_at] datetime DEFAULT GETDATE(), -- URL ảnh của món ăn
 [image_url] nvarchar(255), -- Loại món ăn (ví dụ: chính, phụ)
 [item_type] nvarchar(50), -- Mức độ cay của món ăn
 [spice_level] nvarchar(50), -- Lượng calo trong món ăn
 [calories] int, -- ID người tạo món ăn
 [created_by] uniqueidentifier, -- ID người cập nhật món ăn
 [updated_by] uniqueidentifier, -- Trạng thái món ăn (hoạt động hay không)
 [status] tinyint, -- Thành phần gây dị ứng trong món ăn
 [allergens] nvarchar(255), -- Khóa chính
 PRIMARY KEY ([item_id]),);


CREATE TABLE [Orders] (-- Mã đơn hàng
 [order_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- ID khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- ID nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Ngày đặt hàng
 [order_date] datetime DEFAULT GETDATE(), -- Tổng số tiền
 [total_amount] decimal(18, 2), -- Sửa thành decimal(18,2) để hỗ trợ phần thập phân
 -- Trạng thái đơn hàng
 [status] tinyint, -- Phương thức thanh toán
 [payment_method] nvarchar(50) DEFAULT '10', -- Nên giới hạn độ dài, nếu có thể sử dụng khóa ngoại
 -- Thời gian tạo đơn hàng
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật đơn hàng
 [updated_at] datetime DEFAULT GETDATE(), -- Địa chỉ giao hàng
 [delivery_address] nvarchar(255) DEFAULT '255', -- Yêu cầu đặc biệt
 [special_requests] nvarchar(MAX), -- Trạng thái thanh toán (đã thanh toán hay chưa)
 [is_paid] bit, -- Thời gian giao hàng (nên dùng datetime nếu muốn bao gồm cả ngày)
 [delivery_time] time(7), -- Phản hồi của khách hàng
 [customer_feedback] nvarchar(MAX), -- Mã giảm giá
 [discount_code] nvarchar(50) DEFAULT '50', -- Giới hạn độ dài cho mã giảm giá
 -- Khóa chính
 PRIMARY KEY ([order_id]),);


CREATE TABLE [OrderItems] (-- Yêu cầu đặc biệt của món ăn
 [special_requests] nvarchar(255), -- Giới hạn chiều dài nếu không cần thiết phải dùng nvarchar(max)
 -- Thời gian tạo món ăn trong đơn
 [created_at] datetime DEFAULT GETDATE(), -- Mã định danh của món ăn trong đơn
 [order_item_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- ID đơn hàng (khóa ngoại)
 [order_id_fk] uniqueidentifier, -- ID món ăn (khóa ngoại)
 [item_id_fk] uniqueidentifier, -- Số lượng món ăn
 [quantity] int CHECK (quantity >= 0), -- Kiểm tra số lượng phải là số không âm
 -- Giá món ăn
 [price] decimal(18, 2), -- Sửa thành decimal(18,2) để hỗ trợ phần thập phân
 -- Thời gian cập nhật món ăn trong đơn
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái món ăn trong đơn (hoàn thành hay chưa)
 [status] tinyint, -- Giảm giá cho món ăn
 [discount] decimal(18, 2), -- Sửa thành decimal(18,2) để hỗ trợ phần thập phân
 -- Trạng thái hoàn tiền (hoàn tiền hay không)
 [is_refunded] bit, -- ID người tạo đơn món ăn
 [created_by] uniqueidentifier, -- ID người cập nhật món ăn trong đơn
 [updated_by] uniqueidentifier, -- Ghi chú về món ăn
 [item_notes] nvarchar(255), -- Thành phần gây dị ứng trong món ăn
 [allergens] nvarchar(255) DEFAULT '255', -- Mức độ cay của món ăn
 [spice_level] nvarchar(50) DEFAULT '10', -- Khóa chính
 PRIMARY KEY ([order_item_id]),);


CREATE TABLE [Customers] (-- Thời gian tạo khách hàng
 [created_at] datetime DEFAULT GETDATE(), -- Tự động gán ngày tạo khi thêm mới
 -- Mã khách hàng (khóa chính)
 [customer_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên khách hàng (họ)
 [first_name] nvarchar(100) DEFAULT '100', -- Giới hạn độ dài hợp lý cho tên
 -- Tên khách hàng (tên)
 [last_name] nvarchar(100) DEFAULT '100', -- Giới hạn độ dài hợp lý cho tên
 -- Địa chỉ email
 [email] nvarchar(255) DEFAULT '255', -- Giới hạn độ dài email hợp lý
 -- Số điện thoại
 [phone_number] nvarchar(15) DEFAULT '15', -- Giới hạn độ dài cho số điện thoại
 -- Địa chỉ của khách hàng
 [address] nvarchar(255) DEFAULT '255', -- Giới hạn độ dài cho địa chỉ
 -- Thời gian cập nhật khách hàng
 [updated_at] datetime DEFAULT GETDATE(), -- Tự động gán ngày cập nhật khi có thay đổi
 -- Điểm thưởng của khách hàng
 [loyalty_points] int DEFAULT 0, -- Mặc định là 0 nếu không có điểm thưởng
 -- Ngày sinh của khách hàng
 [date_of_birth] date, -- Giới tính của khách hàng
 [gender] nvarchar(10) DEFAULT 'Unknown', -- Giới hạn giá trị với những lựa chọn hợp lý (ví dụ: 'Male', 'Female', 'Other')
 -- Ảnh hồ sơ của khách hàng (đường dẫn ảnh)
 [profile_picture] nvarchar(255) DEFAULT 'default.jpg', -- Giới hạn độ dài cho đường dẫn ảnh, mặc định là 'default.jpg'
 -- ID người tạo khách hàng
 [created_by] uniqueidentifier, -- ID người cập nhật khách hàng
 [updated_by] uniqueidentifier, -- Trạng thái khách hàng (ví dụ: 1 = Active, 0 = Inactive)
 [status] tinyint, -- Sở thích của khách hàng
 [preferences] nvarchar(500), -- Giới hạn chiều dài nếu cần thiết cho sở thích của khách hàng
 -- Khóa chính
 PRIMARY KEY ([customer_id]));


CREATE TABLE [Staff] (-- ID người tạo bản ghi
 [created_by] uniqueidentifier, -- ID người cập nhật bản ghi
 [updated_by] uniqueidentifier, -- Thời gian bắt đầu ca làm việc
 [shift_start_time] time(7), -- Mã nhân viên (khóa chính)
 [staff_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên nhân viên (họ)
 [first_name] nvarchar(100) DEFAULT 'John', -- Giới hạn độ dài hợp lý cho tên
 -- Tên nhân viên (tên)
 [last_name] nvarchar(100) DEFAULT 'Doe', -- Giới hạn độ dài hợp lý cho tên
 -- Địa chỉ email của nhân viên
 [email] nvarchar(255) DEFAULT 'example@domain.com', -- Giới hạn độ dài email hợp lý
 -- Số điện thoại của nhân viên
 [phone_number] nvarchar(15) DEFAULT '0000000000', -- Giới hạn độ dài cho số điện thoại
 -- Chức vụ của nhân viên
 [role] nvarchar(100) DEFAULT 'Staff', -- Giới hạn độ dài hợp lý cho chức vụ
 -- Mức lương của nhân viên
 [salary] decimal(18, 0), -- Kiểu số thập phân để lưu mức lương
 -- Ngày tuyển dụng
 [hire_date] date, -- Trạng thái nhân viên (ví dụ: 1 = Active, 0 = Inactive)
 [status] tinyint, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Tự động gán ngày tạo khi thêm mới
 -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Tự động gán ngày cập nhật khi có thay đổi
 -- Ảnh hồ sơ của nhân viên
 [profile_picture] nvarchar(255) DEFAULT 'default.jpg', -- Giới hạn độ dài cho đường dẫn ảnh
 -- Mã nhà hàng mà nhân viên làm việc
 [restaurant_id_fk] uniqueidentifier, -- Thời gian kết thúc ca làm việc
 [shift_end_time] time(7), -- Khóa chính
 PRIMARY KEY ([staff_id]));


CREATE TABLE [StaffSchedule] (-- Mã lịch làm việc (khóa chính)
 [schedule_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhân viên (khóa ngoại tham chiếu tới Staff)
 [staff_id_fk] uniqueidentifier NOT NULL, -- Ngày làm việc
 [work_date] date NOT NULL, -- Ca làm việc (ví dụ: Sáng, Chiều, Tối)
 [shift] nvarchar(50) NOT NULL, -- Giờ bắt đầu ca
 [shift_start_time] datetime, -- Giờ kết thúc ca
 [shift_end_time] datetime, -- Trạng thái (ví dụ: Đã xác nhận, Chưa xác nhận)
 [status] tinyint, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([schedule_id]),
                              FOREIGN KEY ([staff_id_fk]) REFERENCES [Staff]([staff_id]));


CREATE TABLE [StaffAttendance] (-- Mã chấm công (khóa chính)
 [attendance_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhân viên (khóa ngoại tham chiếu tới Staff)
 [staff_id_fk] uniqueidentifier NOT NULL, -- Ngày chấm công
 [attendance_date] datetime NOT NULL, -- Giờ vào
 [check_in_time] datetime NOT NULL, -- Giờ ra
 [check_out_time] datetime NULL, -- Tổng số giờ làm việc
 [total_hours] decimal(5, 2) NULL, -- Trạng thái chấm công (ví dụ: Đúng giờ, Trễ giờ, Nghỉ phép)
 [status] tinyint, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([attendance_id]),
                                FOREIGN KEY ([staff_id_fk]) REFERENCES [Staff]([staff_id]));


CREATE TABLE [StaffLeave] (-- Mã nghỉ phép (khóa chính)
 [leave_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhân viên (khóa ngoại tham chiếu tới Staff)
 [staff_id_fk] uniqueidentifier NOT NULL, -- Ngày nghỉ phép
 [leave_date] date NOT NULL, -- Loại nghỉ phép (ví dụ: Nghỉ phép năm, Nghỉ bệnh)
 [leave_type] nvarchar(50), -- Lý do nghỉ
 [leave_reason] nvarchar(255), -- Trạng thái nghỉ phép (ví dụ: Đã duyệt, Chưa duyệt)
 [status] tinyint, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([leave_id]),
                           FOREIGN KEY ([staff_id_fk]) REFERENCES [Staff]([staff_id]));


CREATE TABLE [StaffSalary] (-- Mã bảng lương (khóa chính)
 [salary_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhân viên (khóa ngoại tham chiếu tới Staff)
 [staff_id_fk] uniqueidentifier NOT NULL, -- Tháng thanh toán
 [payment_month] date NOT NULL, -- Mức lương cơ bản
 [basic_salary] decimal(18, 2) NOT NULL, -- Các khoản phụ cấp (nếu có)
 [allowance] decimal(18, 2) NULL, -- Tổng số lương
 [total_salary] decimal(18, 2) NOT NULL, -- Thực nhận (sau khi trừ các khoản)
 [net_salary] decimal(18, 2) NOT NULL, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([salary_id]),
                            FOREIGN KEY ([staff_id_fk]) REFERENCES [Staff]([staff_id]));


CREATE TABLE [Reservations] (-- Mã đặt chỗ (khóa chính)
 [reservation_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Ngày và giờ đặt chỗ
 [reservation_date] datetime, -- Số lượng người
 [number_of_people] int, -- Trạng thái đặt chỗ (ví dụ: 1 = Confirmed, 0 = Canceled)
 [status] tinyint, -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Tự động gán thời gian tạo
 -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Tự động gán thời gian cập nhật khi có thay đổi
 -- Yêu cầu đặc biệt của khách hàng
 [special_requests] nvarchar(255), -- Giới hạn độ dài hợp lý cho yêu cầu
 -- ID người tạo bản ghi
 [created_by] uniqueidentifier, -- ID người cập nhật bản ghi
 [updated_by] uniqueidentifier, -- Số bàn được đặt
 [table_number] int, -- Số điện thoại liên hệ của khách hàng
 [contact_number] nvarchar(15) DEFAULT '0000000000', -- Giới hạn độ dài cho số điện thoại
 -- Địa chỉ email của khách hàng
 [email] nvarchar(255) DEFAULT 'example@domain.com', -- Giới hạn độ dài email hợp lý
 -- Số điểm khách hàng đã sử dụng
 [loyalty_points_used] int, -- Mã xác nhận đặt chỗ
 [confirmation_code] nvarchar(50) DEFAULT 'CONFIRM123', -- Giới hạn độ dài cho mã xác nhận
 -- Khóa chính
 PRIMARY KEY ([reservation_id]));

-- Bảng Payments: Quản lý thông tin thanh toán

CREATE TABLE [Payments] (-- Mã thanh toán (khóa chính)
 [payment_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã đơn hàng (khóa ngoại)
 [order_id_fk] uniqueidentifier, -- Ngày thanh toán
 [payment_date] datetime, -- Số tiền thanh toán
 [amount] decimal(18, 0), -- Phương thức thanh toán (Credit Card, Cash, v.v...)
 [payment_method] nvarchar(50) DEFAULT 'Credit Card', -- Giới hạn độ dài
 -- Trạng thái thanh toán (1 = Thành công, 0 = Thất bại)
 [status] tinyint, -- ID giao dịch từ hệ thống thanh toán
 [transaction_id] nvarchar(100) DEFAULT 'TRANSACTION123', -- Giới hạn độ dài
 -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Mã khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- ID người tạo bản ghi
 [created_by] uniqueidentifier, -- ID người cập nhật bản ghi
 [updated_by] uniqueidentifier, -- Số tiền hoàn lại nếu có
 [refund_amount] decimal(18, 0), -- Trạng thái hoàn tiền (0 = Chưa hoàn, 1 = Đã hoàn)
 [refund_status] tinyint, -- Ghi chú thanh toán
 [payment_notes] nvarchar(255), -- Loại tiền tệ (USD, VND, v.v...)
 [currency] nvarchar(10) DEFAULT 'VND', -- Giới hạn độ dài
 -- Khóa chính
 PRIMARY KEY ([payment_id]));

-- Bảng Reviews: Quản lý các đánh giá của khách hàng

CREATE TABLE [Reviews] (-- Ngày phản hồi đánh giá
 [response_date] datetime, -- Số phiếu bầu hữu ích
 [helpful_votes] int, -- Đánh giá có ẩn danh không
 [is_anonymous] bit, -- Loại đánh giá (Food, Service, v.v...)
 [review_type] tinyint, -- Giới hạn độ dài
 -- Mã đánh giá (khóa chính)
 [review_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Mã khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- Đánh giá sao (0-5)
 [rating] float(53), -- Bình luận của khách hàng
 [comment] nvarchar(1000), -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái đánh giá (1 = Đã duyệt, 0 = Chưa duyệt)
 [status] tinyint, -- ID người tạo bản ghi
 [created_by] uniqueidentifier, -- ID người cập nhật bản ghi
 [updated_by] uniqueidentifier, -- Phản hồi từ nhà hàng (nếu có)
 [response] nvarchar(1000), -- Khóa chính
 PRIMARY KEY ([review_id]));

-- Bảng LoyaltyPrograms: Quản lý các chương trình khách hàng thân thiết

CREATE TABLE [LoyaltyPrograms] (-- Tên chương trình khách hàng thân thiết
 [program_name] nvarchar(255) DEFAULT 'Discount Program', -- Giới hạn độ dài
 -- Số điểm yêu cầu để đổi thưởng
 [points_required] int, -- Phần trăm giảm giá khi đổi thưởng
 [discount_percentage] float(53) CHECK (discount_percentage >= 0
                                        AND discount_percentage <= 100), -- Thời gian có hiệu lực của chương trình (tính theo tháng hoặc ngày)
 [validity_period] int, -- Thời gian tạo chương trình
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật chương trình
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái của chương trình (1 = Đang hoạt động, 0 = Dừng hoạt động)
 [status] tinyint, -- ID người tạo chương trình
 [created_by] uniqueidentifier, -- ID người cập nhật chương trình
 [updated_by] uniqueidentifier, -- Mô tả chương trình
 [description] nvarchar(1000), -- Điều khoản và điều kiện tham gia
 [terms_conditions] nvarchar(1000), -- Ngày bắt đầu chương trình
 [enrollment_date] datetime, -- Số điểm tối đa có thể nhận được trong chương trình
 [max_points] int, -- Mã chương trình khách hàng thân thiết (khóa chính)
 [loyalty_program_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Số điểm tối thiểu để tham gia chương trình
 [min_points] int, -- Khóa chính
 PRIMARY KEY ([loyalty_program_id]));

-- Bảng Notifications: Quản lý thông báo cho khách hàng

CREATE TABLE [Notifications] (-- Mã thông báo (khóa chính)
 [notification_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Nội dung thông báo
 [message] nvarchar(1000), -- Đã đọc hay chưa (1 = Đã đọc, 0 = Chưa đọc)
 [is_read] bit, -- Thời gian tạo thông báo
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật thông báo
 [updated_at] datetime DEFAULT GETDATE(), -- Loại thông báo (Promotion, Alert, v.v...)
 [notification_type] tinyint, -- Giới hạn độ dài
 -- ID liên quan đến thông báo (Ví dụ: ID đơn hàng, ID khách hàng)
 [related_id] uniqueidentifier, -- ID người tạo thông báo
 [created_by] uniqueidentifier, -- ID người cập nhật thông báo
 [updated_by] uniqueidentifier, -- Ngày hết hạn thông báo
 [expiration_date] datetime, -- Độ ưu tiên của thông báo (Low, Medium, High)
 [priority] nvarchar(10) DEFAULT 'Medium', -- Giới hạn độ dài
 -- Trạng thái thông báo (1 = Đã duyệt, 0 = Chưa duyệt)
 [status] tinyint, -- Phản hồi từ khách hàng đối với thông báo
 [customer_feedback] nvarchar(1000), -- Mã khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- Ngày phản hồi của khách hàng
 [response_date] datetime, -- Khóa chính
 PRIMARY KEY ([notification_id]));

-- Bảng Discounts: Quản lý các mã giảm giá

CREATE TABLE [Discounts] (-- Mã giảm giá (khóa chính)
 [discount_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Mã giảm giá
 [discount_code] nvarchar(50) DEFAULT 'DISCOUNT50', -- Giới hạn độ dài
 -- Phần trăm giảm giá
 [discount_percentage] float(53) CHECK (discount_percentage >= 0
                                        AND discount_percentage <= 100), -- Ngày bắt đầu giảm giá
 [valid_from] datetime, -- Ngày kết thúc giảm giá
 [valid_to] datetime , -- Đảm bảo valid_to lớn hơn valid_from
 -- Trạng thái giảm giá (1 = Đang hoạt động, 0 = Hết hạn hoặc không áp dụng)
 [status] tinyint, -- Thời gian tạo mã giảm giá
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật mã giảm giá
 [updated_at] datetime DEFAULT GETDATE(), -- ID người tạo mã giảm giá
 [created_by] uniqueidentifier, -- ID người cập nhật mã giảm giá
 [updated_by] uniqueidentifier, -- Mô tả giảm giá
 [discount_description] nvarchar(500), -- Giới hạn độ dài
 -- ID khách hàng áp dụng mã giảm giá
 [customer_id_fk] uniqueidentifier, -- Khóa chính
 PRIMARY KEY ([discount_id]));

-- Bảng Tables: Quản lý các bàn trong nhà hàng

CREATE TABLE [Tables] (-- Mã bàn (khóa chính)
 [table_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Số hiệu bàn
 [table_number] int, -- Sức chứa bàn (số lượng ghế ngồi)
 [seating_capacity] int, -- Trạng thái bàn (1 = Đang sử dụng, 0 = Rảnh)
 [status] tinyint, -- Thời gian tạo bàn
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bàn
 [updated_at] datetime DEFAULT GETDATE(), -- ID người tạo bàn
 [created_by] uniqueidentifier, -- ID người cập nhật bàn
 [updated_by] uniqueidentifier, -- Loại bàn (Regular, VIP, Outdoor, ...)
 [table_type] tinyint, -- Giới hạn độ dài
 -- Vị trí bàn trong nhà hàng
 [location] tinyint, -- Giới hạn độ dài
 -- Trạng thái đã được đặt chưa (1 = Đã đặt, 0 = Chưa đặt)
 [is_reserved] bit, -- Mã đặt bàn (khóa ngoại liên kết với bảng Reservations)
 [reservation_id_fk] uniqueidentifier, -- Các yêu cầu đặc biệt cho bàn
 [special_requests] nvarchar(500), -- Thời gian đặt bàn gần nhất
 [last_reserved_at] datetime, -- Ghi chú bàn
 [notes] nvarchar(500), -- Khóa chính
 PRIMARY KEY ([table_id]));

-- Bảng Events: Quản lý sự kiện

CREATE TABLE [Events] (-- Mã sự kiện (khóa chính)
 [event_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên sự kiện
 [event_name] nvarchar(255) DEFAULT 'Event Name', -- Giới hạn độ dài
 -- Ngày diễn ra sự kiện
 [event_date] datetime, -- Mô tả sự kiện
 [description] nvarchar(MAX), -- Thời gian tạo sự kiện
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật sự kiện
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái sự kiện (1 = Đang diễn ra, 0 = Kết thúc)
 [status] tinyint, -- Người tạo sự kiện
 [created_by] uniqueidentifier, -- Người cập nhật sự kiện
 [updated_by] uniqueidentifier, -- Số lượng người tham gia tối đa
 [max_attendees] int, -- Giá vé sự kiện
 [ticket_price] decimal(18, 2), -- URL hình ảnh sự kiện
 [image_url] nvarchar(255) DEFAULT 'Image URL', -- Yêu cầu đặc biệt
 [special_requests] nvarchar(MAX), -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Loại sự kiện (1 = Hội nghị, 2 = Biểu diễn, 3 = Lễ hội, ...)
 [event_type] tinyint, -- Khóa chính
 PRIMARY KEY ([event_id]));

-- Bảng Feedback: Quản lý phản hồi của khách hàng

CREATE TABLE [Feedback] (-- Mã phản hồi (khóa chính)
 [feedback_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Nội dung phản hồi
 [feedback_text] nvarchar(1000), -- Giới hạn độ dài
 -- Thời gian tạo phản hồi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật phản hồi
 [updated_at] datetime DEFAULT GETDATE(), -- Trạng thái phản hồi (1 = Đang xử lý, 0 = Đã giải quyết)
 [status] tinyint, -- Người tạo phản hồi
 [created_by] uniqueidentifier, -- Người cập nhật phản hồi
 [updated_by] uniqueidentifier, -- Phản hồi từ nhà hàng
 [response] nvarchar(MAX), -- Thời gian phản hồi
 [response_date] datetime, -- Loại phản hồi (1 = Khen ngợi, 2 = Khiếu nại, ...)
 [feedback_type] tinyint, -- Phản hồi ẩn danh (1 = Ẩn danh, 0 = Không ẩn danh)
 [is_anonymous] bit, -- Đánh giá (1 đến 5)
 [rating] float(53) CHECK (rating >= 1
                           AND rating <= 5), -- Số lượt bình chọn hữu ích
 [helpful_votes] int, -- Mã khách hàng (khóa ngoại)
 [customer_id_fk] uniqueidentifier, -- Trạng thái xử lý phản hồi (1 = Đã giải quyết, 0 = Chưa giải quyết)
 [is_resolved] bit, -- Mã nhà hàng (khóa ngoại)
 [restaurant_id_fk] uniqueidentifier, -- Khóa chính
 PRIMARY KEY ([feedback_id]));

-- Bảng UserAccounts: Quản lý tài khoản người dùng

CREATE TABLE [UserAccounts] (-- Mã người dùng (khóa chính)
 [user_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên người dùng
 [username] nvarchar(100) DEFAULT 'user', -- Giới hạn độ dài
 -- Mật khẩu (hash)
 [password_hash] nvarchar(255) DEFAULT 'hashed_password', -- Email người dùng
 [email] nvarchar(255) DEFAULT 'email@example.com', -- Vai trò người dùng (1 = Admin, 2 = Người dùng, ...)
 [role] int, -- Thời gian tạo tài khoản
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật tài khoản
 [updated_at] datetime DEFAULT GETDATE(), -- Lần đăng nhập cuối
 [last_login] datetime, -- Trạng thái tài khoản (1 = Đang hoạt động, 0 = Đã khóa)
 [status] tinyint, -- Người tạo tài khoản
 [created_by] uniqueidentifier, -- Người cập nhật tài khoản
 [updated_by] uniqueidentifier, -- Hình ảnh hồ sơ
 [profile_picture] nvarchar(255) DEFAULT 'profile.jpg', -- Sở thích của người dùng
 [preferences] nvarchar(MAX), -- Xác thực hai yếu tố (1 = Đã bật, 0 = Chưa bật)
 [two_factor_enabled] bit, -- Lần thay đổi mật khẩu cuối
 [last_password_change] datetime, -- Khóa chính
 PRIMARY KEY ([user_id]));


ALTER TABLE [UserAccounts] ADD [Role_ID_FK] UNIQUEIDENTIFIER;


ALTER TABLE [UserAccounts] ADD CONSTRAINT FK_Role_User
FOREIGN KEY ([Role_ID_FK]) REFERENCES [Roles](ID);

-- Role

CREATE TABLE ROLES (ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho vai trò
 RoleName Nvarchar(100),
          Description NVARCHAR(255))
CREATE TABLE [MenuItemsIngredient] (-- Mã nguyên liệu món ăn (khóa chính)
 [menuitems_ingredient_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã món ăn (khóa ngoại từ bảng Dish)
 [menuitems_id_fk] uniqueidentifier NOT NULL, -- Mã nguyên liệu (khóa ngoại từ bảng Inventory)
 [ingredient_id_fk] uniqueidentifier NOT NULL, -- Số lượng nguyên liệu sử dụng cho món ăn (đơn vị tính theo bảng Inventory)
 [quantity] decimal(18, 2) NOT NULL, -- Đơn vị tính (ví dụ: kg, lít, gói...)
 [unit] nvarchar(50),
        PRIMARY KEY ([menuitems_ingredient_id]),
                                    FOREIGN KEY ([menuitems_id_fk]) REFERENCES [menuitems] ([item_id]),
                                    FOREIGN KEY ([ingredient_id_fk]) REFERENCES [Inventory] ([inventory_id]));

-- Bảng Nguyên Liệu (Inventory)

CREATE TABLE [Inventory] (-- Mã nguyên liệu (khóa chính)
 [inventory_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên nguyên liệu
 [ingredient_name] nvarchar(255) NOT NULL, -- Đơn vị tính (kg, lít, gói...)
 [unit] nvarchar(50), -- Số lượng tồn kho
 [quantity_in_stock] decimal(18, 2) NOT NULL, -- Mã nhà cung cấp (khóa ngoại từ bảng Supplier)
 [supplier_id_fk] uniqueidentifier, -- Ngày nhập kho
 [received_date] datetime DEFAULT GETDATE(), -- Trạng thái nguyên liệu (Hết, Còn)
 [status] nvarchar(50) DEFAULT 'Còn', -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([inventory_id]),
                          FOREIGN KEY ([supplier_id_fk]) REFERENCES [Supplier] ([supplier_id]));


CREATE TABLE [InventoryTransactions] (-- Mã giao dịch kho (khóa chính)
 [transaction_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nguyên liệu (khóa ngoại)
 [inventory_id_fk] uniqueidentifier NOT NULL, -- Số lượng thay đổi (dương = nhập, âm = xuất)
 [quantity_changed] decimal(18, 2), -- Ngày giao dịch
 [transaction_date] datetime DEFAULT GETDATE(), -- Lý do giao dịch
 [transaction_reason] nvarchar(255), -- Người thực hiện giao dịch
 [transaction_by] uniqueidentifier, -- Khóa chính
 PRIMARY KEY ([transaction_id]), -- Khóa ngoại liên kết với bảng Inventory
 CONSTRAINT FK_Ingredient_InventoryTransaction
                                      FOREIGN KEY ([inventory_id_fk]) REFERENCES dbo.Inventory([inventory_id]));

-- Bảng Nhà Cung Cấp (Supplier)

CREATE TABLE [Supplier] (-- Mã nhà cung cấp (khóa chính)
 [supplier_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Tên nhà cung cấp
 [supplier_name] nvarchar(255) NOT NULL, -- Địa chỉ nhà cung cấp
 [address] nvarchar(500), -- Số điện thoại nhà cung cấp
 [phone_number] nvarchar(15), -- Email nhà cung cấp
 [email] nvarchar(255), -- Mã số thuế (nếu có)
 [tax_id] nvarchar(50), -- Trạng thái nhà cung cấp (Active/Inactive)
 [status] nvarchar(50) DEFAULT 'Active', -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([supplier_id]));


CREATE TABLE [PurchaseOrder] (-- Mã đơn đặt hàng (khóa chính)
 [purchase_order_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà cung cấp (khóa ngoại từ bảng Supplier)
 [supplier_id_fk] uniqueidentifier, -- Ngày tạo đơn hàng
 [order_date] datetime DEFAULT GETDATE(), -- Trạng thái đơn hàng (Đã đặt, Đang xử lý, Hoàn thành, Hủy)
 [status] nvarchar(50) DEFAULT 'Đang xử lý', -- Tổng giá trị đơn hàng
 [total_amount] decimal(18, 2), -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(),
                               PRIMARY KEY ([purchase_order_id]),
                              FOREIGN KEY ([supplier_id_fk]) REFERENCES [Supplier] ([supplier_id]));


CREATE TABLE [PurchaseOrderItem] (-- Mã chi tiết đơn đặt hàng (khóa chính)
 [purchase_order_item_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã đơn đặt hàng (khóa ngoại từ bảng PurchaseOrder)
 [purchase_order_id_fk] uniqueidentifier, -- Mã nguyên liệu (khóa ngoại từ bảng Ingredient)
 [ingredient_id_fk] uniqueidentifier, -- Số lượng đặt hàng
 [quantity_ordered] decimal(18, 2), -- Giá nhập vào
 [unit_price] decimal(18, 2), -- Tổng giá trị
 [total_price] AS (quantity_ordered * unit_price),
 PRIMARY KEY ([purchase_order_item_id]),
                                  FOREIGN KEY ([purchase_order_id_fk]) REFERENCES [PurchaseOrder] ([purchase_order_id]),);


CREATE TABLE [SuppliersContacts] (-- ID liên lạc (khóa chính)
 [contact_id] uniqueidentifier NOT NULL DEFAULT NEWID(), -- Mã nhà cung cấp (khóa ngoại)
 [supplier_id_fk] uniqueidentifier NOT NULL, -- Tên người liên hệ
 [contact_name] nvarchar(100) NOT NULL, -- Chức vụ của người liên hệ
 [contact_title] nvarchar(100), -- Email của người liên hệ
 [email] nvarchar(255), -- Số điện thoại của người liên hệ
 [phone_number] nvarchar(15), -- Địa chỉ của người liên hệ
 [address] nvarchar(255), -- Địa chỉ chi tiết (nếu có)
 [detailed_address] nvarchar(255), -- Địa chỉ chi tiết, nếu cần
 -- Ghi chú thêm về người liên hệ
 [notes] nvarchar(MAX), -- Thời gian tạo bản ghi
 [created_at] datetime DEFAULT GETDATE(), -- Thời gian cập nhật bản ghi
 [updated_at] datetime DEFAULT GETDATE(), -- Người tạo bản ghi
 [created_by] uniqueidentifier, -- Người cập nhật bản ghi
 [updated_by] uniqueidentifier, -- Khóa chính
 PRIMARY KEY ([contact_id]), -- Khóa ngoại liên kết với bảng Supplier
 CONSTRAINT FK_Supplier_Contact
                                  FOREIGN KEY ([supplier_id_fk]) REFERENCES dbo.Supplier([supplier_id]));


ALTER TABLE [Menus] ADD CONSTRAINT [Menus_fk13]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [MenuItems] ADD CONSTRAINT [MenuItems_fk1]
FOREIGN KEY ([menu_id_fk]) REFERENCES [Menus]([menu_id]);


ALTER TABLE [Orders] ADD CONSTRAINT [Orders_fk1]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [Orders] ADD CONSTRAINT [Orders_fk2]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk3]
FOREIGN KEY ([order_id_fk]) REFERENCES [Orders]([order_id]);


ALTER TABLE [OrderItems] ADD CONSTRAINT [OrderItems_fk4]
FOREIGN KEY ([item_id_fk]) REFERENCES [MenuItems]([item_id]);


ALTER TABLE [Staff] ADD CONSTRAINT [Staff_fk15]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Reservations] ADD CONSTRAINT [Reservations_fk1]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [Reservations] ADD CONSTRAINT [Reservations_fk2]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Payments] ADD CONSTRAINT [Payments_fk1]
FOREIGN KEY ([order_id_fk]) REFERENCES [Orders]([order_id]);


ALTER TABLE [Payments] ADD CONSTRAINT [Payments_fk9]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [Reviews] ADD CONSTRAINT [Reviews_fk5]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Reviews] ADD CONSTRAINT [Reviews_fk6]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [LoyaltyPrograms] ADD CONSTRAINT [LoyaltyPrograms_fk14]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Notifications] ADD CONSTRAINT [Notifications_fk13]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [Discounts] ADD CONSTRAINT [Discounts_fk1]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Tables] ADD CONSTRAINT [Tables_fk1]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);


ALTER TABLE [Events] ADD CONSTRAINT [Events_fk12]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaur
ants]([restaurant_id]);


ALTER TABLE [Feedback] ADD CONSTRAINT [Feedback_fk13]
FOREIGN KEY ([customer_id_fk]) REFERENCES [Customers]([customer_id]);


ALTER TABLE [Feedback] ADD CONSTRAINT [Feedback_fk15]
FOREIGN KEY ([restaurant_id_fk]) REFERENCES [Restaurants]([restaurant_id]);