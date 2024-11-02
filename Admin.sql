USE QL_MAYLANH_HQTCSDL 

--DASHBOARD
--1: đếm số lượng Admin:
GO
CREATE PROCEDURE Admin_CountAdmins
AS
BEGIN
    SELECT COUNT(*) AS AdminCount FROM NGUOIDUNG WHERE MAQUYEN = 'Q1';
END;
--2: đếm số lượng Nhân viên:
GO
CREATE PROCEDURE Admin_CountEmployees
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount FROM NGUOIDUNG WHERE MAQUYEN IN ('Q2', 'Q3');
END;

EXEC Admin_CountEmployees;


--ADD USER: 
--1:lấy tất cả vai trò:
GO
CREATE PROCEDURE Admin_GetAllRoles
AS
BEGIN
    SELECT * FROM QUYEN;
END;

--2: kiểm tra xem USERNAME đã tồn tại:
GO
CREATE PROCEDURE Admin_CheckUsernameExists
    @username NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) FROM NGUOIDUNG WHERE USERNAME = @username;
END;


--3: thêm người dùng mới:
GO
CREATE PROCEDURE Admin_InsertNguoiDung
    @TEN NVARCHAR(255),
    @NGAYSINH DATE = NULL,
    @SODIENTHOAI VARCHAR(20) = NULL,
    @USERNAME VARCHAR(255),
    @MATKHAU VARCHAR(50),
    @MAQUYEN VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra trùng lặp USERNAME
    IF EXISTS (SELECT 1 FROM NGUOIDUNG WHERE USERNAME = @USERNAME)
    BEGIN
        PRINT 'USERNAME đã tồn tại. Vui lòng chọn USERNAME khác.';
        RETURN;
    END

    -- Chèn dữ liệu vào bảng NGUOIDUNG
    INSERT INTO NGUOIDUNG (TEN, NGAYSINH, SODIENTHOAI, USERNAME, MATKHAU, MAQUYEN)
    VALUES (@TEN, @NGAYSINH, @SODIENTHOAI, @USERNAME, @MATKHAU, @MAQUYEN);

    -- Lấy giá trị MAND vừa được tạo
    DECLARE @NewMAND INT = SCOPE_IDENTITY();

    PRINT 'Thêm người dùng thành công. Mã người dùng mới là: ' + CAST(@NewMAND AS VARCHAR);
END;


EXEC Admin_InsertNguoiDung 
    @TEN = N'LUAN',
    @NGAYSINH = '1990-01-01',
    @SODIENTHOAI = '0912344678',
    @USERNAME = 'LUAN',
    @MATKHAU = '123',
    @MAQUYEN = 'Q3';

GO


--VIEW USER
--1: lấy tất cả người dùng:
GO
CREATE PROCEDURE Admin_GetAllUsers
AS
BEGIN
    SELECT * FROM NGUOIDUNG;
END;

--2: để tìm kiếm người dùng theo USERNAME:
GO
CREATE PROCEDURE Admin_SearchUserByUsername
    @username NVARCHAR(50)
AS
BEGIN
    SELECT * FROM NGUOIDUNG WHERE USERNAME LIKE '%' + @username + '%';
END;

--3: để xóa người dùng theo USERNAME:
GO
CREATE PROCEDURE Admin_DeleteUserByUsername
    @username NVARCHAR(50)
AS
BEGIN
    DELETE FROM NGUOIDUNG WHERE USERNAME = @username;
END;

GO

--PROFILE
--1:
GO
CREATE PROCEDURE Admin_GetUserByUsername
    @username NVARCHAR(50)
AS
BEGIN
    SELECT * FROM NGUOIDUNG WHERE USERNAME = @username;
END;
EXEC Admin_GetUserByUsername @username = 'MinhQuun'

--2:Update
GO
CREATE PROCEDURE Admin_UpdateUser
    @TEN NVARCHAR(255),
    @NGAYSINH DATE,
    @SODIENTHOAI VARCHAR(10),
    @MATKHAU NVARCHAR(255),
    @USERNAME NVARCHAR(50)
AS
BEGIN
    UPDATE NGUOIDUNG
    SET TEN = @TEN,
        NGAYSINH = @NGAYSINH,
        SODIENTHOAI = @SODIENTHOAI,
        MATKHAU = @MATKHAU
    WHERE USERNAME = @USERNAME;
END;
GO
