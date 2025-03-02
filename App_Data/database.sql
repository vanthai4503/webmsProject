USE [master]
GO
/****** Object:  Database [web_nc_music]    Script Date: 11/26/2023 11:23:55 PM ******/
CREATE DATABASE [web_nc_music]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'web_nc_music', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\web_nc_music.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'web_nc_music_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\web_nc_music_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [web_nc_music] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [web_nc_music].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [web_nc_music] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [web_nc_music] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [web_nc_music] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [web_nc_music] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [web_nc_music] SET ARITHABORT OFF 
GO
ALTER DATABASE [web_nc_music] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [web_nc_music] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [web_nc_music] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [web_nc_music] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [web_nc_music] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [web_nc_music] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [web_nc_music] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [web_nc_music] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [web_nc_music] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [web_nc_music] SET  DISABLE_BROKER 
GO
ALTER DATABASE [web_nc_music] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [web_nc_music] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [web_nc_music] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [web_nc_music] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [web_nc_music] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [web_nc_music] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [web_nc_music] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [web_nc_music] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [web_nc_music] SET  MULTI_USER 
GO
ALTER DATABASE [web_nc_music] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [web_nc_music] SET DB_CHAINING OFF 
GO
ALTER DATABASE [web_nc_music] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [web_nc_music] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [web_nc_music] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [web_nc_music] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [web_nc_music] SET QUERY_STORE = OFF
GO
USE [web_nc_music]
GO
/****** Object:  Table [dbo].[Baihat]    Script Date: 11/26/2023 11:23:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Baihat](
	[IDSong] [int] IDENTITY(1,1) NOT NULL,
	[Tenbai] [nvarchar](100) NULL,
	[Casi] [nvarchar](100) NULL,
	[Thoiluong] [nvarchar](100) NULL,
	[Theloai] [nvarchar](300) NULL,
	[Linkbaihat] [nvarchar](300) NULL,
	[Img] [nvarchar](300) NULL,
 CONSTRAINT [PK_Baihat] PRIMARY KEY CLUSTERED 
(
	[IDSong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chitietlist]    Script Date: 11/26/2023 11:23:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietlist](
	[IDlist] [nvarchar](50) NOT NULL,
	[IDsong] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Chitietlist_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Danhsachphat]    Script Date: 11/26/2023 11:23:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Danhsachphat](
	[IDlist] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Tendanhsach] [nvarchar](50) NULL,
	[Riengtu] [bit] NULL,
 CONSTRAINT [PK_Danhsachphat] PRIMARY KEY CLUSTERED 
(
	[IDlist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Baihat] ON 

INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (18, N'hom nay toi buon', N'nguyenwikbu', N'75600000', N'v pop', N'/Assets/audio/hom nay toi buon2023-11-17 10-15-07.mp3', N'/Assets/images/uploadimg/2023-11-17 10-15-07.jpg  ')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (19, N'hom nay toi buon3', N'nguyen', N'75600000', N'v pop', N'/Assets/audio/hom nay toi buon32023-11-17 10-15-41.mp3', N'/Assets/images/uploadimg/2023-11-17 10-15-41.jpg  ')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (20, N'vui hon 1 ti', N'nguyen', N'300410000', N'k pop', N'/Assets/audio/vui hon 1 ti2023-11-17 14-28-13.mp3', N'/Assets/images/uploadimg/2023-11-17 14-28-13.jpg  ')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (21, N'vui tạm 1', N'nguyen', N'288130000', N'V-POP', N'/Assets/audio/vui tạm 12023-11-18 13-56-09.mp3', N'/Assets/images/uploadimg/2023-11-18 13-56-09.jpg  ')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (22, N'adad', N'nguyen', N'300410000', N'V-POP', N'/Assets/audio/adad2023-11-26 10-55-10.mp3', N'/Assets/Admin/images/uploadimg/2023-11-26 16-52-19.jpg')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (26, N'yeu em dai kho', N'nguyen', N'75600000', N'US-UK', N'/Assets/audio/yeu em dai kho2023-11-26 15-44-40.mp3', N'/Assets/Admin/images/uploadimg/2023-11-26 15-44-40.jpg')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (27, N'hom nay toi buon', N'nguyen', N'75600000', N'K-POP', N'/Assets/audio/hom nay toi buon2023-11-26 15-58-19.mp3', N'/Assets/Admin/images/uploadimg/2023-11-26 15-58-19.jpg')
INSERT [dbo].[Baihat] ([IDSong], [Tenbai], [Casi], [Thoiluong], [Theloai], [Linkbaihat], [Img]) VALUES (28, N'the gioi thu4', N'chi dan', N'203490000', N'V-POP', N'/Assets/audio/the gioi thu42023-11-26 16-34-19.mp3', N'/Assets/Admin/images/uploadimg/2023-11-26 16-52-37.jpg')
SET IDENTITY_INSERT [dbo].[Baihat] OFF
GO
ALTER TABLE [dbo].[Chitietlist]  WITH CHECK ADD  CONSTRAINT [FK_Chitietlist_Baihat] FOREIGN KEY([IDsong])
REFERENCES [dbo].[Baihat] ([IDSong])
GO
ALTER TABLE [dbo].[Chitietlist] CHECK CONSTRAINT [FK_Chitietlist_Baihat]
GO
ALTER TABLE [dbo].[Chitietlist]  WITH CHECK ADD  CONSTRAINT [FK_Chitietlist_Danhsachphat] FOREIGN KEY([IDlist])
REFERENCES [dbo].[Danhsachphat] ([IDlist])
GO
ALTER TABLE [dbo].[Chitietlist] CHECK CONSTRAINT [FK_Chitietlist_Danhsachphat]
GO
USE [master]
GO
ALTER DATABASE [web_nc_music] SET  READ_WRITE 
GO
