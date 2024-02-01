use ProjectQuanLyChuoiQuanCaPhe;

BACKUP DATABASE ProjectQuanLyChuoiQuanCaPhe TO DISK = 'F:\ProjectQuanLyChuoiQuanCaPhe.bak';

-- Tạo hàm tính tổng số Lượng Nhân Viên
CREATE FUNCTION FUNC_TinhTongSoLuongNhanVien ()
RETURNS bigint
AS
BEGIN
    DECLARE @tongSoLuong int;

    -- Lấy tổng tiền từ bảng HoaDon dựa trên mã hóa đơn
    SELECT @tongSoLuong = count(*)
    FROM NhanVien

    -- Trả về tổng tiền
    RETURN @tongsoLuong;
END;

SELECT dbo.FUNC_TinhTongSoLuongNhanVien() AS TotalEmployees


--delete from NhanVienDangKyCa
--delete from CaLamViec
--delete from NhanVienHuongLuong

--select *from TaiKhoan
--delete from TaiKhoan

select * from HoaDon
select * from SanPhamTrongHoaDon

--------------------------------------------------------------------------------------------------


--Tạo Role Nhân viên
CREATE ROLE role_NhanVien
--------------------------------------------------------------------------------------------------

go
--Phân quyền cho Nhân viên
--DENY EXECUTE TO role_NhanVien
--DENY SELECT TO role_NhanVien

GRANT SELECT, UPDATE, INSERT ON KhachHang to role_NhanVien
GRANT SELECT, UPDATE, INSERT ON HoaDon to role_NhanVien
GRANT SELECT, UPDATE, INSERT ON SanPhamTrongHoaDon to role_NhanVien
GRANT SELECT ON SanPham to role_NhanVien

GRANT SELECT ON [dbo].[FUNC_GetmaCSAndphanQuyen] to role_NhanVien
GRANT SELECT ON [dbo].[FUNC_GettenCSAnddiaChiCS] to role_NhanVien
GRANT EXECUTE ON [dbo].[PROC_ThemHoaDon] to role_NhanVien
GRANT EXECUTE ON [dbo].[PROC_ThemSanPhamTrongHoaDon] to role_NhanVien
GRANT EXECUTE ON [dbo].[PROC_XemKhachHang] to role_NhanVien
GRANT EXECUTE ON [dbo].[PROC_ThemKhachHang] to role_NhanVien
GRANT EXECUTE ON [dbo].[PROC_SuaKhachHang] to role_NhanVien
GRANT SELECT ON [dbo].[FUNC_TimKiemKhachHang] to role_NhanVien

DENY EXECUTE ON [dbo].[PROC_XoaKhachHang] to role_NhanVien

--------------------------------------------------------------------------------------------------

go
--Tạo Role Quản lý
CREATE ROLE role_QuanLy

--------------------------------------------------------------------------------------------------

go
--Phân quyền cho Quản lý
--DENY EXECUTE TO role_QuanLy
--DENY SELECT TO role_QuanLy

GRANT SELECT, UPDATE, INSERT ON KhachHang to role_QuanLy
GRANT SELECT ON MucLuong to role_QuanLy
GRANT SELECT ON NguyenLieu to role_QuanLy
GRANT SELECT ON NguyenLieuTaoThanhSanPham to role_QuanLy
GRANT SELECT ON SanPham to role_QuanLy
GRANT SELECT, UPDATE, INSERT, DELETE ON HoaDon TO role_QuanLy
GRANT SELECT, UPDATE, INSERT, DELETE ON DoanhThu TO role_QuanLy

GRANT SELECT ON [dbo].[FUNC_GetmaCSAndphanQuyen] to role_QuanLy
GRANT SELECT ON [dbo].[FUNC_GettenCSAnddiaChiCS] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemNhanVienTheoCoSo] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_ThemNhanVien] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_SuaNhanVien] to role_QuanLy

GRANT SELECT ON [dbo].[FUNC_CaLamViecTheoNgayCuaCoSo] to role_QuanLy
GRANT SELECT ON [dbo].[FUNC_TatCaCaLamViecCuaCoSo] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_ThemCaLamViec] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_Xoa1CaLamViec] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemSoLuongNguyenLieuConVaNhaCungCap] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemSanPham] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemNguyenLieuTaoThanhSanPham] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemMucLuong] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemNhanVienHuongLuong] to role_QuanLy
GRANT SELECT ON [dbo].[FUNC_TongCaLamCuaNhanVienTaiCoSo] to role_QuanLy
GRANT SELECT ON [dbo].[FUNC_TinhLuongCuaNhanVienTrongCoSo] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_ThemNhanVienHuongLuong] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XoaAllNhanVienDangKyCaLam] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XoaAllCaLamViec] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_TongKetNhanVienHuongLuong] to role_QuanLy
GRANT EXECUTE ON [dbo].[FUNC_TinhTongTienHoaDon] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemDoanhThuTrongNgay] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_ThemDoanhThuTrongThang] to role_QuanLy
GRANT EXECUTE ON [dbo].[FUNC_TinhTongTienDoanhThu] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemDoanhThuTrongThang] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_TongKetDoanhThu] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemKhachHang] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_SuaKhachHang] to role_QuanLy
GRANT SELECT ON [dbo].[FUNC_TimKiemKhachHang] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_Xoa1NhanVienDangKyCaLam] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemCaLamViecNhanVienTheoNgay] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_XemCaLamViecNhanVien] to role_QuanLy
GRANT EXECUTE ON [dbo].[PROC_ThemNhanVienDangKyCaLam] to role_QuanLy


DENY SELECT ON [dbo].[FUNC_TimKiemNhanVien] to role_QuanLy
DENY EXECUTE ON [dbo].[PROC_XemTaiKhoan] to role_QuanLy



--exec PROC_XemTaiKhoan
go
--Trigger Tạo TK
create or alter TRIGGER [dbo].[Trigger_CreateSQLTaiKhoan] ON TaiKhoan
AFTER INSERT
AS
	DECLARE @userName nvarchar(100), @password nvarchar(100), @phanQuyen nvarchar(100)
	SELECT @userName=nl.userName, @password=nl.password, @phanQuyen=nl.phanQuyen
	FROM inserted nl
