USE [master]
GO
/****** Object:  Database [Quan_Ly_Thu_Vien]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  DatabaseRole [THUTHU]    Script Date: 09-Jun-23 6:05:47 PM ******/
CREATE ROLE [THUTHU]
GO
/****** Object:  DatabaseRole [QUANTRIWEB]    Script Date: 09-Jun-23 6:05:47 PM ******/
CREATE ROLE [QUANTRIWEB]
GO
/****** Object:  DatabaseRole [NHANVIENQUANLY]    Script Date: 09-Jun-23 6:05:47 PM ******/
CREATE ROLE [NHANVIENQUANLY]
GO
/****** Object:  DatabaseRole [NHANVIENHOTRO]    Script Date: 09-Jun-23 6:05:47 PM ******/
CREATE ROLE [NHANVIENHOTRO]
GO
/****** Object:  DatabaseRole [HIEUTRUONG]    Script Date: 09-Jun-23 6:05:47 PM ******/
CREATE ROLE [HIEUTRUONG]
GO
/****** Object:  Table [dbo].[BAOCAO]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[BOITHUONG]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[CHITIETPHIEUMUON]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[ChucNang]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[DAUSACH]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
	[SoLuong] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOIVIEN]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[MyTodo_List]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyTodo_List](
	[NgayTao] [datetime] NOT NULL,
	[MaNV] [char](5) NOT NULL,
	[MoTa] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_MyTodo_List] PRIMARY KEY CLUSTERED 
(
	[NgayTao] ASC,
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[PHIEUMUONSACH]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  Table [dbo].[SACH]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MaSach] [char](5) NOT NULL,
	[TinhTrang] [int] NOT NULL,
	[MaDS] [char](6) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK__SACH__B235742DEAEB92FF] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSOQUYDINH]    Script Date: 09-Jun-23 6:05:47 PM ******/
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

INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (7, N'Báo cáo 100', N'<p>123</p>
', N'NV007', CAST(N'2023-05-20' AS Date))
INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (8, N'Báo cáo 1500', N'<p>abc</p>
', N'NV007', CAST(N'2023-04-21' AS Date))
INSERT [dbo].[BAOCAO] ([Id], [Tieude], [Description], [MaNhanVien], [NgayLapBaoCao]) VALUES (10, N'Tình trạng sách', N'<p>S&aacute;ch A bị hư</p>
', N'NV03 ', CAST(N'2023-05-09' AS Date))
SET IDENTITY_INSERT [dbo].[BAOCAO] OFF
GO
INSERT [dbo].[BOITHUONG] ([MaHV], [MaSach], [GiaTien], [TinhTrang]) VALUES (N'HVS01', N'SVH01', 500003, 2)
GO
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM001', N'SSS05', CAST(N'2023-03-24' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM002', N'SVH03', CAST(N'2023-03-01' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM003', N'SSS05', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM003', N'STL01', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM004', N'SVH04', CAST(N'2023-03-14' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM005', N'STL01', CAST(N'2023-05-06' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM005', N'SVH02', CAST(N'2023-05-06' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM006', N'SVH03', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM007', N'SVH06', CAST(N'2023-04-28' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM008', N'STL01', CAST(N'2023-03-17' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM009', N'SVH09', CAST(N'2023-05-20' AS Date))
INSERT [dbo].[CHITIETPHIEUMUON] ([MaPhieu], [MaSach], [NgayLapPhieu]) VALUES (N'PM010', N'SVH10', CAST(N'2023-05-27' AS Date))
GO
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN01', N'Thủ thư')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN02', N'Nhân viên hổ trợ')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN03', N'Nhân viên quản lý')
INSERT [dbo].[ChucNang] ([MaChucNang], [TenChucNang]) VALUES (N'CN04', N'Quản trị web')
GO
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA001', N'Công nghệ phần mềm', N'IT', N'NXB05', CAST(N'2023-05-20' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA002', N'Lập trình web nâng cao', N'Lập trình', N'NXB05', CAST(N'2023-03-29' AS Date), N'ok', 5)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA003', N'Tâm lý học hành vi', N'Kỹ năng sống', N'NXB01', CAST(N'2022-01-02' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA004', N'Muôn kiếp nhân sinh', N'Triết học', N'NXB03', CAST(N'2023-04-28' AS Date), N'28/04', NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA005', N'Chủ nghĩa khắc kỷ', N'Triết học', N'NXB02', CAST(N'2023-04-28' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA006', N'She-Hulk 2222', N'Truyện', N'NXB01', CAST(N'2023-04-28' AS Date), NULL, 2)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA007', N'Cơ sở dữ liệu - nâng cao', N'IT', N'NXB04', CAST(N'2023-05-25' AS Date), NULL, 1)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA008', N'Lập trình web - NC', N'IT', N'NXB04', CAST(N'2023-06-05' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSA333', N'Hành trình về phương Bắc', N'Truyện ngắn', N'NXB01', CAST(N'2023-03-06' AS Date), N'test 55', NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSB002', N'Ông già và biển cả', N'Văn học Nước ngoài', N'NXB01', CAST(N'2017-08-03' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSD003', N'Đắc Nhân Tâm', N'Kỹ năng sống', N'NXB01', CAST(N'2020-03-02' AS Date), NULL, NULL)
INSERT [dbo].[DAUSACH] ([MaDS], [TenSach], [Theloai], [NXB], [NgayXuatBan], [GhiChu], [SoLuong]) VALUES (N'DSF001', N'Vật Lý Lượng Tử', N'Giáo dục', N'NXB01', CAST(N'2023-01-29' AS Date), N'Vật Lý Lượng Tử', NULL)
GO
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS01', N'Nguyễn Hồng Ân', N'0123456789', CAST(N'2022-10-10' AS Date), CAST(N'2023-04-04' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS02', N'Nguyễn Anh Duy', N'0987651234', CAST(N'2022-10-14' AS Date), CAST(N'2023-02-02' AS Date), N'Không sử dụng', 1, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS03', N'Nguyễn Tuấn Mẫn', N'0799987111', CAST(N'2023-05-20' AS Date), CAST(N'2027-05-20' AS Date), N'Không sử dụng', 1, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS04', N'Đinh Hoàng Minh Thuận', N'07081234565', CAST(N'2023-03-14' AS Date), CAST(N'2023-05-14' AS Date), N'Không sử dụng', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS05', N'test doc gia 123', N'0799987111', CAST(N'2023-05-25' AS Date), CAST(N'2027-05-25' AS Date), N'Không sử dụng', 1, 2)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS07', N'Đặng Duy Thông ', N'0932330605', CAST(N'2023-03-06' AS Date), CAST(N'2023-03-30' AS Date), N'Sử dụng được', 0, NULL)
INSERT [dbo].[HOIVIEN] ([MaHV], [TenHV], [SDT], [NgayLapThe], [NgayHetHan], [TinhTrang], [DangMuon], [TrangThai]) VALUES (N'HVS10', N'Phan Tấn Trung', N'0799987111', CAST(N'2023-04-28' AS Date), CAST(N'2027-04-28' AS Date), N'Không sử dụng', 1, NULL)
GO
INSERT [dbo].[MyTodo_List] ([NgayTao], [MaNV], [MoTa]) VALUES (CAST(N'2023-06-09T14:15:42.887' AS DateTime), N'NV007', N'Kiểm tra sách')
INSERT [dbo].[MyTodo_List] ([NgayTao], [MaNV], [MoTa]) VALUES (CAST(N'2023-06-09T14:22:10.893' AS DateTime), N'NV007', N'Kiểm tra độc giả')
GO
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV001', N'Minh Thành                    ', N'Nhân viên hỗ trợ', N'minhthanh@gmail.com', N'123             ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV003', N'Nguyễn Anh Duy                ', N'Nhân viên hỗ trợ', N'nad149@gmail.com', N'nad1234x        ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV004', N'Nguyen ANh Thanh              ', N'Nhân viên quản lý', N'lva345@gmail.com', N'asd12345        ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV005', N'Đặng Duy Thông                ', N'Nhân viên hỗ trợ', N'pppqqqeee@gmail.com', N'123456          ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV006', N'Minh Thuận                    ', N'Thủ kho', N'barcalona@gmail.com', N'123456          ', NULL)
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV007', N'Thành Thông Thuận Duy         ', N'Hiệu trưởng', N'HieuTruong@gmail.com', N'123             ', N'CauBeXuMi.jpg')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV01 ', N'Duy Thông                     ', N'Thủ thư', N'ThuThu@gmail.com', N'123             ', N'CauBeXuMi.jpg')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV02 ', N'Anh Thành                     ', N'Nhân viên hỗ trợ', N'HoTro@gmail.com', N'123             ', N'aavathanh.jpeg')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV03 ', N'Minh Thuận                    ', N'Nhân viên quản lý', N'QuanLy@gmail.com', N'123             ', N'avathuan.jpeg')
INSERT [dbo].[NHANVIEN] ([MaNV], [TenNV], [ChucVu], [Email], [MatKhau], [ImageAva]) VALUES (N'NV04 ', N'Anh Duy                       ', N'Quản trị web', N'Admin@gmail.com', N'123             ', N'avaduy.jpeg')
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
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM001', N'HVS02', CAST(N'2023-03-24' AS Date), NULL, CAST(N'2023-04-07' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM002', N'HVS01', CAST(N'2023-03-01' AS Date), CAST(N'2023-04-12' AS Date), CAST(N'2023-03-15' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM003', N'HVS01', CAST(N'2023-03-14' AS Date), CAST(N'2023-03-22' AS Date), CAST(N'2023-03-28' AS Date), 2)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM004', N'HVS07', CAST(N'2023-03-14' AS Date), CAST(N'2023-03-30' AS Date), CAST(N'2023-03-28' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM005', N'HVS07', CAST(N'2023-05-06' AS Date), CAST(N'2023-05-06' AS Date), CAST(N'2023-05-20' AS Date), 2)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM006', N'HVS07', CAST(N'2023-04-05' AS Date), CAST(N'2023-04-07' AS Date), CAST(N'2023-04-19' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM007', N'HVS10', CAST(N'2023-04-28' AS Date), NULL, CAST(N'2023-05-12' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM008', N'HVS02', CAST(N'2023-03-17' AS Date), CAST(N'2023-03-08' AS Date), CAST(N'2023-03-31' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM009', N'HVS03', CAST(N'2023-05-20' AS Date), NULL, CAST(N'2023-06-03' AS Date), 1)
INSERT [dbo].[PHIEUMUONSACH] ([MaPhieu], [MaHV], [NgayMuon], [NgayTra], [ThoiHan], [SoLuong]) VALUES (N'PM010', N'HVS05', CAST(N'2023-05-27' AS Date), NULL, CAST(N'2023-06-10' AS Date), 1)
GO
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SSS05', 2, N'DSA333', N'test5')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'STL01', 1, N'DSA003', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH01', 1, N'DSF001', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH02', 1, N'DSA003', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH03', 3, N'DSA002', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH04', 1, N'DSB002', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH06', 2, N'DSA004', N'aaaaa')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH07', 1, N'DSA005', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH09', 2, N'DSA006', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH10', 2, N'DSA007', NULL)
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH11', 1, N'DSA001', N'Sách dành cho khoa CNTT ')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH12', 1, N'DSA001', N'Sách dành cho khoa CNTT')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH13', 1, N'DSA002', N'Lộ trình học lập trình Web từ cơ bản đến nâng cao sẽ được CodeGym chia sẻ cực chi tiết và đơn giản trong bài viết dưới đây. Bài viết này không chỉ là nơi chia sẻ các kiến thức cho người mới mà còn là nơi giúp các Developer trau dồi thêm kiến thức. Từ đây mọi người có thể update năng lực, có được danh mục các công nghệ, kỹ năng cần học trong quá trình học và làm web.

Những lưu ý khi tự học lập trình Web
Lập trình web
Lập trình Website là công việc có nhiệm vụ nhận tất cả dữ liệu từ bộ phận thiết kế Web để chuyển thành một bộ máy Web hoàn chỉnh có tác động qua lại với CSDL và tương tác với người dùng dựa trên ngôn ngữ máy tính. Lập trình web bao gồm 2 mảng cơ bản là lập trình front-end và lập trình back-end. Muốn tiếp cận với lập trình web trước tiên bạn cần phân biệt được lập trình Web và thiết kế Web, tiếp theo là hiểu thế nào là front-end và back-end.

Thiết kế Web
Thiết kế web là công việc của một Web Designer, họ có nhiệm vụ tạo ra một giao diện website hoàn chỉnh, giao diện này có thể ở dạng Ảnh hoặc dạng Web Tĩnh HTML. Bạn cần phải lo về thiết kế, ý tưởng, layout, màu sắc của một trang web cơ bản. Làm sao để khách hàng bị ấn tượng khi họ hướng đến website của bạn.

Cả lập trình và thiết kế web sẽ có rất nhiều điểm tương đồng nên khá dễ nhầm lẫn, trên thực tế 2 công việc này là bộ đôi không thể tách rời nên chỉ trong một số trường hợp cụ thể, vai trò và công việc của Web Designer và Web Developer mới được thể hiện bài bản. Tuy nhiên ta có thể thấy rõ nhất ở một người lập trình viên Web đó là họ bắt buộc phải nắm chắc các kiến thức về lập trình web cũng như ngôn ngữ lập trình web (PHP, MySQL, .NET, SQL Server,…)

Lập trình Front-end
Hiểu đơn giản Front-end là tất cả những gì mà người dùng nhìn thấy khi họ truy cập vào website của bạn. Đồng nghĩa với việc bạn sẽ chịu trách nhiệm thiết kế và xây dựng giao diện cho các trang web hoặc ứng dụng web để người dùng có thể xem và tương tác trực tiếp trên đó. Nếu chọn hướng đi này bạn có thể học thêm các công nghệ: jQuery, CSS và các frameworks front – end, Các frameworks của JavaScript,..

Lập trình Back-end
Back-end liên quan nhiều đến cấu trúc bên trong như database và server. Bạn sẽ chịu trách nhiệm thiết kế và lập trình phần logic bên trong website để kết nối phần giao diện với cơ sở dữ liệu, giúp cho website sống động hơn. Tùy và sở thích cũng như năng khiếu mà bạn có thể lựa chọn 1 trong 2 hướng lập trình trên, còn đối với những ai có thể làm cả 2 thì sẽ được gọi là lập trình viên  Full Stack.')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH14', 1, N'DSA002', N'Lộ trình học lập trình Web từ cơ bản đến nâng cao sẽ được CodeGym chia sẻ cực chi tiết và đơn giản trong bài viết dưới đây. Bài viết này không chỉ là nơi chia sẻ các kiến thức cho người mới mà còn là nơi giúp các Developer trau dồi thêm kiến thức. Từ đây mọi người có thể update năng lực, có được danh mục các công nghệ, kỹ năng cần học trong quá trình học và làm web.

Những lưu ý khi tự học lập trình Web
Lập trình web
Lập trình Website là công việc có nhiệm vụ nhận tất cả dữ liệu từ bộ phận thiết kế Web để chuyển thành một bộ máy Web hoàn chỉnh có tác động qua lại với CSDL và tương tác với người dùng dựa trên ngôn ngữ máy tính. Lập trình web bao gồm 2 mảng cơ bản là lập trình front-end và lập trình back-end. Muốn tiếp cận với lập trình web trước tiên bạn cần phân biệt được lập trình Web và thiết kế Web, tiếp theo là hiểu thế nào là front-end và back-end.

Thiết kế Web
Thiết kế web là công việc của một Web Designer, họ có nhiệm vụ tạo ra một giao diện website hoàn chỉnh, giao diện này có thể ở dạng Ảnh hoặc dạng Web Tĩnh HTML. Bạn cần phải lo về thiết kế, ý tưởng, layout, màu sắc của một trang web cơ bản. Làm sao để khách hàng bị ấn tượng khi họ hướng đến website của bạn.

Cả lập trình và thiết kế web sẽ có rất nhiều điểm tương đồng nên khá dễ nhầm lẫn, trên thực tế 2 công việc này là bộ đôi không thể tách rời nên chỉ trong một số trường hợp cụ thể, vai trò và công việc của Web Designer và Web Developer mới được thể hiện bài bản. Tuy nhiên ta có thể thấy rõ nhất ở một người lập trình viên Web đó là họ bắt buộc phải nắm chắc các kiến thức về lập trình web cũng như ngôn ngữ lập trình web (PHP, MySQL, .NET, SQL Server,…)

Lập trình Front-end
Hiểu đơn giản Front-end là tất cả những gì mà người dùng nhìn thấy khi họ truy cập vào website của bạn. Đồng nghĩa với việc bạn sẽ chịu trách nhiệm thiết kế và xây dựng giao diện cho các trang web hoặc ứng dụng web để người dùng có thể xem và tương tác trực tiếp trên đó. Nếu chọn hướng đi này bạn có thể học thêm các công nghệ: jQuery, CSS và các frameworks front – end, Các frameworks của JavaScript,..

Lập trình Back-end
Back-end liên quan nhiều đến cấu trúc bên trong như database và server. Bạn sẽ chịu trách nhiệm thiết kế và lập trình phần logic bên trong website để kết nối phần giao diện với cơ sở dữ liệu, giúp cho website sống động hơn. Tùy và sở thích cũng như năng khiếu mà bạn có thể lựa chọn 1 trong 2 hướng lập trình trên, còn đối với những ai có thể làm cả 2 thì sẽ được gọi là lập trình viên  Full Stack.')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH15', 1, N'DSA002', N'Lộ trình học lập trình Web từ cơ bản đến nâng cao sẽ được CodeGym chia sẻ cực chi tiết và đơn giản trong bài viết dưới đây. Bài viết này không chỉ là nơi chia sẻ các kiến thức cho người mới mà còn là nơi giúp các Developer trau dồi thêm kiến thức. Từ đây mọi người có thể update năng lực, có được danh mục các công nghệ, kỹ năng cần học trong quá trình học và làm web.

Những lưu ý khi tự học lập trình Web
Lập trình web
Lập trình Website là công việc có nhiệm vụ nhận tất cả dữ liệu từ bộ phận thiết kế Web để chuyển thành một bộ máy Web hoàn chỉnh có tác động qua lại với CSDL và tương tác với người dùng dựa trên ngôn ngữ máy tính. Lập trình web bao gồm 2 mảng cơ bản là lập trình front-end và lập trình back-end. Muốn tiếp cận với lập trình web trước tiên bạn cần phân biệt được lập trình Web và thiết kế Web, tiếp theo là hiểu thế nào là front-end và back-end.

Thiết kế Web
Thiết kế web là công việc của một Web Designer, họ có nhiệm vụ tạo ra một giao diện website hoàn chỉnh, giao diện này có thể ở dạng Ảnh hoặc dạng Web Tĩnh HTML. Bạn cần phải lo về thiết kế, ý tưởng, layout, màu sắc của một trang web cơ bản. Làm sao để khách hàng bị ấn tượng khi họ hướng đến website của bạn.

Cả lập trình và thiết kế web sẽ có rất nhiều điểm tương đồng nên khá dễ nhầm lẫn, trên thực tế 2 công việc này là bộ đôi không thể tách rời nên chỉ trong một số trường hợp cụ thể, vai trò và công việc của Web Designer và Web Developer mới được thể hiện bài bản. Tuy nhiên ta có thể thấy rõ nhất ở một người lập trình viên Web đó là họ bắt buộc phải nắm chắc các kiến thức về lập trình web cũng như ngôn ngữ lập trình web (PHP, MySQL, .NET, SQL Server,…)

Lập trình Front-end
Hiểu đơn giản Front-end là tất cả những gì mà người dùng nhìn thấy khi họ truy cập vào website của bạn. Đồng nghĩa với việc bạn sẽ chịu trách nhiệm thiết kế và xây dựng giao diện cho các trang web hoặc ứng dụng web để người dùng có thể xem và tương tác trực tiếp trên đó. Nếu chọn hướng đi này bạn có thể học thêm các công nghệ: jQuery, CSS và các frameworks front – end, Các frameworks của JavaScript,..

Lập trình Back-end
Back-end liên quan nhiều đến cấu trúc bên trong như database và server. Bạn sẽ chịu trách nhiệm thiết kế và lập trình phần logic bên trong website để kết nối phần giao diện với cơ sở dữ liệu, giúp cho website sống động hơn. Tùy và sở thích cũng như năng khiếu mà bạn có thể lựa chọn 1 trong 2 hướng lập trình trên, còn đối với những ai có thể làm cả 2 thì sẽ được gọi là lập trình viên  Full Stack.')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH16', 1, N'DSA002', N'Lộ trình học lập trình Web từ cơ bản đến nâng cao sẽ được CodeGym chia sẻ cực chi tiết và đơn giản trong bài viết dưới đây. Bài viết này không chỉ là nơi chia sẻ các kiến thức cho người mới mà còn là nơi giúp các Developer trau dồi thêm kiến thức. Từ đây mọi người có thể update năng lực, có được danh mục các công nghệ, kỹ năng cần học trong quá trình học và làm web.

Những lưu ý khi tự học lập trình Web
Lập trình web
Lập trình Website là công việc có nhiệm vụ nhận tất cả dữ liệu từ bộ phận thiết kế Web để chuyển thành một bộ máy Web hoàn chỉnh có tác động qua lại với CSDL và tương tác với người dùng dựa trên ngôn ngữ máy tính. Lập trình web bao gồm 2 mảng cơ bản là lập trình front-end và lập trình back-end. Muốn tiếp cận với lập trình web trước tiên bạn cần phân biệt được lập trình Web và thiết kế Web, tiếp theo là hiểu thế nào là front-end và back-end.

Thiết kế Web
Thiết kế web là công việc của một Web Designer, họ có nhiệm vụ tạo ra một giao diện website hoàn chỉnh, giao diện này có thể ở dạng Ảnh hoặc dạng Web Tĩnh HTML. Bạn cần phải lo về thiết kế, ý tưởng, layout, màu sắc của một trang web cơ bản. Làm sao để khách hàng bị ấn tượng khi họ hướng đến website của bạn.

Cả lập trình và thiết kế web sẽ có rất nhiều điểm tương đồng nên khá dễ nhầm lẫn, trên thực tế 2 công việc này là bộ đôi không thể tách rời nên chỉ trong một số trường hợp cụ thể, vai trò và công việc của Web Designer và Web Developer mới được thể hiện bài bản. Tuy nhiên ta có thể thấy rõ nhất ở một người lập trình viên Web đó là họ bắt buộc phải nắm chắc các kiến thức về lập trình web cũng như ngôn ngữ lập trình web (PHP, MySQL, .NET, SQL Server,…)

Lập trình Front-end
Hiểu đơn giản Front-end là tất cả những gì mà người dùng nhìn thấy khi họ truy cập vào website của bạn. Đồng nghĩa với việc bạn sẽ chịu trách nhiệm thiết kế và xây dựng giao diện cho các trang web hoặc ứng dụng web để người dùng có thể xem và tương tác trực tiếp trên đó. Nếu chọn hướng đi này bạn có thể học thêm các công nghệ: jQuery, CSS và các frameworks front – end, Các frameworks của JavaScript,..

Lập trình Back-end
Back-end liên quan nhiều đến cấu trúc bên trong như database và server. Bạn sẽ chịu trách nhiệm thiết kế và lập trình phần logic bên trong website để kết nối phần giao diện với cơ sở dữ liệu, giúp cho website sống động hơn. Tùy và sở thích cũng như năng khiếu mà bạn có thể lựa chọn 1 trong 2 hướng lập trình trên, còn đối với những ai có thể làm cả 2 thì sẽ được gọi là lập trình viên  Full Stack.')
INSERT [dbo].[SACH] ([MaSach], [TinhTrang], [MaDS], [MoTa]) VALUES (N'SVH17', 1, N'DSA002', N'Lộ trình học lập trình Web từ cơ bản đến nâng cao sẽ được CodeGym chia sẻ cực chi tiết và đơn giản trong bài viết dưới đây. Bài viết này không chỉ là nơi chia sẻ các kiến thức cho người mới mà còn là nơi giúp các Developer trau dồi thêm kiến thức. Từ đây mọi người có thể update năng lực, có được danh mục các công nghệ, kỹ năng cần học trong quá trình học và làm web.

Những lưu ý khi tự học lập trình Web
Lập trình web
Lập trình Website là công việc có nhiệm vụ nhận tất cả dữ liệu từ bộ phận thiết kế Web để chuyển thành một bộ máy Web hoàn chỉnh có tác động qua lại với CSDL và tương tác với người dùng dựa trên ngôn ngữ máy tính. Lập trình web bao gồm 2 mảng cơ bản là lập trình front-end và lập trình back-end. Muốn tiếp cận với lập trình web trước tiên bạn cần phân biệt được lập trình Web và thiết kế Web, tiếp theo là hiểu thế nào là front-end và back-end.

Thiết kế Web
Thiết kế web là công việc của một Web Designer, họ có nhiệm vụ tạo ra một giao diện website hoàn chỉnh, giao diện này có thể ở dạng Ảnh hoặc dạng Web Tĩnh HTML. Bạn cần phải lo về thiết kế, ý tưởng, layout, màu sắc của một trang web cơ bản. Làm sao để khách hàng bị ấn tượng khi họ hướng đến website của bạn.

Cả lập trình và thiết kế web sẽ có rất nhiều điểm tương đồng nên khá dễ nhầm lẫn, trên thực tế 2 công việc này là bộ đôi không thể tách rời nên chỉ trong một số trường hợp cụ thể, vai trò và công việc của Web Designer và Web Developer mới được thể hiện bài bản. Tuy nhiên ta có thể thấy rõ nhất ở một người lập trình viên Web đó là họ bắt buộc phải nắm chắc các kiến thức về lập trình web cũng như ngôn ngữ lập trình web (PHP, MySQL, .NET, SQL Server,…)

Lập trình Front-end
Hiểu đơn giản Front-end là tất cả những gì mà người dùng nhìn thấy khi họ truy cập vào website của bạn. Đồng nghĩa với việc bạn sẽ chịu trách nhiệm thiết kế và xây dựng giao diện cho các trang web hoặc ứng dụng web để người dùng có thể xem và tương tác trực tiếp trên đó. Nếu chọn hướng đi này bạn có thể học thêm các công nghệ: jQuery, CSS và các frameworks front – end, Các frameworks của JavaScript,..

Lập trình Back-end
Back-end liên quan nhiều đến cấu trúc bên trong như database và server. Bạn sẽ chịu trách nhiệm thiết kế và lập trình phần logic bên trong website để kết nối phần giao diện với cơ sở dữ liệu, giúp cho website sống động hơn. Tùy và sở thích cũng như năng khiếu mà bạn có thể lựa chọn 1 trong 2 hướng lập trình trên, còn đối với những ai có thể làm cả 2 thì sẽ được gọi là lập trình viên  Full Stack.')
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
ALTER TABLE [dbo].[MyTodo_List]  WITH CHECK ADD  CONSTRAINT [FK_MyTodo_List_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[MyTodo_List] CHECK CONSTRAINT [FK_MyTodo_List_NHANVIEN]
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
/****** Object:  StoredProcedure [dbo].[CapNhatTinhTrangSach]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_BaoCao]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSoLuongSachHoiVienMuon]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangSach]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangTheHoiVien]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[sp_CapNhatTinhTrangTheHoiVien] @mahoivien char(5)
AS BEGIN
	set nocount on;
	declare @ngaylapthe date, @ngayhethan date, @trangthai int, @dangmuon int
	select @ngaylapthe = NgayLapThe, @ngayhethan = NgayHetHan , @trangthai = TrangThai,@dangmuon = DangMuon From HOIVIEN Where MaHV = @mahoivien

	if exists (select MaHV From BOITHUONG where MaHV = @mahoivien and TinhTrang = 1)
		BEGIN
			Update HOIVIEN set TinhTrang = N'Không sử dụng' where MaHV = @mahoivien
		END
	else if( @trangthai = 1 or GETDATE() > @ngayhethan or @dangmuon >=1)
		BEGIN
			Update HOIVIEN set TinhTrang = N'Không sử dụng' where MaHV = @mahoivien
		END
	else
		BEGIN
			update HOIVIEN set TinhTrang = N'Sử dụng được' where MaHV = @mahoivien
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DoanhThu]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_DSBaoCao]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DSBaoCao] 
as
	select * from BAOCAO
GO
/****** Object:  StoredProcedure [dbo].[sp_DSPhongHopTheoTinhTrang]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_DSPhongHopTheoTinhTrang] @TinhTrang int
as
	select * from PHONGHOP where @TinhTrang=TinhTrang
GO
/****** Object:  StoredProcedure [dbo].[sp_GiaHan]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinNhanVien]    Script Date: 09-Jun-23 6:05:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayThongTinNhanVien] 
as
	select * from NHANVIEN
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 09-Jun-23 6:05:47 PM ******/
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
