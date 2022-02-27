--------- DIEU KHIEN TUONG TRANH DU LIEU ------------
USE master
GO
USE QLQuanCaFe
GO


-- doc du lieu rac
-- tran 1
set transaction isolation level read UNCOMMITTED
CREATE TRIGGER Check_SoLuong ON [dbo].[Order_Detail] FOR INSERT,UPDATE
AS
	IF ( EXISTS (SELECT * FROM inserted WHERE Inserted.Quantity <= 0 ))
BEGIN
	WAITFOR DELAY '0:0:10' 
	RAISERROR(N' Số lượng trong hóa đơn phải > 0',0,1)
	ROLLBACK TRAN
END
COMMIT TRAN
GO	
-- tran 2
CREATE PROC U_SearchBillList
 @orderId INT
AS
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ UNCOMMITTED
SELECT *
FROM dbo.[Order_Detail]
WHERE OrderID = @orderId
COMMIT
GO	

----demo doc phai du lieu rac
UPDATE dbo.Order_Detail SET Quantity = -1 WHERE OrderID = 1
GO	
EXEC dbo.U_SearchBillList @orderId = 1
GO	
WAITFOR DELAY '0:0:20' 
GO	
EXEC dbo.U_SearchBillList @orderId = 1
GO	


--khong doc lai du lieu
-- tran 1

CREATE PROC U_SearchUserNameTwoTimes
@email nvarchar(50)
AS
DECLARE @table TABLE(Email NVARCHAR(50) NULL, EmployeeName NVARCHAR(50) NULL, [Password] NVARCHAR(50) NULL, RoleID INT NULL)
INSERT @table
SELECT Email, EmployeeName, Password,RoleID
FROM dbo.Employee
WHERE Email LIKE N'%' + @email + '%'
WAITFOR DELAY '0:0:10'
INSERT @table
SELECT Email, EmployeeName, Password,RoleID
FROM dbo.Employee
WHERE Email LIKE N'%' + @email + '%'

SELECT * FROM @table
GO	

--set transaction isolation level repeatable READ

--EXEC dbo.U_SearchUserNameTwoTimes @email = 'z' -- varchar(50)
--UPDATE dbo.Employee SET EmployeeName = 'yg' WHERE Email = 'z'

--bong ma
--tran 1
CREATE PROC U_CountUserNameTwoTimes
AS
DECLARE @table TABLE(countUserName int)

INSERT @table
SELECT COUNT(Email)
FROM dbo.Employee

WAITFOR DELAY '0:0:10'

INSERT @table
SELECT COUNT(Email)
FROM dbo.Employee

SELECT * FROM @table
GO	
--set transaction isolation level serializable
--EXEC dbo.U_CountUserNameTwoTimes

--lost update(mất dữ liệu cập nhật)

CREATE PROC sp_UpdateProduct
	@ProductID int,
	@ProductName nvarchar(50),
	@CategoryID int,
	@PriceNew FLOAT,
	@Description NTEXT
AS
	DECLARE @Price FLOAT
	SET @Price = (SELECT Price
				FROM dbo.Product
				WHERE ProductID = @ProductID)
	SET @Price = @Price + @PriceNew
	WAITFOR DELAY '0:0:10'
	UPDATE dbo.Product SET ProductName = @ProductName, CategoryID = @CategoryID, Price = @Price, Description = @Description WHERE ProductID = @ProductID
--set transaction isolation level serializable
GO

--EXEC dbo.sp_UpdateProduct @ProductID = 1, -- int
    @ProductName = N'Coca', -- nvarchar(50)
    @CategoryID = 1, -- nvarchar(50)
    @PriceNew = 14300, -- float
    @Description = NULL -- ntext
