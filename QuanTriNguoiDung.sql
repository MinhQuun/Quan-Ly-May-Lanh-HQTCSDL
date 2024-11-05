USE QL_MAYLANH_HQTCSDL

-- Lưu mã xác thực 2 yếu tố
CREATE TABLE MaXacThucNguoiDung (
    IDMaXacThuc INT PRIMARY KEY IDENTITY(1,1),
    MAND INT,
    MaXacThuc NVARCHAR(6),	  -- Mã xác thực gồm 6 chữ số
    ThoiGianHetHan DATETIME,  -- Thời gian hết hạn của mã xác thực
    DaSuDung BIT DEFAULT 0,			
    FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND) ON DELETE CASCADE
);

INSERT INTO MaXacThucNguoiDung (MAND, MaXacThuc, ThoiGianHetHan, DaSuDung)
VALUES
    (1, '123456', DATEADD(MINUTE, 10, GETDATE()), 0),
    (2, '654321', DATEADD(MINUTE, 15, GETDATE()), 0),
    (3, '111222', DATEADD(MINUTE, 20, GETDATE()), 1),
    (4, '333444', DATEADD(MINUTE, 30, GETDATE()), 0),
    (5, '555666', DATEADD(MINUTE, 25, GETDATE()), 1);


--1. Thủ tục đăng nhập xác thực 2 yếu tố
CREATE PROCEDURE sp_DangNhap_2FA
    @UserName NVARCHAR(255),
    @Password NVARCHAR(50),
    @MaXacThuc NVARCHAR(6)
AS
BEGIN
    DECLARE @MAND INT

    -- Kiểm tra tên đăng nhập và mật khẩu
    SELECT @MAND = MAND 
    FROM NGUOIDUNG 
    WHERE USERNAME = @UserName AND MATKHAU = @Password

    IF @MAND IS NOT NULL
    BEGIN
        -- Kiểm tra mã xác thực
        IF EXISTS (
            SELECT * 
            FROM MaXacThucNguoiDung 
            WHERE MAND = @MAND 
            AND MaXacThuc = @MaXacThuc 
            AND ThoiGianHetHan > GETDATE() 
            AND DaSuDung = 0
        )
        BEGIN
            -- Đánh dấu mã xác thực đã sử dụng
            UPDATE MaXacThucNguoiDung 
            SET DaSuDung = 1 
            WHERE MAND = @MAND AND MaXacThuc = @MaXacThuc

            SELECT 'Đăng nhập thành công' AS Message
        END
        ELSE
        BEGIN
            SELECT 'Mã xác thực không hợp lệ hoặc đã hết hạn' AS Message
        END
    END
    ELSE
    BEGIN
        SELECT 'Sai tên đăng nhập hoặc mật khẩu' AS Message
    END
END

EXEC sp_DangNhap_2FA 
    @UserName = 'MinhQuun',
    @Password = '123',
    @MaXacThuc = '123456';


--2. Thủ tục Gửi mã xác thực
CREATE PROCEDURE sp_GuiMaXacThuc
    @MAND INT
AS
BEGIN
    -- Tạo mã xác thực gồm 6 chữ số ngẫu nhiên
    DECLARE @MaXacThuc NVARCHAR(6) = RIGHT('000000' + CAST((ABS(CHECKSUM(NEWID())) % 1000000) AS NVARCHAR(6)), 6)
    DECLARE @ThoiGianHetHan DATETIME = DATEADD(MINUTE, 5, GETDATE()) -- Mã xác thực có hạn 5 phút

    -- Lưu mã xác thực vào bảng MaXacThucNguoiDung
    INSERT INTO MaXacThucNguoiDung (MAND, MaXacThuc, ThoiGianHetHan, DaSuDung)
    VALUES (@MAND, @MaXacThuc, @ThoiGianHetHan, 0)

    -- Giả lập việc gửi mã (thực tế bạn sẽ gửi mã qua email hoặc SMS)
    SELECT @MaXacThuc AS 'MaXacThuc', 'Mã xác thực đã được gửi. Vui lòng kiểm tra email hoặc SMS.' AS Message
END

EXEC sp_GuiMaXacThuc @MAND = 1;


--3. Thủ tục Thêm NGƯỜI DÙNG
CREATE PROCEDURE sp_ThemNguoiDung
    @Ten NVARCHAR(255),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(20),
    @UserName VARCHAR(255),
    @MatKhau VARCHAR(50)
AS
BEGIN
    -- Kiểm tra trùng tên đăng nhập
    IF EXISTS (SELECT * FROM NGUOIDUNG WHERE USERNAME = @UserName)
    BEGIN
        SELECT 'Tên đăng nhập đã tồn tại' AS Message;
        RETURN;
    END

    -- Thêm người dùng mới không gán quyền
    INSERT INTO NGUOIDUNG (TEN, NGAYSINH, SODIENTHOAI, USERNAME, MATKHAU)
    VALUES (@Ten, @NgaySinh, @SoDienThoai, @UserName, @MatKhau);

    SELECT 'Tạo người dùng thành công' AS Message;
END

EXEC sp_ThemNguoiDung 
    @Ten = N'Nguyen Van B',
    @NgaySinh = '1985-05-15',
    @SoDienThoai = '0987654321',
    @UserName = 'nguyenvanb',
    @MatKhau = 'password456';


--4. Thủ tục CẤP QUYỀN NGƯỜI DÙNG
CREATE PROCEDURE sp_CapQuyenNguoiDung
    @UserName VARCHAR(255),
    @MaQuyen VARCHAR(10)
AS
BEGIN
    DECLARE @MAND INT

    -- Lấy MAND của người dùng
    SELECT @MAND = MAND FROM NGUOIDUNG WHERE USERNAME = @UserName

    IF @MAND IS NULL
    BEGIN
        SELECT 'Người dùng không tồn tại' AS Message;
        RETURN;
    END

    -- Kiểm tra quyền có tồn tại hay không
    IF NOT EXISTS (SELECT * FROM QUYEN WHERE MAQUYEN = @MaQuyen)
    BEGIN
        SELECT 'Quyền không tồn tại' AS Message;
        RETURN;
    END

    -- Cấp quyền cho người dùng
    UPDATE NGUOIDUNG SET MAQUYEN = @MaQuyen WHERE MAND = @MAND;

    SELECT 'Cấp quyền thành công' AS Message;
END

EXEC sp_CapQuyenNguoiDung 
    @UserName = 'tri',
    @MaQuyen = 'Q3';


--5. Thủ tục HỦY QUYỀN NGƯỜI DÙNG
CREATE PROCEDURE sp_HuyQuyenNguoiDung
    @UserName VARCHAR(255)
AS
BEGIN
    DECLARE @MAND INT

    -- Lấy MAND của người dùng
    SELECT @MAND = MAND FROM NGUOIDUNG WHERE USERNAME = @UserName

    IF @MAND IS NULL
    BEGIN
        SELECT 'Người dùng không tồn tại' AS Message;
        RETURN;
    END

    -- Hủy quyền của người dùng
    UPDATE NGUOIDUNG SET MAQUYEN = NULL WHERE MAND = @MAND;

    SELECT 'Hủy quyền thành công' AS Message;
END

EXEC sp_HuyQuyenNguoiDung 
    @UserName = 'lu';
