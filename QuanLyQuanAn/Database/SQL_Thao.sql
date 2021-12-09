USE QLTiecQuanAn
GO

--Proc them
go
create proc insert_LoaiMon(@TenLoai nvarchar(100), @TrangThai bit)
as
	insert into LoaiMonAn(TenLoai, TrangThai)
	values(@TenLoai, @TrangThai)
go

exec insert_LoaiMon N'Tào lao', 1

go
create proc insert_MonAn(@TenMon nvarchar(100), @GiaBan decimal(18,0), @MaLoai int, @TrangThai bit)
as
	insert into MonAn(TenMon, GiaBan, MaLoai, TrangThai)
	values(@TenMon, @GiaBan, @MaLoai, @TrangThai)
go

exec insert_MonAn N'Món gì đó', 1000000, 1, 1

--Proc sua
go
create proc update_LoaiMon(@MaLoai int, @TenLoai nvarchar(100), @TrangThai bit)
as
	update LoaiMonAn
	set TenLoai=@TenLoai, TrangThai=@TrangThai
	where MaLoai=@MaLoai
go

exec update_LoaiMon 7, N'Tào lao ver2', 1

go
create proc update_MonAn(@MaMon int, @TenMon nvarchar(100), @GiaBan decimal(18,0), @MaLoai int, @TrangThai bit)
as
	update MonAn
	set TenMon=@TenMon, GiaBan=@GiaBan,MaLoai=@MaLoai, TrangThai=@TrangThai
	where MaMon=@MaMon
go

exec update_MonAn 15, N'Món gì đó nhưng được sửa lại', 10, 7, 1