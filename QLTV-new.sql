USE [master]
GO
/****** Object:  Database [Quan_Ly_Thu_Vien]    Script Date: 13-Apr-23 4:49:21 PM ******/
CREATE DATABASE [Quan_Ly_Thu_Vien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Quan_Ly_Thu_Vien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Quan_Ly_Thu_Vien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Quan_Ly_Thu_Vien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Quan_Ly_Thu_Vien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Quan_Ly_Thu_Vien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ARITHABORT OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET  MULTI_USER 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET QUERY_STORE = OFF
GO
USE [Quan_Ly_Thu_Vien]
GO
/****** Object:  Table [dbo].[BAOCAO]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOCAO](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tieude] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[MaNhanVien] [char](5) NULL,
	[NgayLapBaoCao] [date] NULL,
 CONSTRAINT [PK_BAOCAO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOITHUONG]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOITHUONG](
	[MaHV] [char](5) NOT NULL,
	[MaSach] [char](5) NOT NULL,
	[GiaTien] [float] NULL,
	[TinhTrang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHV] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHITIETPHIEUMUON]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUMUON](
	[MaPhieu] [char](5) NOT NULL,
	[MaSach] [char](5) NOT NULL,
	[NgayLapPhieu] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucNang]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucNang](
	[MaChucNang] [nvarchar](20) NOT NULL,
	[TenChucNang] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DAUSACH]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DAUSACH](
	[MaDS] [char](6) NOT NULL,
	[TenSach] [nvarchar](50) NOT NULL,
	[Theloai] [nvarchar](30) NULL,
	[NXB] [char](5) NOT NULL,
	[NgayXuatBan] [date] NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOIVIEN]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOIVIEN](
	[MaHV] [char](5) NOT NULL,
	[TenHV] [nvarchar](30) NOT NULL,
	[SDT] [varchar](12) NOT NULL,
	[NgayLapThe] [date] NOT NULL,
	[NgayHetHan] [date] NOT NULL,
	[TinhTrang] [nvarchar](20) NOT NULL,
	[DangMuon] [int] NOT NULL,
	[TrangThai] [int] NULL,
 CONSTRAINT [PK__HOIVIEN__2725A6D2E08BB789] PRIMARY KEY CLUSTERED 
(
	[MaHV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [char](5) NOT NULL,
	[TenNV] [nchar](30) NOT NULL,
	[ChucVu] [nvarchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[MatKhau] [char](16) NOT NULL,
	[ImageAva] [nvarchar](max) NULL,
 CONSTRAINT [PK__NHANVIEN__2725D70ACB61F521] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[NXB] [char](5) NOT NULL,
	[TenNXB] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaNhanVien] [char](5) NOT NULL,
	[MaChucNang] [nvarchar](20) NOT NULL,
	[GhiChu] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC,
	[MaChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUMUONSACH]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUONSACH](
	[MaPhieu] [char](5) NOT NULL,
	[MaHV] [char](5) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayTra] [date] NULL,
	[ThoiHan] [date] NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [char](5) NOT NULL,
	[TinhTrang] [int] NOT NULL,
	[MaDS] [char](6) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSOQUYDINH]    Script Date: 13-Apr-23 4:49:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSOQUYDINH](
	[MaTS] [char](5) NOT NULL,
	[GiaTri] [int] NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BAOCAO] ON 

INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (3, N'Báo cáo 1505', N'<p>test123 456 8</p>
', N'NV01 ', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (5, N'Báo cáo 100', N'<p>123 456 789&nbsp;</p>
', N'NV01 ', CAST(N'2023-04-06' AS Date))
INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (6, N'Báo cáo 1', N'<p>hello</p>
', N'NV007', CAST(N'2023-04-07' AS Date))
INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (7, N'Báo cáo 100', N'<p>123</p>
', N'NV007', CAST(N'2023-04-12' AS Date))
SET IDENTITY_INSERT [dbo].[BAOCAO] OFF
GO
INSERT [dbo].[BOITHUONG] ([MaHV], [MaSach], [GiaTien], [TinhTrang]) VALUES (N'HVS01', N'SVH01', 500003, 2)
GO
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM001', N'SSS05', CAST(N'2023-03-24' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM002', N'SVH03', CAST(N'2023-03-01' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM003', N'SSS05', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM003', N'STL01', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM004', N'SVH04', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM005', N'STL01', CAST(N'2023-04-22' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM006', N'SVH03', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM008', N'STL01', CAST(N'2023-03-17' AS Date))
GO
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN01', N'Thủ thư')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN02', N'Nhân viên hổ trợ')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN03', N'Nhân viên quản lý')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN04', N'Quản trị web')
GO
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSA001', N'She-Hulk', N'Truyện', N'NXB01', CAST(N'0001-01-01' AS Date), NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSA002', N'Lập trình web nâng cao', N'Lập trình', N'NXB05', CAST(N'2023-03-29' AS Date), N'ok')
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSA003', N'Tâm lý học hành vi', N'Kỹ năng sống', N'NXB01', CAST(N'2022-01-02' AS Date), NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSA333', N'Hành trình về phương Bắc', N'Truyện ngắn', N'NXB01', CAST(N'2023-03-06' AS Date), N'test 55')
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSB002', N'Ông già và biển cả', N'Văn học Nước ngoài', N'NXB01', CAST(N'2017-08-03' AS Date), NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSD003', N'Đắc Nhân Tâm', N'Kỹ năng sống', N'NXB01', CAST(N'2020-03-02' AS Date), NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu]) VALUES (N'DSF001', N'Vật Lý Lượng Tử', N'Giáo dục', N'NXB01', CAST(N'2023-01-29' AS Date), N'Vật Lý Lượng Tử')
GO
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVP01', N'Nguyễn Tấn Khoa', N'091 223 6808', CAST(N'2022-09-15' AS Date), CAST(N'2022-07-19' AS Date), N'Không sử dụng', 0, 2)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS01', N'Nguyễn Hồng Ân', N'012 345 6789', CAST(N'2022-10-10' AS Date), CAST(N'2023-04-04' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS02', N'Nguyễn Anh Duy', N'098 765 1234', CAST(N'2022-10-14' AS Date), CAST(N'2023-02-02' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS03', N'Nguyễn Anh Thành', N'038 185 265', CAST(N'0001-01-01' AS Date), CAST(N'2023-03-30' AS Date), N'Sử dụng được', 1, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS04', N'Đinh Hoàng Minh Thuận', N'07081234565', CAST(N'2023-03-14' AS Date), CAST(N'2023-05-14' AS Date), N'Sử dụng được', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS05', N'Lê Gia Bảo', N'07081234523', CAST(N'0001-01-01' AS Date), CAST(N'2023-03-08' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS06', N'Lương Gia huy', N'07081234565', CAST(N'2023-03-16' AS Date), CAST(N'2023-03-29' AS Date), N'Sử dụng được', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS07', N'Đặng Duy Thông ', N'0932330605', CAST(N'2023-03-06' AS Date), CAST(N'2023-03-30' AS Date), N'Sử dụng được', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS08', N'test doc gia', N'12345678910', CAST(N'2023-03-27' AS Date), CAST(N'2023-03-31' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS69', N'Thầy Giáo Ba', N'0932330605', CAST(N'2023-03-01' AS Date), CAST(N'2023-03-30' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS99', N'abc', N'0799987111', CAST(N'2023-03-02' AS Date), CAST(N'2023-03-29' AS Date), N'Sử dụng được', 0, NULL)
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV003', N'Nguyễn Anh Duy                ', N'Nhân viên hỗ trợ', N'nad149@gmail.com', N'nad1234x        ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV004', N'Nguyen ANh Thanh              ', N'Nhân viên quản lý', N'lva345@gmail.com', N'asd12345        ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV005', N'Đặng Duy Thông                ', N'Nhân viên hỗ trợ', N'pppqqqeee@gmail.com', N'123456          ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV006', N'Minh Thuận                    ', N'Thủ kho', N'barcalona@gmail.com', N'123456          ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV007', N'Hiệu Trưởng                   ', N'Hiệu trưởng', N'HieuTruong@gmail.com', N'123             ', N'CauBeXuMi.jpg')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV01 ', N'Duy Thông                     ', N'Thủ thư', N'ThuThu@gmail.com', N'123             ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV02 ', N'Anh Thành                     ', N'Nhân viên hỗ trợ', N'HoTro@gmail.com', N'123             ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV03 ', N'Minh Thuận                    ', N'Nhân viên quản lý', N'QuanLy@gmail.com', N'123             ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV04 ', N'Anh Duy                       ', N'Quản trị web', N'Admin@gmail.com', N'123             ', NULL)
GO
INSERT [dbo].[NhaXuatBan] ([NXB], [TenNXB]) VALUES (N'NXB01', N'Marvel')
INSERT [dbo].[NhaXuatBan] ([NXB], [TenNXB]) VALUES (N'NXB02', N'Kim Đồng')
INSERT [dbo].[NhaXuatBan] ([NXB], [TenNXB]) VALUES (N'NXB03', N'Văn Học')
INSERT [dbo].[NhaXuatBan] ([NXB], [TenNXB]) VALUES (N'NXB04', N'Văn Hóa Thông Tin')
INSERT [dbo].[NhaXuatBan] ([NXB], [TenNXB]) VALUES (N'NXB05', N'Hà Nội')
GO
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV007', N'CN01', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV007', N'CN02', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV007', N'CN03', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV007', N'CN04', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV01 ', N'CN01', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV02 ', N'CN02', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV03 ', N'CN03', NULL)
INSERT [dbo].[PhanQuyen] ([MaNhanVien], [MaChucNang], [GhiChu]) VALUES (N'NV04 ', N'CN04', NULL)
GO
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM001', N'HVS02', CAST(N'2023-03-24' AS Date), CAST(N'2023-04-25' AS Date), CAST(N'2023-04-07' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM002', N'HVS01', CAST(N'2023-03-01' AS Date), CAST(N'2023-04-12' AS Date), CAST(N'2023-03-15' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM003', N'HVS01', CAST(N'2023-03-14' AS Date), CAST(N'2023-03-22' AS Date), CAST(N'2023-03-28' AS Date), 2)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM004', N'HVS07', CAST(N'2023-03-14' AS Date), CAST(N'2023-03-30' AS Date), CAST(N'2023-03-28' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM005', N'HVS03', CAST(N'2023-04-22' AS Date), NULL, CAST(N'2023-05-06' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM006', N'HVS07', CAST(N'2023-04-05' AS Date), CAST(N'2023-04-07' AS Date), CAST(N'2023-04-19' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM008', N'HVS02', CAST(N'2023-03-17' AS Date), CAST(N'2023-03-08' AS Date), CAST(N'2023-03-31' AS Date), 1)
GO
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SSS05', 3, N'DSA333', N'test5')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'STL01', 2, N'DSA003', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SVH01', 1, N'DSF001', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SVH02', 1, N'DSA003', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SVH03', 3, N'DSA002', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SVH04', 1, N'DSB002', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [GhiChu]) VALUES (N'SVH05', 1, N'DSA001', NULL)
GO
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS001', 18, N'Tuổi tối thiểu của khách hàng')
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS002', 55, N'Tuổi tối đa của khách hàng')
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS003', 10, N'Số năm tối đa xuất bản trước đó')
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS004', 5, N'Số sách mượn tối đa')
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS005', 14, N'Số ngày mượn tối đa')
INSERT [dbo].[THAMSOQUYDINH] ([MaTS], [GiaTri], [GhiChu]) VALUES (N'TS006', 10000, N'Đơn giá phạt trả sách trễ hạn 1 ngày')
GO
ALTER TABLE [dbo].[BAOCAO]  WITH CHECK ADD  CONSTRAINT [FK_BAOCAO_NHANVIEN] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[BAOCAO] CHECK CONSTRAINT [FK_BAOCAO_NHANVIEN]
GO
ALTER TABLE [dbo].[BOITHUONG]  WITH CHECK ADD  CONSTRAINT [FK_BOITHUONG_HOIVIEN] FOREIGN KEY([MaHV])
REFERENCES [dbo].[HOIVIEN] ([MaHV])
GO
ALTER TABLE [dbo].[BOITHUONG] CHECK CONSTRAINT [FK_BOITHUONG_HOIVIEN]
GO
ALTER TABLE [dbo].[BOITHUONG]  WITH CHECK ADD  CONSTRAINT [FK_BOITHUONG_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[BOITHUONG] CHECK CONSTRAINT [FK_BOITHUONG_SACH]
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUMUON_CHITIETPHIEUMUON1] FOREIGN KEY([MaPhieu])
REFERENCES [dbo].[PHIEUMUONSACH] ([MaPhieu])
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_CHITIETPHIEUMUON1]
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUMUON_SACH] FOREIGN KEY([MaSach])
REFERENCES [dbo].[SACH] ([MaSach])
GO
ALTER TABLE [dbo].[CHITIETPHIEUMUON] CHECK CONSTRAINT [FK_CHITIETPHIEUMUON_SACH]
GO
ALTER TABLE [dbo].[DAUSACH]  WITH CHECK ADD  CONSTRAINT [FK_DAUSACH] FOREIGN KEY([NXB])
REFERENCES [dbo].[NhaXuatBan] ([NXB])
GO
ALTER TABLE [dbo].[DAUSACH] CHECK CONSTRAINT [FK_DAUSACH]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_ChucNang] FOREIGN KEY([MaChucNang])
REFERENCES [dbo].[ChucNang] ([MaChucNang])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_ChucNang]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_NHANVIEN] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUMUONSACH]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUONSACH] FOREIGN KEY([MaHV])
REFERENCES [dbo].[HOIVIEN] ([MaHV])
GO
ALTER TABLE [dbo].[PHIEUMUONSACH] CHECK CONSTRAINT [FK_PHIEUMUONSACH]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_SACH] FOREIGN KEY([MaDS])
REFERENCES [dbo].[DAUSACH] ([MaDS])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_SACH]
GO
/****** Object:  StoredProcedure [dbo].[CapNhatTinhTrangSach]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[CapNhatTinhTrangSach] @maphieu char(5), @masach char(5)
AS BEGIN
	set Nocount on

	if exists(Select NgayTra from PHIEUMUONSACH where NgayTra is null and  MaPhieu = @maphieu)
		BEGIN
			UPDATE SACH set TinhTrang = 2 where MaSach = @masach 					
		END
	else if exists (select ThoiHan From PHIEUMUONSACH where NgayTra > ThoiHan and MaPhieu = @maphieu)
		BEGIN
			UPDATE SACH set TinhTrang = 3 where MaSach = @masach
		END
	else 
		BEGIN
			UPDATE SACH set TinhTrang = 1 where MaSach = @masach
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BaoCao]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_BaoCao] @MABC char(5), @TENBC nvarchar(50), @Ngay date, @MANV char(5)
as
	begin
		insert into BAOCAO values
		(@MABC,@TENBC,@Ngay,@MANV)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSoLuongSachHoiVienMuon]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[sp_CapNhatSoLuongSachHoiVienMuon] @mahv char(5)
AS BEGIN
	SET NOCOUNT ON;

	Declare @tongsoluong int
	Select  @tongsoluong = sum(SoLuong)  From PHIEUMUONSACH where MaHV=@mahv and NgayTra is null
	if(@tongsoluong is null)
		BEGIN
			set @tongsoluong = 0;
		END
	UPDATE HOIVIEN set DangMuon = @tongsoluong where MaHV = @mahv
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangSach]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[sp_CapNhatTinhTrangSach] @maphieu char(5), @masach char(5)
AS BEGIN
	set nocount on
	if exists (Select * From PHIEUMUONSACH where NgayTra is null and MaPhieu = @maphieu)
		BEGIN
			UPDATE SACH set TinhTrang = 2 where MaSach = @masach
		END
	else
		BEGIN
			UPDATE SACH set TinhTrang = 1 where MaSach = @masach
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangTheHoiVien]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   proc [dbo].[sp_CapNhatTinhTrangTheHoiVien] @mahoivien char(5)
AS BEGIN
	set nocount on;
	declare @ngaylapthe date, @ngayhethan date, @trangthai int
	select @ngaylapthe = NgayLapThe, @ngayhethan = NgayHetHan , @trangthai = TrangThai From HOIVIEN Where MaHV = @mahoivien

	if exists (select MaHV From BOITHUONG where MaHV = @mahoivien and TinhTrang = 1)
		BEGIN
			Update HOIVIEN set TinhTrang = N'Không sử dụng' where MaHV = @mahoivien
		END
	else if( @trangthai = 1 or GETDATE() > @ngayhethan )
		BEGIN
			Update HOIVIEN set TinhTrang = N'Không sử dụng' where MaHV = @mahoivien
		END
	else
		BEGIN
			update HOIVIEN set TinhTrang = N'Sử dụng được' where MaHV = @mahoivien
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThu]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DoanhThu]  @Ngay date, @KhoanTG nvarchar(10),@TongTien int
as
	begin
		insert into DOANHTHU values
		(@Ngay,@KhoanTG,@TongTien)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_DSBaoCao]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DSBaoCao] 
as
	select * from BAOCAO
GO
/****** Object:  StoredProcedure [dbo].[sp_DSPhongHopTheoTinhTrang]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DSPhongHopTheoTinhTrang] @TinhTrang int
as
	select * from PHONGHOP where @TinhTrang=TinhTrang
GO
/****** Object:  StoredProcedure [dbo].[sp_GiaHan]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GiaHan]  @MAPHIEU char(5), @SoNgay int, @ThoiHan date
as
	begin
		insert into GIAHAN values
		(@MAPHIEU, @SoNgay, @ThoiHan)
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinNhanVien]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayThongTinNhanVien] 
as
	select * from NHANVIEN
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 13-Apr-23 4:49:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemNhanVien] @MANV char(5), @TenNV char(30), @CHUCVU nvarchar(30), @Email varchar(30), @Matkhau char(8)
as
	begin
		insert into NHANVIEN values
		(@MANV,@TenNV,@CHUCVU,@Email,@Matkhau)
	end
GO
USE [master]
GO
ALTER DATABASE [Quan_Ly_Thu_Vien] SET  READ_WRITE 
GO


CREATE OR ALTER TRIGGER MUONSACH_TR
ON PHIEUMUONSACH
INSTEAD OF UPDATE
AS
BEGIN
    IF EXISTS (SELECT * FROM INSERTED WHERE SOLUONG > 3)
    BEGIN
        RAISERROR('Error: Không được mượn quá 3 cuốn...', 16, 1);
        ROLLBACK TRANSACTION; -- Optionally, you can roll back the transaction if needed
        RETURN;
    END;
END;

-- Create roles
CREATE ROLE HIEUTRUONG;
CREATE ROLE THUTHU;
CREATE ROLE NHANVIENQUANLY;
CREATE ROLE NHANVIENHOTRO;
CREATE ROLE QUANTRIWEB;

-- Grant permissions to roles

-- HIEUTRUONG
GRANT CONNECT SQL TO HIEUTRUONG;
GRANT CREATE PROCEDURE TO HIEUTRUONG;
GRANT CREATE TABLE TO HIEUTRUONG;
GRANT CREATE VIEW TO HIEUTRUONG;
GRANT EXECUTE TO HIEUTRUONG;
GRANT VIEW DEFINITION TO HIEUTRUONG;

-- THUTHU
GRANT CONNECT SQL TO THUTHU;
GRANT SELECT ON QLTV.NHAXUATBAN TO THUTHU;
GRANT SELECT ON QLTV.DAUSACH TO THUTHU;
GRANT SELECT ON QLTV.SACH TO THUTHU;
GRANT SELECT ON QLTV.BAOCAO TO THUTHU;
GRANT SELECT ON QLTV.NHANVIEN TO THUTHU;
GRANT EXECUTE ON QLTV.DAUSACH TO THUTHU;
GRANT EXECUTE ON QLTV.SACH TO THUTHU;
GRANT EXECUTE ON QLTV.BAOCAO TO THUTHU;
GRANT UPDATE ON QLTV.NHANVIEN TO THUTHU;

-- NHANVIENQUANLY
GRANT CONNECT SQL TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.DAUSACH TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.SACH TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.PHIEUMUONSACH TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.CHITIETPHIEUMUON TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.BAOCAO TO NHANVIENQUANLY;
GRANT SELECT ON QLTV.NHANVIEN TO NHANVIENQUANLY;
GRANT EXECUTE ON QLTV.CHITIETPHIEUMUON TO NHANVIENQUANLY;
GRANT EXECUTE ON QLTV.PHIEUMUONSACH TO NHANVIENQUANLY;
GRANT EXECUTE ON QLTV.BAOCAO TO NHANVIENQUANLY;
GRANT UPDATE ON QLTV.NHANVIEN TO NHANVIENQUANLY;

-- NHANVIENHOTRO
GRANT CONNECT SQL TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.DAUSACH TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.SACH TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.HOIVIEN TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.BOITHUONG TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.BAOCAO TO NHANVIENHOTRO;
GRANT SELECT ON QLTV.NHANVIEN TO NHANVIENHOTRO;
GRANT EXECUTE ON QLTV.HOIVIEN TO NHANVIENHOTRO;
GRANT EXECUTE ON QLTV.BOITHUONG TO NHANVIENHOTRO;
GRANT EXECUTE ON QLTV.BAOCAO TO NHANVIENHOTRO;
GRANT UPDATE ON QLTV.NHANVIEN TO NHANVIENHOTRO;

-- QUANTRIWEB
GRANT CONNECT SQL TO QUANTRIWEB;
GRANT SELECT ON QLTV.NHAXUATBAN TO QUANTRIWEB;
GRANT SELECT ON QLTV.BAOCAO TO QUANTRIWEB;
GRANT SELECT ON QLTV.NHANVIEN TO QUANTRIWEB;
GRANT SELECT ON QLTV.PHANQUYEN TO QUANTRIWEB;
GRANT SELECT ON QLTV.CHUCNANG TO QUANTRIWEB;
GRANT SELECT ON QLTV.THAMSOQUYDINH TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.NHAXUATBAN TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.BAOCAO TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.NHANVIEN TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.PHANQUYEN TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.CHUCNANG TO QUANTRIWEB;
GRANT EXECUTE ON QLTV.THAMSOQUYDINH TO QUANTRIWEB;
