create database QLTiecQuanAn;
go
use QLTiecQuanAn
go



create table Ban
(
	MaBan INT IDENTITY not null primary key,
	TenBan nvarchar(500) not null,
	TrangThai BIT DEFAULT 1				-- 1 Hiển thị, 0 Không hiển thị
)


create table LoaiMonAn
(
	MaLoai INT IDENTITY not null primary key,
	TenLoai nvarchar(100) not NULL UNIQUE,
	TrangThai BIT DEFAULT 1					-- 1 Hiển thị, 0 Không hiển thị
)


create table MonAn
(
	MaMon INT IDENTITY not null primary key,
	TenMon nvarchar(100) not NULL UNIQUE,
	GiaBan decimal(18, 0) not null,
	MaLoai INT not null,
	TrangThai BIT DEFAULT 1						-- 1 Hiển thị, 0 Không hiển thị
	constraint fk_MA_Loai foreign key(MaLoai) references LoaiMonAn(MaLoai)
)


create table KhachHang
(
	MaKH INT IDENTITY not null primary key,
	TenKH nvarchar(100) null,
	NgaySinh date null,
	GioiTinh nchar(5) not null,
	DiaChi nvarchar(500) null,
	SDT char(15) not null,
	TrangThai BIT DEFAULT 1			-- 1 Hiển thị, 0 Không hiển thị
) 


create table NhomNhanVien
(
	MaNhomNV INT IDENTITY not null primary key,
	TenNhom nvarchar(100) null,
	TrangThai bit	DEFAULT 1			-- 1 Hiển thị, 0 Không hiển thị
)


create table NhanVien
(
	MaNV INT IDENTITY not null primary key,
	MaNhomNV INT not null,
	TenDangNhap nvarchar(100) not NULL,
	MatKhau nvarchar(100) not null,
	HoTen nvarchar(100) not null,
	GioiTinh nchar(5) NOT NULL CHECK(GioiTinh IN (N'Nam',N'Nữ')),
	NgaySinh date null,
	DiaChi nvarchar(500) null,
	SDT char(15) null,
	TrangThai BIT DEFAULT 1					-- 1 Hiển thị, 0 Không hiển thị
	constraint fk_NV_NNV foreign key(MaNhomNV) references NhomNhanVien(MaNhomNV)
)


create table HoaDon
(
	MaHD INT IDENTITY not null primary key,
	MaKH INT not null,
	MaNV INT not null,
	MaBan INT not null,
	NgayLap datetime default getdate(),
	TongTien decimal (18, 0) not null,
	constraint fk_HD_KH foreign key(MaKH) references KhachHang(MaKH),
	constraint fk_HD_NV foreign key(MaNV) references NhanVien(MaNV),
	constraint fk_CTHD_B foreign key(MaBan) references Ban(MaBan)
)


create table CTHoaDon
(
	MaHD INT not null,
	MaMon INT not null,
	SoLuong int not null,
	ThanhTien decimal (18, 0) not null,
	primary key (MaHD, MaMon),
	constraint fk_CTHD_HD foreign key(MaHD) references HoaDon(MaHD),
	constraint fk_CTHD_M foreign key(MaMon) references MonAn(MaMon)
)


--======================================================================================================


--insert into NhomNhanVien(TenNhom, TrangThai)

insert into NhomNhanVien
values (N'Quản trị', 1)

insert into NhomNhanVien
values (N'Nhân viên', 1)

select * from NhomNhanVien;


--================================================================


--insert into Ban(MaBan, TenBan, TrangThai)

insert into Ban
values (N'Bàn số 1', 1)

insert into Ban
values (N'Bàn số 2', 1)

insert into Ban
values (N'Bàn số 3', 1)

insert into Ban
values (N'Bàn số 4', 1)

insert into Ban
values (N'Bàn số 5', 1)

insert into Ban
values (N'Bàn số 6', 1)

insert into Ban
values (N'Bàn số 7', 1)

insert into Ban
values (N'Bàn số 8', 1)

insert into Ban
values (N'Bàn số 9', 1)

insert into Ban
values (N'Bàn số 10', 1)

select * from Ban;


--===============================================================


--insert into LoaiMonAn(MaLoai, TenLoai, TrangThai)

insert into LoaiMonAn
values (N'Salad', 1)

insert into LoaiMonAn
values (N'Món hấp xào', 1)

insert into LoaiMonAn
values (N'Món nóng', 1)

insert into LoaiMonAn
values (N'Món tráng miệng', 1)

select * from LoaiMonAn;


--==================================================================


--insert into MonAn(TenMon, GiaBan, MaLoai, TrangThai)

