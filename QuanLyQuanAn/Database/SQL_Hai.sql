USE QLTiecQuanAn
GO

SELECT * FROM dbo.NhanVien
UPDATE dbo.NhanVien SET MatKhau = '659cbbf1e02f19a7e2402df9d23be037'

go
CREATE PROC P_LayNhanVienDangNhap
	@Username NVARCHAR(100), @MatKhau NVARCHAR(100)
AS
	SELECT * FROM dbo.NhanVien
	WHERE TenDangNhap = @Username AND MatKhau = @MatKhau
GO

CREATE PROC P_UpdatePassword
	@Username NVARCHAR(100),@MatKhau NVARCHAR(100)
AS
	UPDATE dbo.NhanVien SET MatKhau = @MatKhau WHERE TenDangNhap = @Username
GO

ALTER PROC P_UpdateNV
	@MaNV INT,@GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500),@SDT CHAR(15), @MaNhomNV INT 
AS
	UPDATE dbo.NhanVien SET GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT= @SDT, NgaySinh = @NgaySinh, MaNhomNV = @MaNhomNV WHERE MaNV = @MaNV
GO

ALTER PROC P_ThemNhanVien
	@MaNhomNV INT, @TenDanhNhap NVARCHAR(100), @MatKhau NVARCHAR(100), @HoTen NVARCHAR(100),@GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500),@SDT CHAR(15), @TrangThai BIT
AS
	INSERT INTO dbo.NhanVien
	     (MaNhomNV, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, DiaChi, SDT, TrangThai)
	VALUES
	(@MaNhomNV, @TenDanhNhap, @MatKhau, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @TrangThai)
GO

ALTER PROC P_SuaNhanVien
	@MaNV INT,@MaNhomNV INT , @HoTen NVARCHAR(100), @GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500), @SDT CHAR(15), @TrangThai BIT
AS
	UPDATE dbo.NhanVien SET MaNhomNV=@MaNhomNV,HoTen = @HoTen, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT= @SDT, NgaySinh = @NgaySinh, TrangThai = @TrangThai  WHERE MaNV = @MaNV
GO

CREATE PROC P_ThemNhomNV
	@TenNhom NVARCHAR(100),@TrangThai BIT
AS
	INSERT INTO dbo.NhomNhanVien
	     (TenNhom, TrangThai)
	VALUES
	(@TenNhom, @TrangThai)
GO

CREATE PROC P_SuaNhomNV
	@MaNhom INT,@TenNhom  NVARCHAR(100), @TrangThai BIT
AS
	UPDATE dbo.NhomNhanVien SET TenNhom = @TenNhom, TrangThai = @TrangThai WHERE MaNhomNV = @MaNhom
GO