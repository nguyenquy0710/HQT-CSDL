CREATE DATABASE Laptop

USE Laptop


SET DATEFORMAT DMY

CREATE TABLE Account
(
	UserName NVARCHAR(15),
	DisplayName NVARCHAR(30),
	PassWord NVARCHAR(20) PRIMARY KEY,
	Type INT
)
INSERT dbo.Account
VALUES  ( N'Admin' , N'ThanhTung' , N'1' , 1),
 ( N'NV01' , N'ThanhDao' , N'2' , 0)


CREATE TABLE Hang
(
	IDHANG INT PRIMARY KEY,
	TENHANG NVARCHAR(10)
)
INSERT dbo.Hang
VALUES(1,'Dell'),
(2,'ASUS'),
(3,'Lenovo'),
(4,'HP'),
(5,'MSI')


CREATE TABLE May
(
	IDHANG INT,
	TENHANG NVARCHAR(10),
	MAMAY INT IDENTITY,
	TENMAY NVARCHAR(40),
	CAUHINH NVARCHAR(1000),
	SL INT,
	GIA INT,
	PRIMARY KEY (MAMAY)
) 
INSERT dbo.May
VALUES (2,'Asus','Asus GL552VX','i7-6700HQ | 8GB DDR4 | HDD 1TB',15,19900000),
(2,'Asus','Asus GL553VE','i7-7700HQ | 16GB DDR4 | HDD 1TB',5,26900000),
(2,'Asus','Asus K401LB','i5-5200U | 4GB DDR3L | HDD 500GB',25,11500000),
(2,'Asus','Asus K550VX','i5-6300HQ | 8GB DDR4 | HDD 1TB',20,15500000),
(2,'Asus','Asus UX390UA','i7-7500U | 8GB DDR4 | SSD 512GB',3,38000000),
(2,'Asus','Asus X441SA','i5-6300HQ | 8GB DDR4 | HDD 1TB',20,15500000),
(2,'Asus','Asus UX501UW','i7-7500U | 8GB DDR4 | HDD 500GB',21,23500000),
(2,'Asus','Asus GX800VH','i7-7820HK | 64GB GDDR5 | SSD 1.5TB',2,145000000),
(2,'Asus','Asus A540LA','i3-5005U | 4GB DDR3L | HDD 500GB',20,10200000),
(1,'Dell','Dell Inspiron 3459','i5-6200U | 4BB DDR3L | HDD 500GB',32,9800000),
(1,'Dell','Dell Inspiron 7559','i7-6700HQ | 8GB DDR3L | SSHD 1TB',40,23500000),
(1,'Dell','Dell Inspiron 5559','i7-6500U | 8GB DDR4 | HDD 1TB',25,18000000),
(1,'Dell','Dell Vostro 5568','i7-7500U | 8GB DDR4 | HDD 1TB',20,21500000),
(1,'Dell','Dell Latitude E5470','i5-6200U | 8GB DDR4 | HDD 500GB',70,13500000),
(1,'Dell','Dell Latitude E7270','i5-6300U | 8GB DDR3L | SSD 250GB',40,18500000),
(1,'Dell','Dell Vostro 5459','i5-6200U | 4GB DDR3L | HDD 1TB',50,15500000),
(1,'Dell','Dell Vostro 5468','i5-7200U | 4GB DDR4 | HDD 500GB',20,13500000),
(1,'Dell','Dell Vostro V3468','i3-7100U | 4GB DDR3L | HDD 1TB',12,11500000),
(4,'HP','Hp Probook 450 G2','i7-5500U | 8GB DDR3L | HDD 1TB',52,19500000),
(4,'HP','Hp Probook 440 G1','i5-5200U | 8GB DDR3L | HDD 1TB',2,15550000),
(2,'Asus','Asus X454LA','i3-5005U | 4GB DDR3L | HDD 500GB',65,10500000),
(1,'Dell','Dell Vostro V5459','i3-6100U | 4GB DDR3L | HDD 500GB',12,9500000),
(5,'MSI','MSI GS63VR 6RF','i7-6700HQ | 16G DDR4 | SSD 128GB',25,45500000),
(2,'Asus','Asus TP501UA','i3-7100U | 4GB DDR3L | HDD 1TB',100,11500000),
(2,'Asus','Asus X541UA','i5-6198DU | 4GB DDR3L | HDD 500GB',60,10700000),
(2,'Asus','Asus GL553VD','i5-7300HQ | 8GB DDR4 | HDD 1TB',122,21900000),
(5,'MSI','MSI PE60 6QD','i5-6300HQ | 4GB DDR4 | HDD 1TB',30,19900000),
(5,'MSI','MSI PE60 7RD','i7-7700HQ | 8GB DDR4  | HDD 1TB',10,29900000),
(3,'Lenovo','Lenovo G400','Pentium 2020M | 2GB DDR3L | HDD 500GB',40,6500000),
(3,'Lenovo','Lenovo G400s','i3-3110M | 2GB DDR3L | HDD 500GB',50,7900000),
(3,'Lenovo','Lenovo G4070','Pentium 3558U Hasswel | 2GB DDR3L | HDD 500GB',120,5950000),
(3,'Lenovo','Lenovo S410','i5-4210U | 4GB DDR3L | HDD 500GB',10,12900000),
(2,'Asus','Asus B8430UA','i7-6600U | 8GB DDR4 | SSD 512GB',25,26900000),
(1,'Dell','Dell Latitude E5450','i5-5300U | 8GB DDR3L | HDD 1TB',17,21900000)