BEGIN
	DECLARE @sqlString nvarchar(2000), @maPhanQuyen nvarchar(10)
	----
	SET @sqlString= 'CREATE LOGIN [' + @userName +'] WITH PASSWORD='''+ @passWord
	+''', DEFAULT_DATABASE=[ProjectQuanLyChuoiQuanCaPhe], CHECK_EXPIRATION=OFF,
	CHECK_POLICY=OFF'
	EXEC (@sqlString)
	----
	SET @sqlString= 'CREATE USER ' + @userName +' FOR LOGIN '+ @userName
	EXEC (@sqlString)
	----
	if (@phanQuyen = 'ad')
	EXEC sp_addsrvrolemember @userName,'sysadmin'
	else if(@phanQuyen = 'nv')
	EXEC sp_addrolemember 'role_NhanVien', @userName
	else
	EXEC sp_addrolemember 'role_QuanLy', @userName
END

go
--Trigger Xoá TK
CREATE OR ALTER TRIGGER [dbo].[Trigger_DeleteSQLTaiKhoan] ON TaiKhoan
AFTER DELETE
AS
BEGIN
	DECLARE @userNameToDelete nvarchar(100)
	SELECT @userNameToDelete = userName FROM deleted

	DECLARE @sqlString nvarchar(2000)

	-- Drop user from the database
	SET @sqlString = 'DROP USER ' + @userNameToDelete
	EXEC (@sqlString)

	-- Drop login
	SET @sqlString = 'DROP LOGIN ' + @userNameToDelete
	EXEC (@sqlString)
END

go
--Trigger Sửa TK
CREATE OR ALTER TRIGGER [dbo].[Trigger_UpdateSQLTaiKhoanPassword] ON TaiKhoan
AFTER UPDATE
AS
BEGIN
	DECLARE @userNameToUpdate nvarchar(100), @newPassword nvarchar(100)
	SELECT @userNameToUpdate = userName, @newPassword = password
	FROM inserted

	DECLARE @sqlString nvarchar(2000)

	-- Alter the login password
	SET @sqlString = 'ALTER LOGIN [' + @userNameToUpdate + '] WITH PASSWORD = ''' + @newPassword + ''''
	EXEC (@sqlString)
END


--------------------------------------------------------------------------------------------------

--insert into
--exec dbo.ThemMoiCoSo @maCS='cs6', @tenCS='SPKT6',@diaChiCS='1 VVN6'
--delete from CoSo where maCS = 'cs6'

--insert into CoSo values('cs7',N'SPKT7',N'1 VVN7')

--insert into TaiKhoan values ('cs1','nvcs1','1','nv')
--insert into TaiKhoan values ('cs1','qlcs1','1','ql')
--insert into TaiKhoan values ('','admin','admin','ad')

--delete from TaiKhoan
--select * from TaiKhoan

--select * from CoSo
--insert into CoSo values('','','')

--drop user nvcs01
--drop user nvcs2
--drop user admin

--select * from NhanVien
--delete from NhanVien where maNV = 'admin'




go
--Tạo dữ liệu mẫu
insert into TaiKhoan values('','admin','admin','ad')
insert into TaiKhoan values('cs1','qlcs1','1','ql')
insert into TaiKhoan values('cs1','nvcs1','1','nv')
insert into TaiKhoan values('cs2','qlcs2','2','ql')
insert into TaiKhoan values('cs2','nvcs2','2','nv')
insert into TaiKhoan values('cs3','qlcs3','3','ql')
insert into TaiKhoan values('cs3','nvcs3','3','nv')









--------------------------------------------------------------------------------------------------
go
--Bảng Cơ Sở
CREATE TABLE CoSo(
	maCS nvarchar(100) constraint PK_CoSo PRIMARY KEY,
	tenCS nvarchar(100) NOT NULL,
	diaChiCS nvarchar(100) NOT NULL,
);

--------------------------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into CoSo values
('','',''),
('cs1',N'U-Station',N'Thư Viện Khu A'),
('cs2',N'Cà Phê Ông Bầu',N'Khu A Tự Học'),
('cs3',N'Galaxy Food',N'Khu E')


--------------------------------------------------------------------------------------------------
go
-- Tạo view Cơ sở
CREATE VIEW V_CoSo AS
SELECT *FROM CoSo;

--------------------------------------------------------------------------------------------------
go
-- Tạo procedure XemViewCoSo
CREATE PROCEDURE PROC_XemCoSo
AS
SELECT *FROM V_CoSo

--------------------------------------------------------------------------------------------------
go
-- Tạo trigger sau khi thêm dữ liệu vào bảng CoSo
CREATE TRIGGER TG_CheckDuplicateCoSo
ON CoSo
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột 'tenCS'
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN CoSo cs ON i.tenCS = cs.tenCS
        WHERE i.maCS <> cs.maCS
    )
    BEGIN
        RAISERROR('Giá trị của cột Tên Cơ Sở bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- Kiểm tra trùng lặp giá trị của cột 'diaChiCS'
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN CoSo cs ON i.diaChiCS = cs.diaChiCS
        WHERE i.maCS <> cs.maCS
    )
    BEGIN
        RAISERROR('Giá trị của cột Địa Chỉ Cơ Sở bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END

--------------------------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng CoSo
CREATE PROCEDURE PROC_ThemCoSo (
    @maCS nvarchar(100),
    @tenCS nvarchar(100),
    @diaChiCS nvarchar(100)
)
AS
BEGIN
      INSERT INTO CoSo(maCS, tenCS, diaChiCS)
			VALUES (@maCS, @tenCS, @diaChiCS)
END


--------------------------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xoá dữ liệu từ bảng CoSo
CREATE PROCEDURE PROC_XoaCoSo (
	@maCS nvarchar(100)
)
AS 
BEGIN 
		DELETE FROM CoSo
				WHERE @maCS = maCS
END

--------------------------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu từ bảng CoSo
CREATE PROCEDURE PROC_SuaCoSo (
    @maCS nvarchar(100),
    @tenCS nvarchar(100),
    @diaChiCS nvarchar(100)
)
AS
BEGIN
    UPDATE CoSo
    SET tenCS = @tenCS, diaChiCS = @diaChiCS
    WHERE maCS = @maCS;
END

--------------------------------------------------------------------------------------------------
go
-- Function tìm kiếm cơ sở
CREATE FUNCTION FUNC_TimKiemCoSo
(
    @tenCS nvarchar(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT * 
    FROM CoSo
    WHERE tenCS = @tenCS
);

-------------------------------------------------------------------------------
go
---Bảng User TaiKhoan
CREATE TABLE TaiKhoan(
	maCS nvarchar(100) CONSTRAINT FK_TaiKhoan FOREIGN KEY REFERENCES CoSo(maCS),
	userName nvarchar(100) NOT NULL PRIMARY KEY,
	password nvarchar(100) NOT NULL,
	phanQuyen nvarchar(50) NOT NULL,
);

--------------------------------------------------------------------------------------------------


--------------------------------------------------------------------------------------------------
go
----Tạo View Tài Khoản
CREATE VIEW V_TaiKhoan AS
SELECT *FROM TaiKhoan;

-------------------------------------------------------------------------------
go
--Tạo procedure Xem View TaiKhoan
CREATE PROCEDURE PROC_XemTaiKhoan
AS
SELECT *FROM V_TaiKhoan

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng TaiKhoan
CREATE PROCEDURE PROC_ThemTaiKhoan (
    @maCS nvarchar(100),
	@userName nvarchar(100),
	@password nvarchar(100),
    @phanQuyen nvarchar(50)
)
AS
BEGIN
        INSERT INTO TaiKhoan(maCS, userName, password, phanQuyen)
        VALUES (@maCS, @userName, @password, @phanQuyen)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xoá dữ liệu từ bảng TaiKhoan
CREATE PROCEDURE PROC_XoaTaiKhoan (
	@userName nvarchar(100)
)
AS 
BEGIN 
		DELETE FROM TaiKhoan
				WHERE @userName = userName
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu từ bảng TaiKhoan
CREATE PROCEDURE PROC_SuaTaiKhoan(
    @userName nvarchar(100),
    @newPassword nvarchar(100)
)
AS
BEGIN
    UPDATE TaiKhoan
    SET password = @newPassword
    WHERE userName = @userName;
END

-------------------------------------------------------------------------------
go
-- Tạo hàm scalar để lấy maCS và phanQuyen dựa trên userName
create FUNCTION FUNC_GetmaCSAndphanQuyen (@userName nvarchar(100), @password nvarchar(100))
RETURNS TABLE
AS
RETURN (
    SELECT maCS, phanQuyen
    FROM TaiKhoan
    WHERE userName = @userName and password = @password
);

-------------------------------------------------------------------------------
go
-- Tạo hàm scalar để lấy tenCS và diaChiCS dựa trên maCS
CREATE FUNCTION FUNC_GettenCSAnddiaChiCS (@maCS nvarchar(100))
RETURNS TABLE
AS
RETURN (
    SELECT tenCS, diaChiCS
    FROM CoSo
    WHERE maCS = @maCS
);

--------------------------------------------------------------------------------
go
--Bảng Nhân Viên
CREATE TABLE NhanVien(
	maNV nvarchar(100) CONSTRAINT PK_NhanVien PRIMARY KEY,
	hoTenNV nvarchar(100) NOT NULL,
	gioiTinhNV nvarchar(100) NOT NULL,
	soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10),
	cMND nvarchar(13) NOT NULL CHECK(LEN(cMND)=12),
	maNQL nvarchar(100)  CONSTRAINT FK_NhanVien_maNQL FOREIGN KEY REFERENCES NhanVien(maNV),
	maCS nvarchar(100) CONSTRAINT FK_NhanVien_maCS FOREIGN KEY REFERENCES CoSo(maCS)
);

--------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into NhanVien values
('',N'admin',N'Nam','0948437348','051203013849','',''),
('qlcs1',N'Nguyễn Trọng Dũng',N'Nam','0000000001','000000000001','','cs1'),
('nv1cs1',N'Huỳnh Gia Hân',N'Nữ','0000000002','000000000002','qlcs1','cs1'),
('nv2cs1',N'Đỗ Ngọc Chí Công',N'Nam','0000000003','000000000003','qlcs1','cs1'),
('nv3cs1',N'Đỗ Ngọc Hân',N'Nữ','0000000004','000000000004','qlcs1','cs1'),
('qlcs2',N'Huỳnh Gia Hân',N'Nữ','0000000005','000000000005','','cs2'),
('nv1cs2',N'Nguyễn Trọng Dũng',N'Nam','0000000006','000000000006','qlcs2','cs2'),
('nv2cs2',N'Đỗ Ngọc Chí Công',N'Nam','0000000007','000000000007','qlcs2','cs2'),
('nv3cs2',N'Đỗ Ngọc Hân',N'Nữ','0000000008','000000000008','qlcs2','cs2'),
('qlcs3',N'Đỗ Ngọc Chí Công',N'Nam','0000000009','000000000009','','cs3'),
('nv1cs3',N'Nguyễn Trọng Dũng',N'Nam','0000000010','000000000010','qlcs3','cs3'),
('nv2cs3',N'Huỳnh Gia Hân',N'Nữ','0000000011','000000000011','qlcs3','cs3'),
('nv3cs3',N'Đỗ Ngọc Hân',N'Nữ','0000000012','000000000012','qlcs3','cs3')

--------------------------------------------------------------------------------
go
--tạo view Nhân Viên
CREATE VIEW V_NhanVien AS
SELECT *FROM NhanVien

--------------------------------------------------------------------------------
go
--tạo procedure xem view Nhân Viên
CREATE PROCEDURE PROC_XemNhanVien AS
SELECT *FROM V_NhanVien WHERE (maNV <> '' OR maNV <> NULL)

--------------------------------------------------------------------------------
go
--tạo procedure xem view Nhân Viên theo từng cơ sở của Quản Lý
CREATE PROCEDURE PROC_XemNhanVienTheoCoSo(@maCS nvarchar(100)) AS
SELECT *FROM V_NhanVien WHERE maCS = @maCS AND (maNQL <> '' OR maNQL <> NULL)

--PROC_XemNhanVienTheoCoSo 'cs1'

--select *from NhanVien

-------------------------------------------------------------------------------
go
-- Tạo trigger kiểm tra trùng lặp soDienThoai và cMND khi thêm hoặc sửa nhân viên
CREATE TRIGGER TG_CheckDuplicateNhanVien
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột soDienThoai
    IF EXISTS (
        SELECT 1
        FROM NhanVien nv
        INNER JOIN inserted i ON nv.soDienThoai = i.soDienThoai
        WHERE i.maNV IS NOT NULL AND i.maNV <> nv.maNV
    )
    BEGIN
        RAISERROR('Giá trị của cột Số Điện Thoại bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- Kiểm tra trùng lặp giá trị của cột cMND
    IF EXISTS (
        SELECT 1
        FROM NhanVien nv
        INNER JOIN inserted i ON nv.cMND = i.cMND
        WHERE i.maNV IS NOT NULL AND i.maNV <> nv.maNV
    )
    BEGIN
        RAISERROR('Giá trị của cột Chứng Minh Nhân Dân bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng NhanVien
CREATE PROCEDURE PROC_ThemNhanVien (
    @maNV nvarchar(100),
	@hoTenNV nvarchar(100),
	@gioiTinhNV nvarchar(100),
	@soDienThoai nvarchar(11),
	@cMND nvarchar(13),
	@maNQL nvarchar(100),
	@maCS nvarchar(100)
)
AS
BEGIN
     INSERT INTO NhanVien(maNV, hoTenNV, gioiTinhNV, soDienThoai, cMND, maNQL, maCS)
     VALUES (@maNV, @hoTenNV, @gioiTinhNV, @soDienThoai, @cMND, @maNQL, @maCS)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để Xóa dữ liệu bảng NhanVien
CREATE PROCEDURE PROC_XoaNhanVien (
    @maNV nvarchar(100)
)
AS
BEGIN
     DELETE FROM NhanVien
        WHERE maNV = @maNV
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để Sửa dữ liệu bảng NhanVien
CREATE PROCEDURE PROC_SuaNhanVien (
	@maNV nvarchar(100),
    @hoTenNV nvarchar(100),
	@gioiTinhNV nvarchar(100),
	@soDienThoai nvarchar(100),
	@cMND nvarchar(100)
)
AS
BEGIN
     UPDATE NhanVien SET hoTenNV = @hoTenNV, gioiTinhNV = @gioiTinhNV, soDienThoai = @soDienThoai, cMND = @cMND
     WHERE maNV = @maNV
END

-------------------------------------------------------------------------------
go
-- Function tìm kiếm Nhân Viên
CREATE FUNCTION FUNC_TimKiemNhanVien
(
    @hoTenNV nvarchar(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT * 
    FROM NhanVien
    WHERE hoTenNV = @hoTenNV
);

-------------------------------------------------------------------------------
go
--Bảng Ca Làm Việc
CREATE TABLE CaLamViec(
	maCLV nvarchar(100) CONSTRAINT PK_CaLamViec PRIMARY KEY,
	gioBD time NOT NULL,
	gioKT time NOT NULL
);

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng CaLamViec
create PROCEDURE PROC_ThemCaLamViec (
	@maCLV nvarchar(100),
	@gioBD time,
	@gioKT time
)
AS
BEGIN
      insert into CaLamViec 
	  values (@maCLV,@gioBD,@gioKT)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xóa 1 dữ liệu bảng CaLamViec
create PROCEDURE PROC_Xoa1CaLamViec (
	@maCLV nvarchar(100)
)
AS
BEGIN
        delete from CaLamViec 
		where maCLV = @maCLV
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xóa tất cả dữ liệu bảng CaLamViec của 1 cơ sở
create PROCEDURE PROC_XoaAllCaLamViec (
	@maCS nvarchar(100)
)
AS
BEGIN
        delete from CaLamViec 
		where maCLV like '%' + @maCS + '%'
END

-------------------------------------------------------------------------------
go
-- Tạo Function trả về Ca Làm Việc theo 1 ngày cụ thể của từng Cơ Sở
create FUNCTION FUNC_CaLamViecTheoNgayCuaCoSo(@maCS NVARCHAR(100), @ngayLam nvarchar(100))
RETURNS TABLE
AS
RETURN
(
    SELECT *from CaLamViec where maCLV like '%' + @maCS + '%' and maCLV like '%' + @ngayLam + '%'
);

-------------------------------------------------------------------------------
go
-- Tạo Function trả về Ca Làm Việc theo tất cả ngày của từng Cơ Sở
create FUNCTION FUNC_TatCaCaLamViecCuaCoSo(@maCS NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(
    SELECT *from CaLamViec where maCLV like '%' + @maCS + '%'
);

-------------------------------------------------------------------------------
go
--Bảng Nhân Viên Đăng Ký Ca Làm
CREATE TABLE NhanVienDangKyCa(
	maNV nvarchar(100) CONSTRAINT FK_NhanVienDangKyCa_maNV FOREIGN KEY REFERENCES NhanVien(maNV),
	maCLV nvarchar(100) CONSTRAINT FK_NhanVienDangKyCa_maCLV FOREIGN KEY REFERENCES CaLamViec(maCLV),
	ngayLam nvarchar(100) NOT NULL,
	CONSTRAINT PK_NhanVienDangKyCa PRIMARY KEY (maNV,maCLV)
);

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để Thêm dữ liệu bảng NhanVienDangKyCaLam
create PROCEDURE PROC_ThemNhanVienDangKyCaLam (
	@maCLV nvarchar(100),
    @maNV nvarchar(100),
	@ngayLam nvarchar(100)
)
AS
BEGIN
      INSERT INTO NhanVienDangKyCa(maCLV, maNV, ngayLam)
      VALUES (@maCLV, @maNV, @ngayLam)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để Xóa 1 dữ liệu bảng NhanVienDangKyCaLam
CREATE PROCEDURE PROC_Xoa1NhanVienDangKyCaLam (
	@maCLV nvarchar(100),
    @maNV nvarchar(100),
	@ngayLam nvarchar(100)
)
AS
BEGIN
     delete from NhanVienDangKyCa
	where maNV = @maNV and maCLV = @maCLV and ngayLam = @ngayLam
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để Xóa tất cả dữ liệu bảng NhanVienDangKyCaLam của từng cơ sở
CREATE PROCEDURE PROC_XoaAllNhanVienDangKyCaLam (
	@maCS nvarchar(100)
)
AS
BEGIN
     delete from NhanVienDangKyCa
	where maCLV like '%' + @maCS + '%'
END

-------------------------------------------------------------------------------
go
--Tạo view để xem Tất cả Ca Làm Việc Của Nhân Viên trong 1 cơ sở
create view V_CaLamViecCuaNhanVien as
select nv.maCS, nvdkc.ngayLam, clv.gioBD, clv.gioKT, clv.maCLV, nvdkc.maNV, nv.hoTenNV, nv.soDienThoai
from CaLamViec clv inner join NhanVienDangKyCa nvdkc on clv.maCLV = nvdkc.maCLV
					inner join NhanVien nv on nvdkc.maNV = nv.maNV

-------------------------------------------------------------------------------
go
--Tạo Procedure Xem View Tất Cả Ca Làm Việc Của Nhân Viên trong 1 cơ sở 
CREATE PROCEDURE PROC_XemCaLamViecNhanVien(@maCS nvarchar(100)) AS
SELECT *FROM V_CaLamViecCuaNhanVien WHERE maCS = @maCS

-------------------------------------------------------------------------------
go
--Tạo Procedure Xem View Ca Làm Việc Của Nhân Viên trong 1 cơ sở theo ngày
CREATE PROCEDURE PROC_XemCaLamViecNhanVienTheoNgay(@maCS nvarchar(100), @ngayLam nvarchar(100)) AS
SELECT *FROM V_CaLamViecCuaNhanVien WHERE maCS = @maCS and ngayLam = @ngayLam

--PROC_XemCaLamViecNhanVienTheoNgay 'cs1','20/11/2023'

-------------------------------------------------------------------------------
go
--Bảng Nguyên Liệu
create TABLE NguyenLieu(
	maNL nvarchar(100) CONSTRAINT PK_NguyenLieu PRIMARY KEY,
	tenNL nvarchar(100) NOT NULL,
	chiPhi int not null
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into NguyenLieu values
('botcaphe',N'Bột Cà Phê',4000), --caphesua, bacxiu, espresso, capheden, americano, capuchino, caphedaxay
('suadac',N'Sữa Đặc',3000), --caphesua, bacxiu
('duongtrang',N'Đường Trắng',1000), --capheden, americano, capuchino, trachanh, tradao, travai
('botcacao',N'Bột Ca Cao',5000), --capuchino
('suatuoi',N'Sữa Tươi',5000), --capuchino, lattedau, lattekhoaimon, lattematcha, vanilla, trasua
('quadau',N'Quả Dâu',4000), --lattedau
('kemtuoi',N'Kem Tươi',4000), --lattedau, lattekhoaimon, lattematcha, vanilla
('quakhoaimon',N'Quả Khoai Môn',6000), --lattekhoaimon
('botmatcha',N'Bột Matcha',5000), --lattematcha
('vanilla',N'Vanilla',5000), --vanilla
('quachanh',N'Quả Chanh',3000), --trachanh
('bottrachanh',N'Bột Trà Chanh',5000), --trachanh
('quadao',N'Quả Đào',7000), --tradao
('bottradao',N'Bột Trà Đào',5000), --tradao
('quavai',N'Quả Vải',6000), --travai
('bottravai',N'Bột Trà Vải',5000), --travai
('bottraden',N'Bột Trà Đen',2000), --trasua
('hattranchau',N'Hạt Trân Châu',4000), --trasua
('dalanh',N'Đá Lạnh',5000), --caphedaxay, matchadaxay
('nuocsuoi',N'Nước Suối',8000), --nuocsuoi
('tiramisu',N'Tiramisu',30000), --tiramisu
('redvelvet',N'Red Velvet',30000), --redvelvet
('macaron',N'Macaron',30000), --macaron
('banhflan',N'Bánh Flan',8000) --banhflan

--delete from NguyenLieu

-------------------------------------------------------------------------------
go
--Tạo procedure xem danh sách nguyên liệu
CREATE PROCEDURE PROC_XemNguyenLieu AS
SELECT *FROM NguyenLieu

-------------------------------------------------------------------------------
go
-- Tạo trigger sau khi thêm dữ liệu vào bảng NguyenLieu
create TRIGGER TG_CheckDuplicateNguyenLieu
ON NguyenLieu
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột 'tenNL'
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN NguyenLieu nl ON i.tenNL = nl.tenNL
        WHERE i.maNL <> nl.maNL
    )
    BEGIN
        RAISERROR('Giá trị của cột Tên Nguyên Liệu bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để sửa dữ liệu bảng NguyenLieu
create PROCEDURE PROC_SuaNguyenLieu(
	@maNL nvarchar(100),
	@tenNL nvarchar(100),
	@chiPhi int
)
AS
BEGIN
        update NguyenLieu set tenNL = @tenNL, chiPhi = @chiPhi where maNL = @maNL
END

-------------------------------------------------------------------------------
go
--Bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap(
    maNCC nvarchar(100) CONSTRAINT PK_NhaCungCap PRIMARY KEY,
    tenNguoiDaiDien nvarchar(100) NOT NULL,
    soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10), 
    email nvarchar(100) NOT NULL
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into NhaCungCap values
('ncc1',N'Đại Diện NCC1','0000000000','emailncc1@gmail.com'),
('ncc2',N'Đại Diện NCC2','0000000002','emailncc2@gmail.com'),
('ncc3',N'Đại Diện NCC3','0000000003','emailncc3@gmail.com'),
('ncc4',N'Đại Diện NCC4','0000000004','emailncc4@gmail.com'),
('ncc5',N'Đại Diện NCC5','0000000005','emailncc5@gmail.com'),
('ncc6',N'Đại Diện NCC6','0000000006','emailncc6@gmail.com'),
('ncc7',N'Đại Diện NCC7','0000000007','emailncc7@gmail.com'),
('ncc8',N'Đại Diện NCC8','0000000008','emailncc8@gmail.com'),
('ncc9',N'Đại Diện NCC9','0000000009','emailncc9@gmail.com'),
('ncc10',N'Đại Diện NCC10','0000000010','emailncc10@gmail.com'),
('ncc11',N'Đại Diện NCC11','0000000011','emailncc11@gmail.com'),
('ncc12',N'Đại Diện NCC12','0000000012','emailncc12@gmail.com'),
('ncc13',N'Đại Diện NCC13','0000000013','emailncc13@gmail.com'),
('ncc14',N'Đại Diện NCC14','0000000014','emailncc14@gmail.com'),
('ncc15',N'Đại Diện NCC15','0000000015','emailncc15@gmail.com'),
('ncc16',N'Đại Diện NCC16','0000000016','emailncc16@gmail.com'),
('ncc17',N'Đại Diện NCC17','0000000017','emailncc17@gmail.com'),
('ncc18',N'Đại Diện NCC18','0000000018','emailncc18@gmail.com'),
('ncc19',N'Đại Diện NCC19','0000000019','emailncc19@gmail.com'),
('ncc20',N'Đại Diện NCC20','0000000020','emailncc20@gmail.com'),
('ncc21',N'Đại Diện NCC21','0000000021','emailncc21@gmail.com'),
('ncc22',N'Đại Diện NCC22','0000000022','emailncc22@gmail.com'),
('ncc23',N'Đại Diện NCC23','0000000023','emailncc23@gmail.com'),
('ncc24',N'Đại Diện NCC24','0000000024','emailncc24@gmail.com')

-------------------------------------------------------------------------------
go
-- Tạo trigger kiểm tra trùng lặp soDienThoai và email khi thêm hoặc sửa Nhà Cung Cấp
CREATE TRIGGER TG_CheckDuplicateNhaCungCap
ON NhaCungCap
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột soDienThoai
    IF EXISTS (
        SELECT 1
        FROM NhaCungCap ncc
        INNER JOIN inserted i ON ncc.soDienThoai = i.soDienThoai
        WHERE i.maNCC IS NOT NULL AND i.maNCC <> ncc.maNCC
    )
    BEGIN
        RAISERROR('Giá trị của cột Số Điện Thoại bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END

    -- Kiểm tra trùng lặp giá trị của cột cMND
    IF EXISTS (
        SELECT 1
        FROM NhaCungCap ncc
        INNER JOIN inserted i ON ncc.email = i.email
        WHERE i.maNCC IS NOT NULL AND i.maNCC <> ncc.maNCC
    )
    BEGIN
        RAISERROR('Giá trị của cột Email bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END

-------------------------------------------------------------------------------
go
--View Xem các nhà cung cấp hiện tại
create view V_NhaCungCap as
select *from NhaCungCap

-------------------------------------------------------------------------------
go
-- Tạo procedure xem danh sách Nhà Cung Cấp
CREATE PROCEDURE PROC_XemNhaCungCap AS
SELECT *FROM V_NhaCungCap

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào Nhà Cung Cấp
CREATE PROCEDURE PROC_ThemNhaCungCap (
    @maNCC nvarchar(100),
	@tenNguoiDaiDien nvarchar(100),
	@soDienThoai nvarchar(100),
	@email nvarchar(11)
)
AS
BEGIN
     INSERT INTO NhaCungCap(maNCC, tenNguoiDaiDien, soDienThoai, email)
     VALUES (@maNCC, @tenNguoiDaiDien, @soDienThoai, @email) 
END

-------------------------------------------------------------------------------
go
--Tạo thủ tục chỉnh sửa Nhà Cung cấp
CREATE PROCEDURE PROC_SuaNhaCungCap (
	@maNCC nvarchar(100),
	@tenNguoiDaiDien nvarchar(100),
	@soDienThoai nvarchar(100),
	@email nvarchar(11)
)
AS
BEGIN
    UPDATE dbo.NhaCungCap
    SET tenNguoiDaiDien = @tenNguoiDaiDien, soDienThoai = @soDienThoai, email = @email
    WHERE maNCC = @maNCC;
END

-------------------------------------------------------------------------------
go
--Bảng Nhà Cung Cấp Cung Cấp Nguyên Liệu Cho Cơ Sở
create table NhaCungCapNguyenLieuChoCoSo(
	maNCC nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maNCC foreign key references NhaCungCap(maNCC),
	maCS nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maCS foreign key references CoSo(maCS),
	maNL nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maNL foreign key references NguyenLieu(maNL),
	soLuongNL int not null,
	constraint PK_NhaCungCapCungCapNguyenLieuChoCoSo primary key (maNCC,maCS)
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into NhaCungCapNguyenLieuChoCoSo values
('ncc1','cs1','botcaphe',1500),
('ncc1','cs2','botcaphe',1500),
('ncc1','cs3','botcaphe',1500),
('ncc2','cs1','suadac',1500),
('ncc2','cs2','suadac',1500),
('ncc2','cs3','suadac',1500),
('ncc3','cs1','duongtrang',1500),
('ncc3','cs2','duongtrang',1500),
('ncc3','cs3','duongtrang',1500),
('ncc4','cs1','botcacao',1500),
('ncc4','cs2','botcacao',1500),
('ncc4','cs3','botcacao',1500),
('ncc5','cs1','suatuoi',1500),
('ncc5','cs2','suatuoi',1500),
('ncc5','cs3','suatuoi',1500),
('ncc6','cs1','quadau',1500),
('ncc6','cs2','quadau',1500),
('ncc6','cs3','quadau',1500),
('ncc7','cs1','kemtuoi',1500),
('ncc7','cs2','kemtuoi',1500),
('ncc7','cs3','kemtuoi',1500),
('ncc8','cs1','quakhoaimon',1500),
('ncc8','cs2','quakhoaimon',1500),
('ncc8','cs3','quakhoaimon',1500),
('ncc9','cs1','botmatcha',1500),
('ncc9','cs2','botmatcha',1500),
('ncc9','cs3','botmatcha',1500),
('ncc10','cs1','vanilla',1500),
('ncc10','cs2','vanilla',1500),
('ncc10','cs3','vanilla',1500),
('ncc11','cs1','quachanh',1500),
('ncc11','cs2','quachanh',1500),
('ncc11','cs3','quachanh',1500),
('ncc12','cs1','bottrachanh',1500),
('ncc12','cs2','bottrachanh',1500),
('ncc12','cs3','bottrachanh',1500),
('ncc13','cs1','quadao',1500),
('ncc13','cs2','quadao',1500),
('ncc13','cs3','quadao',1500),
('ncc14','cs1','bottradao',1500),
('ncc14','cs2','bottradao',1500),
('ncc14','cs3','bottradao',1500),
('ncc15','cs1','quavai',1500),
('ncc15','cs2','quavai',1500),
('ncc15','cs3','quavai',1500),
('ncc16','cs1','bottravai',1500),
('ncc16','cs2','bottravai',1500),
('ncc16','cs3','bottravai',1500),
('ncc17','cs1','bottraden',1500),
('ncc17','cs2','bottraden',1500),
('ncc17','cs3','bottraden',1500),
('ncc18','cs1','hattranchau',1500),
('ncc18','cs2','hattranchau',1500),
('ncc18','cs3','hattranchau',1500),
('ncc19','cs1','dalanh',1500),
('ncc19','cs2','dalanh',1500),
('ncc19','cs3','dalanh',1500),
('ncc20','cs1','nuocsuoi',1500),
('ncc20','cs2','nuocsuoi',1500),
('ncc20','cs3','nuocsuoi',1500),
('ncc21','cs1','tiramisu',1500),
('ncc21','cs2','tiramisu',1500),
('ncc21','cs3','tiramisu',1500),
('ncc22','cs1','redvelvet',1500),
('ncc22','cs2','redvelvet',1500),
('ncc22','cs3','redvelvet',1500),
('ncc23','cs1','macaron',1500),
('ncc23','cs2','macaron',1500),
('ncc23','cs3','macaron',1500),
('ncc24','cs1','banhflan',1500),
('ncc24','cs2','banhflan',1500),
('ncc24','cs3','banhflan',1500)

-------------------------------------------------------------------------------
go
--View cho Bảng Nhà Cung Cấp Cung Cấp Nguyên Liệu Cho Cơ Sở
create view V_NhaCungCapNguyenLieuChoCoSo as
select ncc.maNCC, ncc.tenNguoiDaiDien, ncc.soDienThoai, ncc.email, cs.maCS, cs.tenCS, cs.diaChiCS, nl.maNL, nl.tenNL, nccnlcs.soLuongNL
from NhaCungCapNguyenLieuChoCoSo nccnlcs inner join CoSo cs on nccnlcs.maCS = cs.maCS
													inner join NguyenLieu nl on nccnlcs.maNL = nl.maNL
													inner join NhaCungCap ncc on nccnlcs.maNCC = ncc.maNCC

-------------------------------------------------------------------------------
go
--Thủ tục Xem View cho Bảng Nhà Cung Cấp Cung Cấp Nguyên Liệu Cho Cơ Sở
CREATE PROCEDURE PROC_XemNhaCungCapNguyenLieuChoCoSo AS
SELECT *FROM V_NhaCungCapNguyenLieuChoCoSo

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu vào NhaCungCapNguyenLieuChoCoSo
create PROCEDURE PROC_ThemNhaCungCapNguyenLieuChoCoSo (
    @maNCC nvarchar(100),
	@maCS nvarchar(100),
	@maNL nvarchar(100),
	@soLuongNL int
)
AS
BEGIN
	insert into NhaCungCapNguyenLieuChoCoSo 
	values(@maNCC,@maCS,@maNL,@soLuongNL)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để sửa dữ liệu vào NhaCungCapNguyenLieuChoCoSo
create PROCEDURE PROC_SuaNhaCungCapNguyenLieuChoCoSo (
    @maNCC nvarchar(100),
	@maCS nvarchar(100),
	@maNL nvarchar(100),
	@soLuongNL int
)
AS
BEGIN
	update NhaCungCapNguyenLieuChoCoSo set soLuongNL = @soLuongNL
	where maNCC = @maNCC and maCS = @maCS and maNL = @maNL
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xóa dữ liệu vào NhaCungCapNguyenLieuChoCoSo
CREATE PROCEDURE PROC_XoaNhaCungCapNguyenLieuChoCoSo (
    @maNCC nvarchar(100)
)
AS
BEGIN
	declare @soLuongNL int
	select @soLuongNL = sum(soLuongNL) from NhaCungCapNguyenLieuChoCoSo where maNCC = @maNCC

    IF @SoLuongNL > 0 
		BEGIN
			RAISERROR('Không thể xóa do Vẫn Còn Sản Phẩm được Sử dụng ở các cửa hàng', 16, 1);
			
		END
	ELSE
		BEGIN
			-- Nếu số lượng không phải là 0, xuất ra thông báo lỗi
			DELETE FROM NhaCungCapNguyenLieuChoCoSo WHERE maNCC = @maNCC;
		END
END

-------------------------------------------------------------------------------
go
--Function tìm kiếm NhaCungCapCungCapNguyenLieuChoCoSo
CREATE FUNCTION FUNC_TimKiemNhaCungCapNguyenLieuChoCoSo
(
    @soDienThoai nvarchar(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT ncc.maNCC, ncc.tenNguoiDaiDien, ncc.soDienThoai, ncc.email, cs.maCS, cs.tenCS, cs.diaChiCS, nl.maNL, nl.tenNL, nccnlcs.soLuongNL
    FROM NhaCungCap ncc
			LEFT OUTER JOIN NhaCungCapNguyenLieuChoCoSo nccnlcs ON ncc.maNCC = nccnlcs.maNCC
			LEFT OUTER JOIN CoSo cs ON nccnlcs.maCS = cs.maCS
			LEFT OUTER JOIN NguyenLieu nl ON nccnlcs.maNL = nl.maNL
    WHERE ncc.soDienThoai = @soDienThoai
);

-------------------------------------------------------------------------------
go
--Tạo View Số Lượng Còn của Nguyên Liệu và Thông Tin của Nhà Cung Cấp
create view V_SoLuongNguyenLieuConVaNhaCungCap as
select nccnlcs.maCS, nl.maNL, nl.tenNL, nccnlcs.soLuongNL, nl.chiPhi, ncc.tenNguoiDaiDien, ncc.soDienThoai, ncc.email
from NguyenLieu nl left outer join NhaCungCapNguyenLieuChoCoSo nccnlcs on nl.maNL = nccnlcs.maNL
					inner join NhaCungCap ncc on nccnlcs.maNCC = ncc.maNCC

-------------------------------------------------------------------------------
go
--Tạo procedure Xem View Số Lượng Còn của Nguyên Liệu và Thông Tin của Nhà Cung Cấp
CREATE PROCEDURE PROC_XemSoLuongNguyenLieuConVaNhaCungCap(@maCS nvarchar(100)) AS
BEGIN
	SELECT *FROM V_SoLuongNguyenLieuConVaNhaCungCap WHERE maCS = @maCS
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xóa dữ liệu Nhà Cung Cấp
CREATE PROCEDURE PROC_XoaNhaCungCap (
    @maNCC nvarchar(100)
)
AS
BEGIN
	 exec PROC_XoaNhaCungCapNguyenLieuChoCoSo @maNCC;

	 DECLARE @SoLuongMaNCC INT;
	SELECT @SoLuongMaNCC = COUNT(*) FROM NhaCungCapNguyenLieuChoCoSo WHERE maNCC = @maNCC;

	-- Nếu số lượng là 0, thì mới thực hiện xóa
	IF @SoLuongMaNCC = 0
		BEGIN
			DELETE FROM NhaCungCap WHERE maNCC = @maNCC;
		END
	ELSE
		BEGIN
			-- Nếu số lượng không phải là 0, xuất ra thông báo lỗi
			RAISERROR('Không thể xóa do tồn tại liên kết với NhaCungCapNguyenLieuChoCoSo.', 16, 1);
		END
END

-------------------------------------------------------------------------------
go
--Bảng Sản Phẩm
CREATE TABLE SanPham(
	maSP nvarchar(100) CONSTRAINT PK_SanPham PRIMARY KEY,
	tenSP nvarchar(100) NOT NULL,
	chiPhi int NOT NULL CHECK(chiPhi > 0)
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('caphesua',N'Cà Phê Sữa',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('bacxiu', N'BẠC XỈU',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('espresso', N'ESPRESSO', 20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('capheden',N'Cà Phê Đen',12000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('americano',N'AMERICANO',20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('capuchino',N'CAPUCHINO',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattedau',N'LATTE DÂU',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattekhoaimon',N'LATTE KHOAI MÔN',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattematcha',N'LATTE MATCHA',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('vanilla',N'VANILLA',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('trachanh',N'Trà Chanh',10000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('tradao' ,N'Trà Đào',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('travai',N'Trà Vải',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('trasua',N'Trà Sữa',20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('caphedaxay',N'Cà Phê Đá Xay',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('matchadaxay', N'MATCHA ĐÁ Xay',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('nuocsuoi', N'Nước Suối',10000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('tiramisu', N'TIRAMISU',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('redvelvet',N'RED VELVET',40000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('macaron',N'MACARON',35000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('banhflan',N'Bánh FLAN',10000)

-------------------------------------------------------------------------------
go
-- Tạo view bảng SanPham
create view V_SanPham as
select *from SanPham	

-------------------------------------------------------------------------------
go
-- tạo procedure Xem Danh Sách Sản Phẩm
CREATE PROCEDURE PROC_XemSanPham AS
SELECT *FROM V_SanPham

-------------------------------------------------------------------------------
go
--Bảng Nguyên Liệu Tạo Thành Sản Phẩm
CREATE TABLE NguyenLieuTaoThanhSanPham(
	maNL nvarchar(100) CONSTRAINT FK_NguyenLieuTaoRaSanPham_maNL FOREIGN KEY REFERENCES NguyenLieu(maNL),
	maSP nvarchar(100) CONSTRAINT FK_NguyenLieuTaoRaSanPham_maSP FOREIGN KEY REFERENCES SanPham(maSP),
	soLuongNLCan int NOT NULL CHECK(soLuongNLCan > 0),
	CONSTRAINT PK_NguyenLieuTaoRaSanPham PRIMARY KEY (maNL,maSP)
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into NguyenLieuTaoThanhSanPham values
('botcaphe','caphesua',5),
('botcaphe','bacxiu',5),
('botcaphe','espresso',5),
('botcaphe','capheden',5),
('botcaphe','americano',5),
('botcaphe','capuchino',5),
('botcaphe','caphedaxay',5),
('suadac','caphesua',2),
('suadac','bacxiu',4),
('duongtrang','capheden',2),
('duongtrang','americano',2),
('duongtrang','capuchino',2),
('duongtrang','trachanh',2),
('duongtrang','tradao',2),
('duongtrang','travai',2),
('botcacao','capuchino',5),
('suatuoi','capuchino',3),
('suatuoi','lattedau',3),
('suatuoi','lattekhoaimon',3),
('suatuoi','lattematcha',3),
('suatuoi','vanilla',3),
('suatuoi','trasua',5),
('quadau','lattedau',2),
('kemtuoi','lattedau',3),
('kemtuoi','lattekhoaimon',3),
('kemtuoi','lattematcha',3),
('kemtuoi','vanilla',3),
('quakhoaimon','lattekhoaimon',2),
('botmatcha','lattematcha',3),
('vanilla','vanilla',3),
('quachanh','trachanh',2),
('bottrachanh','trachanh',4),
('quadao','tradao',2),
('bottradao','tradao',4),
('quavai','travai',2),
('bottravai','travai',4),
('bottraden','trasua',5),
('hattranchau','trasua',5),
('dalanh','caphedaxay',5),
('dalanh','matchadaxay',5),
('nuocsuoi','nuocsuoi',1),
('tiramisu','tiramisu',1),
('redvelvet','redvelvet',1),
('macaron','macaron',1),
('banhflan','banhflan',1)

-------------------------------------------------------------------------------
go
-- Tạo View dữ liệu bảng NguyenLieuTaoThanhSanPham
create view V_NguyenLieuTaoThanhSanPham as
select nlttsp.maNL, nl.tenNL, nlttsp.maSP, sp.tenSP, nlttsp.soLuongNLCan 
from NguyenLieuTaoThanhSanPham nlttsp inner join NguyenLieu nl on nlttsp.maNL = nl.maNL
											  inner join SanPham sp on nlttsp.maSP = sp.maSP

-------------------------------------------------------------------------------
go
-- tạo procedure xem Nguyên Liệu Tạo Thành Sản Phẩm
CREATE PROCEDURE PROC_XemNguyenLieuTaoThanhSanPham AS
SELECT *FROM V_NguyenLieuTaoThanhSanPham

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để sửa dữ liệu bảng NguyenLieuTaoThanhSanPham
CREATE PROCEDURE PROC_SuaNguyenLieuTaoThanhSanPham(
	@maNL nvarchar(100),
	@maSP nvarchar(100),
	@soLuongNLCan int
)
AS
BEGIN
        update NguyenLieuTaoThanhSanPham set soLuongNLCan = @soLuongNLCan
		where maNL = @maNL and maSP = @maSP
END

-------------------------------------------------------------------------------
go
--Bảng Doanh Thu
create TABLE DoanhThu(
	maDoanhThu nvarchar(100) CONSTRAINT PK_DoanhThu PRIMARY KEY,
     maCS nvarchar(100) CONSTRAINT FK_DoanhThu FOREIGN KEY REFERENCES CoSo(maCS),
	soTienDoanhThu int NOT NULL CHECK(SoTienDoanhThu>=0),
	ngayDoanhThu nvarchar(100) NOT NULL
);

--------------------------------------------------------------------------------
go
--Tạo view Doanh Thu
CREATE VIEW V_DoanhThu AS
SELECT *FROM DoanhThu

-------------------------------------------------------------------------------
go
--Tạo procedure xem doanh thu tháng theo maCS
CREATE PROCEDURE PROC_XemDoanhThuTrongThang(@maCS nvarchar(100)) AS
BEGIN
	SELECT *FROM V_DoanhThu WHERE maCS = @maCS
END

-------------------------------------------------------------------------------
go
-- Tạo hàm tính tổng tiền cho bảng DoanhThu
CREATE FUNCTION FUNC_TinhTongTienDoanhThu (@maCS nvarchar(100))
RETURNS int
AS
BEGIN
    DECLARE @tongTien int;

    -- Lấy tổng tiền từ bảng DoanhThu dựa trên mã Cơ Sở
    SELECT @tongTien = sum(soTienDoanhThu)
    FROM DoanhThu
    WHERE maCS = @maCS

    -- Trả về tổng tiền
    RETURN @tongTien;
END;

-------------------------------------------------------------------------------
go
--Tổng kết doanh thu cuối tháng theo maCS
CREATE procedure PROC_TongKetDoanhThu(@maCS nvarchar) as
begin
	delete from DoanhThu WHERE maDoanhThu LIKE '%' + @maCS + '%'
end

--EXEC PROC_TongKetDoanhThu 'cs1'
--select *from DoanhThu
--insert into DoanhThu values('20112023_cs1','cs1',11112003,'11/11/2003')
--insert into DoanhThu values('21112023_cs1','cs1',11112003,'12/11/2003')

--delete from DoanhThu
-------------------------------------------------------------------------------
go
--Bảng Mức Lương
CREATE TABLE MucLuong(
	maML nvarchar(100) CONSTRAINT PK_MucLuong PRIMARY KEY,
	soTien int NOT NULL CHECK(soTien > 0)
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into MucLuong values
('_NV_A',125000),
('_NV_B',150000),
('_QL_A',525000),
('_QL_B',600000)

-------------------------------------------------------------------------------
go
--View Mức Lương
create view V_MucLuong as
select *from MucLuong

-------------------------------------------------------------------------------
go
--Tạo procedure xem Mức Lương
CREATE PROCEDURE PROC_XemMucLuong AS
SELECT *FROM V_MucLuong

-------------------------------------------------------------------------------
go
-- procedure Sửa số Tiền Lương
create procedure PROC_SuaMucLuong (@maML nvarchar(100), @soTien int) as
begin
	update MucLuong set soTien = @soTien where maML = @maML
end

-------------------------------------------------------------------------------
go
--Bảng Khách Hàng
CREATE TABLE KhachHang(
	maKH nvarchar(100) CONSTRAINT PK_KhachHang PRIMARY KEY,	
	tenKH nvarchar(100) NOT NULL,
	soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10)
);

-------------------------------------------------------------------------------
go
--Tạo dữ liệu mẫu
insert into KhachHang values
('kh1',N'Nguyễn Trọng Dũng','0948437348'),
('kh2',N'Đỗ Ngọc Chí Công','0000000000'),
('kh3',N'Huỳnh Gia Hân','0000000001')

-------------------------------------------------------------------------------
go
--View Khách Hàng
create view V_KhachHang as
select *from KhachHang

-------------------------------------------------------------------------------
go
--Tạo Procedure để xem bảng KhachHang
CREATE PROCEDURE PROC_XemKhachHang
AS
SELECT *FROM V_KhachHang

-------------------------------------------------------------------------------
go
-- Tạo trigger sau khi thêm dữ liệu vào bảng KhachHang
CREATE TRIGGER TG_CheckDuplicateKhachHang
ON KhachHang
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột 'soDienThoai'
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN KhachHang kh ON i.soDienThoai = kh.soDienThoai
        WHERE i.maKH <> kh.maKH
    )
    BEGIN
        RAISERROR('Giá trị của cột Số Điện Thoại bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng KhachHang
CREATE PROCEDURE PROC_ThemKhachHang (
    @maKH nvarchar(100),
    @tenKH nvarchar(100),
    @soDienThoai nvarchar(100)
)
AS
BEGIN
      INSERT INTO KhachHang
			VALUES (@maKH, @tenKH, @soDienThoai)
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để xóa dữ liệu bảng KhachHang
CREATE PROCEDURE PROC_XoaKhachHang (
    @maKH nvarchar(100)
)
AS
BEGIN
      delete from KhachHang
	  where maKH = @maKH
END

-------------------------------------------------------------------------------
go
-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu bảng KhachHang
CREATE PROCEDURE PROC_SuaKhachHang (
    @maKH nvarchar(100),
	@tenKH nvarchar(100),
    @soDienThoai nvarchar(100)
)
AS
BEGIN
      update KhachHang set tenKH = @tenKH, soDienThoai = @soDienThoai
	  where maKH = @maKH
END

-------------------------------------------------------------------------------
go
-- Function tim kiếm khách hàng
create FUNCTION FUNC_TimKiemKhachHang
(
    @soDienThoai nvarchar(100)
)
RETURNS TABLE
AS
RETURN (
    SELECT maKH, tenKH, soDienThoai
    FROM KhachHang
    WHERE soDienThoai = @soDienThoai
);

-------------------------------------------------------------------------------
go
--Bảng Hóa Đơn
CREATE TABLE HoaDon(
    maHoaDon nvarchar(100) CONSTRAINT PK_HoaDon PRIMARY KEY,
	maCS nvarchar(100) constraint FK_HoaDon_maCS references CoSo(maCS),
    tongTien int NOT NULL CHECK(tongTien > 0),
	maNV nvarchar(100) constraint FK_HoaDon_maNV references NhanVien(maNV),
	maKH nvarchar(100) constraint FK_HoaDon_maKH references KhachHang(maKH)
);

-------------------------------------------------------------------------------
go
-- Tạo procedure Thêm Hóa Đơn
CREATE PROCEDURE PROC_ThemHoaDon(@maHoaDon nvarchar(100), @maCS nvarchar(100), @tongTien int, @maNV nvarchar(100), @maKH nvarchar(100)) AS
BEGIN
	INSERT INTO HoaDon VALUES(@maHoaDon,@maCS,@tongTien,@maNV,@maKH)
END

-------------------------------------------------------------------------------
go
insert into HoaDon values
('21112023_1_cs1','cs1',140630,'nv1cs1','kh1'),
('21112023_2_cs1','cs1',102463,'nv1cs1','kh1'),
('21112023_3_cs1','cs1',100762,'nv1cs1','kh1'),
('21112023_4_cs1','cs1',221437,'nv1cs1','kh1'),
('21112023_5_cs1','cs1',69070,'nv1cs1','kh1'),
('21112023_6_cs1','cs1',279665,'nv1cs1','kh1'),
('21112023_7_cs1','cs1',272062,'nv1cs1','kh1'),
('21112023_8_cs1','cs1',179556,'nv1cs1','kh1'),
('21112023_9_cs1','cs1',166644,'nv1cs1','kh1'),
('21112023_10_cs1','cs1',179816,'nv1cs1','kh1'),
('21112023_11_cs1','cs1',130748,'nv1cs1','kh1'),
('21112023_12_cs1','cs1',142836,'nv1cs1','kh1'),
('21112023_13_cs1','cs1',99825,'nv1cs1','kh1'),
('21112023_14_cs1','cs1',111400,'nv1cs1','kh1'),
('21112023_15_cs1','cs1',107913,'nv1cs1','kh1'),
('21112023_16_cs1','cs1',23180,'nv1cs1','kh1'),
('21112023_17_cs1','cs1',80277,'nv1cs1','kh3'),
('21112023_18_cs1','cs1',169359,'nv1cs1','kh3'),
('21112023_19_cs1','cs1',121150,'nv1cs1','kh3'),
('21112023_20_cs1','cs1',106937,'nv1cs1','kh1'),
('21112023_21_cs1','cs1',163122,'nv1cs1','kh1'),
('21112023_22_cs1','cs1',78071,'nv1cs1','kh2'),
('21112023_23_cs1','cs1',145973,'nv1cs1','kh1'),
('21112023_24_cs1','cs1',73209,'nv1cs1','kh1'),
('21112023_25_cs1','cs1',172537,'nv1cs1','kh3'),
('21112023_26_cs1','cs1',185670,'nv1cs1','kh1'),
('21112023_27_cs1','cs1',156562,'nv1cs1','kh2'),
('21112023_28_cs1','cs1',141306,'nv2cs1','kh3'),
('21112023_29_cs1','cs1',15395,'nv1cs1','kh2'),
('21112023_30_cs1','cs1',67989,'nv1cs1','kh1')

-------------------------------------------------------------------------------
go
--Tạo view Doanh Thu Trong ngày theo từng cơ sở (xem dựa trên HoaDon)
CREATE VIEW V_HoaDon AS 
SELECT * FROM HoaDon 

-------------------------------------------------------------------------------
go
--Tạo procedure xem Doanh Thu Trong ngày theo từng cơ sở (xem dựa trên HoaDon)
CREATE PROCEDURE PROC_XemDoanhThuTrongNgay(@maCS nvarchar(100)) AS
BEGIN
	SELECT * FROM V_HoaDon 
	WHERE maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%') AND maCS = @maCS
END

-------------------------------------------------------------------------------
go
-- Tạo hàm tính tổng tiền của Hóa đơn để thêm vào DoanhThu của 1 cơ sở cụ thể
CREATE FUNCTION FUNC_TinhTongTienHoaDon (@maCS nvarchar(100))
RETURNS bigint
AS
BEGIN
    DECLARE @tongTien int;

    -- Lấy tổng tiền từ bảng HoaDon dựa trên mã hóa đơn
    SELECT @tongTien = sum(tongTien)
    FROM HoaDon
    WHERE maCS = @maCS and maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%')

    -- Trả về tổng tiền
    RETURN @tongTien;
END;

-------------------------------------------------------------------------------
go
-- Thêm từ Hóa Đơn vào Doanh Thu Tháng của 1 cơ sở cụ thể
create procedure PROC_ThemDoanhThuTrongThang(
	@maDoanhThu nvarchar(100),
	@maCS nvarchar(100),
	@ngayDoanhThu nvarchar(100)
)
as
begin
	declare @sumTongTien int
	-- Gọi hàm để lấy tổng tiền
    SET @sumTongTien = dbo.FUNC_TinhTongTienHoaDon(@maCS);

	begin
		insert into DoanhThu
		values(@maDoanhThu,@maCS,@sumTongTien,@ngayDoanhThu)
	end

	begin
		delete from SanPhamTrongHoaDon 
		where maHoaDon LIKE '%' + @maCS + '%'
	end

	begin
		delete from HoaDon 
		where maCS = @maCS and maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%')
	end
end

-------------------------------------------------------------------------------
go
--Bảng Sản Phẩm Trong Hóa Đơn
CREATE TABLE SanPhamTrongHoaDon(
	maHoaDon nvarchar(100) CONSTRAINT FK_SanPhamTrongHoaDon_maHoaDon FOREIGN KEY REFERENCES HoaDon(maHoaDon),
	maSP nvarchar(100) CONSTRAINT FK_SanPhamTrongHoaDon_maSP FOREIGN KEY REFERENCES SanPham(maSP),
	chiPhiSP int NOT NULL CHECK(chiPhiSP > 0),
	soLuongSP int NOT NULL CHECK(soLuongSP > 0),
	CONSTRAINT FK_SanPhamTrongHoaDon PRIMARY KEY (maHoaDon,maSP)
);

-------------------------------------------------------------------------------
go
-- Tạo procedure thêm Sản phẩm trong hóa đơn
CREATE PROCEDURE PROC_ThemSanPhamTrongHoaDon(@maHoaDon nvarchar(100), @maSP nvarchar(100), @chiPhiSP int, @soLuongSP int) AS
BEGIN
	INSERT INTO SanPhamTrongHoaDon VAlUES(@maHoaDon,@maSP,@chiPhiSP,@soLuongSP)
END

-------------------------------------------------------------------------------
go
--Bảng Nhân Viên Hưởng Lương
CREATE TABLE NhanVienHuongLuong(
	maNV nvarchar(100) CONSTRAINT FK_NhanVienHuongLuong_maNV FOREIGN KEY REFERENCES NhanVien(maNV),
	maML nvarchar(100) CONSTRAINT FK_NhanVienHuongLuong_maML FOREIGN KEY REFERENCES MucLuong(maML),
	soTien int not null,
	CONSTRAINT PK_NhanVienHuongLuong PRIMARY KEY (maNV,maML)
);

-------------------------------------------------------------------------------
go
--Tạo Function tính số lượng ca làm trong tháng của Nhân Viên tại 1 cơ sở cụ thể
CREATE FUNCTION FUNC_TongCaLamCuaNhanVienTaiCoSo(@maCS NVARCHAR(100))
RETURNS TABLE
AS
RETURN (

	select maNV, '_NV_A' as loaiCa, count(*) as soLuong from NhanVienDangKyCa 
	where RIGHT(maCLV, 5) IN ('_NV_A') AND maCLV LIKE '%' + @maCS + '%'
	group by maNV
	union
	select maNV, '_NV_B' as loaiCa, count(*) as soLuong from NhanVienDangKyCa 
	where RIGHT(maCLV, 5) IN ('_NV_B') AND maCLV LIKE '%' + @maCS + '%'
	group by maNV
	union
	select maNV, '_QL_A' as loaiCa, count(*) as soLuong from NhanVienDangKyCa 
	where RIGHT(maCLV, 5) IN ('_QL_A') AND maCLV LIKE '%' + @maCS + '%'
	group by maNV
	union
	select maNV, '_QL_B' as loaiCa, count(*) as soLuong from NhanVienDangKyCa 
	where RIGHT(maCLV, 5) IN ('_QL_B') AND maCLV LIKE '%' + @maCS + '%'
	group by maNV
);

--delete from NhanVienDangKyCa
--delete from CaLamViec
--select *from CaLamViec
--select *from NhanVienDangKyCa
--select *from FUNC_TongCaLamCuaNhanVienTaiCoSo('cs1')
--delete from HoaDon
--delete from SanPhamTrongHoaDon
--select *from DoanhThu
-------------------------------------------------------------------------------
go
--tạo function tính lương theo tổng số ca làm của nhân viên tại 1 cơ sở cụ thể
create FUNCTION FUNC_TinhLuongCuaNhanVienTrongCoSo(@maCS NVARCHAR(100))
RETURNS TABLE
AS
RETURN
(

    SELECT
        tclcnv.maNV,
		tclcnv.loaiCa,
        ML.soTien * tclcnv.soLuong AS soTien
    FROM
        FUNC_TongCaLamCuaNhanVienTaiCoSo(@maCS) tclcnv
    JOIN
        MucLuong ML ON tclcnv.loaiCa = ML.maML
);

-------------------------------------------------------------------------------
go
--Tạo procedure Thêm vào bảng NhanVienHuongLuong theo từng cơ sở
create PROCEDURE PROC_ThemNhanVienHuongLuong(@maCS NVARCHAR(100))
AS
BEGIN
	begin
		delete from NhanVienHuongLuong
	end
	begin
		INSERT INTO NhanVienHuongLuong
		SELECT * FROM FUNC_TinhLuongCuaNhanVienTrongCoSo(@maCS);
	end
END;

--exec PROC_ThemNhanVienHuongLuong 'cs1'

-------------------------------------------------------------------------------
go
-- View Nhân Viên Hưởng Lương
create view V_NhanVienHuongLuong as
select maCS,nv.maNV, nv.hoTenNV, nvhl.maML, nvhl.soTien from NhanVienHuongLuong nvhl inner join NhanVien nv on nvhl.maNV = nv.maNV

-------------------------------------------------------------------------------
go
--Tạo procedure Xem Lương Mà Nhân Viên từng người nhận được
CREATE PROCEDURE PROC_XemNhanVienHuongLuong(@maCS nvarchar(100)) AS
BEGIN
	SELECT *FROM V_NhanVienHuongLuong WHERE maCS = @maCS
END

--exec PROC_XemNhanVienHuongLuong 'cs1'

-------------------------------------------------------------------------------
go
-- Tạo Procedure Tổng Kết Lương Cuối Tháng
CREATE PROCEDURE PROC_TongKetNhanVienHuongLuong(@maCS nvarchar(100)) AS
BEGIN
	EXEC PROC_XoaAllNhanVienDangKyCaLam @maCS
	EXEC PROC_XoaAllCaLamViec @maCS
END


-------------------------------------------------------------------------------
go
-- Trigger thay đổi số lượng còn lại của nguyên liệu mỗi khi có sản phẩm tương ứng được bán ra
CREATE TRIGGER TG_UpdateRemainingQuantities
ON SanPhamTrongHoaDon
AFTER INSERT
AS
BEGIN
    -- Lấy thông tin về sản phẩm và số lượng từ bản ghi mới được thêm vào
    DECLARE @maSP nvarchar(100)
    DECLARE @soLuongSP int
    DECLARE @maHoaDon nvarchar(100)

    SELECT @maSP = i.maSP, @soLuongSP = i.soLuongSP, @maHoaDon = i.maHoaDon
    FROM inserted i
    
    -- Tạo một bảng tạm để lưu trữ thông tin về nguyên liệu cần cập nhật
    CREATE TABLE #TempNguyenLieu (
        maNL nvarchar(100),
        soLuongCan int
    )

	-- Tạo một bảng tạm để lưu trữ thông tin về số lượng sản phẩm trong hóa đơn
    CREATE TABLE #TempSanPham (
        maSP nvarchar(100),
        soLuongSP int
    )
    
    -- Lấy thông tin về các nguyên liệu cần cập nhật từ bảng NguyenLieuTaoThanhSanPham
    INSERT INTO #TempNguyenLieu (maNL, soLuongCan)
    SELECT maNL, soLuongNLCan
    FROM NguyenLieuTaoThanhSanPham
    WHERE maSP = @maSP

    -- Cập nhật số lượng còn lại của NguyenLieu trong bảng NhaCungCapNguyenLieuChoCoSo
    UPDATE NhaCungCapNguyenLieuChoCoSo
    SET soLuongNL = soLuongNL - (t.soLuongCan * @soLuongSP)
		FROM NguyenLieu n
		JOIN #TempNguyenLieu t ON n.maNL = t.maNL
		JOIN NhaCungCapNguyenLieuChoCoSo nccnlccs ON nccnlccs.maNL = n.maNL
	where maCS LIKE right(@maHoaDon,3)
    
    -- Xóa bảng tạm
	DROP TABLE #TempSanPham
    DROP TABLE #TempNguyenLieu
END;
