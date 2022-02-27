USE QLQuanCaFe
GO
INSERT INTO dbo.Role
        ( RoleName, Description )
VALUES  ( N'administrator', -- RoleName - nvarchar(50)
          N'Quản lý chính của cửa hàng'  -- Description - nvarchar(50)
          ),
		  (N'employee',N'Nhân viên của cửa hàng')

GO

INSERT INTO dbo.Employee
        ( EmployeeName ,
          RoleID ,
          Password ,
          Email ,
          Address ,
          Mobile ,
          DOB ,
          Status
        )
VALUES  ( N'Administrator' , -- EmployeeName - nvarchar(50)
          1 , -- RoleID - int
          N'admin' , -- Password - nvarchar(50)
          N'admin@abc.com' , -- Email - nvarchar(50)
          N'quận 12' , -- Address - ntext
          N'0974691005' , -- Mobile - nvarchar(50)
          GETDATE() , -- DOB - date
          1  -- Status - int
        ),
		( N'employee' , -- EmployeeName - nvarchar(50)
          2 , -- RoleID - int
          N'1' , -- Password - nvarchar(50)
          N'employee@abc.com' , -- Email - nvarchar(50)
          N'quận 12' , -- Address - ntext
          N'01652958506' , -- Mobile - nvarchar(50)
          GETDATE() , -- DOB - date
          1  -- Status - int
        )
GO
