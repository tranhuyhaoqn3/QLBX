USE [master]
GO
/****** Object:  Database [QuanLyBenXe]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE DATABASE [QuanLyBenXe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBenXe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyBenXe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBenXe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\QuanLyBenXe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QuanLyBenXe] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBenXe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBenXe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBenXe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBenXe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyBenXe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBenXe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBenXe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBenXe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBenXe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBenXe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBenXe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBenXe] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyBenXe', N'ON'
GO
ALTER DATABASE [QuanLyBenXe] SET QUERY_STORE = OFF
GO
USE [QuanLyBenXe]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QuanLyBenXe]
GO
/****** Object:  UserDefinedFunction [dbo].[countghecon]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[countghecon]
(
       @IDXe int,
	   @datekh	datetime
)
RETURNS int
AS
BEGIN
       DECLARE @Result int
       SELECT @Result=COUNT(IDGhe)
	   From Ghe
	   where Ghe.IDXe=@IDXe AND Ghe.NgayKhoiHanh=@datekh AND Ghe.TinhTrang=0
       RETURN @Result
END
GO
/****** Object:  Table [dbo].[Ghe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ghe](
	[IDGhe] [int] IDENTITY(1,1) NOT NULL,
	[ViTri] [nvarchar](50) NULL,
	[TinhTrang] [int] NOT NULL,
	[IDXe] [int] NULL,
	[IDHoaDon] [int] NULL,
	[NgayKhoiHanh] [datetime] NOT NULL,
 CONSTRAINT [PK_Ghe1] PRIMARY KEY CLUSTERED 
(
	[IDGhe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[fcLayGhe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fcLayGhe](@mahoadon int)
RETURNS TABLE AS RETURN 
( 
 SELECT Ghe.IDGhe,Ghe.ViTri
 FROM Ghe
 WHERE Ghe.IDHoaDon = @mahoadon 
);
GO
/****** Object:  Table [dbo].[BenXeDi]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenXeDi](
	[IDBenXeDi] [int] IDENTITY(1,1) NOT NULL,
	[TenBenXe] [nvarchar](100) NULL,
	[DiaDiemDi] [nvarchar](100) NULL,
 CONSTRAINT [PK_BenXe] PRIMARY KEY CLUSTERED 
(
	[IDBenXeDi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BenXeVe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenXeVe](
	[IDBenXeVe] [int] IDENTITY(1,1) NOT NULL,
	[TenBenXe] [nvarchar](100) NULL,
	[DiaDiemVe] [nvarchar](100) NULL,
 CONSTRAINT [PK_BenXeVe] PRIMARY KEY CLUSTERED 
(
	[IDBenXeVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuyenXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenXe](
	[IDChuyen] [int] IDENTITY(1,1) NOT NULL,
	[GiaVe] [int] NULL,
	[IDBenXeDi] [int] NULL,
	[IDBenXeVe] [int] NULL,
 CONSTRAINT [PK_ChuyenXe] PRIMARY KEY CLUSTERED 
(
	[IDChuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[TaiKhoan] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[IDHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[NgayDat] [datetime] NULL,
	[TongTien] [int] NULL,
	[IDKh] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[IDHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachhang] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[IDKhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiXe](
	[IDLoai] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](50) NULL,
	[SoGhe] [int] NULL,
 CONSTRAINT [PK_LoaiXe] PRIMARY KEY CLUSTERED 
(
	[IDLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXe](
	[IDNhaXe] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[SDT] [int] NULL,
 CONSTRAINT [PK_NhaXe] PRIMARY KEY CLUSTERED 
(
	[IDNhaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[NgayKhoiHanh] [datetime] NOT NULL,
	[IDChuyen] [int] NOT NULL,
	[IDXe] [int] NOT NULL,
	[ThoiGianDen] [datetime] NULL,
 CONSTRAINT [PK_PhanCong_1] PRIMARY KEY CLUSTERED 
(
	[NgayKhoiHanh] ASC,
	[IDChuyen] ASC,
	[IDXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Xe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xe](
	[IDXe] [int] IDENTITY(1,1) NOT NULL,
	[IDLoai] [int] NULL,
	[BienSoXe] [nvarchar](50) NULL,
	[IDNhaXe] [int] NULL,
 CONSTRAINT [PK_Xe] PRIMARY KEY CLUSTERED 
(
	[IDXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IndexBenXeDi]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE NONCLUSTERED INDEX [IndexBenXeDi] ON [dbo].[BenXeDi]
(
	[IDBenXeDi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IndexBenXeVe]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE NONCLUSTERED INDEX [IndexBenXeVe] ON [dbo].[BenXeVe]
(
	[IDBenXeVe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IndexIDChuyen]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE NONCLUSTERED INDEX [IndexIDChuyen] ON [dbo].[ChuyenXe]
(
	[IDChuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IndexNhaXe]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE NONCLUSTERED INDEX [IndexNhaXe] ON [dbo].[NhaXe]
(
	[IDNhaXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IndexPhanCong]    Script Date: 12/12/2018 11:21:45 AM ******/
