--Xóa database

use master;
go
alter database QL_BANMAYTINH set SINGLE_USER WITH ROLLBACK IMMEDIATE;
go
drop database QL_BANMAYTINH

--Tạo database

CREATE DATABASE QL_BANMAYTINH
go
USE QL_BANMAYTINH

CREATE TABLE THUONGHIEU
(
	MaThuongHieu varchar(10),
	TenThuongHieu nvarchar(50),
	primary key (MaThuongHieu)
)

CREATE TABLE TAIKHOAN
(
	TaiKhoan VARCHAR(50) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	Email VARCHAR(100),
	Quyen VARCHAR(10),
	HoTen NVARCHAR(50) NOT NULL,
	GioiTinh NVARCHAR(5),
	NgaySinh DATE,
	SDT VARCHAR(15),
	DiaChi NVARCHAR(100),
	Flag int,
	PRIMARY KEY (TaiKhoan)
)

CREATE TABLE SANPHAM
(
	MaSP VARCHAR(10),
	TenSP NVARCHAR(100) NOT NULL,
	MaThuongHieu varchar(10),
	SoLuongTon INT,
	GiaBanLe decimal(19,3),
	XuatSu NVARCHAR(20),
	Motakithuat NVARCHAR(1000),
	Hinhanh varchar(100),
	Hinhanhindex varchar(100),
	TrangThai NVARCHAR(20),
	PRIMARY KEY (MaSP),
	foreign key (MaThuongHieu) references THUONGHIEU(MaThuongHieu)
)

CREATE TABLE NHACUNGCAP
(
	MaNCC VARCHAR(10),
	TenNCC NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100),
	SDT VARCHAR(15),
	Flag int,
	PRIMARY KEY (MaNCC)
)

CREATE TABLE PHIEUNHAP
(
	MaPN VARCHAR(10),
	NgayNhap DATE,
	MaNCC VARCHAR(10),
	TongTien DECIMAL(19,3),
	Flag int,
	PRIMARY KEY (MaPN),
	FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
)

CREATE TABLE CHITIETPHIEUNHAP
(
	MaPN VARCHAR(10),
	MaSP VARCHAR(10),
	SoLuongNhap INT,
	ThanhTien DECIMAL(19,3),
	Primary key (MaPN, MaSP),
	FOREIGN KEY (MaPN) REFERENCES PHIEUNHAP(MaPN),
	FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
)

CREATE TABLE DONHANG
(
	MaDH nvarchar(50),
	NgayTao DATE,
	TaiKhoan varchar(50),
	Shipname nvarchar(50),
	ShipMobile nvarchar(50),
	ShipAddress nvarchar(50),
	ShipEmail nvarchar(50),
	TongTien DECIMAL(19,3),
	DaThanhToan int,
	Status int,
	PRIMARY KEY (MaDH),
	FOREIGN KEY (TaiKhoan) REFERENCES TAIKHOAN(TaiKhoan)
)

CREATE TABLE CHITIETDONHANG
(
	MaDH nvarchar(50),
	MaSP VARCHAR(10),
	SoLuong int,
	ThanhTien DECIMAL(19,3),
	Primary key (MaDH,MaSP),
	FOREIGN KEY (MaDH) REFERENCES DONHANG(MaDH),
	FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
)

--INSERT

--THUONGHIEU
insert into THUONGHIEU values('ASUS',N'Thương hiệu laptop ASUS')
insert into THUONGHIEU values('DELL',N'Thương hiệu laptop DELL')
insert into THUONGHIEU values('HP',N'Thương hiệu laptop HP')
insert into THUONGHIEU values('ACER',N'Thương hiệu laptop ACER')