CREATE TABLE NhanVien
(
	MANV NVARCHAR(5),
	TENNV NVARCHAR(30),
	NGAYSINH DATE,
	DCNV NVARCHAR(100),
	SDT INT,
	PRIMARY KEY (MANV)
)
INSERT dbo.NhanVien
VALUES('NV01',N'Đỗ Lương Thành Đào','23/06/1996',N'Hoàng Hoa Thám - Quận Tân Bình','0995333222'),
('NV02',N'Lê Thị Mỹ Hòa','13/01/1996',N'Trường Chinh - Quận 12','0974321456')


CREATE TABLE Khach
(
	MAKH NVARCHAR(10),
	TENKH NVARCHAR(50),
	TENMAY NVARCHAR(40),
	DCKH NVARCHAR(100),
	SDTKH CHAR(15),
	NGAYMUA CHAR(20),
	PRIMARY KEY (MAKH)
)
INSERT dbo.Khach
VALUES ('MAKH01',N'Nguyễn Văn Tâm','Asus GL552VX',N'Lương Đình Của - Quận 2','09777762502','21/02/2016'),
('MAKH02',N'Trần Thị Thanh','Asus GL553VE',N'Tân Chánh Hiệp 18 - Quận 12','09777762502','21/02/2016'),
('MAKH03',N'Nguyễn Minh Nhật','Asus K401LB',N'Lương Đình Của - Quận 2','0977762502','21/02/2016'),
('MAKH04',N'Đỗ Chính Hùng','Dell Latitude E5450',N'Đồng Nai - Quận Phú Nhuận','09777762502','21/02/2016'),
('MAKH05',N'Lê Thị Giang','Lenovo S410',N'Bình Thới - Quận 11','09777762502','21/02/2016'),
('MAKH06',N'Nguyễn Thanh Hiền','MSI PE60 7RD',N'Lương Đình Của - Quận 2','09777762502','21/02/2016'),
('MAKH07',N'Phan Quỳnh Hương','Asus X454LA',N'Cao Thắng - Quận 3','09777762502','21/02/2016'),
('MAKH08',N'Lâm Thanh Tâm','Dell Vostro 5459',N'Đinh Tiên Hoàng - Quận 1','09777762502','21/02/2016'),
('MAKH09',N'Bùi Đức Anh','Dell Latitude E5470',N'Tân Chánh Hiệp 18 - Quận 12','09777762502','21/02/2016'),
('MAKH10',N'Lê Văn Thành','Hp Probook 450 G2',N'Tân Thới Hiệp - Quận 12  ','09777762502','21/02/2016'),
('MAKH11',N'Trần Tuấn Kiệt','Asus X541UA',N'An Dương Vương - Quận 11','09777762502','21/02/2016'),
('MAKH12',N'Phan Thị Thanh Nga','Asus UX501UW',N'Cao Thắng - Quận 3','09777762502','21/02/2016'),
('MAKH13',N'Trần Thị Kiều','MSI GS63VR 6RF',N'Lũy Bán Bích - Quận Tân Phú','09777762502','21/02/2016'),
('MAKH14',N'Nguyễn Văn Long','Asus UX501UW',N'Võ Thị Sáu - Quận 3','09777762502','21/02/2016'),
('MAKH15',N'Trần Mạnh Hùng','Dell Inspiron 3459',N'Lương Đình Của - Quận 2','09777762502','21/02/2016')


