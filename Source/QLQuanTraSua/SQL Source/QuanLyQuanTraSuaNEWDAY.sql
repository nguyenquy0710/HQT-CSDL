USE [HQTDB]
GO
/****** Object:  Table [dbo].[FrmView]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FrmView](
	[NameFrm] [nvarchar](50) NOT NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_FormView] PRIMARY KEY CLUSTERED 
(
	[NameFrm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HinhAnh]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnh](
	[IdImg] [int] IDENTITY(1,1) NOT NULL,
	[NameImg] [nvarchar](50) NOT NULL,
	[TittleImg] [nvarchar](50) NULL,
	[AltImg] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[IdImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IdKhach] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](50) NOT NULL,
	[DiaChiKH] [ntext] NULL,
	[PhoneKH] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IdKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LsGia]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LsGia](
	[MaSP] [nchar](5) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdGia] [int] NOT NULL,
	[NgayDat] [date] NOT NULL,
	[Gia] [int] NOT NULL,
	[HieuLuc] [bit] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[IdGia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[IdUser] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[HoNV] [nvarchar](20) NOT NULL,
	[TenNV] [nvarchar](20) NOT NULL,
	[CMNDNV] [nvarchar](10) NOT NULL,
	[DiaChiNV] [ntext] NOT NULL,
	[PhoneNV] [nvarchar](20) NOT NULL,
	[EmailNV] [nvarchar](50) NULL,
	[IdRole] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdKhach] [int] NOT NULL,
	[NgayTao] [date] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[IdOrder] [int] NOT NULL,
	[MaSP] [nchar](5) NOT NULL,
	[SoLuong] [int] NOT NULL,
 CONSTRAINT [PK_Order_Detail] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[IdRole] [int] NOT NULL,
	[NameFrm] [nvarchar](50) NOT NULL,
	[ChkView] [bit] NOT NULL,
	[ChkUpdate] [bit] NOT NULL,
	[ChkEdit] [bit] NOT NULL,
	[ChkDelete] [bit] NOT NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC,
	[NameFrm] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relation_NhanVien_Img]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_NhanVien_Img](
	[IdUser] [int] NOT NULL,
	[IdImg] [int] NOT NULL,
 CONSTRAINT [PK_Relation_NhanVien_Img] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC,
	[IdImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Relation_SP_Img]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_SP_Img](
	[MaSP] [nchar](5) NOT NULL,
	[IdImg] [int] NOT NULL,
 CONSTRAINT [PK_Relation_SP_Img] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[IdImg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](50) NOT NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 9/3/2017 12:47:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nchar](5) NOT NULL,
	[TenSP] [nvarchar](50) NOT NULL,
	[Description] [ntext] NULL,
	[StatusSP] [bit] NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[FrmView] ([NameFrm], [Description]) VALUES (N'frmQuanLy', N'frm Quan Ly')
INSERT [dbo].[NhanVien] ([IdUser], [Username], [Password], [HoNV], [TenNV], [CMNDNV], [DiaChiNV], [PhoneNV], [EmailNV], [IdRole], [Status]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'', N'Admintrator', N'261454130', N'Đường TCH 18, Quận 12', N'01203119422', N'kyniem.sinhvien.it@gmail.com', 1, 1)
INSERT [dbo].[PhanQuyen] ([IdRole], [NameFrm], [ChkView], [ChkUpdate], [ChkEdit], [ChkDelete]) VALUES (1, N'frmQuanLy', 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole], [Description]) VALUES (1, N'Admintratior', N'Người chủ cửa hàng')
INSERT [dbo].[Role] ([IdRole], [NameRole], [Description]) VALUES (2, N'Quản lý chi nhánh', NULL)
INSERT [dbo].[Role] ([IdRole], [NameRole], [Description]) VALUES (3, N'Nhân viên chi nhánh', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
ALTER TABLE [dbo].[LsGia]  WITH CHECK ADD  CONSTRAINT [FK_LsGia_NhanVien] FOREIGN KEY([IdUser])
REFERENCES [dbo].[NhanVien] ([IdUser])
GO
ALTER TABLE [dbo].[LsGia] CHECK CONSTRAINT [FK_LsGia_NhanVien]
GO
ALTER TABLE [dbo].[LsGia]  WITH CHECK ADD  CONSTRAINT [FK_LsGia_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[LsGia] CHECK CONSTRAINT [FK_LsGia_SanPham]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Role]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_KhachHang] FOREIGN KEY([IdKhach])
REFERENCES [dbo].[KhachHang] ([IdKhach])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_KhachHang]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_NhanVien] FOREIGN KEY([IdUser])
REFERENCES [dbo].[NhanVien] ([IdUser])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_NhanVien]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_Order] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([IdOrder])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_Order]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Detail_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Detail_SanPham]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_FormView] FOREIGN KEY([NameFrm])
REFERENCES [dbo].[FrmView] ([NameFrm])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_FormView]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_Role]
GO
ALTER TABLE [dbo].[Relation_NhanVien_Img]  WITH CHECK ADD  CONSTRAINT [FK_Relation_NhanVien_Img_Image] FOREIGN KEY([IdImg])
REFERENCES [dbo].[HinhAnh] ([IdImg])
GO
ALTER TABLE [dbo].[Relation_NhanVien_Img] CHECK CONSTRAINT [FK_Relation_NhanVien_Img_Image]
GO
ALTER TABLE [dbo].[Relation_NhanVien_Img]  WITH CHECK ADD  CONSTRAINT [FK_Relation_NhanVien_Img_NhanVien] FOREIGN KEY([IdUser])
REFERENCES [dbo].[NhanVien] ([IdUser])
GO
ALTER TABLE [dbo].[Relation_NhanVien_Img] CHECK CONSTRAINT [FK_Relation_NhanVien_Img_NhanVien]
GO
ALTER TABLE [dbo].[Relation_SP_Img]  WITH CHECK ADD  CONSTRAINT [FK_Relation_SP_Img_Image] FOREIGN KEY([IdImg])
REFERENCES [dbo].[HinhAnh] ([IdImg])
GO
ALTER TABLE [dbo].[Relation_SP_Img] CHECK CONSTRAINT [FK_Relation_SP_Img_Image]
GO
ALTER TABLE [dbo].[Relation_SP_Img]  WITH CHECK ADD  CONSTRAINT [FK_Relation_SP_Img_SanPham] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[Relation_SP_Img] CHECK CONSTRAINT [FK_Relation_SP_Img_SanPham]
GO
