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

CREATE TABLE Menu
(
	MaBan INT FOREIGN KEY REFERENCES dbo.Ban(MaBan),
	MaMon INT FOREIGN KEY REFERENCES dbo.MonAn(MaMon),
	TenMon NVARCHAR(50),
	SoLuong INT CHECK ( SoLuong > 0),
	GiaBan decimal(18, 0),
	ThanhTien decimal(18, 0),

	PRIMARY KEY(MaBan,MaMon)
)
GO



ALTER PROC P_ThemMonMenu
	@MaBan INT, @MaMon INT, @SoLuong INT
AS
	IF(EXISTS(SELECT * FROM dbo.Menu WHERE MaMon = @MaMon AND MaBan = @MaBan))
	BEGIN
		IF(@SoLuong = 0)
			DELETE dbo.Menu WHERE MaMon = @MaMon AND MaBan = @MaBan
		ELSE
		BEGIN
		    UPDATE dbo.Menu SET SoLuong = @SoLuong WHERE MaMon = @MaMon AND MaBan = @MaBan
			UPDATE dbo.Menu SET ThanhTien = (SELECT SoLuong * GiaBan FROM dbo.Menu WHERE MaBan = @MaBan AND MaMon = @MaMon) WHERE MaBan = @MaBan AND MaMon = @MaMon
		END		
	END
	ELSE
    BEGIN
		DECLARE @TenMon NVARCHAR(50)
		DECLARE @GiaBan decimal(18, 0)
		SELECT @TenMon = TenMon,@GiaBan = GiaBan FROM dbo.MonAn WHERE MaMon = @MaMon
        INSERT INTO dbo.Menu (MaBan, MaMon, TenMon, SoLuong, GiaBan, ThanhTien)VALUES(@MaBan, @MaMon, @TenMon, @SoLuong, @GiaBan, @SoLuong * @GiaBan)
    END
GO

EXEC dbo.P_ThemMonMenu @MaBan = 1, @MaMon = 2, @SoLuong = 5
EXEC dbo.P_ThemMonMenu @MaBan = 1, @MaMon = 3, @SoLuong = 5
EXEC dbo.P_ThemMonMenu @MaBan = 1, @MaMon = 4, @SoLuong = 1

EXEC dbo.P_ThemMonMenu @MaBan = 2, @MaMon = 5, @SoLuong = 5
EXEC dbo.P_ThemMonMenu @MaBan = 2, @MaMon = 3, @SoLuong = 5
EXEC dbo.P_ThemMonMenu @MaBan = 3, @MaMon = 5, @SoLuong = 1

EXEC dbo.P_ThemMonMenu @MaBan = 1, @MaMon = 2, @SoLuong = 2
SELECT * FROM dbo.Menu