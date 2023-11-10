use ProjectQuanLyChuoiQuanCaPhe;

drop *
--Bảng Cơ Sở
CREATE TABLE CoSo(
	maCS nvarchar(100) constraint PK_CoSo PRIMARY KEY,
	tenCS nvarchar(100) NOT NULL,
	diaChiCS nvarchar(100) NOT NULL,
);

-- Tạo view Cơ sở
CREATE VIEW V_CoSo AS
SELECT *FROM CoSo;

----------
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

----------
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng CoSo
CREATE PROCEDURE dbo.ThemMoiCoSo (
    @maCS nvarchar(100),
    @tenCS nvarchar(100),
    @diaChiCS nvarchar(100)
)
AS
BEGIN
      INSERT INTO CoSo(maCS, tenCS, diaChiCS)
			VALUES (@maCS, @tenCS, @diaChiCS)
END


----------
-- Tạo thủ tục lưu trữ để xoá dữ liệu từ bảng CoSo
CREATE PROCEDURE dbo.XoaCoSo (
	@maCS nvarchar(100)
)
AS 
BEGIN 
		DELETE FROM CoSo
				WHERE @maCS = maCS
END

----------
-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu từ bảng CoSo
CREATE PROCEDURE dbo.ChinhSuaCoSo (
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


-------------------------------------------------------------------------------
---Bảng User
CREATE TABLE Account(
	maCS nvarchar(100) CONSTRAINT FK_Account FOREIGN KEY REFERENCES CoSo(maCS),
	userName nvarchar(100) NOT NULL PRIMARY KEY,
	password nvarchar(100) NOT NULL,
	phanQuyen nvarchar(50) NOT NULL,
);

----Tạo View Account
CREATE VIEW V_Account AS
SELECT *FROM Account;
-----------------------

----------
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng Account
CREATE PROCEDURE dbo.ThemMoiAccount (
    @maCS nvarchar(100),
	@userName nvarchar(100),
	@password nvarchar(100),
    @phanQuyen nvarchar(50)
)
AS
BEGIN
        INSERT INTO Account(maCS, userName, password, phanQuyen)
        VALUES (@maCS, @userName, @password, @phanQuyen)
END



-- Tạo thủ tục lưu trữ để xoá dữ liệu từ bảng Account
CREATE PROCEDURE dbo.XoaAccount (
	@userName nvarchar(100)
)
AS 
BEGIN 
		DELETE FROM Account
				WHERE @userName = userName
END



-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu từ bảng Account
CREATE PROCEDURE dbo.ChinhSuaAccount (
    @userName nvarchar(100),
    @newPassword nvarchar(100)
)
AS
BEGIN
    UPDATE Account
    SET password = @newPassword
    WHERE userName = @userName;
END



-- Tạo hàm scalar để lấy maCS và phanQuyen dựa trên userName
create FUNCTION dbo.GetUserMaCSAndPhanQuyen (@userName nvarchar(100), @password nvarchar(100))
RETURNS TABLE
AS
RETURN (
    SELECT maCS, phanQuyen
    FROM Account
    WHERE userName = @userName and password = @password
);


-- Tạo hàm scalar để lấy tenCS và diaChiCS dựa trên maCS
CREATE FUNCTION dbo.GetTenAndDiaChiCS (@maCS nvarchar(100))
RETURNS TABLE
AS
RETURN (
    SELECT tenCS, diaChiCS
    FROM CoSo
    WHERE maCS = @maCS
);



--------------------------------------------------------------------------------
--Bảng Nhân Viên
CREATE TABLE NhanVien(
	maNV nvarchar(100) CONSTRAINT PK_NhanVien PRIMARY KEY,
	hoTenNV nvarchar(100) NOT NULL,
	gioiTinhNV nvarchar(100) NOT NULL,
	soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10),
	cMND nvarchar(13) NOT NULL CHECK(LEN(cMND)=12),
	maNQL nvarchar(100) CONSTRAINT FK_NhanVien_maNQL FOREIGN KEY REFERENCES NhanVien(maNV),
	maCS nvarchar(100) CONSTRAINT FK_NhanVien_maCS FOREIGN KEY REFERENCES CoSo(maCS)
);



---------------
--Tạo view Nhân Viên
-- Tạo view để xem tất cả cột trong bảng NhanVien
CREATE VIEW V_NhanVien AS
SELECT *FROM NhanVien


---------------
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


