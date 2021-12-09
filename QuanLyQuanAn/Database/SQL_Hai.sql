USE QLTiecQuanAn
GO

SELECT * FROM dbo.NhanVien
UPDATE dbo.NhanVien SET MatKhau = '659cbbf1e02f19a7e2402df9d23be037'
UPDATE dbo.NhanVien SET TenDangNhap = '1' WHERE MaNV = 1

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

CREATE PROC P_UpdateNV
	@MaNV INT,@GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500),@SDT CHAR(15)
AS
	UPDATE dbo.NhanVien SET GioiTinh = GioiTinh, DiaChi = @DiaChi, SDT= @SDT, NgaySinh = @NgaySinh  WHERE MaNV = @MaNV
GO

