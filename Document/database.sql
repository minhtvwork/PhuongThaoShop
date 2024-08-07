USE [master]
GO
/****** Object:  Database [PTS_DEV]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE DATABASE [PTS_DEV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PTS_DEV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PTS_DEV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PTS_DEV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PTS_DEV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PTS_DEV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PTS_DEV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PTS_DEV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PTS_DEV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PTS_DEV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PTS_DEV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PTS_DEV] SET ARITHABORT OFF 
GO
ALTER DATABASE [PTS_DEV] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PTS_DEV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PTS_DEV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PTS_DEV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PTS_DEV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PTS_DEV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PTS_DEV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PTS_DEV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PTS_DEV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PTS_DEV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PTS_DEV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PTS_DEV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PTS_DEV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PTS_DEV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PTS_DEV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PTS_DEV] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PTS_DEV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PTS_DEV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PTS_DEV] SET  MULTI_USER 
GO
ALTER DATABASE [PTS_DEV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PTS_DEV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PTS_DEV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PTS_DEV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PTS_DEV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PTS_DEV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PTS_DEV] SET QUERY_STORE = ON
GO
ALTER DATABASE [PTS_DEV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PTS_DEV]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressName] [nvarchar](max) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[UserEntityId] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceCode] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[FullName] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[Payment] [int] NOT NULL,
	[IsPayment] [bit] NOT NULL,
	[Discount] [decimal](18, 2) NULL,
	[VoucherEntityId] [int] NULL,
	[UserEntityId] [int] NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[UpdUserId] [int] NULL,
	[UpdDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[CodeProductDetail] [nvarchar](max) NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[BillEntityId] [int] NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[UpdUserId] [int] NULL,
	[UpdDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardVGA]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardVGA](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](100) NULL,
	[ThongSo] [nvarchar](50) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_CardVGA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[UserEntityId] [int] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[UserEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartDetail]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartEntityId] [int] NOT NULL,
	[ProductDetailEntityId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_CartDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[CodeManagePost] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CPU]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CPU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[Ten] [nvarchar](100) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_CPU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HardDrive]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HardDrive](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](50) NULL,
	[ThongSo] [nvarchar](100) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_HardDrive] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagePost]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagePost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[LinkImage] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_ManagePost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[ManufacturerEntityId] [int] NULL,
	[ProductTypeEntityId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetail]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OldPrice] [decimal](18, 2) NOT NULL,
	[Upgrade] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ProductEntityId] [int] NOT NULL,
	[ColorEntityId] [int] NULL,
	[RamEntityId] [int] NULL,
	[CpuEntityId] [int] NULL,
	[HardDriveEntityId] [int] NULL,
	[ScreenEntityId] [int] NULL,
	[CardVGAEntityId] [int] NULL,
	[CrUserId] [int] NULL,
	[DiscountId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[UpdUserId] [int] NULL,
	[UpdDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetailImage]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetailImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductDetailId] [int] NOT NULL,
	[IsIndex] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_ProductDetailImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ram]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ram](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](max) NOT NULL,
	[ThongSo] [nvarchar](100) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Ram] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Screen]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ma] [nvarchar](max) NOT NULL,
	[KichCo] [nvarchar](50) NULL,
	[TanSo] [nvarchar](50) NULL,
	[ChatLieu] [nvarchar](50) NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Serial]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Serial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [nvarchar](max) NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[UpdUserId] [int] NULL,
	[UpdDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[ProductDetailEntityId] [int] NULL,
	[BillDetailEntityId] [int] NULL,
 CONSTRAINT [PK_Serial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[AvatarPath] [nvarchar](max) NULL,
	[IsEnabled] [bit] NULL,
	[LastTimeChangePass] [datetime2](7) NULL,
	[LastTimeLogin] [datetime2](7) NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 7/27/2024 9:07:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaVoucher] [nvarchar](50) NOT NULL,
	[TenVoucher] [nvarchar](200) NULL,
	[StartDay] [datetime2](7) NULL,
	[EndDay] [datetime2](7) NULL,
	[GiaTri] [decimal](18, 2) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[CrUserId] [int] NULL,
	[CrDateTime] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616070106_InitDb', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240707091904_InitDb', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240727140009_InitDb', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (4, N'BilloPBktzB', N'45', N'Vũ Phương Thảo', NULL, 1, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-10T22:20:24.1664033' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (5, N'BillOtUvhPi', N'54', N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-13T15:29:59.6430666' AS DateTime2), NULL, NULL, 8)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (6, N'BillFplVG7P', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-13T15:29:59.8109918' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (7, N'Billm9RRrXV', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-13T15:30:49.7423853' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (8, N'BilluHII5Yd', NULL, N'Administrator', NULL, 0, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-13T15:33:51.7245037' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (9, N'BillCFaeXdP', NULL, N'Administrator', NULL, 2, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-13T16:02:48.1586879' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (10, N'BilleGPZ4rm', NULL, N'Administrator', NULL, 3, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T16:16:51.2668634' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (11, N'BilliKKJxDs', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:07:13.1337410' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (12, N'BillFhg5ZPW', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:08:40.6565400' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (13, N'BillIqEDuB3', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:11:05.9414275' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (14, N'BillbmRfyV6', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:11:27.8630136' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (15, N'Bill5dtAP5V', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:12:00.1980631' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (16, N'BillVAPBXal', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:13:46.7257251' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (17, N'BillCc4KEHX', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:15:18.7181898' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (18, N'BilleJcaoDC', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:35:45.9284759' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (19, N'BillbEO8GX1', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:46:17.6300985' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (20, N'Bille3x8XzK', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:46:21.9958696' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (21, N'BillIGBqmsC', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:51:45.2306069' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (22, N'Billy4p0Ubp', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:52:06.7440404' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (23, N'BillIHmpN7G', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:52:35.6589666' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (24, N'BillUflJiZA', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:52:41.9969087' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (25, N'BillZ3Tr9D5', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T17:58:12.3694719' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (26, N'BillU79M496', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T18:41:50.2397927' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (27, N'BillSpLoRc3', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T18:42:19.5087254' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (28, N'BillVAUzBb6', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T18:44:53.8731306' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (29, N'Billql1FTJD', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T18:50:42.3100981' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (30, N'Bill4CaqPP2', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T18:56:55.5011514' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (31, N'BillaK1AOP0', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T19:19:08.6582570' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (32, N'BillP8JeywA', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T19:21:08.9100319' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (33, N'BillrEQSyBA', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T22:40:04.8986861' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (34, N'BillFDKMR1J', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-20T23:59:34.0920126' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (35, N'Billq9rLbKC', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T07:49:10.4542897' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (36, N'BillqPyb5eI', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:05:47.8229683' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (37, N'BillbHiUlaQ', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:08:10.4825756' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (38, N'BilliDZ8JOZ', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:10:40.7635988' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (39, N'BillUmrXmYV', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:14:51.4595838' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (40, N'BillwKkOviE', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:27:51.9857689' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (41, N'BillZySvqoq', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T08:51:14.8487993' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (42, N'BillXnY5V5T', NULL, N'Administrator', NULL, 4, 1, NULL, NULL, 1, NULL, CAST(N'2024-07-21T14:36:02.7597069' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (43, N'rwHNZcEPaEGB', NULL, N'Administrator', NULL, 4, 1, NULL, NULL, 1, NULL, CAST(N'2024-07-21T15:14:23.4466856' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (44, N'tVpmQ7GzKICU', NULL, N'Administrator', NULL, 1, 0, NULL, 1, 1, NULL, CAST(N'2024-07-21T20:13:32.9458686' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (45, N'Gvdc9mIb8ibi', NULL, N'Administrator', NULL, 4, 1, NULL, 1, 1, NULL, CAST(N'2024-07-21T20:27:52.1183770' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (46, N'vaAGhxINfxgi', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-21T20:42:46.9380752' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (47, N'WcNbLwU5Kl1n', NULL, N'Administrator', NULL, 1, 0, NULL, 1, 1, NULL, CAST(N'2024-07-21T20:45:12.6450456' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (51, N'wNcxaBf8VTdJ', N'54', N'5454', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-25T22:15:14.1655476' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (52, N'24pfvz9M7QYO', N'54', N'5454', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-25T22:16:43.2002578' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (53, N'S33h5lTeo4c4', N'54', N'4', NULL, 3, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-25T22:18:48.0729487' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (54, N'ssC6ZSbXycwu', N'34', N'34', NULL, 3, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-25T22:20:34.8821285' AS DateTime2), NULL, NULL, 4)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (55, N'o44tBlF8Csi7', N'5454', N'45', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-25T22:21:04.8022110' AS DateTime2), NULL, NULL, 3)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (56, N'xZTDh4JCYZfJ', N'0', N'0', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-26T21:55:23.5642287' AS DateTime2), NULL, NULL, 3)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (57, N'QJb9p5mxyemD', N'0', N'0', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-26T21:55:30.3524894' AS DateTime2), NULL, NULL, 3)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (58, N'rZigYLHzcGJa', N'0', N'0', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-26T21:55:37.4816021' AS DateTime2), NULL, NULL, 3)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (59, N'kIiZtqR9NjEX', N'0', N'0', NULL, 2, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-26T21:55:48.2970390' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (60, N'WLnYm4mtUGqD', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-26T23:19:56.3162648' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (61, N'ECcSZbKkiBnO', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-26T23:20:44.0178203' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (62, N'c2cwY0Qv1eLt', NULL, N'Administrator', NULL, 4, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-27T15:08:59.7162335' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (63, N'rzoy1p8qrwSL', NULL, N'Administrator', NULL, 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-27T15:16:37.2119054' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (64, N'BCNE9NP8jW9Z', N'43', N'34', N'43', 4, 0, NULL, NULL, NULL, NULL, CAST(N'2024-07-27T15:53:48.6618382' AS DateTime2), NULL, NULL, 2)
INSERT [dbo].[Bill] ([Id], [InvoiceCode], [PhoneNumber], [FullName], [Address], [Payment], [IsPayment], [Discount], [VoucherEntityId], [UserEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (65, N'gq9l29WecQdM', NULL, N'Nguyễn Phương Thảo', N'', 1, 0, NULL, NULL, 1, NULL, CAST(N'2024-07-27T21:03:21.3638111' AS DateTime2), NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
SET IDENTITY_INSERT [dbo].[BillDetail] ON 

INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (1, N'BilloPBktzBCTBCwUs', N'KMMA', 1, CAST(20000000.00 AS Decimal(18, 2)), 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (2, N'BillOtUvhPiop90hlq', N'15P00', 25, CAST(15000000.00 AS Decimal(18, 2)), 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (3, N'Billm9RRrXV7j4u5Du', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 7, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (4, N'BilluHII5Ydy3zLP2G', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 8, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (5, N'BillCFaeXdPPvlwDtL', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 9, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (6, N'BilleGPZ4rmlFk3MiT', N'15P00', 11, CAST(15000000.00 AS Decimal(18, 2)), 10, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (7, N'BilliKKJxDslDqeK9R', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 11, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (8, N'BillFhg5ZPWGRdnhL6', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 12, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (9, N'BillIqEDuB3FIHv0PH', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 13, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (10, N'BillbmRfyV6PS0dtvy', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 14, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (11, N'Bill5dtAP5VVFfwp6Z', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 15, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (12, N'BillVAPBXalB7pD2kU', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 16, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (13, N'BillCc4KEHXHIVfLIf', N'15P00', 2, CAST(15000000.00 AS Decimal(18, 2)), 17, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (14, N'BilleJcaoDC2jLOt5n', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 18, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (15, N'BillbEO8GX1iieFWDY', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 19, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (16, N'BillIGBqmsCX9uLaYI', N'15P00', 4, CAST(15000000.00 AS Decimal(18, 2)), 21, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (17, N'BillIGBqmsCIi7PxiW', N'KMMA', 1, CAST(20000000.00 AS Decimal(18, 2)), 21, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (18, N'BillIHmpN7GC6BGvO4', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 23, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (19, N'BillZ3Tr9D5XDpMPzd', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 25, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (20, N'BillU79M496e22l5wh', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 26, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (21, N'BillSpLoRc3K05rmDd', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 27, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (22, N'BillVAUzBb6vn0WvZ0', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 28, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (23, N'Billql1FTJDTqxQPsO', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 29, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (24, N'Bill4CaqPP2PVdzaxx', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 30, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (25, N'BillaK1AOP0J3wr5Uy', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 31, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (26, N'BillP8JeywAoq1YCdi', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 32, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (27, N'BillrEQSyBAmPEcL4w', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 33, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (28, N'BillFDKMR1JxJYTn4f', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 34, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (29, N'Billq9rLbKCcxPdhrj', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 35, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (30, N'BillqPyb5eIVs5gaNv', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 36, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (31, N'BillbHiUlaQH8g6R0y', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 37, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (32, N'BilliDZ8JOZbPanHvJ', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 38, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (33, N'BillUmrXmYVYalZx0x', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 39, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (34, N'BillwKkOviEHqqnDkq', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 40, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (35, N'BillZySvqoqMQYF4xL', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 41, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (36, N'BillXnY5V5Ttn1N9BE', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 42, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (37, N'rwHNZcEPaEGByRlDEaD', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 43, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (38, N'tVpmQ7GzKICUh59K0tW', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 44, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (39, N'Gvdc9mIb8ibiKdKxj17', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 45, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (40, N'vaAGhxINfxgiXLAKH1f', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 46, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (41, N'WcNbLwU5Kl1nsLiTu6r', N'SKS1K3', 6, CAST(15000000.00 AS Decimal(18, 2)), 47, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (42, N'WLnYm4mtUGqDgSjCmbu', N'KMMA', 2, CAST(20000000.00 AS Decimal(18, 2)), 60, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (43, N'ECcSZbKkiBnOLqG2qll', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 61, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (44, N'c2cwY0Qv1eLtNtjt8WG', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 62, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (45, N'rzoy1p8qrwSL3jf1e6R', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 63, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (46, N'BCNE9NP8jW9ZRBqJJV1', N'15P00', 1, CAST(15000000.00 AS Decimal(18, 2)), 64, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[BillDetail] ([Id], [Code], [CodeProductDetail], [Quantity], [Price], [BillEntityId], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (47, N'gq9l29WecQdMtou6FUC', N'15P00', 10, CAST(15000000.00 AS Decimal(18, 2)), 65, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[BillDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[CardVGA] ON 

INSERT [dbo].[CardVGA] ([Id], [Ma], [Ten], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'AMD Radeon Graphics', N'AMD Radeon Graphics', N'4GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CardVGA] OFF
GO
INSERT [dbo].[Cart] ([UserEntityId], [Description], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Giỏ hàng của admin', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'
black', N'Màu đen', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'
white', N'Màu trắng', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'silver', N'Màu bạc', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (5, N'grey', N'Màu xám', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[CPU] ON 

INSERT [dbo].[CPU] ([Id], [Ma], [Ten], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Core i5-13500HX', N'Core i5-13500HX', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CPU] ([Id], [Ma], [Ten], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'Core i5-13420H', N'Core i5-13420H', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CPU] OFF
GO
SET IDENTITY_INSERT [dbo].[HardDrive] ON 

INSERT [dbo].[HardDrive] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'SSD256-PT', N'256 GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[HardDrive] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([Id], [Name], [Url], [Description], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'dell1', N'/uploads/dell1.jpg', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Dell', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'Acer', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'HP', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (5, N'Asus', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (6, N'Gigabyte', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (7, N'Lenovo', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (8, N'MSI', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (9, N'Samsung', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (1, N'Dell Alienware', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (2, N'Dell XPS 15', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (3, N'Dell Alain X', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (4, N'Dell Lattiue', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (1, N'15P00', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (2, N'KMMA', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (3, N'SKS1K', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (4, N'KKSM', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (5, N'15P002', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (6, N'KMMA2', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (7, N'SKS1K2', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (8, N'KKSM2', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (9, N'15P003', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (10, N'KMMA3', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (11, N'SKS1K3', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (12, N'KKSM3', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (13, N'15P003', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (14, N'KMMA3', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (15, N'SKS1K3', CAST(15000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [DiscountId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status]) VALUES (16, N'KKSM3', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, N'f', 1, 1, 2, 1, 1, 1, 1, 1, NULL, CAST(N'2024-07-07T00:00:00.0000000' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetailImage] ON 

INSERT [dbo].[ProductDetailImage] ([Id], [ProductDetailId], [IsIndex], [Status], [ImageId]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[ProductDetailImage] ([Id], [ProductDetailId], [IsIndex], [Status], [ImageId]) VALUES (2, 2, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[ProductDetailImage] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Laptop Gaming', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Ram] ON 

INSERT [dbo].[Ram] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'DDR4-PM', N'8GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Ram] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'DDR5-PM16', N'16GB DDR5', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Ram] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (4, N'KMS', N'16GB', 1, CAST(N'2024-07-14T17:14:54.9271516' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Ram] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Administrator', N'Admin', N'ADMIN', N'phuongthaoshop.vn')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Employee', N'Employee', N'EMPLOYEE', N'phuongthaoshop.vn')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Customer', N'Customer', N'CUSTOMER', N'phuongthaoshop.vn')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Screen] ON 

INSERT [dbo].[Screen] ([Id], [Ma], [KichCo], [TanSo], [ChatLieu], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'PM-16K', N'15.6"', N'144Hz', N'IPS', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Screen] OFF
GO
SET IDENTITY_INSERT [dbo].[Serial] ON 

INSERT [dbo].[Serial] ([Id], [SerialNumber], [CrUserId], [CrDateTime], [UpdUserId], [UpdDateTime], [Status], [ProductDetailEntityId], [BillDetailEntityId]) VALUES (1, N'049439439', NULL, NULL, NULL, NULL, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Serial] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 3)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [Notes], [AvatarPath], [IsEnabled], [LastTimeChangePass], [LastTimeLogin], [CrDateTime], [Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'Nguyễn Phương Thảo', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'adphuongthao', N'ADPHUONGTHAO', N'adphuongthao@gmail.com', N'ADPHUONGTHAO@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEERQ5zhByb7xZMDVKaUFJyA4tG2mPyAfI4qumrpxq9HQUA0hi1Lqq0Z5VHIn+Snh5A==', N'phuongthaoshop.vn', N'phuongthaoshop.vn', NULL, 0, 0, NULL, 0, 0)
INSERT [dbo].[Users] ([Id], [FullName], [Notes], [AvatarPath], [IsEnabled], [LastTimeChangePass], [LastTimeLogin], [CrDateTime], [Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (2, N'Vũ Thị Huyền', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'thuhuyen', N'THUHUYEN', N'thuhuyen@gmail.com', N'THUHUYEN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEAsRvIOt7/n/cu9jrjdu+J3p65VkYt3/Rd32McBFRq7CndQLFNEbv4s/66UZYXHP+w==', N'phuongthaoshop.vn', N'phuongthaoshop.vn', NULL, 0, 0, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Voucher] ON 

INSERT [dbo].[Voucher] ([Id], [MaVoucher], [TenVoucher], [StartDay], [EndDay], [GiaTri], [SoLuong], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'MungGiangSinh', N'Mừng Giáng Sinh', CAST(N'2024-07-20T00:00:00.0000000' AS DateTime2), CAST(N'2024-12-12T00:00:00.0000000' AS DateTime2), CAST(1000000.00 AS Decimal(18, 2)), 100, 1, CAST(N'2024-07-20T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Voucher] OFF
GO
/****** Object:  Index [IX_Address_UserEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Address_UserEntityId] ON [dbo].[Address]
(
	[UserEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bill_UserEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_UserEntityId] ON [dbo].[Bill]
(
	[UserEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bill_VoucherEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_VoucherEntityId] ON [dbo].[Bill]
(
	[VoucherEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BillDetail_BillEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_BillDetail_BillEntityId] ON [dbo].[BillDetail]
(
	[BillEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartDetail_CartEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartDetail_CartEntityId] ON [dbo].[CartDetail]
(
	[CartEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartDetail_ProductDetailEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_CartDetail_ProductDetailEntityId] ON [dbo].[CartDetail]
(
	[ProductDetailEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ManufacturerEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ManufacturerEntityId] ON [dbo].[Product]
(
	[ManufacturerEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_ProductTypeEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ProductTypeEntityId] ON [dbo].[Product]
(
	[ProductTypeEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_CardVGAEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_CardVGAEntityId] ON [dbo].[ProductDetail]
(
	[CardVGAEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_ColorEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_ColorEntityId] ON [dbo].[ProductDetail]
(
	[ColorEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_CpuEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_CpuEntityId] ON [dbo].[ProductDetail]
(
	[CpuEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_DiscountId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_DiscountId] ON [dbo].[ProductDetail]
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_HardDriveEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_HardDriveEntityId] ON [dbo].[ProductDetail]
(
	[HardDriveEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_ProductEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_ProductEntityId] ON [dbo].[ProductDetail]
(
	[ProductEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_RamEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_RamEntityId] ON [dbo].[ProductDetail]
(
	[RamEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetail_ScreenEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetail_ScreenEntityId] ON [dbo].[ProductDetail]
(
	[ScreenEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetailImage_ImageId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetailImage_ImageId] ON [dbo].[ProductDetailImage]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductDetailImage_ProductDetailId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductDetailImage_ProductDetailId] ON [dbo].[ProductDetailImage]
(
	[ProductDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Serial_BillDetailEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Serial_BillDetailEntityId] ON [dbo].[Serial]
(
	[BillDetailEntityId] ASC
)
WHERE ([BillDetailEntityId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Serial_ProductDetailEntityId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Serial_ProductDetailEntityId] ON [dbo].[Serial]
(
	[ProductDetailEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/27/2024 9:07:14 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Users_UserEntityId] FOREIGN KEY([UserEntityId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Users_UserEntityId]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Users_UserEntityId] FOREIGN KEY([UserEntityId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Users_UserEntityId]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Voucher_VoucherEntityId] FOREIGN KEY([VoucherEntityId])
REFERENCES [dbo].[Voucher] ([Id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Voucher_VoucherEntityId]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill_BillEntityId] FOREIGN KEY([BillEntityId])
REFERENCES [dbo].[Bill] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill_BillEntityId]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Users_UserEntityId] FOREIGN KEY([UserEntityId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Users_UserEntityId]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_Cart_CartEntityId] FOREIGN KEY([CartEntityId])
REFERENCES [dbo].[Cart] ([UserEntityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_Cart_CartEntityId]
GO
ALTER TABLE [dbo].[CartDetail]  WITH CHECK ADD  CONSTRAINT [FK_CartDetail_ProductDetail_ProductDetailEntityId] FOREIGN KEY([ProductDetailEntityId])
REFERENCES [dbo].[ProductDetail] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartDetail] CHECK CONSTRAINT [FK_CartDetail_ProductDetail_ProductDetailEntityId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer_ManufacturerEntityId] FOREIGN KEY([ManufacturerEntityId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer_ManufacturerEntityId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType_ProductTypeEntityId] FOREIGN KEY([ProductTypeEntityId])
REFERENCES [dbo].[ProductType] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType_ProductTypeEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_CardVGA_CardVGAEntityId] FOREIGN KEY([CardVGAEntityId])
REFERENCES [dbo].[CardVGA] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_CardVGA_CardVGAEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Color_ColorEntityId] FOREIGN KEY([ColorEntityId])
REFERENCES [dbo].[Color] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Color_ColorEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_CPU_CpuEntityId] FOREIGN KEY([CpuEntityId])
REFERENCES [dbo].[CPU] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_CPU_CpuEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Discount_DiscountId] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Discount_DiscountId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_HardDrive_HardDriveEntityId] FOREIGN KEY([HardDriveEntityId])
REFERENCES [dbo].[HardDrive] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_HardDrive_HardDriveEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Product_ProductEntityId] FOREIGN KEY([ProductEntityId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Product_ProductEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Ram_RamEntityId] FOREIGN KEY([RamEntityId])
REFERENCES [dbo].[Ram] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Ram_RamEntityId]
GO
ALTER TABLE [dbo].[ProductDetail]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetail_Screen_ScreenEntityId] FOREIGN KEY([ScreenEntityId])
REFERENCES [dbo].[Screen] ([Id])
GO
ALTER TABLE [dbo].[ProductDetail] CHECK CONSTRAINT [FK_ProductDetail_Screen_ScreenEntityId]
GO
ALTER TABLE [dbo].[ProductDetailImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetailImage_Image_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDetailImage] CHECK CONSTRAINT [FK_ProductDetailImage_Image_ImageId]
GO
ALTER TABLE [dbo].[ProductDetailImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductDetailImage_ProductDetail_ProductDetailId] FOREIGN KEY([ProductDetailId])
REFERENCES [dbo].[ProductDetail] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductDetailImage] CHECK CONSTRAINT [FK_ProductDetailImage_ProductDetail_ProductDetailId]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[Serial]  WITH CHECK ADD  CONSTRAINT [FK_Serial_BillDetail_BillDetailEntityId] FOREIGN KEY([BillDetailEntityId])
REFERENCES [dbo].[BillDetail] ([Id])
GO
ALTER TABLE [dbo].[Serial] CHECK CONSTRAINT [FK_Serial_BillDetail_BillDetailEntityId]
GO
ALTER TABLE [dbo].[Serial]  WITH CHECK ADD  CONSTRAINT [FK_Serial_ProductDetail_ProductDetailEntityId] FOREIGN KEY([ProductDetailEntityId])
REFERENCES [dbo].[ProductDetail] ([Id])
GO
ALTER TABLE [dbo].[Serial] CHECK CONSTRAINT [FK_Serial_ProductDetail_ProductDetailEntityId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [PTS_DEV] SET  READ_WRITE 
GO