CREATE TABLE HoaDon
(
	MAHD INT IDENTITY,
	MANV NVARCHAR(5),
	TENNV NVARCHAR(50),
	TENMAY NVARCHAR(40),
	MAKH NVARCHAR(10),
	TENKH NVARCHAR(50),
	DCKH NVARCHAR(50),
	SDTKH CHAR(15),
	SL INT,
	DONGIA INT,
	NGAYBAN CHAR(20),
	TONGTIEN INT
	PRIMARY KEY(MAHD)
)
INSERT dbo.HoaDon
VALUES  (N'NV01',N'Đỗ Lương Thành Đào',N'Asus UX390UA',N'MAKH01',N'Nguyễn Văn Tâm',N'Lương Đình Của - Quận 2','09777762502',1,38000000,'21/02/2016',38000000),


-- STORE PROCEDURE

-- Store Procedure cho Login
CREATE PROC U_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END


--Store Procedure cho danh sách Laptop
CREATE PROC U_GetLaptopList
AS SELECT * FROM dbo.May

EXEC dbo.U_GetLaptopList

-- Store Procedure cho danh sách Account
CREATE PROC U_GetAccountList
AS SELECT * FROM dbo.Account

EXEC U_GetAccountList

-- Store Procedure cho danh sách nhân viên
CREATE PROC U_GetStaffList
AS SELECT * FROM dbo.NhanVien

EXEC U_GetStaffList

-- Store Procedure cho danh sách khách hàng
CREATE PROC U_GetCustomerList
AS SELECT * FROM dbo.Khach

EXEC U_GetCustomerList

-- Store Procedure danh sách hóa đơn
CREATE PROC U_GetBillList
AS
SELECT MAHD, MANV, TENNV, TENMAY, NGAYBAN, MAKH, TENKH, SDTKH, DCKH, SL, DONGIA, TONGTIEN = DONGIA * SL
FROM dbo.HoaDon
EXEC U_GetBillList



-- VIEW

-- View cho danh sách laptop
CREATE VIEW User_GetLaptopList AS
SELECT * 
FROM dbo.MAY

SELECT * FROM User_GetLaptopList

-- View cho danh sách tài khoản
CREATE VIEW User_GetAccountList AS
SELECT * 
FROM dbo.Account
SELECT * FROM User_GetAccountList

-- View cho danh sách nhân viên
CREATE VIEW User_GetStaffList AS
SELECT *
FROM dbo.NHANVIEN

SELECT * FROM User_GetStaffList

-- View cho danh sách khách
CREATE VIEW User_GetCustomerList AS
SELECT * FROM dbo.KHACH

SELECT * FROM User_GetCustomerList

-- View cho danh sách hóa đơn
CREATE VIEW User_GetBillList AS
SELECT MAHD, MANV, TENNV, TENMAY, NGAYBAN, MAKH, TENKH, SDTKH, DCKH, SL, DONGIA, DONGIA * SL AS TongTien
FROM dbo.HoaDon

SELECT * FROM User_GetBillList




-- FUNCTION

-- Function cho danh sách laptop
CREATE FUNCTION func_U_GetLaptopList()
RETURNS TABLE
AS
 RETURN ( SELECT * FROM dbo.May)

SELECT * FROM func_U_GetLaptopList()

-- Function cho danh sách tài khoản
CREATE FUNCTION func_User_GetAccountList()
RETURNS TABLE
AS
 RETURN ( SELECT * FROM dbo.Account)

 SELECT * FROM func_User_GetAccountList
 
-- Function cho danh sách nhân viên
CREATE FUNCTION func_U_GetStaffList()
RETURNS TABLE 
AS
RETURN ( SELECT * FROM dbo.Nhanvien)

SELECT * FROM func_U_GetStaffList()

-- Function cho danh sách nhân viên
CREATE FUNCTION func_U_GetCustomerList()
RETURNS TABLE
AS
 RETURN (SELECT * FROM dbo.Khach)
 
