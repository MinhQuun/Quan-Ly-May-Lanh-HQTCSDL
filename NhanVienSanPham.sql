USE QL_MAYLANH_HQTCSDL 


--DASHBOARD
--1: Đếm số lượng Nhân viên sản phẩm:
GO
CREATE PROCEDURE NVSP_CountEmployees
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount FROM NGUOIDUNG WHERE MAQUYEN = 'Q2';
END;

EXEC NVSP_CountEmployees;


--ADD SUPPLIER
--1: Thêm nhà cung cấp:
GO
CREATE PROCEDURE NVSP_AddSupplier
    @MANCC VARCHAR(10),
    @TENNCC NVARCHAR(50),
    @DIACHI NVARCHAR(100)
AS
BEGIN
    -- Kiểm tra mã nhà cung cấp đã tồn tại hay chưa
    IF EXISTS (SELECT 1 FROM NHACUNGCAP WHERE MANCC = @MANCC)
    BEGIN
        -- Nếu tồn tại, trả về mã lỗi
        RAISERROR('Mã nhà cung cấp đã tồn tại', 16, 1);
        RETURN;
    END

    -- Thêm nhà cung cấp mới nếu mã chưa tồn tại
    INSERT INTO NHACUNGCAP (MANCC, TENNCC, DIACHI)
    VALUES (@MANCC, @TENNCC, @DIACHI);
END;

--2:
GO
CREATE PROCEDURE NVSP_CheckSupplierExistence
    @MANCC VARCHAR(10)
AS
BEGIN
    SELECT COUNT(*) AS SupplierCount
    FROM NHACUNGCAP
    WHERE MANCC = @MANCC;
END;


--VIEW SUPPLIER
--1: Tìm kiếm nhà cung cấp theo tên
GO
CREATE PROCEDURE NVSP_SearchSupplierByName
    @tenncc NVARCHAR(50)
AS
BEGIN
    SELECT * FROM NHACUNGCAP
    WHERE TENNCC LIKE '%' + @tenncc + '%';
END;

--2: Xóa nhà cung cấp theo tên

ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM_NHACUNGCAP
FOREIGN KEY (MANCC) REFERENCES NHACUNGCAP(MANCC)
ON DELETE CASCADE;

GO
CREATE PROCEDURE NVSP_DeleteSupplierByName
    @tenncc NVARCHAR(50)
AS
BEGIN
    DECLARE @mancc VARCHAR(10);

    -- Lấy mã nhà cung cấp từ tên nhà cung cấp
    SELECT @mancc = MANCC FROM NHACUNGCAP WHERE TENNCC = @tenncc;

    -- Kiểm tra nếu mã nhà cung cấp tồn tại
    IF @mancc IS NOT NULL
    BEGIN
        -- Xóa các bản ghi phụ thuộc trong CTHOADONNHAP trước
        DELETE FROM CTHOADONNHAP 
        WHERE MASANPHAM IN (SELECT MASANPHAM FROM SANPHAM WHERE MANCC = @mancc);

        -- Xóa các bản ghi trong HOADONNHAP liên quan đến nhà cung cấp
        DELETE FROM HOADONNHAP WHERE MANCC = @mancc;

        -- Xóa các sản phẩm liên quan trong bảng SANPHAM
        DELETE FROM SANPHAM WHERE MANCC = @mancc;

        -- Cuối cùng, xóa nhà cung cấp từ NHACUNGCAP
        DELETE FROM NHACUNGCAP WHERE MANCC = @mancc;

        PRINT 'Xóa nhà cung cấp và các sản phẩm liên quan thành công!';
    END
    ELSE
    BEGIN
        PRINT 'Nhà cung cấp không tồn tại!';
    END
END;




--3: Lưu trữ để tải tất cả nhà cung cấp
GO
CREATE PROCEDURE NVSP_GetAllSuppliers
AS
BEGIN
    SELECT * FROM NHACUNGCAP;
END;


--UPDATE SUPPLIER
--1: Tìm kiếm nhà cung cấp theo mã
GO
CREATE PROCEDURE NVSP_SearchSupplierByID
    @MANCC VARCHAR(10)
