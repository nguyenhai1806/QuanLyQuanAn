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


CREATE PROC P_LayCTHDTheoMaHD
	@MaHD INT
AS
	SELECT MA.MaMon,MA.TenMon,CTHD.SoLuong,MA.GiaBan,CTHD.ThanhTien FROM dbo.CTHoaDon CTHD
	JOIN dbo.HoaDon HD ON HD.MaHD = CTHD.MaHD
	JOIN dbo.MonAn MA ON MA.MaMon = CTHD.MaMon
	WHERE HD.MaHD = @MaHD
GO

CREATE PROC P_LayHoaDons
AS
	SELECT HD.MaHD, KH.TenKH, B.TenBan, NV.HoTen, HD.NgayLap,HD.TongTien FROM dbo.HoaDon HD
	JOIN dbo.Ban B ON B.MaBan = HD.MaBan
	JOIN dbo.KhachHang KH ON KH.MaKH = HD.MaKH
	JOIN dbo.NhanVien NV ON NV.MaNV = HD.MaNV
	ORDER BY HD.MaHD DESC
GO

CREATE PROC P_TimHoaDon
	@MaHD INT, @TenKH NVARCHAR(50), @TenNV NVARCHAR(50)
AS
	SELECT HD.MaHD, KH.TenKH, B.TenBan, NV.HoTen, HD.NgayLap,HD.TongTien FROM dbo.HoaDon HD
	JOIN dbo.Ban B ON B.MaBan = HD.MaBan
	JOIN dbo.KhachHang KH ON KH.MaKH = HD.MaKH
	JOIN dbo.NhanVien NV ON NV.MaNV = HD.MaNV
	WHERE HD.MaHD = @MaHD OR  NV.HoTen LIKE @TenNV OR KH.TenKH LIKE @TenKH
	ORDER BY HD.MaHD DESC
GO