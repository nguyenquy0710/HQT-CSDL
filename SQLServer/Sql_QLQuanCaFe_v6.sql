USE [master]
GO
/****** Object:  Database [QLQuanCaFe]    Script Date: 6/4/2017 8:54:47 PM ******/
CREATE DATABASE [QLQuanCaFe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLQuanCaFe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLQuanCaFe.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLQuanCaFe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QLQuanCaFe_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLQuanCaFe] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLQuanCaFe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLQuanCaFe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLQuanCaFe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLQuanCaFe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLQuanCaFe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLQuanCaFe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLQuanCaFe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLQuanCaFe] SET  MULTI_USER 
GO
ALTER DATABASE [QLQuanCaFe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLQuanCaFe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLQuanCaFe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLQuanCaFe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLQuanCaFe]
GO
/****** Object:  UserDefinedFunction [dbo].[func_TongTienSanPham]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------ FUNCTION --------
--tinh tong tien
CREATE FUNCTION [dbo].[func_TongTienSanPham](@OrderID int, @ProductID int) RETURNS FLOAT
AS
	BEGIN
	DECLARE @kq FLOAT
		SELECT @kq = (a.Price*a.Quantity) FROM  dbo.v_OrderDetail_Product AS a
		WHERE a.OrderID = @OrderID AND a.ProductID = @ProductID
	RETURN @kq
	END



GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[AuID] [int] NOT NULL,
	[RoleID] [int] NULL,
	[AUInsert] [bit] NULL,
	[AUDelete] [bit] NULL,
	[AUUpdate] [bit] NULL,
	[AUSelect] [bit] NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[AuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [ntext] NULL,
	[Mobile] [nvarchar](50) NULL,
	[DOB] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[TableID] [int] NULL,
	[EmployeeID] [int] NULL,
	[DateCheckIn] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[v_Employee_Order]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ket giua employee voi order
CREATE VIEW [dbo].[v_Employee_Order]
AS
	SELECT e.EmployeeID, e.EmployeeName, o.OrderID, o.TableID, o.DateCheckIn, o.Status FROM dbo.Employee AS e, dbo.[Order] AS o
	WHERE e.EmployeeID = o.EmployeeID



GO
/****** Object:  View [dbo].[v_Employee_Role]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_Employee_Role]
AS
	SELECT e.EmployeeID, e.EmployeeName, e.Email, e.Address, e.Mobile, e.DOB, e.Status, r.RoleName, r.Description FROM dbo.Employee AS e, dbo.Role AS r
	WHERE e.RoleID = r.RoleID



GO
/****** Object:  View [dbo].[v_Order_OrderDetail]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------ VIEW --------
--ket giu order voi ordẻ detail
CREATE VIEW [dbo].[v_Order_OrderDetail]
AS
	SELECT o.OrderID, o.TableID, o.EmployeeID, o.DateCheckIn, o.[Status], od.ProductID, od.Quantity FROM dbo.[Order] AS o, dbo.Order_Detail AS od
	WHERE o.OrderID = od.OrderID



GO
/****** Object:  View [dbo].[v_OrderDetail_Product]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ket giua order detal voi product
CREATE VIEW [dbo].[v_OrderDetail_Product]
AS
	SELECT od.OrderID, od.ProductID, od.Quantity, p.ProductName, p.CategoryID, p.Price, p.[Description] FROM dbo.Order_Detail AS od, dbo.Product AS p
	WHERE od.ProductID = p.ProductID



GO
/****** Object:  View [dbo].[v_Table_Order]    Script Date: 6/4/2017 8:54:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ket giua table voi order
CREATE VIEW [dbo].[v_Table_Order]
AS
	SELECT t.TableID, t.TableName, t.[Status], o.OrderID, o.EmployeeID, o.DateCheckIn FROM dbo.[Table] AS t, dbo.[Order] AS o
	WHERE t.TableID = o.TableID



GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Nước Ngọt', N'')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Cà Phê', NULL)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Trà Sữa', NULL)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (4, N'Trà Nguyên Chất', NULL)
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (5, N'Trà Kem Sữa', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (1, N'Nguyễn Văn A', 1, N'fbade9e36a3f36d3d676c1b808451dd7', N'z', N'Quận 12', N'0974691005', CAST(N'2017-06-02' AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (2, N'Nguyễn Thị B', 2, N'c20ad4d76fe97759aa27a0c99bff6710', N'employee@abc.com', N'Quận 12', N'01652958506', NULL, 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (3, N'Nguyễn Thị C', 2, NULL, N'c@abc.com', N'Quận 1', N'012345678', CAST(N'1998-02-02' AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (4, N'Nguyễn Thị D', 2, NULL, N'd@abc.com', N'Quận 9', N'098765432', CAST(N'1997-02-04' AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (28, N'Nguyễn Văn G', 2, N'1', N'g@abc.com', N'Quận 3', N'0988787665', NULL, 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (29, N'Nguyễn Văn H', 1, N'1', N'h@abc.com', N'Quận11', N'9837189477', CAST(N'1996-04-04' AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (30, N'Nguyễn Văn J', 1, N'1', N'j@abc.com', N'Quận 12', N'3456787867', CAST(N'1990-08-07' AS Date), 1)
INSERT [dbo].[Employee] ([EmployeeID], [EmployeeName], [RoleID], [Password], [Email], [Address], [Mobile], [DOB], [Status]) VALUES (36, N'Nguyễn Thị K', 2, N'd3d9446802a44259755d38e6d163e820', N'k@abc.com', N'Quận 1', N'123456789', CAST(N'2017-04-06' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (1, N'Coca Cola', 1, 14300, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (2, N'Pepsi', 1, 16000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (3, N'Trà xanh 0 độ', 1, 7500, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (4, N'Trà xanh C2', 1, 5600, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (5, N'7 Up', 1, 6300, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (6, N'Cam ép Twister', 1, 9000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (7, N'Sting', 1, 7800, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (8, N'Bò húc', 1, 11000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (9, N'Trà sữa trà xanh', 3, 25000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (10, N'Trà sữa trà đen', 3, 25000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (11, N'Trà sữa trà Olong', 3, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (12, N'Trà sữa khoai môn', 3, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (13, N'Trà sữa Socola', 3, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (14, N'Trà sữa bạc hà', 3, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (15, N'Trà sữa tươi', 3, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (16, N'Trà sữa khoai môn tươi', 3, 35000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (17, N'Trà sữa quan âm', 3, 35000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (18, N'Trà xanh', 4, 20000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (19, N'Trà đen', 4, 20000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (20, N'Trà Olong', 4, 20000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (21, N'Trà xoài', 4, 22000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (22, N'Trà quan âm', 4, 26000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (23, N'Trà xanh kem sữa', 5, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (24, N'Trà đen kem sữa', 5, 28000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (25, N'Trà Olong kem sữa', 5, 30000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (26, N'Trà xoài kem sữa', 5, 32000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (27, N'Trà quan âm kem sữa', 5, 34000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (28, N'Cà phê đen', 2, 18000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (30, N'Cà phê kem tươi', 2, 60000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (31, N'Cà phê kem lạnh', 2, 68000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (33, N'Cà phê kem tươi sữa tươi', 2, 65000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (34, N'Cà phê kem lạnh sữa tươi', 2, 72000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (37, N'Cà phê cabochino', 2, 60000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (38, N'Cà phê kem sữa lạnh', 2, 68000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (40, N'Cà phê sữa', 2, 20000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (48, N'Cà phê thơm', 2, 30000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (49, N'Cà phê vú sữa', 2, 40000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (50, N'Trà kim cương', 5, 45000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (51, N'Trà vàng', 5, 44000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (52, N'Trà bạc', 5, 43000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (53, N'Trà đồng', 5, 42000, NULL)
INSERT [dbo].[Product] ([ProductID], [ProductName], [CategoryID], [Price], [Description]) VALUES (54, N'Trà sắc', 5, 41000, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName], [Description]) VALUES (1, N'Quản lý', N'Quản lý chính của cửa hàng')
INSERT [dbo].[Role] ([RoleID], [RoleName], [Description]) VALUES (2, N'Nhân viên', N'NhânNhân viên phụ vụ')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (27, N'Bàn 1', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (28, N'Bàn 2', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (29, N'Bàn 3', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (30, N'Bàn 4', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (31, N'Bàn 5', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (32, N'Bàn 6', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (33, N'Bàn 7', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (34, N'Bàn 8', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (35, N'Bàn 9', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (36, N'Bàn 10', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (37, N'Bàn 11', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (38, N'Bàn 12', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (39, N'Bàn 13', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (40, N'Bàn 14', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (41, N'Bàn 15', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (42, N'Bàn 16', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (43, N'Bàn 17', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (44, N'Bàn 18', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (45, N'Bàn 19', 0)
INSERT [dbo].[Table] ([TableID], [TableName], [Status]) VALUES (46, N'Bàn 20', 0)
SET IDENTITY_INSERT [dbo].[Table] OFF
ALTER TABLE [dbo].[Authorization]  WITH CHECK ADD  CONSTRAINT [FK_Authorization_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Authorization] CHECK CONSTRAINT [FK_Authorization_Role]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([TableID])
REFERENCES [dbo].[Table] ([TableID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [QLQuanCaFe] SET  READ_WRITE 
GO
