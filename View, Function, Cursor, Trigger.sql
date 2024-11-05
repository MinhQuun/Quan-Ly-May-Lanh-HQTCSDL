USE QL_MAYLANH_HQTCSDL
GO

---VIEW
--doanh thu từ các hóa đơn xuất theo từng tháng và năm
CREATE VIEW V_DOANHTHUTHEOTHANGNAM AS
SELECT 
    MONTH(HDX.NGAY) AS THANG,
    YEAR(HDX.NGAY) AS NAM,
    SUM(TONGTIEN) AS TONGDOANHTHU
FROM 
    HOADONXUAT AS HDX
GROUP BY 
    MONTH(HDX.NGAY), YEAR(HDX.NGAY);
GO
SELECT * FROM V_DOANHTHUTHEOTHANGNAM
GO

--sản phẩm bán chạy nhất sắp xếp dựa trên số lượng đã bán từ chi tiết hóa đơn xuất
CREATE VIEW V_SANPHAMBANCHAY AS
SELECT 
    CTHDX.MASANPHAM,
    SP.TENSANPHAM,
    SUM(CTHDX.SOLUONG) AS TONGSOLUONGDABAN
FROM 
    CHITIETHOADONXUAT AS CTHDX
JOIN 
    SANPHAM AS SP ON CTHDX.MASANPHAM = SP.MASANPHAM
GROUP BY 
    CTHDX.MASANPHAM, SP.TENSANPHAM;
GO
SELECT * 
FROM V_SANPHAMBANCHAY
ORDER BY TONGSOLUONGDABAN DESC;
GO

--doanh thu từ từng khách hàng để xác định khách hàng có giá trị mua hàng cao nhất.
CREATE VIEW V_THONGKEDOANHTHUTHEOKHACHHANG AS
SELECT 
    KHACHHANG.MAKH,
    KHACHHANG.TENKH,
    SUM(HOADONXUAT.TONGTIEN) AS TONGDOANHTHU
FROM 
    HOADONXUAT
JOIN 
    KHACHHANG ON HOADONXUAT.MAKH = KHACHHANG.MAKH
GROUP BY 
    KHACHHANG.MAKH, KHACHHANG.TENKH;
	GO
SELECT * 
FROM V_THONGKEDOANHTHUTHEOKHACHHANG
ORDER BY TONGDOANHTHU DESC;
GO

--số lượng tồn kho hiện tại của từng sản phẩm trong hệ thống
CREATE VIEW V_SOLUONGTONKHO AS
SELECT 
    MASANPHAM,
    TENSANPHAM,
    SOLUONG AS SOLUONGTONKHO
FROM 
    SANPHAM
WHERE 
    SOLUONG > 0

GO
SELECT * 
FROM V_SOLUONGTONKHO
ORDER BY SOLUONGTONKHO DESC;
GO

--số lượng và giá trị hóa đơn nhập theo từng nhà cung cấp
CREATE VIEW V_HOADONNHAPTHEONCC AS
SELECT 
    NHACUNGCAP.MANCC,
    NHACUNGCAP.TENNCC,
    COUNT(HOADONNHAP.MAHDN) AS SOLUONGHOADONNHAP,
    SUM(HOADONNHAP.TONGTIEN) AS TONGGIATRINHAP
FROM 
    HOADONNHAP
JOIN 
    NHACUNGCAP ON HOADONNHAP.MANCC = NHACUNGCAP.MANCC
GROUP BY 
    NHACUNGCAP.MANCC, NHACUNGCAP.TENNCC;
GO
SELECT * 
FROM V_HOADONNHAPTHEONCC
ORDER BY TONGGIATRINHAP DESC;
GO

