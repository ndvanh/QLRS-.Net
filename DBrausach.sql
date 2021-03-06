USE [master]
GO
/****** Object:  Database [QlyRauSach]    Script Date: 12/25/2021 10:28:38 PM ******/
CREATE DATABASE [QlyRauSach]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QlyRauSach', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QlyRauSach.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QlyRauSach_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QlyRauSach_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QlyRauSach] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QlyRauSach].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QlyRauSach] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QlyRauSach] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QlyRauSach] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QlyRauSach] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QlyRauSach] SET ARITHABORT OFF 
GO
ALTER DATABASE [QlyRauSach] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QlyRauSach] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QlyRauSach] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QlyRauSach] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QlyRauSach] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QlyRauSach] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QlyRauSach] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QlyRauSach] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QlyRauSach] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QlyRauSach] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QlyRauSach] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QlyRauSach] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QlyRauSach] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QlyRauSach] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QlyRauSach] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QlyRauSach] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QlyRauSach] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QlyRauSach] SET RECOVERY FULL 
GO
ALTER DATABASE [QlyRauSach] SET  MULTI_USER 
GO
ALTER DATABASE [QlyRauSach] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QlyRauSach] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QlyRauSach] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QlyRauSach] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QlyRauSach] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QlyRauSach] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QlyRauSach', N'ON'
GO
ALTER DATABASE [QlyRauSach] SET QUERY_STORE = OFF
GO
USE [QlyRauSach]
GO
/****** Object:  Table [dbo].[CTHoadon]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHoadon](
	[Mahd] [nvarchar](50) NOT NULL,
	[Masp] [nvarchar](50) NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [float] NULL,
	[Thanhtien] [float] NULL,
	[Ngayban] [date] NULL,
 CONSTRAINT [PK_CTHoadon] PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC,
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dangnhap]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dangnhap](
	[Tk] [nvarchar](50) NOT NULL,
	[Mk] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dangnhap] PRIMARY KEY CLUSTERED 
(
	[Tk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hoadon]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hoadon](
	[Mahd] [nvarchar](50) NOT NULL,
	[Manv] [nvarchar](50) NULL,
	[Ngayban] [date] NULL,
	[Makhach] [nvarchar](50) NULL,
 CONSTRAINT [PK_Hoadon] PRIMARY KEY CLUSTERED 
(
	[Mahd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[Makhach] [nvarchar](50) NOT NULL,
	[Tenkhach] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Sdt] [int] NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[Makhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhacungcap]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhacungcap](
	[Mancc] [nvarchar](50) NOT NULL,
	[Tenncc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nhacungcap] PRIMARY KEY CLUSTERED 
(
	[Mancc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhanvien]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhanvien](
	[Manv] [nvarchar](50) NOT NULL,
	[Tennv] [nvarchar](50) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Sdt] [int] NULL,
	[Ngaysinh] [date] NULL,
	[Chucvu] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nhanvien] PRIMARY KEY CLUSTERED 
(
	[Manv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phieunhap]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phieunhap](
	[Mapn] [nvarchar](50) NOT NULL,
	[Mancc] [nvarchar](50) NULL,
	[Tensp] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[Ngay] [date] NULL,
	[Gianhap] [float] NULL,
 CONSTRAINT [PK_Phieunhap] PRIMARY KEY CLUSTERED 
(
	[Mapn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 12/25/2021 10:28:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[Masp] [nvarchar](50) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Mancc] [nvarchar](50) NULL,
	[Soluong] [int] NULL,
	[Gianhap] [float] NULL,
	[Giaban] [float] NULL,
	[Anh] [nvarchar](200) NULL,
	[Mota] [nvarchar](200) NULL,
	[Trangthai] [nvarchar](50) NULL,
	[Mapn] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CTHoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Thanhtien], [Ngayban]) VALUES (N'HD01', N'SP01', 1, 83000, 83000, CAST(N'2021-12-24' AS Date))
INSERT [dbo].[CTHoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Thanhtien], [Ngayban]) VALUES (N'HD01', N'SP02', 2, 180000, 180000, CAST(N'2021-12-24' AS Date))
INSERT [dbo].[CTHoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Thanhtien], [Ngayban]) VALUES (N'HD01', N'SP03', 1, 100000, 100000, CAST(N'2021-12-24' AS Date))
INSERT [dbo].[CTHoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Thanhtien], [Ngayban]) VALUES (N'HD01', N'SP04', 1, 83000, 83000, CAST(N'2021-12-24' AS Date))
INSERT [dbo].[CTHoadon] ([Mahd], [Masp], [Soluong], [Dongia], [Thanhtien], [Ngayban]) VALUES (N'HD02', N'SP03', 3, 210000, 210000, CAST(N'2021-12-31' AS Date))
GO
INSERT [dbo].[Dangnhap] ([Tk], [Mk]) VALUES (N'admin', N'123')
GO
INSERT [dbo].[Hoadon] ([Mahd], [Manv], [Ngayban], [Makhach]) VALUES (N'HD01', N'NV01', CAST(N'2021-12-24' AS Date), N'KH01')
INSERT [dbo].[Hoadon] ([Mahd], [Manv], [Ngayban], [Makhach]) VALUES (N'HD02', N'NV05', CAST(N'2021-12-31' AS Date), N'KH02')
GO
INSERT [dbo].[Khachhang] ([Makhach], [Tenkhach], [Diachi], [Sdt]) VALUES (N'KH01', N'Nguyen A', N'Ha Noi', 3355467)
INSERT [dbo].[Khachhang] ([Makhach], [Tenkhach], [Diachi], [Sdt]) VALUES (N'KH02', N'Nguyen B', N'Ha Noi', 23564646)
INSERT [dbo].[Khachhang] ([Makhach], [Tenkhach], [Diachi], [Sdt]) VALUES (N'KH03', N'Nguyen B', N'Ha Noi', 23564646)
GO
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'', N'')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC01', N'Trang trai Bac Tom')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC02', N'Trang trai VNG')
INSERT [dbo].[Nhacungcap] ([Mancc], [Tenncc]) VALUES (N'NCC03', N'Trang trai Ba Vi')
GO
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV01', N'Nguyen Van An', N'Nam', N'Ha Noi', 123456789, CAST(N'2002-04-05' AS Date), N'Bao ve')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV02', N'Nguyen Thi B', N'Nu', N'Ha Noi', 398568399, CAST(N'1999-06-02' AS Date), N'Thu Ngan')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV03', N'Nguyen C', N'Nam', N'Ha Noi', 34598593, CAST(N'1992-07-12' AS Date), N'Ban Hang')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV04', N'Nguyen Van A', N'Nam', N'Ha Noi', 123456789, CAST(N'2001-12-22' AS Date), N'Bao ve')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV05', N'Nguyen Thi C', N'Nu', N'Hai Phong', 123456786, CAST(N'1997-12-27' AS Date), N'Thu kho')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV06', N'Nguyen ABCD', N'Nam', N'Cau Giay, Ha Noi', 918385938, CAST(N'2000-05-09' AS Date), N'Bao ve')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV07', N'Nguyen E', N'Nu', N'Hue', 918385978, CAST(N'1997-08-22' AS Date), N'Thu ngan')
INSERT [dbo].[Nhanvien] ([Manv], [Tennv], [Gioitinh], [Diachi], [Sdt], [Ngaysinh], [Chucvu]) VALUES (N'NV08', N'Nguyen Van B', N'Nam', N'Ha Noi', 12434663, CAST(N'1996-12-28' AS Date), N'Nhan vien')
GO
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN01', N'NCC02', N'Ca rot GAP', 200, CAST(N'2021-11-25' AS Date), 20000000)
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN02', N'NCC01', N'Ca chua fresh', 200, CAST(N'2021-10-20' AS Date), 18000000)
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN03', N'NCC03', N'Bong cai xanh', 300, CAST(N'2021-12-06' AS Date), 15000000)
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN04', N'NCC03', N'Bong cai trang', 300, CAST(N'2021-11-29' AS Date), 25000000)
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN05', N'NCC02', N'Bap cai huu co', 100, CAST(N'2021-11-22' AS Date), 9000000)
INSERT [dbo].[Phieunhap] ([Mapn], [Mancc], [Tensp], [Soluong], [Ngay], [Gianhap]) VALUES (N'PN06', N'NCC01', N'Dau Ha Lan', 100, CAST(N'2021-12-17' AS Date), 12000000)
GO
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Mancc], [Soluong], [Gianhap], [Giaban], [Anh], [Mota], [Trangthai], [Mapn]) VALUES (N'SP01', N'Ca rot GAP', N'NCC02', 200, 100000, 120000, N'C:\DoAndotNet\img\carot.jpg', N'Ca rot chat luong', N'Con hang', N'PN01')
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Mancc], [Soluong], [Gianhap], [Giaban], [Anh], [Mota], [Trangthai], [Mapn]) VALUES (N'SP02', N'Ca chua fresh', N'NCC01', 200, 90000, 120000, N'C:\DoAndotNet\img\cachua.jpg', N'Ca chua tuoi ngon moi', N'Het hang', N'PN02')
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Mancc], [Soluong], [Gianhap], [Giaban], [Anh], [Mota], [Trangthai], [Mapn]) VALUES (N'SP03', N'Bong cai xanh', N'NCC03', 300, 50000, 70000, N'C:\DoAndotNet\img\bongcaixanh.jpg', N'Bong cai xanh ngon chat luong', N'Con hang', N'PN03')
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Mancc], [Soluong], [Gianhap], [Giaban], [Anh], [Mota], [Trangthai], [Mapn]) VALUES (N'SP04', N'Bong cai trang', N'NCC03', 300, 83000, 100000, N'C:\DoAndotNet\img\bongcaitrang.jpg', N'Hang chat luong cao', N'Het hang', N'PN04')
GO
ALTER TABLE [dbo].[CTHoadon]  WITH CHECK ADD  CONSTRAINT [FK_CTHoadon_Hoadon] FOREIGN KEY([Mahd])
REFERENCES [dbo].[Hoadon] ([Mahd])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CTHoadon] CHECK CONSTRAINT [FK_CTHoadon_Hoadon]
GO
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Khachhang] FOREIGN KEY([Makhach])
REFERENCES [dbo].[Khachhang] ([Makhach])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Khachhang]
GO
ALTER TABLE [dbo].[Hoadon]  WITH CHECK ADD  CONSTRAINT [FK_Hoadon_Nhanvien] FOREIGN KEY([Manv])
REFERENCES [dbo].[Nhanvien] ([Manv])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hoadon] CHECK CONSTRAINT [FK_Hoadon_Nhanvien]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Nhacungcap] FOREIGN KEY([Mancc])
REFERENCES [dbo].[Nhacungcap] ([Mancc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Nhacungcap]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Phieunhap] FOREIGN KEY([Mapn])
REFERENCES [dbo].[Phieunhap] ([Mapn])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Phieunhap]
GO
USE [master]
GO
ALTER DATABASE [QlyRauSach] SET  READ_WRITE 
GO
