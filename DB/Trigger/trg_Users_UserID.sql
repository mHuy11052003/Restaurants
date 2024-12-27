
-- Tạo Trigger để tự động tăng UserID theo định dạng 'US000001', 'US000002', ...
CREATE TRIGGER trg_Users_UserID
ON Users
AFTER INSERT
AS
BEGIN
    DECLARE @maxUserID NVARCHAR(8);
    
    -- Lấy UserID lớn nhất hiện có
    SELECT @maxUserID = MAX(UserID) FROM Users;
    
    -- Tạo UserID mới
    IF @maxUserID IS NOT NULL
    BEGIN
        SET @maxUserID = 'US' + RIGHT('000000' + CAST(CAST(SUBSTRING(@maxUserID, 3, 6) AS INT) + 1 AS NVARCHAR(6)), 6);
        UPDATE Users
        SET UserID = @maxUserID
        WHERE ID IN (SELECT ID FROM inserted);
    END
    ELSE
    BEGIN
        -- Trường hợp nếu là người dùng đầu tiên, khởi tạo 'US000001'
        UPDATE Users
        SET UserID = 'US000001'
        WHERE ID IN (SELECT ID FROM inserted);
    END
END;