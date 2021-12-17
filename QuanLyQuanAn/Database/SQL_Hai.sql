USE QLTiecQuanAn
GO

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

CREATE PROC P_UpdateNV
	@MaNV INT,@GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500),@SDT CHAR(15)
AS
	UPDATE dbo.NhanVien SET GioiTinh = GioiTinh, DiaChi = @DiaChi, SDT= @SDT, NgaySinh = @NgaySinh WHERE MaNV = @MaNV
GO

CREATE PROC P_ThemNhanVien
	@MaNhomNV INT, @TenDanhNhap NVARCHAR(100), @MatKhau NVARCHAR(100), @HoTen NVARCHAR(100),@GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500),@SDT CHAR(15), @TrangThai BIT
AS
	INSERT INTO dbo.NhanVien
	     (MaNhomNV, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, DiaChi, SDT, TrangThai)
	VALUES
	(@MaNhomNV, @TenDanhNhap, @MatKhau, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @TrangThai)
GO

CREATE PROC P_SuaNhanVien
	@MaNV INT,@MaNhomNV INT , @HoTen NVARCHAR(100), @GioiTinh NCHAR(5), @NgaySinh DATE, @DiaChi NVARCHAR(500), @SDT CHAR(15), @TrangThai BIT
AS
	UPDATE dbo.NhanVien SET MaNhomNV=@MaNhomNV,HoTen = @HoTen, GioiTinh = GioiTinh, DiaChi = @DiaChi, SDT= @SDT, NgaySinh = @NgaySinh, TrangThai = @TrangThai  WHERE MaNV = @MaNV
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


ALTER DATABASE QLTiecQuanAn SET RECOVERY FULL
GO
USE QLTiecQuanAn
GO
CREATE PROC P_DiffBackup @link varchar(max)
AS
	DECLARE @database NVARCHAR(100)
	SELECT @database = DB_NAME()
	DECLARE @sqlCommand NVARCHAR(100)
	SET @sqlCommand = ' BACKUP DATABASE ' + @database + ' TO DISK = N''' + @link + '\DiffBackup.bak' +'''' + ' with differential '
	EXEC (@sqlCommand)
GO


CREATE PROC P_LogBackup @link varchar(max)
AS
	DECLARE @database NVARCHAR(100)
	SELECT @database = DB_NAME()
	DECLARE @sqlCommand NVARCHAR(100)
	SET @sqlCommand = ' BACKUP LOG ' + @database + ' TO DISK = N''' + @link + '\LogBackup.trn' + ''''
	EXEC (@sqlCommand)
GO


CREATE PROCEDURE P_FullBackup @link varchar(max)
AS
	DECLARE @database NVARCHAR(100)
	SELECT @database = DB_NAME()
	DECLARE @sqlCommand NVARCHAR(100)
	SET @sqlCommand = ' BACKUP DATABASE ' + @database + ' TO DISK = N''' + @link + '\FullBackup.bak' +''''
	EXEC (@sqlCommand)
GO

USE master
GO
ALTER PROC P_Recovery  @database nvarchar(max),@fullBackup nvarchar(max), @diffBackup nvarchar(max), @logBackup nvarchar(max)
AS
	DECLARE @sqlCommand NVARCHAR(100)
	IF (@fullBackup != '' AND @diffBackup = '' AND @logBackup = '')
	BEGIN
		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @fullBackup + ''' WITH RECOVERY ,REPLACE'
		EXEC (@sqlCommand)
		RETURN
	END

	ELSE IF (@fullBackup != '' AND @diffBackup != '' AND @logBackup = '')
	BEGIN
		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @fullBackup + ''' WITH NORECOVERY ,REPLACE'
		EXEC (@sqlCommand)

		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @diffBackup + ''' WITH RECOVERY ,REPLACE'
		EXEC (@sqlCommand)
		RETURN
	END

	ELSE IF(@fullBackup != '' AND @diffBackup = '' AND @logBackup != '')
	BEGIN
		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @fullBackup + ''' WITH NORECOVERY ,REPLACE'
		EXEC (@sqlCommand)

		SET @sqlCommand = 'RESTORE LOG ' + @database + ' FROM DISK = ''' + @logBackup + ''' WITH RECOVERY ,REPLACE'
		EXEC (@sqlCommand)
		RETURN
	END

	ELSE IF(@fullBackup != '' AND @diffBackup != '' AND @logBackup != '')
	BEGIN
		
		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @fullBackup + ''' WITH NORECOVERY ,REPLACE'
		EXEC (@sqlCommand)

		SET @sqlCommand = 'RESTORE DATABASE ' + @database + ' FROM DISK = ''' + @diffBackup + ''' WITH NORECOVERY ,REPLACE'
		EXEC (@sqlCommand)

		SET @sqlCommand = 'RESTORE LOG ' + @database + ' FROM DISK = ''' + @logBackup + ''' WITH RECOVERY ,REPLACE'
		EXEC (@sqlCommand)
		RETURN
	END
GO

USE QLTiecQuanAn
GO

CREATE PROC P_ChuyenBan
	@MaBanCu INT, @MaBanMoi INT
AS
	UPDATE Menu SET MaBan = @MaBanMoi WHERE MaBan = @MaBanCu
GO

EXEC dbo.P_ChuyenBan @MaBanCu = 0, @MaBanMoi = 0
GO

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



CREATE PROC P_ThemMonMenu
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

CREATE PROC P_ThemCTHD
	@MaHD INT
AS
BEGIN
	DECLARE @MaMon INT
	DECLARE @SoLuong INT
	DECLARE @ThanhTien INT
	DECLARE @MaBan INT  = (SELECT MaBan FROM dbo.HoaDon WHERE MaHD = @MaHD)
	DECLARE @TongTien INT = 0
	DECLARE cur_Menu CURSOR
	FORWARD_ONLY
	FOR SELECT MaMon,SoLuong,ThanhTien FROM dbo.Menu WHERE MaBan = @MaBan
	OPEN cur_Menu
	FETCH NEXT FROM cur_Menu INTO @MaMon, @SoLuong, @ThanhTien
	WHILE(@@FETCH_STATUS=0)
	BEGIN
		INSERT INTO dbo.CTHoaDon (MaHD, MaMon, SoLuong, ThanhTien)VALUES(@MaHD, @MaMon, @SoLuong, @ThanhTien)
		SET @TongTien = @TongTien + @ThanhTien
		FETCH NEXT FROM cur_Menu INTO @MaMon, @SoLuong, @ThanhTien
	END
	CLOSE cur_Menu
	DEALLOCATE cur_Menu
	DELETE dbo.Menu WHERE MaBan = @MaBan
	UPDATE dbo.HoaDon SET TongTien = @TongTien WHERE MaHD = @MaHD
END
GO	

CREATE PROC P_TaoHoaDon @MaBan int, @MaKH int, @MaNV int
AS
	INSERT INTO dbo.HoaDon (MaKH, MaNV, MaBan, NgayLap, TongTien)
	VALUES
	     (@MaKH,@MaNV ,@MaBan , GETDATE(), 0)
GO