-----------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng NhanVien
CREATE PROCEDURE dbo.ThemMoiNhanVien (
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


----------------------
-- Tạo thủ tục lưu trữ để Xóa dữ liệu bảng NhanVien
CREATE PROCEDURE dbo.XoaNhanVien (
    @maNV nvarchar(100)
)
AS
BEGIN
     DELETE FROM NhanVien
        WHERE maNV = @maNV
END

-----------------------
-- Tạo thủ tục lưu trữ để Sửa dữ liệu bảng NhanVien
CREATE PROCEDURE dbo.SuaNhanVien (
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
--Bảng Ca Làm Việc
CREATE TABLE CaLamViec(
	maCLV nvarchar(100) CONSTRAINT PK_CaLamViec PRIMARY KEY,
	gioBD time NOT NULL,
	gioKT time NOT NULL
);


select *from CaLam


-----------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng CaLamViec
create PROCEDURE dbo.ThemMoiCLV (
	@maCLV nvarchar(100),
	@gioBD time,
	@gioKT time
)
AS
BEGIN
      insert into CaLamViec 
	  values (@maCLV,@gioBD,@gioKT)
END


-----------------
-- Tạo thủ tục lưu trữ để xóa dữ liệu bảng CaLamViec
create PROCEDURE dbo.XoaCLV (
	@maCLV nvarchar(100)
)
AS
BEGIN
        delete from CaLamViec 
		where maCLV = @maCLV
END


---------------
-- Tạo View Ca làm việc
create view V_CaLamViec as 
select *from CaLamViec



-------------------------------------------------------------------------------
--Bảng Nhân Viên Đăng Ký Ca Làm
CREATE TABLE NhanVienDangKyCa(
	maNV nvarchar(100) CONSTRAINT FK_NhanVienDangKyCa_maNV FOREIGN KEY REFERENCES NhanVien(maNV),
	maCLV nvarchar(100) CONSTRAINT FK_NhanVienDangKyCa_maCLV FOREIGN KEY REFERENCES CaLamViec(maCLV),
	ngayLam nvarchar(100) NOT NULL,
	CONSTRAINT PK_NhanVienDangKyCa PRIMARY KEY (maNV,maCLV)
);

select *from NhanVienDangKyCa


-------------
-- Tạo thủ tục lưu trữ để Thêm dữ liệu bảng NhanVienDangKyCaLam
create PROCEDURE dbo.ThemNhanVienDangKyCaLam (
	@maCLV nvarchar(100),
    @maNV nvarchar(100),
	@ngayLam nvarchar(100)
)
AS
BEGIN
      INSERT INTO NhanVienDangKyCa(maCLV, maNV, ngayLam)
      VALUES (@maCLV, @maNV, @ngayLam)
END

delete from NhanVienDangKyCa

-------------
-- Tạo thủ tục lưu trữ để Xóa dữ liệu bảng NhanVienDangKyCaLam
CREATE PROCEDURE dbo.XoaNhanVienDangKyCaLam (
	@maCLV nvarchar(100),
    @maNV nvarchar(100),
	@ngayLam nvarchar(100)
)
AS
BEGIN
     delete from NhanVienDangKyCa
	where maNV = @maNV and maCLV = @maCLV and ngayLam = @ngayLam
END


---------------------------
--Tạo view để xem Nhân Viên Đăng Ký Ca Làm Việc Nào
create view V_CaLamViecCuaNhanVien as
select nv.maCS, nvdkc.ngayLam, clv.gioBD, clv.gioKT, clv.maCLV, nvdkc.maNV, nv.hoTenNV, nv.soDienThoai
from CaLamViec clv inner join NhanVienDangKyCa nvdkc on clv.maCLV = nvdkc.maCLV
					inner join NhanVien nv on nvdkc.maNV = nv.maNV



-------------------------------------------------------------------------------
--Bảng Nguyên Liệu
create TABLE NguyenLieu(
	maNL nvarchar(100) CONSTRAINT PK_NguyenLieu PRIMARY KEY,
	tenNL nvarchar(100) NOT NULL,
	chiPhi int not null
);


--Tạo View xem Số Lượng NL cũng như bên cung cấp
create view V_NguyenLieuConVaCungCap as
select nccnlcs.maCS, nl.maNL, nl.tenNL, nccnlcs.soLuongNL, nl.chiPhi, ncc.tenNguoiDaiDien, ncc.soDienThoai, ncc.email
from NguyenLieu nl left outer join NhaCungCapNguyenLieuChoCoSo nccnlcs on nl.maNL = nccnlcs.maNL
					inner join NhaCungCap ncc on nccnlcs.maNCC = ncc.maNCC

select *from V_NguyenLieuConVaCungCap 

----------
-- Tạo trigger sau khi thêm dữ liệu vào bảng NguyenLieu
create TRIGGER TG_CheckDuplicateNguyenLieu
ON NguyenLieu
AFTER INSERT, UPDATE
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



-------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng NguyenLieu
create PROCEDURE dbo.ThemNguyenLieu(
	@maNL nvarchar(100),
    @tenNL nvarchar(100),
	@chiPhi int
)
AS
BEGIN
      insert into NguyenLieu
		values(@maNL,@tenNL,@chiPhi)
END



------------------
-- Tạo thủ tục lưu trữ để xóa dữ liệu bảng NguyenLieu
CREATE PROCEDURE dbo.XoaNguyenLieu(
	@maNL nvarchar(100)
)
AS
BEGIN
        delete from NguyenLieu where maNL = @maNL
END




------------------
-- Tạo thủ tục lưu trữ để sửa dữ liệu bảng NguyenLieu
create PROCEDURE dbo.SuaNguyenLieu(
	@maNL nvarchar(100),
	@tenNL nvarchar(100),
	@chiPhi int
)
AS
BEGIN
        update NguyenLieu set tenNL = @tenNL, chiPhi = @chiPhi where maNL = @maNL
END







-------------------------------------------------------------------------------
--Bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap(
    maNCC nvarchar(100) CONSTRAINT PK_NhaCungCap PRIMARY KEY,
    tenNguoiDaiDien nvarchar(100) NOT NULL,
    soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10), 
    email nvarchar(100) NOT NULL
);


-------------------------------------------------------------------------------
--View Xem các nhà cung cấp hiện tại
create view V_DanhSachNCC as
select *from NhaCungCap


-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào Nhà Cung Cấp
CREATE PROCEDURE dbo.ThemNhaCungCap (
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

------------------------------
--Tạo thủ tục chỉnh sửa Nhà Cung cấp
CREATE PROCEDURE dbo.ChinhSuaNhaCungCap (
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
--Bảng Nhà Cung Cấp Cung Cấp Nguyên Liệu Cho Cơ Sở
create table NhaCungCapNguyenLieuChoCoSo(
	maNCC nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maNCC foreign key references NhaCungCap(maNCC),
	maCS nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maCS foreign key references CoSo(maCS),
	maNL nvarchar(100) constraint FK_NhaCungCapCungCapNguyenLieuChoCoSo_maNL foreign key references NguyenLieu(maNL),
	soLuongNL int not null,
	constraint PK_NhaCungCapCungCapNguyenLieuChoCoSo primary key (maNCC,maCS)
);

-----------
--View cho Bảng Nhà Cung Cấp Cung Cấp Nguyên Liệu Cho Cơ Sở
create view V_NhaCungCapNguyenLieuChoCoSo as
select ncc.maNCC, ncc.tenNguoiDaiDien, ncc.soDienThoai, ncc.email, cs.maCS, cs.tenCS, cs.diaChiCS, nl.maNL, nl.tenNL, nccnlcs.soLuongNL
from NhaCungCapNguyenLieuChoCoSo nccnlcs inner join CoSo cs on nccnlcs.maCS = cs.maCS
													inner join NguyenLieu nl on nccnlcs.maNL = nl.maNL
													inner join NhaCungCap ncc on nccnlcs.maNCC = ncc.maNCC

-- Tạo thủ tục lưu trữ để xóa dữ liệu vào NhaCungCapNguyenLieuChoCoSo
create PROCEDURE dbo.ThemNhaCungCapNguyenLieuChoCoSo (
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



-- Tạo thủ tục lưu trữ để sửa dữ liệu vào NhaCungCapNguyenLieuChoCoSo
create PROCEDURE dbo.SuaNhaCungCapNguyenLieuChoCoSo (
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

-- Tạo thủ tục lưu trữ để xóa dữ liệu vào NhaCungCapNguyenLieuChoCoSo
create PROCEDURE dbo.XoaNhaCungCapNguyenLieuChoCoSo (
    @maNCC nvarchar(100)
)
AS
BEGIN
	declare @soLuongNL int
	select @soLuongNL = sum(soLuongNL) from NhaCungCapNguyenLieuChoCoSo where maNCC = @maNCC
    IF @SoLuongNL <= 0
		BEGIN
			DELETE FROM NhaCungCapNguyenLieuChoCoSo WHERE maNCC = @maNCC;
		END
	ELSE
		BEGIN
			-- Nếu số lượng không phải là 0, xuất ra thông báo lỗi
			RAISERROR('Không thể xóa do Vẫn Còn Sản Phẩm được Sử dụng ở các cửa hàng', 16, 1);
		END
END


exec dbo.XoaNhaCungCapNguyenLieuChoCoSo @maNCC = 'ncc3'


-- Tạo thủ tục lưu trữ để xóa dữ liệu vào Nhà Cung Cấp
CREATE PROCEDURE dbo.XoaNhaCungCap (
    @maNCC nvarchar(100)
)
AS
BEGIN
	 exec dbo.XoaNhaCungCapNguyenLieuChoCoSo @maNCC;

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
























------------------



------------------




------------------




































-------------------------------------------------------------------------------
--Bảng Sản Phẩm
CREATE TABLE SanPham(
	maSP nvarchar(100) CONSTRAINT PK_SanPham PRIMARY KEY,
	tenSP nvarchar(100) NOT NULL,
	chiPhi int NOT NULL CHECK(chiPhi > 0)
);

insert into dbo.SanPham(maSP,tenSP,chiphi) values ('caphesua',N'Cà Phê Sữa',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('bacxiu', N'BẠC XỈU',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('espresso', N'ESPRESSO', 20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('capheden',N'Cà Phê Đen',12000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('americano',N'AMERICANO',20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('capuchino',N'CAPUCHINO',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattedau',N'LATTE DÂU',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattekm',N'LATTE KHOAI MÔN',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('lattemc',N'LATTE MATCHA',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('latte',N'VANILLA',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('trachanh',N'Trà Chanh',10000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('tradao' ,N'Trà Đào',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('travai',N'Trà Vải',15000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('trasua',N'Trà Sữa',20000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('cadx',N'Cà Phê Đá Xay',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('latte',N'VANILLA',25000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('matchadx', N'MATCHA ĐÁ Xay',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('nuocsuoi', N'Nước Suối',10000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('tiramisu', N'TIRAMISU',30000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('redvelvet',N'RED VELVET',40000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('macaron',N'MACARON',35000)
insert into dbo.SanPham(maSP,tenSP,chiphi) values ('banhflan',N'Bánh FLAN',10000)

----------
-- Tạo view bảng SanPham
create view V_SanPham as
select *from SanPham	



----------
-- Tạo trigger sau khi thêm dữ liệu vào bảng SanPham
create TRIGGER TG_CheckDuplicateSanPham
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra trùng lặp giá trị của cột 'tenSP'
    IF EXISTS (
        SELECT 1
        FROM inserted i
        INNER JOIN SanPham sp ON i.tenSP = sp.tenSP
        WHERE i.maSP <> sp.maSP
    )
    BEGIN
        RAISERROR('Giá trị của cột Tên Sản Phẩm bị trùng lặp.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END


------------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng SanPham
CREATE PROCEDURE dbo.ThemSanPham(
	@maSP nvarchar(100),
	@tenSP nvarchar(100),
	@chiPhi int
)
AS
BEGIN
        insert into SanPham 
		values(@maSP,@tenSP,@chiPhi)
END



------------------
-- Tạo thủ tục lưu trữ để sửa dữ liệu bảng SanPham
CREATE PROCEDURE dbo.SuaSanPham(
	@maSP nvarchar(100),
	@tenSP nvarchar(100),
	@chiPhi int
)
AS
BEGIN
        update SanPham set tenSP = @tenSP, chiPhi = @chiPhi
		where maSP = @maSP
END


--------------------
---- TẠO THỦ TỤC LƯU TRỮ ĐỂ XÓA DỮ LIỆU BẢNG SANPHAM
--CREATE PROCEDURE DBO.XOASANPHAM(
--	@MASP NVARCHAR(100),
--)
--AS
--BEGIN
--    BEGIN
--        DELETE FROM SANPHAM SET TENSP = @TENSP, CHIPHI = @CHIPHI
--		WHERE MASP = @MASP
--    END
--END














-------------------------------------------------------------------------------
--Bảng Nguyên Liệu Tạo Thành Sản Phẩm
CREATE TABLE NguyenLieuTaoThanhSanPham(
	maNL nvarchar(100) CONSTRAINT FK_NguyenLieuTaoRaSanPham_maNL FOREIGN KEY REFERENCES NguyenLieu(maNL),
	maSP nvarchar(100) CONSTRAINT FK_NguyenLieuTaoRaSanPham_maSP FOREIGN KEY REFERENCES SanPham(maSP),
	soLuongNLCan int NOT NULL CHECK(soLuongNLCan > 0),
	CONSTRAINT PK_NguyenLieuTaoRaSanPham PRIMARY KEY (maNL,maSP)
);


------------------
-- Tạo View dữ liệu bảng NguyenLieuTaoThanhSanPham
create view V_NguyenLieuTaoThanhSanPham as
select nlttsp.maNL, nl.tenNL, nlttsp.maSP, sp.tenSP, nlttsp.soLuongNLCan 
from NguyenLieuTaoThanhSanPham nlttsp inner join NguyenLieu nl on nlttsp.maNL = nl.maNL
											  inner join SanPham sp on nlttsp.maSP = sp.maSP


select *from V_NguyenLieuTaoThanhSanPham
------------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng NguyenLieuTaoThanhSanPham
CREATE PROCEDURE dbo.ThemNguyenLieuTaoThanhSanPham(
	@maNL nvarchar(100),
	@maSP nvarchar(100),
	@soLuongNLCan int
)
AS
BEGIN
        insert into NguyenLieuTaoThanhSanPham 
		values(@maNL,@maSP,@soLuongNLCan)
END


------------------
-- Tạo thủ tục lưu trữ để sửa dữ liệu bảng NguyenLieuTaoThanhSanPham
CREATE PROCEDURE dbo.SuaNguyenLieuTaoThanhSanPham(
	@maNL nvarchar(100),
	@maSP nvarchar(100),
	@soLuongNLCan int
)
AS
BEGIN
        update NguyenLieuTaoThanhSanPham set soLuongNLCan = @soLuongNLCan
		where maNL = @maNL and maSP = @maSP
END


------------------
-- Tạo thủ tục lưu trữ để xóa dữ liệu bảng NguyenLieuTaoThanhSanPham
CREATE PROCEDURE dbo.XoaNguyenLieuTaoThanhSanPham(
	@maNL nvarchar(100),
	@maSP nvarchar(100)
)
AS
BEGIN
        delete from NguyenLieuTaoThanhSanPham 
		where maNL = @maNL and maSP = @maSP
END


























-------------------------------------------------------------------------------
--Bảng Hình Phạt
CREATE TABLE HinhPhat(
	maHP nvarchar(100) CONSTRAINT PK_HinhPhat PRIMARY KEY,
	loaiHP nvarchar(100) NOT NULL,
	soTienPhat int NOT NULL
);



-------------------------------------------------------------------------------
--Bảng Doanh Thu
create TABLE DoanhThu(
	maDoanhThu nvarchar(100) CONSTRAINT PK_DoanhThu PRIMARY KEY,
     maCS nvarchar(100) CONSTRAINT FK_DoanhThu FOREIGN KEY REFERENCES CoSo(maCS),
	soTienDoanhThu int NOT NULL CHECK(SoTienDoanhThu>=0),
	ngayDoanhThu nvarchar(100) NOT NULL
);


----------------------------------------
--View DoanhThu Tháng Theo maCS
create view V_DoanhThu as
select *from DoanhThu

--select * from SanPhamTrongHoaDon

--select *from Voucher

--delete from DoanhThu


--Tổng kết doanh thu cuối tháng theo maCS
create procedure dbo.TongKetDoanhThu(@maCS nvarchar) as
begin
	delete from DoanhThu where maCS = @maCS
end

-------------------------------------------------------------------------------
--Bảng Mức Lương
CREATE TABLE MucLuong(
	maML nvarchar(100) CONSTRAINT PK_MucLuong PRIMARY KEY,
	soTien int NOT NULL CHECK(soTien > 0)
);

insert into MucLuong values
('coban',25000),
('tienthuong',1),
('quanly',15000000)

create view V_MucLuong as
select *from MucLuong

select *from V_MucLuong

create procedure dbo.ThayDoiTienLuong (@maML nvarchar(100), @soTien int) as
begin
	update MucLuong set soTien = @soTien where maML = @maML
end


-------------------------------------------------------------------------------
--Bảng Khách Hàng
CREATE TABLE KhachHang(
	maKH nvarchar(100) CONSTRAINT PK_KhachHang PRIMARY KEY,	
	tenKH nvarchar(100) NOT NULL,
	soDienThoai nvarchar(11) NOT NULL CHECK(LEN(soDienThoai)=10)
);

---------------
-- View Khách Hàng
create view V_KhachHang as
select *from KhachHang


----------
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

-- Tạo thủ tục lưu trữ để thêm dữ liệu mới vào bảng KhachHang
CREATE PROCEDURE dbo.ThemMoiKhachHang (
    @maKH nvarchar(100),
    @tenKH nvarchar(100),
    @soDienThoai nvarchar(100)
)
AS
BEGIN
      INSERT INTO KhachHang
			VALUES (@maKH, @tenKH, @soDienThoai)
END


-- Tạo thủ tục lưu trữ để xóa dữ liệu bảng KhachHang
CREATE PROCEDURE dbo.XoaKhachHang (
    @maKH nvarchar(100)
)
AS
BEGIN
      delete from KhachHang
	  where maKH = @maKH
END


-- Tạo thủ tục lưu trữ để chỉnh sửa dữ liệu bảng KhachHang
CREATE PROCEDURE dbo.SuaKhachHang (
    @maKH nvarchar(100),
	@tenKH nvarchar(100),
    @soDienThoai nvarchar(100)
)
AS
BEGIN
      update KhachHang set tenKH = @tenKH, soDienThoai = @soDienThoai
	  where maKH = @maKH
END

-- Function tim kiếm khách hàng
create FUNCTION TimKiemKhachHang
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
--Bảng Hóa Đơn
CREATE TABLE HoaDon(
    maHoaDon nvarchar(100) CONSTRAINT PK_HoaDon PRIMARY KEY,
	maCS nvarchar(100) constraint FK_HoaDon_maCS references CoSo(maCS),
    tongTien int NOT NULL CHECK(tongTien > 0),
	maNV nvarchar(100) constraint FK_HoaDon_maNV references NhanVien(maNV),
	maKH nvarchar(100) constraint FK_HoaDon_maKH references KhachHang(maKH)
);


insert into HoaDon values
('07112023_1_cs1','cs1',140630,'nv1','kh1'),
('07112023_2_cs1','cs1',102463,'nv1','kh1'),
('07112023_3_cs1','cs1',100762,'nv1','kh1'),
('07112023_4_cs1','cs1',221437,'nv1','kh1'),
('07112023_5_cs1','cs1',69070,'nv1','kh1'),
('07112023_6_cs1','cs1',279665,'nv1','kh1'),
('07112023_7_cs1','cs1',272062,'nv1','kh1'),
('07112023_8_cs1','cs1',179556,'nv1','kh1'),
('07112023_9_cs1','cs1',166644,'nv1','kh1'),
('07112023_10_cs1','cs1',179816,'nv1','kh1'),
('07112023_11_cs1','cs1',130748,'nv1','kh1'),
('07112023_12_cs1','cs1',142836,'nv1','kh1'),
('07112023_13_cs1','cs1',99825,'nv1','kh1'),
('07112023_14_cs1','cs1',111400,'nv1','kh1'),
('07112023_15_cs1','cs1',107913,'nv1','kh1'),
('07112023_16_cs1','cs1',23180,'nv1','kh1'),
('07112023_17_cs1','cs1',80277,'nv1','kh3'),
('07112023_18_cs1','cs1',169359,'nv1','kh3'),
('07112023_19_cs1','cs1',121150,'nv1','kh3'),
('07112023_20_cs1','cs1',106937,'nv1','kh1'),
('07112023_21_cs1','cs1',163122,'nv1','kh1'),
('07112023_22_cs1','cs1',78071,'nv1','kh2'),
('07112023_23_cs1','cs1',145973,'nv1','kh1'),
('07112023_24_cs1','cs1',73209,'nv1','kh1'),
('07112023_25_cs1','cs1',172537,'nv1','kh3'),
('07112023_26_cs1','cs1',185670,'nv1','kh1'),
('07112023_27_cs1','cs1',156562,'nv1','kh2'),
('07112023_28_cs1','cs1',141306,'nv2','kh3'),
('07112023_29_cs1','cs1',15395,'nv1','kh2'),
('07112023_30_cs1','cs1',67989,'nv1','kh1')



-----------------------------------------------
--Tạo view xem Doanh Thu Trong ngày theo từng cơ sở (xem dựa trên HoaDon)
CREATE VIEW V_HoaDonTrongNgay AS 
SELECT * FROM HoaDon 
WHERE maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%')




--Xem V_HoaDonTrongNgay theo maCS
select *from V_HoaDonTrongNgay where maCS = 'cs1'



--------------------------
-- Thêm từ Hóa Đơn vào Doanh Thu Tháng
create procedure dbo.AddDoanhThuThang(
	@maDoanhThu nvarchar(100),
	@maCS nvarchar(100),
	@ngayDoanhThu nvarchar(100)
)
as
begin
	declare @sumTongTien int
	SELECT @sumTongTien = SUM(tongTien)
    FROM HoaDon
    WHERE maCS = @maCS AND maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%')

	begin
		insert into DoanhThu
		values(@maDoanhThu,@maCS,@sumTongTien,@ngayDoanhThu)
	end

	begin
		delete from SanPhamTrongHoaDon 
		where maHoaDon LIKE CONCAT('%',@maCS)
	end

	begin
		delete from HoaDon 
		where maCS = @maCS and maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMMyyyy'), '%')
	end
end


exec dbo.AddDoanhThuThang @maDoanhThu = '07112023_cs1', @maCS = 'cs1', @ngayDoanhThu ='07/11/2023'


select *from V_DoanhThu where maCS ='cs1'



-------------------------------------------------------------------------------
--Bảng Voucher
create TABLE Voucher(
	maVoucher nvarchar(100) CONSTRAINT PK_Voucher PRIMARY KEY,	
	phanTramGiam int NOT NULL CHECK(phanTramGiam > 0),
	nguongKichHoat int check(nguongKichHoat >=0),
	ngayHan nvarchar(100) not null
);

-- Tạo View dữ liệu bảng Voucher
create view V_Voucher as
select * from Voucher


drop view V_Voucher
select *from V_Voucher

------------------
-- Tạo thủ tục lưu trữ để thêm dữ liệu bảng Voucher
create PROCEDURE dbo.ThemVoucher(
	@maVoucher nvarchar(100),
	@phanTramGiam int,
	@nguongKichHoat int,
	@ngayHan nvarchar(100)
)
AS
BEGIN
     insert into Voucher
		values(@maVoucher,@phanTramGiam,@nguongKichHoat, @ngayHan)
END

drop procedure dbo.ThemVoucher


-- Tạo thủ tục lưu trữ để Xoá dữ liệu từ bảng Voucher
create PROCEDURE dbo.XoaThuCongVoucher(
	@maVoucher nvarchar(100)

)
AS 
BEGIN 
		DELETE FROM Voucher
				WHERE maVoucher = @maVoucher
END


-- Tạo thủ tục lưu trữ để Xoá dữ liệu theo ngày từ bảng Voucher
create PROCEDURE dbo.XoaTuDongVoucher(
	@ngayHan nvarchar(100)
)
AS 
BEGIN 
		DELETE FROM Voucher
		WHERE ngayHan = @ngayHan
END




-------------------------------------------------------------------------------
--Bảng Sản Phẩm Trong Hóa Đơn
CREATE TABLE SanPhamTrongHoaDon(
	maHoaDon nvarchar(100) CONSTRAINT FK_SanPhamTrongHoaDon_maHoaDon FOREIGN KEY REFERENCES HoaDon(maHoaDon),
	maSP nvarchar(100) CONSTRAINT FK_SanPhamTrongHoaDon_maSP FOREIGN KEY REFERENCES SanPham(maSP),
	chiPhiSP int NOT NULL CHECK(chiPhiSP > 0),
	soLuongSP int NOT NULL CHECK(soLuongSP > 0),
	CONSTRAINT FK_SanPhamTrongHoaDon PRIMARY KEY (maHoaDon,maSP)
);


-------------------------------------------------------------------------------
--Bảng Nhân Viên Bị Phạt
CREATE TABLE NhanVienBiPhat(
	maNV nvarchar(100) CONSTRAINT FK_NhanVienBiPhat_maNV FOREIGN KEY REFERENCES NhanVien(maNV),
	maHP nvarchar(100) CONSTRAINT FK_NhanVienBiPhat_maHP FOREIGN KEY REFERENCES HinhPhat(maHP),
	CONSTRAINT PK_NhanVienBiPhat PRIMARY KEY (maNV,maHP)
);

-------------------------------------------------------------------------------
--Bảng Nhân Viên Được Hưởng Lương
CREATE TABLE NhanVienHuongLuong(
	maNV nvarchar(100) CONSTRAINT FK_NhanVienHuongLuong_maNV FOREIGN KEY REFERENCES NhanVien(maNV),
	maML nvarchar(100) CONSTRAINT FK_NhanVienHuongLuong_maML FOREIGN KEY REFERENCES MucLuong(maML),
	CONSTRAINT PK_NhanVienHuongLuong PRIMARY KEY (maNV,maML)
);






















-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------


--Xem danh sách Sản Phẩm
CREATE VIEW V_SanPham AS 
SELECT maSP, tenSP, soLuongCon 
FROM dbo.SanPham;

-------------------------------------------------------------------------------
--Xem Danh Sách Nguyên Liệu để tạo thành Sản Phẩm
CREATE VIEW V_NguyenLieuTaoSanPham AS
SELECT nl.maNL, nl.tenNL, nl.soLuongCon, sp.maSP, sp.tenSP, nlttsp.soLuongNLCan 
FROM dbo.NguyenLieu nl INNER JOIN dbo.NguyenLieuTaoThanhSanPham nlttsp 
ON nl.maNL = nlttsp.maNL INNER JOIN  dbo.SanPham sp 
ON nlttsp.maSP = sp.maSP

-------------------------------------------------------------------------------
--Xem thông tin khách hàng nhận được voucher.
create view V_ThongTinKhachHangvaVoucher as
select kh_vc.maKH as maKH, vch.maVoucher as maVoucher,dieuKienMuaBan, dieuKienThuong, phanTramGiam from dbo.KhachHangNhanVoucher kh_vc	join dbo.Voucher vch on kh_vc.maVoucher = vch.maVoucher

-------------------------------------------------------------------------------
--Hàm Gộp Để Đếm Số Lượng Mã Khách Hàng và Mã Voucher tương ứng
create view V_GomKhachHangVoucher as
	select maKH, maVoucher, COUNT(phanTramGiam) as sl from V_ThongTinKhachHangvaVoucher group by maKH, maVoucher;

-------------------------------------------------------------------------------
----Xem Thông Tin Hóa Đơn, Khách Hàng và Sản Phẩm
--create view V_HDonKhHangSanPham as
--select hd.maHoaDon as maHoaDon, hd.maKH as maKH, hd.maSP from dbo.HoaDon hd                                                                           join SanPhamTrongHoaDon spthd on spthd.maHoaDon = hd.maHoaDon

-------------------------------------------------------------------------------
--Xem Danh Sách Khách Hàng
CREATE VIEW V_KhachHang AS
SELECT *
FROM KhachHang

-------------------------------------------------------------------------------
--Xem danh sách ca làm việc của Nhân Viên theo ngày
CREATE VIEW V_CaLamViecNhanVienTheoNgay AS
SELECT nv.maNV, nv.hoTenNV, nv.soDienThoai, clv.maCLV, clv.gioBD, clv.gioKT, nvdkc.ngayLam, nv.maCS, cs.tenCS
FROM NhanVien nv INNER JOIN NhanVienDangKyCa nvdkc ON nv.maNV = nvdkc.maNV
INNER JOIN CaLamViec clv ON nvdkc.maCLV = clv.maCLV 
INNER JOIN CoSo cs ON nv.maCS = cs.maCS
WHERE nvdkc.ngayLam = CAST(GETDATE() AS DATE); -- Thay đổi ngày ở đây nếu muốn xem cho một ngày cụ thể

-------------------------------------------------------------------------------
--Xem Hóa Đơn Trong 1 ngày
CREATE VIEW V_HoaDonTrongNgay AS 
SELECT * FROM HoaDon 
WHERE maHoaDon LIKE CONCAT(FORMAT(GETDATE(), 'ddMM'), '%')

-------------------------------------------------------------------------------
--Xem Danh Sách Nhà Cung Cấp Hợp Tác Với Cơ Sở
CREATE VIEW V_HopTac AS 
SELECT ncc.maNCC, ncc.tenNguoiDaiDien, cs.maCS, cs.tenCS, ht.tienHopDong FROM dbo.HopTac ht 
	join dbo.NhaCungCap ncc on ht.maNCC = ncc.maNCC 
	join dbo.CoSo cs on ht.maCS = cs.maCS


---------------------------------------------------------------------------------------------


-- Trigger thay đổi số lượng còn lại của nguyên liệu và số lượng sản phẩm có thể làm còn lại
create TRIGGER TG_UpdateRemainingQuantities
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

	-- Lấy thông tin về các sản phẩm cần cập nhật từ bảng SanPhamTrongHoaDon
    INSERT INTO #TempSanPham (maSP, soLuongSP)
    SELECT SanPham.maSP, soLuongSP
    FROM SanPham, inserted
    WHERE SanPham.maSP = inserted.maSP
    
    -- Lấy thông tin về các nguyên liệu cần cập nhật từ bảng NguyenLieuTaoThanhSanPham
    INSERT INTO #TempNguyenLieu (maNL, soLuongCan)
    SELECT maNL, soLuongNLCan
    FROM NguyenLieuTaoThanhSanPham
    WHERE maSP = @maSP

    -- Cập nhật số lượng còn lại của sản phẩm trong bảng NhaCungCapNguyenLieuChoCoSo
    UPDATE NhaCungCapNguyenLieuChoCoSo
    SET soLuongNL = soLuongNL - (t.soLuongCan * @soLuongSP)
		FROM NguyenLieu n
		JOIN #TempNguyenLieu t ON n.maNL = t.maNL
	where maCS LIKE right(@maHoaDon,3)
    
    -- Xóa bảng tạm
	DROP TABLE #TempSanPham
    DROP TABLE #TempNguyenLieu
END;

/*
delete from SanPhamTrongHoaDon
delete from HoaDon
delete from NguyenLieuTaoThanhSanPham
delete from SanPham
delete from NguyenLieu

select *from SanPham
select *from NguyenLieu
*/

-------------------------------------------------------------------------------
--Trigger Kiểm Tra Tên Sản Phẩm Có Tồn Tại Hay Chưa
CREATE TRIGGER TG_TenSanPham
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra tên sản phẩm vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM SanPham kh
			WHERE kh.tenSP = i.tenSP AND kh.maSP <> i.maSP
		)
	)
	BEGIN
		--Nếu trùng thì rollback
		RAISERROR('SẢN PHẨM BẠN MUỐN THÊM ĐÃ TỒN TẠI',16,1)
         ROLLBACK;
	END
END

-------------------------------------------------------------------------------
--Trigger Kiểm Tra Số Điện Thoại Của Khách Hàng Có Tồn Tại Chưa
CREATE TRIGGER TG_SdtKhachHang 
ON KhachHang
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra số điện thoại vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM KhachHang kh
			WHERE kh.soDienThoai = i.soDienThoai AND kh.maKH <> i.maKH
		)
	)
	BEGIN
		-- Nếu trùng thi rollback
		RAISERROR('Số điện thoại đã dùng cho khách hàng khác',16,1)
		ROLLBACK;
	END
END

-------------------------------------------------------------------------------
--Trigger kiểm tra Số Điện Thoại và CMND của Nhân Viên đã tồn tại hay chưa
CREATE TRIGGER TG_SDT_NhanVien
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra số điện thoại vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM NhanVien nv
			WHERE nv.soDienThoai = i.soDienThoai AND nv.maNV <> i.maNV
		)
	)
	BEGIN
		--Nếu trùng thì rollback
		RAISERROR('Số điện thoại này đã dùng cho nhân viên khác',16,1)
         ROLLBACK;
	END
END


CREATE TRIGGER TG_CMND_NhanVien
ON NhanVien
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra số CMND vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM NhanVien nv
			WHERE nv.cMND = i.cMND AND nv.maNV <> i.maNV
		)
	)
	BEGIN
		--Nếu trùng thì rollback
		RAISERROR('Số CMND này đã dùng cho nhân viên khác',16,1)
         ROLLBACK;
	END
END

-------------------------------------------------------------------------------
--Trigger kiểm tra Số Điện Thoại và email của Nhà Cung Cấp đã tồn tại hay chưa
CREATE TRIGGER TG_SDT_NhaCungCap
ON NhaCungCap
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra số điện thoại vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM NhaCungCap ncc
			WHERE ncc.soDienThoai = i.soDienThoai AND ncc.maNCC <> i.maNCC
		)
	)
	BEGIN
		--Nếu trùng thì rollback
		RAISERROR('Số điện thoại này đã dùng cho nhà cung cấp khác',16,1)
         ROLLBACK;
	END
END


CREATE TRIGGER TG_email_NhaCungCap
ON NhaCungCap
AFTER INSERT, UPDATE
AS
BEGIN
	--kiểm tra địa chỉ email vừa thêm có bị trùng lặp hay không?
	IF EXISTS (
		SELECT *
		FROM inserted i
		WHERE EXISTS (
			SELECT *
			FROM NhaCungCap ncc
			WHERE ncc.email = i.email AND ncc.maNCC <> i.maNCC
		)
	)
	BEGIN
		--Nếu trùng thì rollback
		RAISERROR('Địa chỉ email này đã dùng cho nhà cung cấp khác',16,1)
         ROLLBACK;
	END
END

-------------------------------------

--Trigger cập nhật số lượng Sản Phẩm có thể làm mỗi khi có sự thay đổi trong kho nguyên liệu (thêm, xóa, sửa nguyên liệu)
--Trigger update soLuongCon của Sản Phẩm khi chỉnh sửa soLuongCon của Nguyên Liệu




--Kiểm tra nhân viên đã đăng ký ca làm việc đó trong ngày đó hay chưa
-- Tạo trigger INSTEAD OF INSERT
CREATE TRIGGER Tr_NhanVienDangKyCa_InsteadOfInsert
ON NhanVienDangKyCa
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra xem nhân viên đã đăng ký ca làm việc trước đó hay chưa
    IF EXISTS (
        SELECT 1
        FROM NhanVienDangKyCa n
        JOIN inserted i ON n.maNV = i.maNV AND n.maCLV = i.maCLV
    )
    BEGIN
        RAISERROR ('Nhân viên đã đăng ký ca làm việc trước đó', 16, 1)
    END
    ELSE
    BEGIN
        -- Nếu không có đăng ký trước đó, thực hiện việc chèn dữ liệu
        INSERT INTO NhanVienDangKyCa (maNV, maCLV, ngayLam)
        SELECT i.maNV, i.maCLV, i.ngayLam
        FROM inserted i
    END
END


--delete from NhanVienDangKyCa

/*
insert into NhanVienDangKyCa values
('nv01','31102023cachieu','31/10/2023')
*/

--update NhanVienDangKyCa set maCLV = '31102023cachieu' where maNV = 'nv01' and ngayLam ='31/10/2023'

--select *from NhanVienDangKyCa



--trigger nếu sản phẩm trong hóa đơn không đủ đáp ứng thì báo lỗi và xóa hóa đơn đó



--function thêm từ HoaDon vào DoanhThu (cuối ngày)
CREATE PROCEDURE ProcessDoanhThu_Ngay(@maCS nvarchar(100))
AS
BEGIN
    insert into DoanhThu(maDoanhThu, maCS, soTienDoanhThu, ngayDoanhThu)
	select maHoaDon, maCS, tongTien, GETDATE()
	from HoaDon where maCS = @maCS

	--Xóa HoaDon theo maCS
	delete from HoaDon where maCS = @maCS
END