--TAIKHOAN
insert into TAIKHOAN values ('admin',CONVERT(VARCHAR(50), HashBytes('MD5', 'admin'), 2),'admin@gmail.com','1',N'admin',N'Nam','1997-11-25','',N'', 1)
insert into TAIKHOAN values ('ngocson',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'son@gmail.com','2',N'Nguyễn Ngọc Sơn',N'Nam','1997/11/25','0123456789',N'Quận 12', 1)
insert into TAIKHOAN values ('thanhtan',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'tan@gmail.com','2',N'Huỳnh Thanh Tân',N'Nam','1997/3/3','0987654321',N'Quận 5', 1)
insert into TAIKHOAN values ('nhusang',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'sang@gmail.com','2',N'Nguyễn Như Sang',N'Nam','1997/2/2','0521364890',N'Quận 12', 1)
insert into TAIKHOAN values ('havi',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'vi@gmail.com','2',N'Nguyễn Thị Hà Vi',N'Nữ','1997/9/9','0124953017',N'Quận 1', 1)
insert into TAIKHOAN values ('thudiep',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'diep@gmail.com','2',N'Trần Thu Diệp',N'Nữ','1997/9/23','0946251674',N'Quận 3', 1)
insert into TAIKHOAN values ('huongtram',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'tram@gmail.com','2',N'Hương Tràm',N'Nữ','1997/4/1','0562148637',N'Quận 2', 1)
insert into TAIKHOAN values ('khanhphuong',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'phuong@gmail.com','2',N'Khánh Phương',N'Nam','1997/8/12','0721634189',N'Quận 1', 1)
insert into TAIKHOAN values ('jangmi',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'jangmi@gmail.com','2',N'Jang Mi',N'Nữ','1997/5/11','0426841263',N'Quận 7', 1)
insert into TAIKHOAN values ('hoavinh',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'vinh@gmail.com','2',N'Hoa Vinh',N'Nam','1997/12/7','0641882694',N'Quận 8', 1)
insert into TAIKHOAN values ('camly',CONVERT(VARCHAR(50), HashBytes('MD5', '123456'), 2),'ly@gmail.com','2',N'Cẩm Ly',N'Nữ','1997/6/14','0482615796',N'Quận 2', 1)

--SANPHAM
insert into SANPHAM values('SP001', N'Laptop Asus VivoBook S15 S510UA','ASUS',15, 12990000 , N'Trung Quốc',N' CPU:Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB SATA3*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620','/Assets/imagedetail/ca-heo-ania-as-19-pacific-white-sided-dolphin-1.jpg','/Assets/images/mhnvdv1.jpg','1')

insert into SANPHAM values('SP002', N'Laptop Asus ROG Strix Scar GL504GM','ASUS',14, 45490000, N'Trung Quốc',N' CPU:Intel Core i7 Coffee Lake, 8750H, 2.20 GHz*RAM:16 GB, DDR4 (2 khe), 2666 MHz*Ổ cứng:HDD: 1 TB + SSD: 128GB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa rời, NVIDIA GeForce GTX1060, 6GB','/Assets/imagedetail/anh-hung-white-baymax-big-hero-6-loai-10-in.jpg','/Assets/images/mhnvdv2.jpg','1')

insert into SANPHAM values('SP003', N'Laptop Asus Vivobook S15 S530UA','ASUS',8,17390000, N'Trung Quốc',N' CPU:Intel Core i5 Coffee Lake, 8250U, 1.60 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 SATA3, Intel Optane 16GB*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620','/Assets/imagedetail/do-choi-khung-long-triceratops-nho-14549-1.jpg','/Assets/images/mhnvdv3.jpg','1')

insert into SANPHAM values('SP004', N'Laptop Asus VivoBook X540UB','ASUS',20,11290000, N'Trung Quốc',N' CPU:Intel Core i3 Skylake, 6006U, 2.00 GHz*RAM:4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng:HDD: 1 TB*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa rời, NVIDIA GeForce MX110, 2GB','/Assets/imagedetail/mo-hinh-one-piece-general-franky-bandai-8.jpg','/Assets/images/mhnvdv4.jpg','1')

insert into SANPHAM values('SP005', N'Laptop Dell Inspiron 7570','DELL',6,22990000, N'Trung Quốc',N' Mô hình nguyên mẫu tỷ lệ 1/18* Chất liệu đa phần bằng kim loại* Mở được cửa, nắp cốp và capo* Có các mẫu khác màu để lựa chọn','/Assets/imagedetail/mo-hinh-bentley-continental-supersports-coup-1-18.jpg','/Assets/images/mhxc1.jpg','1')

insert into SANPHAM values('SP006', N'Laptop Dell Vostro 3468','DELL',16,13790000, N'USA',N' CPU:Intel Core i5 Kabylake, 7200U, 2.50 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB*Màn hình:14 inch, HD (1366 x 768)*Card màn hình:Card đồ họa tích hợp, Intel® HD Graphics 620','/Assets/imagedetail/bo-suu-tap-xe-o-to-hot-wheels-star-wars-cgw35-2_1.jpg','/Assets/images/mhxc2.jpg','1')

