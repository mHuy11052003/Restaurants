
--User
CREATE TABLE Users (
    ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho người dùng
    UserID NVARCHAR(10) NOT NULL DEFAULT 'US000000',             -- UserID tự động tăng (sẽ có trigger để tăng tự động)
    Username NVARCHAR(50) NOT NULL,                             -- Tên đăng nhập
    Password NVARCHAR(255) NOT NULL,                        -- Mã hóa mật khẩu
    FirstName NVARCHAR(100) NOT NULL,                            -- Họ
    LastName NVARCHAR(100) NOT NULL,                            -- Tên
    Email NVARCHAR(100) NOT NULL,                               -- Địa chỉ email
    Role_ID_FK UNIQUEIDENTIFIER,                                                 -- ID vai trò (FK)
    Phone NVARCHAR(20),                                         -- Số điện thoại
    Status TINYINT,
    CreatedAt DATETIME DEFAULT GETDATE(),                       -- Thời gian tạo tài khoản
    UpdatedAt DATETIME DEFAULT GETDATE(),                       -- Thời gian cập nhật tài khoản
);


-- Role
CREATE TABLE Roles (
	ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho vai trò 
	RoleName Nvarchar(100),
	Description NVARCHAR(255)
)

--Khóa ngoại Role_ID_FK vào bảng Users và ràng buộc với bảng Roles.
ALTER TABLE Users ADD CONSTRAINT FK_Role_User FOREIGN KEY (Role_ID_FK) REFERENCES Roles(ID)





-- Tạo bảng MenuCategories (Nhóm Món Ăn)
CREATE TABLE MenuCategories (
	ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho nhóm
    CatID NVARCHAR(10) , -- ID nhóm món (tự động tăng) 
    CatParentID UNIQUEIDENTIFIER, 
    CategoryName NVARCHAR(255) NOT NULL,     -- Tên nhóm món
    Description NVARCHAR(MAX) NULL,           -- Mô tả nhóm món
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian tạo
    CreatedBy UNIQUEIDENTIFIER,     -- Người tạo
    UpdatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian cập nhật
    UpdatedBy UNIQUEIDENTIFIER,     -- Người cập nhật
);

-- Tạo bảng MenuItems (Quản lý Thực Đơn)
CREATE TABLE MenuItems (
	ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho món ăn
    Name NVARCHAR(255) NOT NULL,              -- Tên món ăn
    Description NVARCHAR(MAX) NULL,           -- Mô tả món ăn
    Price DECIMAL(10, 2) NOT NULL,            -- Giá bán
    CostPrice DECIMAL(10, 2) NOT NULL,        -- Giá vốn
    ImageURL NVARCHAR(500) NULL,              -- Đường dẫn tới hình ảnh món ăn
    PreparationTime INT NULL,                 -- Thời gian chuẩn bị (phút)
    Status tinyint,                     -- Trạng thái món ăn (1: Đang phục vụ, 0: Ngừng phục vụ)
	Popularity int,
	IsTrending bit,
	IsFeature bit,
    Category_ID_FK UNIQUEIDENTIFIER NOT NULL,              -- FK tới MenuCategories
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian tạo
    CreatedBy UNIQUEIDENTIFIER,               -- Người tạo
    UpdatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian cập nhật
    UpdatedBy UNIQUEIDENTIFIER,               -- Người cập nhật
    
);


ALTER TABLE MenuItems 
ADD CONSTRAINT FK_MenuItems_MenuCategories FOREIGN KEY (Category_ID_FK)
        REFERENCES MenuCategories(ID) -- Quan hệ với nhóm món ăn
        ON DELETE CASCADE
        ON UPDATE CASCADE


CREATE TABLE MenuItemCombos (
	ID UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID() PRIMARY KEY, -- ID duy nhất cho món ăn
    ComboID NVARCHAR(10) NOT NULL DEFAULT 'COB000000',
    Name NVARCHAR(255) NOT NULL,          -- Tên combo
    Description NVARCHAR(MAX) NULL,       -- Mô tả combo
    TotalPrice DECIMAL(10, 2) NOT NULL,   -- Giá combo
    ImageURL NVARCHAR(500) NULL,              -- Đường dẫn tới hình ảnh combo
    CreatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian tạo
    CreatedBy UNIQUEIDENTIFIER,               -- Người tạo
    UpdatedAt DATETIME DEFAULT GETDATE(),     -- Thời gian cập nhật
    UpdatedBy UNIQUEIDENTIFIER,               -- Người cập nhật
);

CREATE TABLE ComboItems (
    Combo_ID_FK UNIQUEIDENTIFIER NOT NULL,                 -- FK tới MenuItemCombos
    MenuItem_ID_FK UNIQUEIDENTIFIER NOT NULL, -- FK tới MenuItems
    Quantity INT NOT NULL,                -- Số lượng món trong combo
    PRIMARY KEY (Combo_ID_FK, MenuItem_ID_FK),
    FOREIGN KEY (Combo_ID_FK) REFERENCES MenuItemCombos(ID),
    FOREIGN KEY (MenuItem_ID_FK) REFERENCES MenuItems(ID)
);




