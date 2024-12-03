USE QL_MAYLANH_HQTCSDL

-- 1. Tạo role
-- Tạo vai trò cho quản trị viên (Admin)
CREATE ROLE Admin;

-- Tạo vai trò cho nhân viên sản phẩm
CREATE ROLE NhanVienSanPham;

-- Tạo vai trò cho nhân viên kho hàng
CREATE ROLE NhanVienKho;

-- Tạo vai trò cho nhân viên tài chính
CREATE ROLE NhanVienTaiChinh;


-- 2. Cấp quyền (role)
-- ADMIN
-- Cấp quyền SELECT, INSERT, UPDATE, DELETE cho Admin trên bảng NGUOIDUNG
GRANT SELECT, INSERT, UPDATE, DELETE ON NGUOIDUNG TO Admin;

-- Cấp quyền GRANT để Admin có thể cấp quyền cho người khác
GRANT SELECT, INSERT, UPDATE, DELETE ON NGUOIDUNG TO Admin WITH GRANT OPTION;

-- Từ chối quyền GRANT cho tất cả các vai trò không phải Admin
DENY SELECT, INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienSanPham;
DENY SELECT, INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienKho;
DENY SELECT, INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienTaiChinh;


-- NVSP
-- Nhân viên sản phẩm có quyền SELECT, INSERT, UPDATE, DELETE trên bảng SANPHAM và NHACUNGCAP
GRANT SELECT, INSERT, UPDATE, DELETE ON SANPHAM TO NhanVienSanPham;
GRANT SELECT, INSERT, UPDATE, DELETE ON NHACUNGCAP TO NhanVienSanPham;

-- Nhân viên sản phẩm không có quyền trên bảng NGUOIDUNG
DENY INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienSanPham;

-- NVKHO
-- Nhân viên kho có quyền SELECT, INSERT, UPDATE, DELETE trên bảng HOADONNHAP, CTHOADONNHAP, HOADONXUAT, CHITIETHOADONXUAT
GRANT SELECT, INSERT, UPDATE, DELETE ON HOADONNHAP TO NhanVienKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CTHOADONNHAP TO NhanVienKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON HOADONXUAT TO NhanVienKho;
GRANT SELECT, INSERT, UPDATE, DELETE ON CHITIETHOADONXUAT TO NhanVienKho;

-- Nhân viên kho không có quyền trên bảng NGUOIDUNG
DENY INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienKho;


--NVTC
-- Nhân viên tài chính có quyền SELECT, INSERT, UPDATE, DELETE trên bảng HOADONXUAT, CHITIETHOADONXUAT, THONGKE
GRANT SELECT, INSERT, UPDATE, DELETE ON HOADONXUAT TO NhanVienTaiChinh;
GRANT SELECT, INSERT, UPDATE, DELETE ON CHITIETHOADONXUAT TO NhanVienTaiChinh;
GRANT SELECT, INSERT, UPDATE, DELETE ON THONGKE TO NhanVienTaiChinh;

-- Nhân viên tài chính không có quyền trên bảng NGUOIDUNG
DENY INSERT, UPDATE, DELETE ON NGUOIDUNG TO NhanVienTaiChinh;


--Ví dụ thực thi
-- Gán người dùng vào vai trò Admin
EXEC sp_addrolemember 'Admin', 'MinhQuun';

-- Gán người dùng vào vai trò Nhân Viên Sản Phẩm
EXEC sp_addrolemember 'NhanVienSanPham', 'Doan';

-- Gán người dùng vào vai trò Nhân Viên Kho Hàng
EXEC sp_addrolemember 'NhanVienKho', 'Son';