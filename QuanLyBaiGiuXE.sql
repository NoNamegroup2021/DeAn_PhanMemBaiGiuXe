drop database QL_BaiGiuXe
create database QL_BaiGiuXe
use QL_BaiGiuXe
go
create table Login
(
	Username char(30) not null Primary key,
	Password char(30) ,
	MaNV char(10),
	MaCV char(10),
)
create table LoaiTK
(
	MaCV char(10) not null primary key,
	TenCV nvarchar(30),
)
create table NhanVien
(
	MaNV char(10) not null Primary key,
	HoTen nvarchar(50),
	GioiTinh char(10),
	SoCMND char(20),
	DiaChi nvarchar(100),
)
alter table Login
add constraint FK_MaNV foreign key (MaNV) references NhanVien(MaNV)
alter table login
add constraint FK_MaCV foreign key (MaCV) references LoaiTK(MaCV)
insert into Login
values
('hieu','123','NV02','CV01'),
('nhan','456','QL01','CV02'),
('thao','789','QL02','CV02'),
('tuyen','123','NV03','CV01'),
('an','456','QL03','CV02'),
('quy','789','NV01','CV01')
insert into LoaiTK
values
('CV01',N'Nhân viên'),
('CV02',N'Quản lý')
insert into NhanVien
values 
('NV01',N'Nguyễn Hoàng Quý',N'Nam','0123456789113',N'Bình Tân'),
('NV02',N'Lữ Hoàng Hiếu',N'Nam','0123456789114',N'Gò Vấp'),
('NV03',N'Võ Bội Tuyền',N'Nữ','0123456789115',N'Bình Tân'),
('QL01',N'Nguyễn Văn Thảo',N'Nam','0123456789116',N'Bình Tân'),
('QL02',N'Tô Đình Nhân',N'Nam','0123456789117',N'Quận 4'),
('QL03',N'Vũ Hoàng Thiên Ân',N'Nam','0123456789118',N'Bình Tân')