insert into SANPHAM values('SP007', N'Laptop Dell Inspiron 7373','DELL',7,10490000, N'Trung Quốc',N' CPU:Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM:8 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:SSD: 256 GB*Màn hình:13.3 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620','/Assets/imagedetail/mo-hinh-lamborghini-huracan-lp-610-4-ty-le-1-18.jpg','/Assets/images/mhxc3.jpg','1')

insert into SANPHAM values('SP008', N'Laptop DELL Inspiron 15 N3567','DELL',17,750000, N'Japan',N' CPU:Intel Core i3 Skylake, 6006U, 2.00 GHz*RAM:4 GB, DDR4 (2 khe), 2133 MHz*Ổ cứng:HDD: 1 TB*Màn hình:15.6 inch, HD (1366 x 768)*Card màn hình:Card đồ họa rời, AMD Radeon R5 M430, 2 GB','/Assets/imagedetail/bo-duong-ray-va-san-ga-tau-hoa-rail-yard-set-1.jpg','/Assets/images/mhxc4.jpg','1')

insert into SANPHAM values('SP009', N'Laptop HP 15 da0054TU','HP',16,10990000, N'Trung Quốc',N' CPU:Intel Core i3 Kabylake, 7020U, 2.30 GHz*RAM:4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng:HDD: 500 GB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® HD Graphics 620','/Assets/imagedetail/bo-450-hat-hama-khuon-hinh-sao-4149-1.jpg','/Assets/images/dcxhlg1.jpg','1')

insert into SANPHAM values('SP010', N'Laptop HP 15 da0036TX','HP',7,17490000, N'USA',N' CPU:Intel Core i7 Kabylake Refresh, 8550U, 1.80 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa rời, NVIDIA Geforce MX130, 2GB','/Assets/imagedetail/bo-lap-ghep-spinning-tops-con-quay-52100-2.jpg','/Assets/images/dcxhlg2.jpg','1')

insert into SANPHAM values('SP011', N'Laptop HP 15 da0055TU','HP',12,10290000, N'Trung Quốc',N' CPU:Intel Core i3 Kabylake, 7020U, 2.30 GHz*RAM:4 GB, DDR4 (1 khe), 2133 MHz*Ổ cứng:HDD: 1 TB*Màn hình:15.6 inch, HD (1366 x 768)*Card màn hình:Card đồ họa tích hợp, Intel® HD Graphics 620','/Assets/imagedetail/bo-lap-rap-bien-thu-ho-boi-sluban-m38-b0532-5_1.jpg','/Assets/images/dcxhlg3.jpg','1')

insert into SANPHAM values('SP012', N'Laptop HP Pavilion','HP',20,13490000, N'USA',N' CPU:Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM:4 GB, DDR4 (2 khe), 2400 MHz*Ổ cứng:HDD: 1 TB SATA3, Hỗ trợ khe cắm SSD M.2 SATA3*Màn hình:14 inch, HD (1366 x 768)*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620','/Assets/imagedetail/bo-lap-rap-can-ho-cua-banya-va-roufi-sluban-b0573-4.jpg','/Assets/images/dcxhlg4.jpg','1')

insert into SANPHAM values('SP013', N'Laptop Acer Aspire E5 576 34ND','ACER',8, 10790000, N'Trung Quốc', N'CPU:Intel Core i3 Kabylake Refresh, 8130U, 2.20 GHz*RAM:4 GB, DDR3L (2 khe RAM), 2133 MHz*Ổ cứng:HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® HD Graphics 620','/Assets/imagedetail/bo-do-choi-mau-giao-sylvanian-families-3589-2.jpg','/Assets/images/dcbb1.jpg','1')

insert into SANPHAM values('SP014', N'Laptop Acer Swift SF314 54 51QL','ACER',16, 17290000, N'Trung Quốc', N'CPU:Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM:4 GB, DDR4 (On board +1 khe), 2133 MHz*Ổ cứng:HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe, Hỗ trợ bộ nhớ Intel® Optane™*Màn hình:14 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa tích hợp, Intel® HD Graphics 620','/Assets/imagedetail/bo-do-nha-si-sylvanian-families-2817-1.jpg','/Assets/images/dcbb2.jpg','1')

insert into SANPHAM values('SP015', N'Laptop Acer Swift SF315 51 530V','ACER',12, 15490000, N'Trung Quốc', N'CPU:Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM:4 GB, DDR4 (On board), 2400 MHz*Ổ cứng:HDD: 1 TB*Màn hình:15.6 inch*Card màn hình:Card đồ họa tích hợp, Intel® UHD Graphics 620','/Assets/imagedetail/bua-tiec-bup-be-mau-giao-sylvanian-families-3591-1.jpg','/Assets/images/dcbb3.jpg','1')

