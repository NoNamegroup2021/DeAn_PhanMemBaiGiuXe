﻿Create database QL_HeThongBaiGiuXe
go
use QL_HeThongBaiGiuXe
go

drop database QL_HeThongBaiGiuXe
use QL_DTDD1

create table NhanVien
(
	MaNV varchar(11) not null,
	TenNV nvarchar(51),
	GioiTinh nvarchar(5),
	SDT varchar(30),
	NgaySinh date,
	DiaChi nvarchar(101),
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
	TenTaiKhoan varchar(30) not null primary key,
	ThoiGianDangNhap date,
	ThoiGianDangXuat date,
	Constraint FK_DangNhap foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan)
)

create table TheXe
(
	MaThe varchar(30) not null,
	TinhTrang bit not null default 0,
	Constraint PK_TheXe primary key (MaThe)
)

create table QuanLyTheXe
(
	ID varchar(11),
	TenTaiKhoan varchar(30) not null,
	MaThe varchar(30) not null,
	ThoiGianXuLy date
	Constraint PK_QuanLyTheXe primary key (TenTaiKhoan,MaThe,ID),
	Constraint Fk_QuanLy_TaiKhoan Foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan),
	Constraint FK_QuanLy_The foreign key (MaThe) references TheXe(MaThe)
)

create table KhachHang
(
	MaKH varchar(30),
	BienSo nvarchar(21),
	TrangThaiKH nvarchar(21),
	Constraint PK_KH primary key (MaKH)
)

create table GiaoTac
(
	MaThe varchar(30),
	TenTaiKhoan varchar(30),
	MaKH varchar(30),
	MaGiaoTac varchar(30),
	LoaiGiaoTac int,
	ThoiGIan date,
	Constraint PK_GiaoTac primary key (MaGiaoTac),
	Constraint FK_GiaoTac_The foreign key (MaThe) references TheXe(MaThe),
	Constraint FK_GiaoTac_TK foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan),
	Constraint FK_GiaoTac_KH foreign key (MaKH) references KhachHang(MaKH)
)

create table NgoaiLe
(
	MaNL varchar(30),
	MaKH varchar(30),
	TenTaiKhoan varchar(30),
	TrangThaiNL  bit,
	ThoiGian date,
	Constraint PK_NgoaiLe primary key (MaNL,MaKH,TenTaiKhoan),
	Constraint FK_NgoaiLe_KH foreign key (MaKH) references KhachHang(MaKH),
	Constraint FK_NgoaiLe_Tk foreign key (TenTaiKhoan) references TaiKhoan(TenTaiKhoan)
)


set dateformat dmy 
insert into NhanVien
values 
('NV01',N'Nguyễn Hoàng Quý',N'Nam','0123456789113','01/01/2000',N'Bình Tân'),
('NV02',N'Lữ Hoàng Hiếu',N'Nam','0123456789114','01/01/2000',N'Gò Vấp'),
('NV03',N'Võ Bội Tuyền',N'Nữ','0123456789115','01/01/2000',N'Bình Tân'),
('QL01',N'Nguyễn Văn Thảo',N'Nam','0123456789116','01/01/2000',N'Bình Tân'),
('QL02',N'Tô Đình Nhân',N'Nam','0123456789117','19/06/1997',N'Quận 4'),
('QL03',N'Vũ Hoàng Thiên Ân',N'Nam','0123456789118','21/05/2000',N'Bình Tân')


insert into LoaiTK
values
(1,N'Nhân viên'),
(2,N'Quản lý')


set dateformat dmy 
insert into TaiKhoan
values
('hieu','123','NV02','01/01/2020',2),
('nhan','456','QL01','01/01/2020',1),
('thao','789','QL02','01/01/2020',2),
('tuyen','123','NV03','01/01/2020',2),
('an','456','QL03','01/01/2020',1),
('quy','789','NV01','01/01/2020',1)