AS
BEGIN
    SELECT * FROM NHACUNGCAP WHERE MANCC = @MANCC;
END;

--2: Cập nhật thông tin nhà cung cấp
GO
CREATE PROCEDURE NVSP_UpdateSupplier
    @MANCC VARCHAR(10),
    @TENNCC NVARCHAR(50),
    @DIACHI NVARCHAR(100)
AS
BEGIN
    UPDATE NHACUNGCAP
    SET TENNCC = @TENNCC, DIACHI = @DIACHI
    WHERE MANCC = @MANCC;
END;


--ADD PRODUCT
--1: Kiểm tra sự tồn tại của mã sản phẩm
GO
CREATE PROCEDURE NVSP_CheckProductExistence
    @MASP VARCHAR(10)
AS
BEGIN
    SELECT COUNT(*) AS ProductCount
    FROM SANPHAM
    WHERE MASANPHAM = @MASP;
END;

--2: Thêm sản phẩm mới
GO
CREATE PROCEDURE NVSP_AddProduct
    @MASP VARCHAR(10),
    @TENSP NVARCHAR(100),
    @DONGIANHAP DECIMAL(18,0),
    @DONGIABAN DECIMAL(18,0),
    @MANCC VARCHAR(10)
AS
BEGIN
    INSERT INTO SANPHAM (MASANPHAM, TENSANPHAM, SOLUONG, DONGIANHAP, DONGIABAN, MANCC)
    VALUES (@MASP, @TENSP, 0, @DONGIANHAP, @DONGIABAN, @MANCC);
END;


--VIEW PRODUCT
--1: Tìm kiếm sản phẩm theo tên
GO
CREATE PROCEDURE NVSP_SearchProductByName
    @tensp NVARCHAR(100)
AS
BEGIN
    SELECT * FROM SANPHAM
    WHERE TENSANPHAM LIKE '%' + @tensp + '%';
END;

--2: Xóa sản phẩm theo tên
GO
CREATE PROCEDURE NVSP_DeleteProductByName
    @tensp NVARCHAR(100)
AS
BEGIN
    DECLARE @masp VARCHAR(10);

    -- Lấy mã sản phẩm từ tên sản phẩm
    SELECT @masp = MASANPHAM FROM SANPHAM WHERE TENSANPHAM = @tensp;

    -- Kiểm tra nếu mã sản phẩm tồn tại
    IF @masp IS NOT NULL
    BEGIN
        -- Xóa các bản ghi phụ thuộc trong CTHOADONNHAP trước
        DELETE FROM CTHOADONNHAP WHERE MASANPHAM = @masp;

        -- Sau đó xóa sản phẩm từ SANPHAM
        DELETE FROM SANPHAM WHERE MASANPHAM = @masp;

        PRINT 'Xóa sản phẩm thành công!';
    END
    ELSE
    BEGIN
        PRINT 'Sản phẩm không tồn tại!';
    END
END;

--3: Tải tất cả sản phẩm
GO
CREATE PROCEDURE NVSP_GetAllProducts
AS
BEGIN
    SELECT * FROM SANPHAM;
END;


--UPDATE PRODUCT
--1: Tìm kiếm sản phẩm theo mã
GO
CREATE PROCEDURE NVSP_SearchProductByID
    @MASANPHAM VARCHAR(10)
AS
BEGIN
    SELECT * FROM SANPHAM
    WHERE MASANPHAM = @MASANPHAM;
END;

--2: Cập nhật thông tin sản phẩm
GO
CREATE PROCEDURE NVSP_UpdateProduct
    @MASANPHAM VARCHAR(10),
    @TENSANPHAM NVARCHAR(100),
    @DONGIANHAP DECIMAL(18,0),
    @DONGIABAN DECIMAL(18,0),
    @MANCC VARCHAR(10)
AS
BEGIN
    UPDATE SANPHAM
    SET TENSANPHAM = @TENSANPHAM,
        DONGIANHAP = @DONGIANHAP,
        DONGIABAN = @DONGIABAN,
        MANCC = @MANCC
    WHERE MASANPHAM = @MASANPHAM;
END;