insert into SANPHAM values('SP016', N'Laptop Acer Aspire E5 576G 52YQ','ACER', 39,14890000, N'Trung Quốc', N'CPU:Intel Core i5 Kabylake Refresh, 8250U, 1.60 GHz*RAM:4 GB, DDR3L (2 khe RAM), 1600 MHz*Ổ cứng:HDD: 1 TB, Hỗ trợ khe cắm SSD M.2 PCIe*Màn hình:15.6 inch, Full HD (1920 x 1080)*Card màn hình:Card đồ họa rời, NVIDIA Geforce MX130, 2GB','/Assets/imagedetail/bup-be-tinker-bell-1.jpg','/Assets/images/dcbb4.jpg','1')

--NHACUNGCAP
insert into NHACUNGCAP values ('NCC001', N'Công ty cửa hàng máy tính phân phối sỉ lẻ HUỲNH ĐỨC', N'20/13 Phù Đổng Thiên Vương, P11, Q5, TP.HCM', '0984565882',1)
insert into NHACUNGCAP values ('NCC002', N'Công ty xuất nhập khẩu máy tính Gia Long', N'605 Nguyễn Trãi, P12, Q5, TP.HCM', '0986889320',1)
insert into NHACUNGCAP values ('NCC003', N'Đại lí máy tính DELLX9', N'61/2 Cách Mạng Tháng Tám, P6, Q3, TP.HCM', '0124526997',1)
insert into NHACUNGCAP values ('NCC004', N'Cửa hàng buôn bán máy tính QUỲNH NHI', N'853/4 D2, P1, Q10, TP.HCM', '0984789550',1)
insert into NHACUNGCAP values ('NCC005', N'Công ty đại lí phân phối sản phẩn máy tính ASUS9', N'61/1 Phạm Hữu Lầu, P2, Q8, TP.HCM', '0165895325',1)


--PHIEUNHAP
insert into PHIEUNHAP values('PN001','2015/12/07','NCC001',433700000,1)
insert into PHIEUNHAP values('PN002','2016/01/01','NCC002',908150000,1)
insert into PHIEUNHAP values('PN003','2016/04/06','NCC004',610600000,1)
insert into PHIEUNHAP values('PN004','2016/06/11','NCC005',234800000,1)
insert into PHIEUNHAP values('PN005','2016/07/05','NCC003',174900000,1)
insert into PHIEUNHAP values('PN006','2016/11/21','NCC004',154350000,1)
insert into PHIEUNHAP values('PN007','2017/05/06','NCC001',269800000,1)
insert into PHIEUNHAP values('PN008','2017/06/12','NCC002',161850000,1)
insert into PHIEUNHAP values('PN009','2017/07/12','NCC005',345800000,1)
insert into PHIEUNHAP values('PN010','2017/12/31','NCC001',232350000,1)
insert into PHIEUNHAP values('PN011','2018/01/11','NCC003',297800000,1)
insert into PHIEUNHAP values('PN012','2018/03/02','NCC002',297800000,1)


--CHITIETPHIEUNHAP
insert into CHITIETPHIEUNHAP values('PN001','SP001',20,259800000)
insert into CHITIETPHIEUNHAP values('PN001','SP003',10,173900000)
insert into CHITIETPHIEUNHAP values('PN002','SP002',15,682350000)
insert into CHITIETPHIEUNHAP values('PN002','SP004',20,225800000)
insert into CHITIETPHIEUNHAP values('PN003','SP005',10,229900000)
insert into CHITIETPHIEUNHAP values('PN003','SP006',20,275800000)
insert into CHITIETPHIEUNHAP values('PN003','SP007',10,104900000)
insert into CHITIETPHIEUNHAP values('PN004','SP008',20,15000000)
insert into CHITIETPHIEUNHAP values('PN004','SP009',20,219800000)
insert into CHITIETPHIEUNHAP values('PN005','SP010',10,174900000)
insert into CHITIETPHIEUNHAP values('PN006','SP011',15,154350000)
insert into CHITIETPHIEUNHAP values('PN007','SP012',20,269800000)
insert into CHITIETPHIEUNHAP values('PN008','SP013',15,161850000)
insert into CHITIETPHIEUNHAP values('PN009','SP014',20,345800000)
insert into CHITIETPHIEUNHAP values('PN010','SP015',15,232350000)
insert into CHITIETPHIEUNHAP values('PN011','SP016',20,297800000)
insert into CHITIETPHIEUNHAP values('PN012','SP016',20,297800000)