---FUNCTION
-- tính tổng giá trị hóa đơn
CREATE FUNCTION fn_CalculateOrderValue (@MaHoaDon VARCHAR(10))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TotalValue DECIMAL(18, 2);
    
    SELECT @TotalValue = SUM(CTHDX.SOLUONG * DONGIABAN)
    FROM CHITIETHOADONXUAT CTHDX
    INNER JOIN SANPHAM ON CTHDX.MASANPHAM = SANPHAM.MASANPHAM
    WHERE CTHDX.MAHDX = @MaHoaDon;

    RETURN ISNULL(@TotalValue, 0);
END;
SELECT dbo.fn_CalculateOrderValue('HDX002') AS TotalOrderValue;

--lấy thông tin nhà cung cấp và sản phẩm liên quan
CREATE FUNCTION fn_GetSupplierProducts (@MaNCC VARCHAR(10))
RETURNS TABLE
AS
RETURN (
    SELECT NCC.MANCC, NCC.TENNCC, NCC.DIACHI, SP.MASANPHAM, SP.TENSANPHAM, SP.DONGIANHAP, SP.DONGIABAN
    FROM NHACUNGCAP AS NCC
    JOIN SANPHAM AS SP ON NCC.MANCC = SP.MANCC
    WHERE NCC.MANCC = @MaNCC
);
SELECT * 
FROM dbo.fn_GetSupplierProducts('DAI');

--tổng số lượng sản phẩm hiện có trong kho
CREATE FUNCTION fn_TotalStock()
RETURNS INT
AS
BEGIN
    DECLARE @TotalStock INT;
    SELECT @TotalStock = SUM(SOLUONG) FROM SANPHAM;
    RETURN ISNULL(@TotalStock, 0);
END;
SELECT dbo.fn_TotalStock() AS TotalStock;

--tính tổng số tiền đã chi để nhập một sản phẩm cụ thể
CREATE FUNCTION fn_TotalImportCost(@MaSanPham VARCHAR(10))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TotalCost DECIMAL(18, 2);
    SELECT @TotalCost = SUM(SOLUONG * DONGIA) FROM CTHOADONNHAP WHERE MASANPHAM = @MaSanPham;
    RETURN ISNULL(@TotalCost, 0);
END;
SELECT dbo.fn_TotalImportCost('SP7') AS TotalImportCost;

--tính tổng số tiền bán của một sản phẩm
CREATE FUNCTION fn_TotalSalesRevenue(@MaSanPham VARCHAR(10))
RETURNS DECIMAL(18, 2)
AS
BEGIN
    DECLARE @TotalRevenue DECIMAL(18, 2);
    
    SELECT @TotalRevenue = SUM(SOLUONG * DONGIA)
    FROM CHITIETHOADONXUAT
    WHERE MASANPHAM = @MaSanPham;

    RETURN ISNULL(@TotalRevenue, 0);
END;
SELECT dbo.fn_TotalSalesRevenue('SP4') AS TotalSalesRevenue;


---CURSOR
--cập nhật giá bán khi giá nhập thay đổi
DECLARE @MASANPHAM VARCHAR(10), @DONGIANHAP DECIMAL(18,2), @DONGIABAN DECIMAL(18,2);
DECLARE product_cursor CURSOR FOR SELECT MASANPHAM, DONGIANHAP FROM SANPHAM;

OPEN product_cursor;
FETCH NEXT FROM product_cursor INTO @MASANPHAM, @DONGIANHAP;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @DONGIABAN = @DONGIANHAP * 1.2;  -- Giả định tăng 20%
    UPDATE SANPHAM SET DONGIABAN = @DONGIABAN WHERE MASANPHAM = @MASANPHAM;

    FETCH NEXT FROM product_cursor INTO @MASANPHAM, @DONGIANHAP;
END

CLOSE product_cursor;
DEALLOCATE product_cursor;



--Cập nhật tồn kho sản phẩm khi xuất kho:
DECLARE @MaSanPham VARCHAR(10), @SoLuong INT;
DECLARE sale_cursor CURSOR FOR SELECT MASANPHAM, SOLUONG FROM CHITIETHOADONXUAT;

