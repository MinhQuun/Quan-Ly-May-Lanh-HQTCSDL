USE QL_MAYLANH_HQTCSDL
--1: Kiểm tra số lượng tài khoản trong bảng NGUOIDUNG
GO
CREATE PROCEDURE Login_CountUser
AS
BEGIN
    SELECT COUNT(*) FROM NGUOIDUNG;
END;

--2: Kiểm tra thông tin đăng nhập và lấy vai trò của người dùng
GO
CREATE PROCEDURE Login_GetUserRole
    @username NVARCHAR(50),
    @password NVARCHAR(50)
AS
BEGIN
    SELECT MAQUYEN 
    FROM NGUOIDUNG 
    WHERE USERNAME = @username 
      AND MATKHAU = @password;
END;