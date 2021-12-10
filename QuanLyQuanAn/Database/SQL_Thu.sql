USE QLTiecQuanAn
GO

CREATE PROC P_ThemKhachHang
	@TenKH NVARCHAR(100), @NgaySinh DATE, @GioiTinh NCHAR(5), @DiaChi NVARCHAR(500), @SDT CHAR(15), @TrangThai BIT
AS
	INSERT INTO dbo.KhachHang
	     (TenKH, NgaySinh, GioiTinh, DiaChi, SDT, TrangThai)
	VALUES
	(@TenKH, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @TrangThai)
GO

CREATE PROC P_SuaKhachHang
	@TenKH NVARCHAR(100), @NgaySinh DATE, @GioiTinh NCHAR(5), @DiaChi NVARCHAR(500), @TrangThai BIT, @SDT CHAR(12)
AS
	UPDATE dbo.KhachHang SET TenKH = @TenKH, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, TrangThai = @TrangThai WHERE SDT = @SDT
GO


update Ban
set TrangThai = 0


