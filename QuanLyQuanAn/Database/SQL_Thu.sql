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


CREATE VIEW pHoaDon AS
  select MaHD, kh.TenKH, nv.HoTen, b.TenBan, NgayLap, TongTien
 from HoaDon hd  
 join KhachHang kh on hd.MaKH = kh.MaKH  
 join NhanVien nv on nv.MaNV = hd.MaNV  
 join Ban b on b.MaBan = hd.MaBan
 

 CREATE VIEW pCTHoaDon AS
  select MaHD, TenMon, SoLuong, ThanhTien
  from CTHoaDon ct 
  join MonAn ma on ct.MaMon = ma.MaMon 


--nếu có thấy lỗi của view thì cứ chạy bình thường