CREATE NONCLUSTERED INDEX [IndexPhanCong] ON [dbo].[PhanCong]
(
	[IDXe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChuyenXe]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenXe_BenXeDi] FOREIGN KEY([IDBenXeDi])
REFERENCES [dbo].[BenXeDi] ([IDBenXeDi])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChuyenXe] CHECK CONSTRAINT [FK_ChuyenXe_BenXeDi]
GO
ALTER TABLE [dbo].[ChuyenXe]  WITH CHECK ADD  CONSTRAINT [FK_ChuyenXe_BenXeVe] FOREIGN KEY([IDBenXeVe])
REFERENCES [dbo].[BenXeVe] ([IDBenXeVe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChuyenXe] CHECK CONSTRAINT [FK_ChuyenXe_BenXeVe]
GO
ALTER TABLE [dbo].[Ghe]  WITH CHECK ADD  CONSTRAINT [FK_Ghe_HoaDon] FOREIGN KEY([IDHoaDon])
REFERENCES [dbo].[HoaDon] ([IDHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ghe] CHECK CONSTRAINT [FK_Ghe_HoaDon]
GO
ALTER TABLE [dbo].[Ghe]  WITH CHECK ADD  CONSTRAINT [FK_Ghe_Xe1] FOREIGN KEY([IDXe])
REFERENCES [dbo].[Xe] ([IDXe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ghe] CHECK CONSTRAINT [FK_Ghe_Xe1]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([IDKh])
REFERENCES [dbo].[KhachHang] ([IDKhachhang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_ChuyenXe] FOREIGN KEY([IDChuyen])
REFERENCES [dbo].[ChuyenXe] ([IDChuyen])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_ChuyenXe]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_Xe] FOREIGN KEY([IDXe])
REFERENCES [dbo].[Xe] ([IDXe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_Xe]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_LoaiXe] FOREIGN KEY([IDLoai])
REFERENCES [dbo].[LoaiXe] ([IDLoai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_LoaiXe]
GO
ALTER TABLE [dbo].[Xe]  WITH CHECK ADD  CONSTRAINT [FK_Xe_NhaXe] FOREIGN KEY([IDNhaXe])
REFERENCES [dbo].[NhaXe] ([IDNhaXe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Xe] CHECK CONSTRAINT [FK_Xe_NhaXe]
GO
/****** Object:  StoredProcedure [dbo].[deleteghe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[deleteghe]
@IDXe int,
@NgayKH nvarchar(50)
AS
BEGIN
    Delete Ghe
	Where DATEDIFF(minute, 	CONVERT(datetime,@NgayKH), Ghe.NgayKhoiHanh)=0 AND IDXe=@IDXe
END
GO
/****** Object:  StoredProcedure [dbo].[deletenhaxe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deletenhaxe]
@idnhaXe int
AS
BEGIN
	begin transaction
	if exists (select * from Xe,PhanCong where Xe.IDNhaXe=@idnhaXe AND Xe.IDXe=PhanCong.IDXe)
	begin
	rollback tran 
	end
	else
	begin
	delete NhaXe where NhaXe.IDNhaXe=@idnhaXe
	commit tran
	end
END
GO
/****** Object:  StoredProcedure [dbo].[deletephancong]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deletephancong]
@IDXe int,
@NgayKH nvarchar(50),
@IDChuyen int
AS
BEGIN
    Delete PhanCong
	Where IDChuyen=@IDChuyen AND IDXe=@IDXe  AND DATEDIFF(second, 	CONVERT(datetime,@NgayKH), PhanCong.NgayKhoiHanh)=0
END
GO
/****** Object:  StoredProcedure [dbo].[editghe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[editghe]
@IDXe int,
@NgayKH nvarchar(50),
@NgayEdit datetime
AS

BEGIN
    Update Ghe
	Set NgayKhoiHanh=@NgayEdit
	Where  IDXe=@IDXe AND DATEDIFF(SECOND, 	CONVERT(datetime,@NgayKH), Ghe.NgayKhoiHanh)=0
END
GO
/****** Object:  StoredProcedure [dbo].[getchuyenxebyghe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getchuyenxebyghe]
@ID int,
@NgayKH datetime
AS
BEGIN
    Select CONCAT( BenXeDi.DiaDiemDi,' - ',BenXeVe.DiaDiemVe) as LoTrinh
	From Ghe,ChuyenXe,PhanCong,BenXeDi,BenXeVe
	Where PhanCong.IDXe=@ID AND DATEDIFF(SECOND,PhanCong.NgayKhoiHanh,@NgayKH)=0AND PhanCong.IDChuyen=ChuyenXe.IDChuyen AND  ChuyenXe.IDBenXeDi=BenXeDi.IDBenXeDi AND ChuyenXe.IDBenXeVe=BenXeVe.IDBenXeVe
END
GO
/****** Object:  StoredProcedure [dbo].[getLotrinh]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[getLotrinh]
as
Begin 

     SELECT ChuyenXe.IDChuyen,CONCAT( BenXeDi.DiaDiemDi,' - ',BenXeVe.DiaDiemVe) as LoTrinh
     FROM ChuyenXe,BenXeDi,BenXeVe
	 where ChuyenXe.IDBenXeDi=BenXeDi.IDBenXeDi AND ChuyenXe.IDBenXeVe=BenXeVe.IDBenXeVe
End

GO
/****** Object:  StoredProcedure [dbo].[getLotrinhSoghe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[getLotrinhSoghe]
@IDXe int
as
Begin 
     SELECT PhanCong.IDXe,CONCAT( BenXeDi.DiaDiemDi,' - ',BenXeVe.DiaDiemVe) as LoTrinh,PhanCong.NgayKhoiHanh,CONCAT( dbo.[countghecon](@IDXe,PhanCong.NgayKhoiHanh),' / ',LoaiXe.SoGhe) as SoGHe,PhanCong.ThoiGianDen
     FROM PhanCong,ChuyenXe,BenXeDi,BenXeVe,Xe,LoaiXe
	 where PhanCong.IDXe=@IDXe AND ChuyenXe.IDChuyen=PhanCong.IDChuyen AND ChuyenXe.IDBenXeDi=BenXeDi.IDBenXeDi AND ChuyenXe.IDBenXeVe=BenXeVe.IDBenXeVe AND Xe.IDXe=PhanCong.IDXe AND Xe.IDLoai=LoaiXe.IDLoai
End
GO
/****** Object:  StoredProcedure [dbo].[getlotrinhxe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[getlotrinhxe]
@IDDi int,
@IDVe int,
@NgayKH nvarchar(50)
AS
BEGIN
    Select NhaXe.Ten,CONCAT( BenXeDi.DiaDiemDi,' - ',BenXeVe.DiaDiemVe) as LoTrinh,PhanCong.NgayKhoiHanh,PhanCong.ThoiGianDen,ChuyenXe.GiaVe,PhanCong.IDXe,LoaiXe.SoGhe
	From PhanCong,ChuyenXe,Xe,LoaiXe,NhaXe,BenXeDi,BenXeVe
	Where ChuyenXe.IDBenXeDi=@IDDi AND ChuyenXe.IDBenXeVe=@IDVe AND ChuyenXe.IDChuyen=PhanCong.IDChuyen AND DATEDIFF(day, 	CONVERT(datetime,@NgayKH), PhanCong.NgayKhoiHanh)=0 AND Xe.IDXe=PhanCong.IDXe AND Xe.IDLoai=LoaiXe.IDLoai AND Xe.IDNhaXe=NhaXe.IDNhaXe AND ChuyenXe.IDBenXeDi=BenXeDi.IDBenXeDi AND ChuyenXe.IDBenXeVe=BenXeVe.IDBenXeVe
END
GO
/****** Object:  StoredProcedure [dbo].[insertchuyenxe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[insertchuyenxe]
@idBenDi int,
@idBenVe int,
@GiaVe int
AS
BEGIN
	begin transaction
	insert into ChuyenXe(IDBenXeDi,IDBenXeVe,GiaVe) values(@idBenDi,@idBenVe,@GiaVe)
	if (select COUNT(*) from ChuyenXe where IDBenXeDi=@idBenDi AND IDBenXeVe=@idBenVe)>1
	begin
	rollback tran 
	end
	else
	begin
	commit
	end
END
GO
/****** Object:  StoredProcedure [dbo].[insertnhaxe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertnhaxe]
@name nvarchar(50),
@SDT int
AS
BEGIN
	begin transaction
	insert into NhaXe(Ten,SDT) values(@name,@SDT)
	if (select COUNT(*) from NhaXe where NhaXe.Ten=@name)>1
	begin
	rollback tran 
	end
	else
	begin
	commit
	end
END
GO
/****** Object:  StoredProcedure [dbo].[spChitiethoadon]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spChitiethoadon]
	@idhoadon int
AS
BEGIN
	select * from fcLayGhe(@idhoadon) 

END
GO
/****** Object:  StoredProcedure [dbo].[spchuyenxe1]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE  [dbo].[spchuyenxe1]
as
begin
SELECT ChuyenXe.IDChuyen,ChuyenXe.GiaVe,BenXeDi.DiaDiemDi,BenXeVe.DiaDiemVe
from  BenXeDi join ChuyenXe on BenXeDi.IDBenXeDi=ChuyenXe.IDBenXeDi join BenXeVe on BenXeVe.IDBenXeVe=ChuyenXe.IDBenXeVe
end
GO
/****** Object:  StoredProcedure [dbo].[spDangKy]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spDangKy]
@TaiKhoan nvarchar(100),@MatKhau nvarchar(100)
	
AS
BEGIN

insert into DangNhap(TaiKhoan,MatKhau)
values (@TaiKhoan,@MatKhau)
	
END
GO
/****** Object:  StoredProcedure [dbo].[spdeleteBenXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spdeleteBenXe]
	@IDBenXe int
AS
BEGIN
	delete 
	from BenXeDi
	where BenXeDi.IDBenXeDi=@IDBenXe
	delete
	from BenXeVe
	where BenXeVe.IDBenXeVe=@IDBenXe
END
GO
/****** Object:  StoredProcedure [dbo].[spDemsoghedadat]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spDemsoghedadat]
	@idhoadon int
AS
BEGIN
	select count(*) from Ghe
	where Ghe.IDHoaDon =@idhoadon 
END
GO
/****** Object:  StoredProcedure [dbo].[spHoaDon]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spHoaDon]

AS
BEGIN
	select HoaDon.IDHoaDon, KhachHang.Ten, HoaDon.NgayDat,HoaDon.TongTien
	from HoaDon join KhachHang on HoaDon.IDKh=KhachHang.IDKhachHang
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaChuyenXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spXoaChuyenXe]
@idChuyenXe int
AS
BEGIN
	begin transaction
	if exists (select * from PhanCong, ChuyenXe where PhanCong.IDChuyen=@idChuyenXe)
	begin
	print 'trung'
	rollback tran 
	end
	else
	begin
	delete ChuyenXe where ChuyenXe.IDChuyen=@idChuyenXe
	commit tran
	end
END
GO
/****** Object:  StoredProcedure [dbo].[spXoaXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[spXoaXe]
@idXe int
AS
BEGIN
	begin transaction
	if exists (select * from PhanCong where PhanCong.IDXe=@idXe)
	begin
	rollback tran 
	end
	else
	begin
	delete Xe where Xe.IDXe=@idXe
	commit tran
	end
END
GO
/****** Object:  StoredProcedure [dbo].[udsGetNhaXe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[udsGetNhaXe]
as
Begin
     SELECT *
     FROM NhaXe
	  End
GO
/****** Object:  StoredProcedure [dbo].[udsXebyIDnhaxe]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[udsXebyIDnhaxe]
    @IDNhaXe int
AS
BEGIN
     SELECT IDXe,LoaiXe.Ten,BienSoXe,SoGhe
     FROM Xe,LoaiXe
     WHERE Xe.IDNhaXe = @IDNhaXe AND Xe.IDLoai=LoaiXe.IDLoai
END

GO
/****** Object:  StoredProcedure [dbo].[udsXebyIDnhaxeandLoai]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[udsXebyIDnhaxeandLoai]
    @IDNhaXe int,
	@NameLoai nvarchar(50)
AS
BEGIN
     SELECT IDXe,LoaiXe.Ten,BienSoXe,SoGhe
     FROM Xe,LoaiXe
     WHERE Xe.IDNhaXe = @IDNhaXe AND Xe.IDLoai=LoaiXe.IDLoai AND LoaiXe.Ten Like @NameLoai
END
GO
/****** Object:  StoredProcedure [dbo].[updatephancong]    Script Date: 12/12/2018 11:21:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updatephancong]
@IDXe int,
@NgayKH nvarchar(50),
@IDChuyen int,

@NgayKHed datetime,
@IDChuyened int,
@ThoiGianDen datetime
AS
BEGIN
    Update PhanCong
	Set IDChuyen=@IDChuyened ,NgayKhoiHanh=@NgayKHed,PhanCong.ThoiGianDen=@ThoiGianDen
	Where IDChuyen=@IDChuyen AND IDXe=@IDXe  AND DATEDIFF(second, 	CONVERT(datetime,@NgayKH), PhanCong.NgayKhoiHanh)=0 AND IDXe=@IDXe
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyBenXe] SET  READ_WRITE 
GO