SELECT * FROM func_U_GetCustomerList()

-- Function danh sách hóa đơn
CREATE FUNCTION func_U_GetBillList()
RETURNS TABLE
AS
return (SELECT MAHD, MANV, TENNV, TENMAY, NGAYBAN, MAKH, TENKH, SDTKH, DCKH, SL, DONGIA, DONGIA * SL AS TongTien
FROM dbo.HoaDon)

SELECT * FROM func_U_GetBillList()

-- TRIGGER

-- Bảng hóa đơn




CREATE TRIGGER Check_DonGia ON HoaDon FOR INSERT,UPDATE
AS
	IF(EXISTS (SELECT * FROM inserted WHERE DONGIA <= 0 ))
BEGIN 
	RAISERROR(N' Đơn giá trong hóa đơn phải > 0',0,1)
	ROLLBACK TRAN
END



-- Bảng máy
CREATE TRIGGER SoLuong ON dbo.May FOR INSERT,UPDATE
AS
	IF (EXISTS (SELECT * FROM inserted WHERE SL < 0))
BEGIN
	RAISERROR (N'Số lượng máy phải >= 0',0,1)
	ROLLBACK TRAN
END

CREATE TRIGGER Gia ON dbo.May FOR INSERT,UPDATE
AS
	IF (EXISTS (SELECT * FROM inserted WHERE GIA <= 0))
BEGIN
	RAISERROR(N'Giá của máy phải là số dương',0,1)
	ROLLBACK TRAN
END



-- Bảng nhân viên
CREATE TRIGGER SDT ON dbo.NhanVien FOR INSERT,UPDATE
AS
	IF (EXISTS (SELECT * FROM inserted WHERE SDT < 0))
BEGIN
	RAISERROR(N'SDT phải là số dương',0,1)
	ROLLBACK TRAN
END

-- doc du lieu rac
-- tran 1
set transaction isolation level read uncommitted
CREATE TRIGGER Check_SoLuong ON dbo.HoaDon FOR INSERT,UPDATE
AS
	IF ( EXISTS (SELECT * FROM inserted WHERE SL <= 0 ))
BEGIN
	WAITFOR DELAY '0:0:5' 
	RAISERROR(N' Số lượng trong hóa đơn phải > 0',0,1)
	ROLLBACK TRAN
END
COMMIT TRAN
-- tran 2
CREATE PROC U_SearchBillList
 @tenKH nvarchar(50)
AS
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ UNCOMMITTED
SELECT *
FROM dbo.HoaDon
WHERE TENKH LIKE N'%' + @tenKH + '%'



--khong doc lai du lieu
-- tran 1
CREATE PROC U_SearchUserNameTwoTimes
@userName varchar(50)
AS
DECLARE @table TABLE(UserName NVARCHAR(15), DisplayName NVARCHAR(30), PassWord NVARCHAR(40), Type INT)

INSERT @table
SELECT *
FROM dbo.Account
WHERE UserName LIKE N'%' + @userName + '%'

WAITFOR DELAY '0:0:5'

INSERT @table
SELECT *
FROM dbo.Account
WHERE UserName LIKE N'%' + @userName + '%'

SELECT * FROM @table

--set transaction isolation level repeatable READ



--bong ma
--tran 1
CREATE PROC U_CountUserNameTwoTimes
AS
DECLARE @table TABLE(countUserName int)

INSERT @table
SELECT COUNT(UserName)
FROM dbo.Account

WAITFOR DELAY '0:0:5'

INSERT @table
SELECT COUNT(UserName)
FROM dbo.Account

SELECT * FROM @table

--set transaction isolation level serializable


--lost update

CREATE PROC U_UpdateComputer
	@maMay int,
	@tenMay nvarchar(50),
	@cauHinh nvarchar(50),
	@soLuong int,
	@giaThemVao int
AS
	DECLARE @gia INT
	SET @gia = (SELECT GIA
				FROM dbo.May
				WHERE MAMAY = @maMay)
	SET @gia = @gia + @giaThemVao
	WAITFOR DELAY '0:0:5'
	UPDATE dbo.May SET TENMAY = @tenMay, CAUHINH = @cauHinh, SL = @soLuong, GIA = @gia WHERE MAMAY = @maMay