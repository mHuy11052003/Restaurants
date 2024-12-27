CREATE TRIGGER trg_MenuItemCombos_ComboID
ON MenuItemCombos
AFTER INSERT
AS
BEGIN
    DECLARE @maxComboID NVARCHAR(9);
    
    -- Lấy ComboID lớn nhất hiện có
    SELECT @maxComboID = MAX(ComboID) FROM MenuItemCombos;
    
    -- Tạo ComboID mới
    IF @maxComboID IS NOT NULL
    BEGIN
        SET @maxComboID = 'COB' + RIGHT('000000' + CAST(CAST(SUBSTRING(@maxComboID, 4, 6) AS INT) + 1 AS NVARCHAR(6)), 6);
        UPDATE MenuItemCombos
        SET ComboID = @maxComboID
        WHERE ID IN (SELECT ID FROM inserted);
    END
    ELSE
    BEGIN
        -- Trường hợp nếu lànhóm đầu tiên, khởi tạo 'CAT000001'
        UPDATE MenuItemCombos
        SET ComboID = 'COB000001'
        WHERE ID IN (SELECT ID FROM inserted);
    END
END;