OPEN sale_cursor;
FETCH NEXT FROM sale_cursor INTO @MaSanPham, @SoLuong;

WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE SANPHAM SET SOLUONG = SOLUONG - @SoLuong WHERE MASANPHAM = @MaSanPham;
    FETCH NEXT FROM sale_cursor INTO @MaSanPham, @SoLuong;
END

CLOSE sale_cursor;
DEALLOCATE sale_cursor;


--Xóa các sản phẩm không có trong kho và đã bán hết
DECLARE @MaSanPham VARCHAR(10);
DECLARE product_cursor CURSOR FOR 
    SELECT MASANPHAM 
    FROM SANPHAM 
    WHERE SOLUONG = 0 AND NOT EXISTS (
        SELECT 1 FROM CHITIETHOADONXUAT WHERE MASANPHAM = SANPHAM.MASANPHAM
    );

OPEN product_cursor;
FETCH NEXT FROM product_cursor INTO @MaSanPham;

WHILE @@FETCH_STATUS = 0
BEGIN
    DELETE FROM SANPHAM WHERE MASANPHAM = @MaSanPham;
    FETCH NEXT FROM product_cursor INTO @MaSanPham;
END

CLOSE product_cursor;
DEALLOCATE product_cursor;

--Tăng giá bán sản phẩm nếu số lượng tồn dưới 3
DECLARE @MaSanPham VARCHAR(10), @SoLuong INT, @DonGiaBan DECIMAL(18, 2);
DECLARE price_increase_cursor CURSOR FOR 
    SELECT MASANPHAM, SOLUONG, DONGIABAN 
    FROM SANPHAM 
    WHERE SOLUONG < 3;

OPEN price_increase_cursor;
FETCH NEXT FROM price_increase_cursor INTO @MaSanPham, @SoLuong, @DonGiaBan;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @DonGiaBan = @DonGiaBan * 1.1;  -- Tăng giá bán thêm 10%
    UPDATE SANPHAM 
    SET DONGIABAN = @DonGiaBan 
    WHERE MASANPHAM = @MaSanPham;

    FETCH NEXT FROM price_increase_cursor INTO @MaSanPham, @SoLuong, @DonGiaBan;
END

CLOSE price_increase_cursor;
DEALLOCATE price_increase_cursor;

--cập nhật tồn kho sản phẩm khi có nhập hàng mới
DECLARE @MaSanPham VARCHAR(10), @SoLuong INT;
DECLARE stock_update_cursor CURSOR FOR 
    SELECT MASANPHAM, SOLUONG 
    FROM CTHOADONNHAP;

OPEN stock_update_cursor;
FETCH NEXT FROM stock_update_cursor INTO @MaSanPham, @SoLuong;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Cập nhật số lượng tồn kho của sản phẩm trong bảng SANPHAM
    UPDATE SANPHAM 
    SET SOLUONG = SOLUONG + @SoLuong 
    WHERE MASANPHAM = @MaSanPham;

    FETCH NEXT FROM stock_update_cursor INTO @MaSanPham, @SoLuong;
END

CLOSE stock_update_cursor;
DEALLOCATE stock_update_cursor;


---TRIGGER
--kiểm tra số lượng tồn kho trước khi xuất hàng
CREATE TRIGGER trg_CheckStockBeforeSale
ON CHITIETHOADONXUAT
FOR INSERT
AS
BEGIN
    DECLARE @MASANPHAM VARCHAR(10), @SOLUONG INT, @CurrentStock INT;

    DECLARE cur CURSOR FOR SELECT MASANPHAM, SOLUONG FROM INSERTED;
    OPEN cur;
    FETCH NEXT FROM cur INTO @MASANPHAM, @SOLUONG;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @CurrentStock = SOLUONG FROM SANPHAM WHERE MASANPHAM = @MASANPHAM;

        IF @CurrentStock < @SOLUONG
        BEGIN
            RAISERROR ('Không đủ  %s', 16, 1, @MASANPHAM);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        FETCH NEXT FROM cur INTO @MASANPHAM, @SOLUONG;
    END

    CLOSE cur;
    DEALLOCATE cur;
