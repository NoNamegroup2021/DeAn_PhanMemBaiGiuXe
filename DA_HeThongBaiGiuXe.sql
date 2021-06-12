Create database QL_HeThongBaiGiuXe
go
use QL_HeThongBaiGiuXe
go
drop database QL_HeThongBaiGiuXe
create table NhanVien
(
	MaNV varchar(11) not null,
	TenNV nvarchar(51),
	GioiTinh nvarchar(5),
	SDT varchar(30),
	NgaySinh date,
	DiaChi nvarchar(101),
	SoCMND nvarchar(21),
	COnstraint PK_NhanVien primary key (MaNV)
)

create table LoaiTK
(
	MaLoai int,
	TenLoai nvarchar(30),
	Constraint PK_LoaiTK primary key (MaLoai)
)

create table TaiKhoan
(
	TenTaiKhoan varchar(30) not null,
	Password char(30),
	MaNV varchar(11),
	NgayTaoTaiKhoan date,
	LoaiTaiKhoan int,
	Constraint PK_TaiKhoan primary key (TenTaiKhoan),
	Constraint FK_Tk_loai foreign key (LoaiTaiKhoan) references LoaiTK(MaLoai),
	Constraint FK_TK_Mnv foreign key (MaNV) references NhanVien(MaNV)

)

create table DangNhap
(
	TenTaiKhoan varchar(30) not null,
	ThoiGianDangNhap datetime,
	ThoiGianDangXuat datetime,
	Constraint FK_DangNhap foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan)
)
alter table DangNhap
ADD IDDN int IDENTITY (1,1) primary key
go
create table TheXe
(
	MaThe varchar(30) not null,
	TinhTrang bit not null default 0,
	Constraint PK_TheXe primary key (MaThe)
)

create table ChiTietTheXe
(
	IDQLy int IDENTITY (1,1),
	TenTaiKhoan varchar(30) not null,
	MaThe varchar(30) not null,
	ThoiGianXuLy date
	Constraint PK_QuanLyTheXe primary key (IDQLy),
	Constraint Fk_QuanLy_TaiKhoan Foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan),
	Constraint FK_QuanLy_The foreign key (MaThe) references TheXe(MaThe)
)

create table KhachHang
(
	MaKH int IDENTITY(1,1),
	BienSo nvarchar(300),
	Constraint PK_KH primary key (MaKH)
)

create table LanXe
(
	MaLanXe int primary key,
	TenLanXe nvarchar(30)

)

create table ChiTietLanXe
(
	MaLanXe int IDENTITY (1,1),
	MaThe varchar(30),
	TenTaiKhoan varchar(30),
	MaKH int,
	MaLoaiLanXe int,
	ThoiGIan date,
	Constraint PK_LanXe primary key (MaLanXe),
	Constraint FK_LanXe_The foreign key (MaThe) references TheXe(MaThe),
	Constraint FK_LanXe_TK foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan),
	Constraint FK_LanXe_KH foreign key (MaKH) references KhachHang(MaKH),
	Constraint FK_LanXe_Loai foreign key (MaLoaiLanXe) references LanXe(MaLanXe)
)

create table NgoaiLe
(
	MaNL int IDENTITY (1,1),
	MaKH int,
	HoTenKH nvarchar(51),
	CMND nvarchar(21),
	DiaChi nvarchar(51),
	SDT nvarchar(21),
	TenNV nvarchar(51),
	ThoiGian dateTime,
	NoiDung nvarchar(51),
	Constraint PK_NgoaiLe primary key (MaNL,MaKH,TenNV),
	Constraint FK_NgoaiLe_KH foreign key (MaKH) references KhachHang(MaKH),
)


set dateformat dmy 
insert into NhanVien
values 
('NV01',N'Nguyễn Hoàng Quý',N'Nam','0123456789113','01/01/2000',N'Bình Tân',null),
('NV02',N'Lữ Hoàng Hiếu',N'Nam','0123456789114','01/01/2000',N'Gò Vấp',null),
('NV03',N'Võ Bội Tuyền',N'Nữ','0123456789115','01/01/2000',N'Bình Tân',null),
('QL01',N'Nguyễn Văn Thảo',N'Nam','0123456789116','01/01/2000',N'Bình Tân',null),
('QL02',N'Tô Đình Nhân',N'Nam','0123456789117','19/06/1997',N'Quận 4',null),
('QL03',N'Vũ Hoàng Thiên Ân',N'Nam','0123456789118','21/05/2000',N'Bình Tân',null)

insert into LoaiTK
values
(1,N'Nhân viên'),
(2,N'Quản lý')

set dateformat dmy 
insert into TaiKhoan
values
('hieu','123','NV02','01/01/2020',1),
('nhan','456','QL01','01/01/2020',2),
('thao','789','QL02','01/01/2020',2),
('tuyen','123','NV03','01/01/2020',1),
('an','456','QL03','01/01/2020',2),
('quy','789','NV01','01/01/2020',1)

insert into LanXe
values 
(1,N'Gửi Xe'),
(2,N'Lấy Xe')

go
insert into TheXe
values 
('T1',0),
('T2',0),
('T3',0),
('T4',0),
('T5',0)

use QL_HeThongBaiGiuXe
select * from ChiTietLanXe
select * from TheXe
select * from KhachHang