insert into MonAn
values (N'Gỏi cuốn tôm thịt', 30000,1, 1)

insert into MonAn
values (N'Salad phô mai thịt xông khói', 20000, 1, 1)

insert into MonAn
values (N'Gỏi bồn bồn tôm thịt', 30000, 1, 1)

insert into MonAn
values (N'Nghêu hấp thái', 30000,2, 1)

insert into MonAn
values (N'Sò huyết xào me', 30000, 2, 1)

insert into MonAn
values (N'Ốc dừa xào bơ', 25000, 2, 1)

insert into MonAn
values (N'Há cảo xíu mại', 20000,2, 1)

insert into MonAn
values (N'Cơm chiên lá sen', 25000,3, 1)

insert into MonAn
values (N'Mì Ý sốt thịt bò', 30000,3, 1)

insert into MonAn
values (N'Bánh chanh dây', 15000,4, 1)

insert into MonAn
values (N'Pepsi', 12000, 4, 1)

insert into MonAn
values (N'Nước Cam', 12000,4, 1)

insert into MonAn
values (N'String', 12000,4, 1)

insert into MonAn
values (N'Trà xanh', 12000,4, 1)

select * from MonAn;


--===========================================================================================================


--insert into KhachHang(MaKH, TenKH, NgaySinh, GioiTinh, DiaChi, SDT, TrangThai)

set dateformat dmy;
insert into KhachHang
values (N'Nguyễn Thành Minh', '25/05/1969', N'Nam', N'Đồng Tháp', '0961900525', 1)

insert into KhachHang
values (N'Trần Văn Thanh', '13/12/1984', N'Nam', N'TPHCM', '0963213026', 1)

insert into KhachHang
values (N'Lê Thị Hoa', '08/08/1995', N'Nữ', N'Bình Dương', '0968100763', 1)

insert into KhachHang
values (N'Nguyễn Quỳnh Thi', '19/02/1980', N'Nữ', N'Tây Ninh', '0938356346', 1)

insert into KhachHang
values (N'Trần Thị Kiều Diễm', '01/10/1990', N'Nữ', N'Tiền Giang', '0862141511', 1)

insert into KhachHang
values (N'Mai Quốc Tiến', '23/06/1993', N'Nam', N'Đà Nẵng', '0979009541', 1)

insert into KhachHang
values (N'Nguyễn Hoàng Anh', '23/11/1990', N'Nam', N'Hà Nội', '0938351289', 1)

insert into KhachHang
values (N'Nguyễn Thị Diệu An', '17/02/1990', N'Nữ', N'Vĩnh Long', '0862143157', 1)

insert into KhachHang
values (N'Trần Văn Lợi', '18/05/1990', N'Nam', N'Cà Mau', '0979007423', 1)

insert into KhachHang
values (N'Lê Thanh Trúc', '21/07/1997', N'Nữ', N'Khánh Hòa', '0938359807', 1)

insert into KhachHang
values (N'Nguyễn Thành Trí', '11/09/1983', N'Nam', N'Bình Thuận', '0862145162', 1)

insert into KhachHang
values (N'Nguyễn Thị Hồng Ngân', '04/06/1982', N'Nữ', N'Vĩnh Long', '0979008087', 1)

insert into KhachHang
values (N'Huỳnh Văn Hậu', '24/03/1967', N'Nam', N'TPHCM', '0935909807', 1)
insert into KhachHang
values (N'Nguyễn Thị Phượng', '18/07/1973', N'Nữ', N'Đồng Tháp', '0861753162', 1)

insert into KhachHang
values (N'Đặng Hoàng Tuấn', '05/06/1993', N'Nam', N'TPHCM', '0976965087', 1)
--========================================================================================================


--insert into NhanVien(MaNV, MaNhomNV, TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, DiaChi, SDT, TrangThai)

set dateformat dmy;
insert into NhanVien
values (1, 'HaiNguyen', '123', N'Nguyễn Duy Hải', N'Nam', '18/06/2000', N'TPHCM', '0918353686', 1)

insert into NhanVien
values (1, 'ThaoHoang', '123', N'Hoàng Minh Thảo', N'Nam', '15/04/2000', N'TPHCM', '0338836275', 1)

insert into NhanVien
values (1, 'ThuNguyen', '123', N'Nguyễn Anh Thư', N'Nữ', '29/04/2000', N'Đồng Tháp', '0961327210', 1)

insert into NhanVien
values (2, 'NgocTran', '123', N'Trần Mỹ Ngọc', N'Nữ', '03/05/2000', N'Đà Nẵng', '0919864466', 1)

