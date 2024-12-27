DECLARE @BackupFileName NVARCHAR(255);
DECLARE @CurrentDate NVARCHAR(10);

-- Lấy ngày hiện tại theo định dạng YYYYMMDD
SET @CurrentDate = CONVERT(NVARCHAR(10), GETDATE(), 112);

-- Xây dựng tên tệp sao lưu
SET @BackupFileName = N'B:\graduation-project\DB\Backups\BU_' + @CurrentDate + '.bak';

-- Sao lưu cơ sở dữ liệu
BACKUP DATABASE [SmartRes]
TO DISK = @BackupFileName
WITH INIT, FORMAT;