--DONHANG--

insert into DONHANG values('DH001','2018/3/19','ngocson',N'Nguyễn Ngọc Sơn','0123456789',N'Quận 12','son@gmail.com',161910000,'1','1')
insert into DONHANG values('DH002','2018/3/21','thanhtan',N'Huỳnh Thanh Tân','0987654321',N'Quận 5','tan@gmail.com',95730000,'1','1')
insert into DONHANG values('DH003','2018/3/20','ngocson',N'Nguyễn Ngọc Sơn','0123456789',N'Quận 12','son@gmail.com',46470000,'1','1')
insert into DONHANG values('DH004','2018/3/11','khanhphuong',N'Khánh Phương','0721634189',N'Quận 1','phuong@gmail.com',81140000,'1','1')
insert into DONHANG values('DH005','2018/3/16','hoavinh',N'Hoa Vinh','0641882694',N'Quận 8','vinh@gmail.com',80760000,'1','1')
insert into DONHANG values('DH006','2018/3/1','camly',N'Cẩm Ly','0482615796',N'Quận 2','ly@gmail.com',17290000,'1','1')
insert into DONHANG values('DH007','2018/3/4','huongtram',N'Hương Tràm','0562148637',N'Quận 2','tram@gmail.com',53450000,'1','1')
insert into DONHANG values('DH008','2018/3/7','nhusang',N'Nguyễn Như Sang','0521364890',N'Quận 12','sang@gmail.com',16040000,'1','1')
insert into DONHANG values('DH009','2018/3/21','thudiep',N'Trần Thu Diệp','0946251674',N'Quận 3','diep@gmail.com',89330000,'1','1')
insert into DONHANG values('DH010','2018/3/21','thudiep',N'Trần Thu Diệp','0946251674',N'Quận 3','diep@gmail.com',17290000,'1','1')


--CHITIETHOADON
insert into CHITIETDONHANG values ('DH001','SP001',3,38970000)
insert into CHITIETDONHANG values ('DH001','SP005',2,45980000)
insert into CHITIETDONHANG values ('DH001','SP007',3,31470000)
insert into CHITIETDONHANG values ('DH001','SP002',1,45490000)
insert into CHITIETDONHANG values ('DH002','SP006',3,41370000)
insert into CHITIETDONHANG values ('DH002','SP009',2,21980000)
insert into CHITIETDONHANG values ('DH002','SP010',1,17490000)
insert into CHITIETDONHANG values ('DH002','SP016',1,14890000)
insert into CHITIETDONHANG values ('DH003','SP015',3,46470000)
insert into CHITIETDONHANG values ('DH004','SP014',2,25980000)
insert into CHITIETDONHANG values ('DH004','SP011',2,20580000)
insert into CHITIETDONHANG values ('DH004','SP001',2,34580000)
insert into CHITIETDONHANG values ('DH005','SP005',2,34780000)
insert into CHITIETDONHANG values ('DH005','SP003',2,45980000)
insert into CHITIETDONHANG values ('DH006','SP014',1,17290000)
insert into CHITIETDONHANG values ('DH007','SP011',1,10290000)
insert into CHITIETDONHANG values ('DH007','SP013',4,43160000)
insert into CHITIETDONHANG values ('DH008','SP006',1,13790000)
insert into CHITIETDONHANG values ('DH008','SP008',3,2250000)
insert into CHITIETDONHANG values ('DH009','SP009',2,21980000)
insert into CHITIETDONHANG values ('DH009','SP010',2,34980000)
insert into CHITIETDONHANG values ('DH009','SP013',3,32370000)
insert into CHITIETDONHANG values ('DH010','SP014',1,17290000)

	CREATE PROCEDURE sanphambanchay
AS
BEGIN
		select top 3 sp.TenSP,sum(ctdh.SoLuong) as SoLuongBan
		from CHITIETDONHANG ctdh,DONHANG dh,SANPHAM sp
		where ctdh.MaDH=dh.MaDH and ctdh.MaSP=sp.MaSP and MONTH(dh.NgayTao)=3
		group by sp.TenSP
		order by sum(ctdh.SoLuong) DESC
END