insert into NhanVien
values (2, 'AnhBui', '123', N'Bùi Thái Anh', N'Nam', '29/07/2000', N'TPHCM', '0352271239', 1)

insert into NhanVien
values (2, 'ThanhNguyen', '123', N'Nguyễn Thị Kim Thanh', N'Nữ', '17/06/2000', N'Hà Nội', '0961518900', 0)

insert into NhanVien
values (2, 'TuanNguyen', '123', N'Nguyễn Hữu Tuấn', N'Nam', '21/09/2000', N'Kiên Giang', '0919651346', 1)

insert into NhanVien
values (2, 'TranDuong', '123', N'Dương Thị Huyền Trân', N'Nữ', '09/11/2000', N'TPHCM', '0350965339', 1)

select * from NhanVien;


--===============================================================================================================


--insert into HoaDon(MaHD, MaKH, MaNV, MaBan, NgayLap, TongTien)

set dateformat dmy;
insert into HoaDon
values (1, 1,4, '05/12/2021', 125000)

insert into HoaDon
values (3, 2, 6, '05/12/2021', 72000)

insert into HoaDon
values (6,3, 10, '05/12/2021', 170000)

--

insert into HoaDon
values (7,4,7, '06/12/2021', 66000)

insert into HoaDon
values (11,3, 1, '06/12/2021', 130000)

--

insert into HoaDon
values (2,3,2, '07/12/2021', 78000)

insert into HoaDon
values (4, 4,3, '07/12/2021', 60000)

insert into HoaDon
values (5,5,5, '07/12/2021', 30000)

--

insert into HoaDon
values (8,5,8, '08/12/2021', 125000)

insert into HoaDon
values (9,6,9, '08/12/2021', 45000)

insert into HoaDon
values (10,6,10, '08/12/2021', 146000)

--

insert into HoaDon
values (15, 7, 7, '09/12/2021', 48000)

insert into HoaDon
values (12, 7,1, '09/12/2021', 121000)

insert into HoaDon
values (13, 8,2, '09/12/2021', 155000)

insert into HoaDon
values (14, 8,9, '09/12/2021', 105000)

select * from HoaDon;


--=====================================================================================

--insert into CTHoaDon(MaHD, MaMon, SoLuong, ThanhTien)

insert into CTHoaDon
values (1, 6, 2, 50000)

insert into CTHoaDon
values (1,1, 1, 30000)

insert into CTHoaDon
values (2, 3, 1, 30000)

insert into CTHoaDon
values (2, 14, 1, 12000)

--

insert into CTHoaDon
values (3, 9, 3, 90000)

insert into CTHoaDon
values (3, 1, 1, 30000)

insert into CTHoaDon
values (3, 2, 1, 20000)

insert into CTHoaDon
values (3, 5, 1, 30000)

--

insert into CTHoaDon
values (4, 3, 3, 36000)

insert into CTHoaDon
values (4,10, 2, 30000)

--

insert into CTHoaDon
values (5, 1, 2, 60000)

insert into CTHoaDon
values (5, 6, 2, 50000)

insert into CTHoaDon
values (5,7, 1, 20000)

--

insert into CTHoaDon
values (6,14, 1, 12000)

insert into CTHoaDon
values (6, 13, 3, 36000)

insert into CTHoaDon
values (6, 12, 3, 36000)

--

insert into CTHoaDon
values (7, 5, 2, 60000)

--

insert into CTHoaDon
values (8, 5, 1, 30000)

--

insert into CTHoaDon
values (9, 6, 2, 50000)

insert into CTHoaDon
values (9, 8, 3, 75000)

--

insert into CTHoaDon
values (10,3, 1, 30000)

insert into CTHoaDon
values (10, 10, 1, 15000)

--

insert into CTHoaDon
values (11,2, 1, 20000)

insert into CTHoaDon
values (11,12, 3, 36000)

insert into CTHoaDon
values (11, 4, 2, 60000)

insert into CTHoaDon
values (11, 9, 1, 30000)

--

insert into CTHoaDon
values (12, 13, 1, 12000)

insert into CTHoaDon
values (12, 14, 3, 36000)

--

insert into CTHoaDon
values (13, 14, 3, 36000)

insert into CTHoaDon
values (13, 3, 2, 60000)

insert into CTHoaDon
values (13, 8, 1, 25000)

--

insert into CTHoaDon
values (14, 6, 1, 25000)

insert into CTHoaDon
values (14, 2, 2, 40000)

insert into CTHoaDon
values (14, 01, 3, 90000)

--

insert into CTHoaDon
values (15, 1, 3, 90000)

insert into CTHoaDon
values (15, 10, 1, 15000)

select * from CTHoaDon;