END;

--cập nhật số lượng tồn kho sau khi hàng được nhập
CREATE TRIGGER trg_UpdateStockOnImport
ON CTHOADONNHAP
AFTER INSERT
AS
BEGIN
    DECLARE @MaSanPham VARCHAR(10), @SoLuongNhap INT;

    DECLARE cur CURSOR FOR SELECT MASANPHAM, SOLUONG FROM INSERTED;
    OPEN cur;
    FETCH NEXT FROM cur INTO @MaSanPham, @SoLuongNhap;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE SANPHAM SET SOLUONG = SOLUONG + @SoLuongNhap WHERE MASANPHAM = @MaSanPham;
        FETCH NEXT FROM cur INTO @MaSanPham, @SoLuongNhap;
    END

    CLOSE cur;
    DEALLOCATE cur;
END;
--tự động cập nhật số lượng tồn kho khi xuất hàng
CREATE TRIGGER trg_UpdateStockOnSale
ON CHITIETHOADONXUAT
AFTER INSERT
AS
BEGIN
    DECLARE @MaSanPham VARCHAR(10), @SoLuong INT;

    DECLARE sale_cursor CURSOR FOR 
        SELECT MASANPHAM, SOLUONG 
        FROM INSERTED;

    OPEN sale_cursor;
    FETCH NEXT FROM sale_cursor INTO @MaSanPham, @SoLuong;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        UPDATE SANPHAM 
        SET SOLUONG = SOLUONG - @SoLuong 
        WHERE MASANPHAM = @MaSanPham;

        FETCH NEXT FROM sale_cursor INTO @MaSanPham, @SoLuong;
    END

    CLOSE sale_cursor;
    DEALLOCATE sale_cursor;
END;
--tự động cập nhật tổng tiền hóa đơn khi có thay đổi về chi tiết đơn hàng
CREATE TRIGGER trg_UpdateTotalAmountOnOrderChange
ON CHITIETHOADONXUAT
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @MaHoaDon VARCHAR(10);

    -- Lấy mã hóa đơn từ các bản ghi mới hoặc đã bị thay đổi
    IF EXISTS (SELECT * FROM INSERTED)
        SELECT @MaHoaDon = MAHDX FROM INSERTED;
    ELSE
        SELECT @MaHoaDon = MAHDX FROM DELETED;

    -- Tính lại tổng tiền dựa trên chi tiết đơn hàng
    DECLARE @TotalAmount DECIMAL(18, 2);
    SELECT @TotalAmount = SUM(SOLUONG * MAHDX)
    FROM CHITIETHOADONXUAT
    WHERE MAHDX = @MaHoaDon;

    -- Cập nhật tổng tiền trong bảng HOADONXUAT
    UPDATE HOADONXUAT 
    SET TONGTIEN = ISNULL(@TotalAmount, 0)
    WHERE MAHDX = @MaHoaDon;
END;

-- Trigger tự động cập nhật giá bán khi giá nhập thay đổi
CREATE TRIGGER trg_UpdateSellingPriceOnCostChange
ON SANPHAM
AFTER UPDATE
AS
BEGIN
    DECLARE @MaSanPham VARCHAR(10), @GiaNhap DECIMAL(18,2), @GiaBan DECIMAL(18,2);

    SELECT @MaSanPham = MASANPHAM, @GiaNhap = DONGIANHAP FROM INSERTED;
    SET @GiaBan = @GiaNhap * 1.2; -- Tăng giá bán lên 20% từ giá nhập

    UPDATE SANPHAM
    SET DONGIABAN = @GiaBan
    WHERE MASANPHAM = @MaSanPham;
END;
