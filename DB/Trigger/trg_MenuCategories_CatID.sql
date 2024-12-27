-- Tạo Trigger để tự động tăng CatID theo định dạng 'CAT000001', 'CAT000002', ...
CREATE TRIGGER trg_MenuCategories_CatID
ON MenuCategories
AFTER INSERT
AS
BEGIN
    DECLARE @maxCatID NVARCHAR(9);
    
    -- Lấy CatID lớn nhất hiện có
    SELECT @maxCatID = MAX(CatID) FROM MenuCategories;
    
    -- Tạo CatID mới
    IF @maxCatID IS NOT NULL
    BEGIN
        -- Trích xuất phần số từ CatID hiện tại và cộng thêm 1
        SET @maxCatID = 'CAT' + RIGHT('000000' + CAST(CAST(SUBSTRING(@maxCatID, 4, 6) AS INT) + 1 AS NVARCHAR(6)), 6);
        
        -- Cập nhật CatID mới cho nhóm món ăn vừa thêm
        UPDATE MenuCategories
        SET CatID = @maxCatID
        WHERE ID IN (SELECT ID FROM inserted);
    END
    ELSE
    BEGIN
        -- Trường hợp nếu là nhóm món đầu tiên, khởi tạo 'CAT000001'
        UPDATE MenuCategories
        SET CatID = 'CAT000001'
        WHERE ID IN (SELECT ID FROM inserted);
    END
END;
