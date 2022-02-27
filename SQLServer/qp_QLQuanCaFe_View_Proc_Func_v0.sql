USE QLQuanCaFe
GO
------ VIEW --------
--ket giu order voi order detail
CREATE VIEW v_Order_OrderDetail
AS
	SELECT o.OrderID, o.TableID, o.EmployeeID, o.DateCheckIn, o.[Status], od.ProductID, od.Quantity FROM dbo.[Order] AS o, dbo.Order_Detail AS od
	WHERE o.OrderID = od.OrderID
GO

--ket giua order detal voi product
CREATE VIEW v_OrderDetail_Product
AS
	SELECT od.OrderID, od.ProductID, od.Quantity, p.ProductName, p.CategoryID, p.Price, p.[Description] FROM dbo.Order_Detail AS od, dbo.Product AS p
	WHERE od.ProductID = p.ProductID
GO

--ket giua employee voi order
CREATE VIEW v_Employee_Order
AS
	SELECT e.EmployeeID, e.EmployeeName, o.OrderID, o.TableID, o.DateCheckIn, o.Status FROM dbo.Employee AS e, dbo.[Order] AS o
	WHERE e.EmployeeID = o.EmployeeID
GO

--ket giua table voi order
CREATE VIEW v_Table_Order
AS
	SELECT t.TableID, t.TableName, t.[Status], o.OrderID, o.EmployeeID, o.DateCheckIn FROM dbo.[Table] AS t, dbo.[Order] AS o
	WHERE t.TableID = o.TableID
GO

--ket giua nhan vien va role
CREATE VIEW v_Employee_Role
AS
	SELECT e.EmployeeID, e.EmployeeName, e.Email, e.Address, e.Mobile, e.DOB, e.Status, r.RoleName, r.Description FROM dbo.Employee AS e, dbo.Role AS r
	WHERE e.RoleID = r.RoleID
GO

------ FUNCTION --------
--tinh tong tien
CREATE FUNCTION func_TongTienSanPham(@OrderID int, @ProductID int) RETURNS FLOAT
AS
	BEGIN
	DECLARE @kq FLOAT
		SELECT @kq = (a.Price*a.Quantity) FROM  dbo.v_OrderDetail_Product AS a
		WHERE a.OrderID = @OrderID AND a.ProductID = @ProductID
	RETURN @kq
	END
GO

------ TRIGGER --------


-- so luong mua phai lon hon 0
create TRIGGER InsertOrderDetail_Quanty
ON dbo.Order_Detail for INSERT, UPDATE 
AS
BEGIN
	DECLARE @qty INT = (SELECT Inserted.Quantity FROM Inserted)
	IF(@qty <= 0)
		BEGIN
			RAISERROR('So luong mua phai lon hon 0', 15, 0)
			ROLLBACK TRANSACTION
		END 
END
GO
--drop trigger InsertOrderDetail_Quanty
--san pham phai khong trung ten
Create TRIGGER InsertProduct_ProductName
ON dbo.Product AFTER INSERT, UPDATE 
AS
BEGIN
	DECLARE @n INT = 0
	SELECT @n = (SELECT COUNT(DISTINCT i.ProductName) FROM Inserted AS i, dbo.Product AS p WHERE i.ProductName = p.ProductName AND i.ProductID <> p.ProductID)
	IF(@n > 0)
		BEGIN		
			RAISERROR('Ten san pham phai khac nhau', 15, 0)
			ROLLBACK TRANSACTION
		END 
END
GO
--drop trigger InsertProduct_ProductName
-- email nhan vien khac nhau
CREATE trigger insert_email_doublicate on [dbo].[Employee] after insert, update
as
if(exists(select * from Employee e inner join inserted i on i.Email = e.Email and i.EmployeeID <> e.EmployeeID))
begin
raiserror('email trung nhau',15,0)
rollback transaction
end
go
--drop trigger insert_email_doublicate
--SELECT * FROM [sys].[triggers]