USE [master]
GO
/****** Object:  Database [AutoSphere]    Script Date: 13.03.2023 9:57:19 ******/
CREATE DATABASE [AutoSphere]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AutoSphere', FILENAME = N'D:\sqlll123\MSSQL15.SQLEXPRESS01\MSSQL\DATA\AutoSphere.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AutoSphere_log', FILENAME = N'D:\sqlll123\MSSQL15.SQLEXPRESS01\MSSQL\DATA\AutoSphere_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AutoSphere] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoSphere].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoSphere] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AutoSphere] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AutoSphere] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AutoSphere] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AutoSphere] SET ARITHABORT OFF 
GO
ALTER DATABASE [AutoSphere] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AutoSphere] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AutoSphere] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AutoSphere] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AutoSphere] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AutoSphere] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AutoSphere] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AutoSphere] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AutoSphere] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AutoSphere] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AutoSphere] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AutoSphere] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AutoSphere] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AutoSphere] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AutoSphere] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AutoSphere] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AutoSphere] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AutoSphere] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AutoSphere] SET  MULTI_USER 
GO
ALTER DATABASE [AutoSphere] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AutoSphere] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AutoSphere] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AutoSphere] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AutoSphere] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AutoSphere] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AutoSphere] SET QUERY_STORE = OFF
GO
USE [AutoSphere]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[CarID] [int] NOT NULL,
	[Mark] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Color] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[CountryID] [int] NULL,
	[Cost] [money] NULL,
	[VIN] [nvarchar](50) NULL,
	[DriveID] [int] NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PassNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countrys]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countrys](
	[CountryID] [int] NOT NULL,
	[CountryCode] [nvarchar](50) NULL,
	[CountryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Countrys] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drives]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drives](
	[DriveID] [int] NOT NULL,
	[DriveName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Drives] PRIMARY KEY CLUSTERED 
(
	[DriveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnterHistory]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnterHistory](
	[EnterID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK_EnterHistory] PRIMARY KEY CLUSTERED 
(
	[EnterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[MarkID] [int] NOT NULL,
	[MarkName] [nvarchar](50) NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[MarkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[CarID] [int] NOT NULL,
	[Garanty] [int] NOT NULL,
	[DateOfOrder] [date] NOT NULL,
	[StuffID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[ServID] [int] NOT NULL,
	[Sum] [money] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QR-Codes]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QR-Codes](
	[CodeID] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_QR-Codes] PRIMARY KEY CLUSTERED 
(
	[CodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServID] [int] NOT NULL,
	[ServName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Cost] [money] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ServID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[RoleID] [int] NOT NULL,
	[ZoneID] [int] NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zones]    Script Date: 13.03.2023 9:57:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zones](
	[ZoneID] [int] NOT NULL,
	[ZoneName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Zones] PRIMARY KEY CLUSTERED 
(
	[ZoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (1, N'Audi', N'A3', N'Серебристый-белый', N'Хэтчбек', 1996, 1, 1200000.0000, N'WMI9QD1UJQSWCQQFK0GA', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (2, N'BMW', N'X5', N'Чёрный', N'Внедорожник', 1999, 1, 1500000.0000, N'WMITXMGCH23NKECPUHKD', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (3, N'Mercedes-Benz', N'E-Class', N'Чёрный', N'Седан', 1953, 1, 600000.0000, N'WMIOMYXIBPNJDKCYMUIF', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (4, N'Volkswagen', N'Golf', N'Тёмно-синий', N'Хэтчбек', 1974, 1, 2500000.0000, N'WMI781M2UYC224M39IOP', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (5, N'Porsche', N'Panamera', N'Белый', N'Купе', 2009, 1, 1000000.0000, N'WMI2FTMYT79RWHV1IJXP', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (6, N'Toyota', N'Camry', N'Белый', N'Седан', 1982, 2, 1200000.0000, N'WMICWUO65PJDH4ONVEYD', 3)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (7, N'Honda', N'Civic', N'Голубой', N'Седан', 1969, 2, 1240000.0000, N'WMIGCX9VQHDWQ5W0X69V', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (8, N'Mazda', N'Mazda6', N'Чёрный', N'Седан', 1989, 2, 500000.0000, N'WMI0P1988B6S5DYX2K63', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (9, N'Nissan', N'GT-R', N'Чёрный', N'Купе', 1998, 2, 450000.0000, N'WMI9QZIJEGNMPD8POSO0', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (10, N'Subaru', N'Legacy', N'Белый', N'Универсал', 1964, 2, 300000.0000, N'WMIL2O58AOHRRQKKMLVY', 3)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (11, N'Ford', N'Focus', N'Жёлтый', N'Хэтчбек', 1998, 3, 5000000.0000, N'WMIH05CANB5IGFPDA4Z6', 3)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (12, N'Ford', N'Mustang', N'Жёлтый', N'Купе', 1964, 3, 2000000.0000, N'WMIBIQE6U25DZ20G5BVE', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (13, N'Cadillac', N'Escalade', N'Чёрный', N'Внедорожник', 2014, 3, 3000000.0000, N'WMIM8W6Y642T82266R8E', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (14, N'Jeep', N'Renegade', N'Коричневый', N'Внедорожник', 2000, 3, 500000.0000, N'WMIW950TCINQE3QOD8BN', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (15, N'Toyota', N'Corolla', N'Оранжевый', N'Седан', 2002, 2, 550000.0000, N'WMI4OK5AAWUX1S35ZO2S', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (16, N'Toyota', N'Supra', N'Белый', N'Купе', 2019, 2, 7000000.0000, N'WMI5KM60F0YG6MOC3E8V', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (17, N'Ford', N'Taurus', N'Жёлтый', N'Седан', 2001, 2, 2500000.0000, N'WMI2O6KXW14Q8ADORHAX', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (18, N'Koenigsegg', N'Jesko', N'Синий', N'Купе', 2020, 4, 1000000.0000, N'WMICN5WRY8HDUBRE8G1F', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (19, N'Scania', N'Scania P-series', N'Оранжевый', N'Фургон', 2010, 4, 300000.0000, N'WMI9PBRCZ5SHJW3E98NU', 3)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (20, N'Toyota', N'Camry', N'Красный', N'Седан', 2007, 2, 1500000.0000, N'WMIB2L8ZK2IBATUDN00Z', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (21, N'Mazda', N'Mazda3', N'Красный', N'Купе', 2007, 2, 1000000.0000, N'WMIR4AQ9QVN8VRGAJ65J', 3)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (22, N'Toyota', N'Camry', N'Красный', N'Седан', 2017, 2, 330000.0000, N'WMIIOSLZ87GAYTRS4VE1', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (23, N'Mazda', N'CX-3', N'Белый', N'Кроссовер', 2022, 2, 350000.0000, N'WMITJX7EY59RU7TKRH5R', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (24, N'Mazda', N'MX-30', N'Чёрный', N'Кроссовер', 2003, 2, 300000.0000, N'WMI3M5JHT6L64R2L4962', 2)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (25, N'Ford', N'Edge', N'Белый', N'Внедорожник', 2000, 3, 2000000.0000, N'WMICPCTPSE8N7ID9YT6F', 1)
INSERT [dbo].[Cars] ([CarID], [Mark], [Model], [Color], [Type], [Year], [CountryID], [Cost], [VIN], [DriveID]) VALUES (26, N'Renault', N'Logan', N'Белый', N'Седан', 1999, 6, 1200000.0000, N'WMIW550TCINQE2HOP8BN', 2)
GO
INSERT [dbo].[Clients] ([ClientID], [FirstName], [MiddleName], [LastName], [PhoneNumber], [Email], [PassNumber]) VALUES (1, N'Дмитрий', N'Комаров', N'Александрович', N'79858039147', N'casto@mail.ru', N'4623202322')
INSERT [dbo].[Clients] ([ClientID], [FirstName], [MiddleName], [LastName], [PhoneNumber], [Email], [PassNumber]) VALUES (2, N'Андрей', N'Юдин', N'Олегович', N'79119024455', N'yd@mail.ru', N'4616220392')
INSERT [dbo].[Clients] ([ClientID], [FirstName], [MiddleName], [LastName], [PhoneNumber], [Email], [PassNumber]) VALUES (3, N'Алёна', N'Маркова', N'Олеговна', N'79126336766', N'olegovna@mail.ru', N'4616245031')
GO
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (1, N'GE', N'Germany')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (2, N'JP', N'Japan')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (3, N'US', N'United States')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (4, N'SW', N'Sweden')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (5, N'IT', N'Italy')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (6, N'FR', N'France')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (7, N'UK', N'United Kingdom')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (8, N'IN', N'India')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (9, N'ML', N'Malaysia')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (10, N'CN', N'China')
INSERT [dbo].[Countrys] ([CountryID], [CountryCode], [CountryName]) VALUES (11, N'SK', N'South Korea')
GO
INSERT [dbo].[Drives] ([DriveID], [DriveName]) VALUES (1, N'Передний')
INSERT [dbo].[Drives] ([DriveID], [DriveName]) VALUES (2, N'Задний')
INSERT [dbo].[Drives] ([DriveID], [DriveName]) VALUES (3, N'Полный')
GO
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (1, 1, CAST(N'2023-03-11' AS Date))
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (2, 1, CAST(N'2023-03-12' AS Date))
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (3, 2, CAST(N'2023-03-13' AS Date))
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (4, 2, CAST(N'2023-03-14' AS Date))
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (5, 3, CAST(N'2023-03-15' AS Date))
INSERT [dbo].[EnterHistory] ([EnterID], [UserID], [Date]) VALUES (6, 1, CAST(N'2023-03-16' AS Date))
GO
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (1, N'Audi', 1)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (2, N'BMW', 1)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (3, N'Mercedes-Benz', 1)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (4, N'Volkswagen', 1)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (5, N'Porsche', 1)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (6, N'Toyota', 2)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (7, N'Honda', 2)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (8, N'Mazda', 2)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (9, N'Nissan', 2)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (10, N'Subaru', 2)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (11, N'Chevrolet', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (12, N'Ford', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (13, N'Cadillac', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (14, N'Jeep', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (15, N'Tesla', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (16, N'Volvo', 4)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (17, N'Saab', 4)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (18, N'Koenigsegg', 4)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (19, N'Scania', 4)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (20, N'Hennessey', 3)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (21, N'Lamborghini', 5)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (22, N'Ferrari', 5)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (23, N'Maserati', 5)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (24, N'Alfa Romeo', 5)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (25, N'Bugatti', 6)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (26, N'Renault', 6)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (27, N'Peugeot', 6)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (28, N'Citroën', 6)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (29, N'Aston Martin', 7)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (30, N'Bentley', 7)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (31, N'Jaguar', 7)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (32, N'Rolls-Royce', 7)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (33, N'McLaren', 7)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (34, N'Hyundai', 11)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (35, N'Kia', 11)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (36, N'Genesis', 11)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (37, N'SsangYong', 11)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (38, N'Mahindra', 8)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (39, N'Tata Motors', 8)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (40, N'Proton', 9)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (41, N'Perodua', 9)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (42, N'Geely', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (43, N'BYD', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (44, N'Chery', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (45, N'Brilliance', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (46, N'FAW', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (47, N'Dongfeng', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (48, N'Great Wall', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (49, N'Lifan', 10)
INSERT [dbo].[Marks] ([MarkID], [MarkName], [CountryID]) VALUES (50, N'Zotye', 10)
GO
INSERT [dbo].[Orders] ([OrderID], [CarID], [Garanty], [DateOfOrder], [StuffID], [ClientID], [ServID], [Sum]) VALUES (1, 3, 5, CAST(N'2023-03-10' AS Date), 1, 1, 2, 700000.0000)
INSERT [dbo].[Orders] ([OrderID], [CarID], [Garanty], [DateOfOrder], [StuffID], [ClientID], [ServID], [Sum]) VALUES (2, 1, 5, CAST(N'2023-02-09' AS Date), 3, 2, 1, 1000000.0000)
INSERT [dbo].[Orders] ([OrderID], [CarID], [Garanty], [DateOfOrder], [StuffID], [ClientID], [ServID], [Sum]) VALUES (3, 2, 5, CAST(N'2023-01-04' AS Date), 3, 3, 4, 1500000.0000)
GO
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Менеджер')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Консультант')
GO
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (1, N'кредитование', N'', 3000.0000)
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (2, N'обмен', N'', 2500.0000)
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (3, N'гарантийное обслуживание', N'', 3000.0000)
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (4, N'техобслуживание', N'', 5000.0000)
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (5, N'покупка за наличные', N'', 1000.0000)
INSERT [dbo].[Services] ([ServID], [ServName], [Description], [Cost]) VALUES (6, N'тест-драйв', N'', 5000.0000)
GO
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (1, N'Иван', N'Комаров', N'Николаевич', CAST(N'1997-07-17' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (2, N'Даниил', N'Козлов', N'Алексеевич', CAST(N'1994-03-29' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (3, N'Валентина', N'Морозова', N'Викторовна', CAST(N'1992-12-06' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (4, N'Дарья', N'Лебедева', N'Николаевна', CAST(N'1989-09-28' AS Date), 1, 2)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (5, N'Татьяна', N'Савицкая', N'Сергеевна', CAST(N'1987-08-02' AS Date), 2, 2)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (6, N'Юлия', N'Макарова', N'Викторовна', CAST(N'1991-05-11' AS Date), 2, 2)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (7, N'Татьяна', N'Новикова', N'Олеговна', CAST(N'1988-02-01' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (8, N'Егор', N'Зайцев', N'Дмитриевич', CAST(N'1996-11-19' AS Date), 2, 3)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (9, N'Виктор', N'Иванов', N'Олегович', CAST(N'1998-06-07' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (10, N'Денис', N'Соколов', N'Александрович', CAST(N'1993-03-24' AS Date), 2, 1)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (11, N'Никита', N'Лебедев', N'Викторович', CAST(N'1984-12-10' AS Date), 2, 3)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (12, N'Сергей', N'Сергеев', N'Романович', CAST(N'1986-08-08' AS Date), 2, 3)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (13, N'Антон', N'Баженов', N'Валентинович', CAST(N'1983-01-14' AS Date), 1, 4)
INSERT [dbo].[Staff] ([StaffID], [FirstName], [MiddleName], [LastName], [DateOfBirth], [RoleID], [ZoneID]) VALUES (14, N'Дмитрий', N'Смирнов', N'Юрьевич', CAST(N'1985-09-03' AS Date), 1, 4)
GO
INSERT [dbo].[Users] ([UserID], [Login], [Password], [RoleID]) VALUES (1, N'Masaru123', N'pass123', 1)
INSERT [dbo].[Users] ([UserID], [Login], [Password], [RoleID]) VALUES (2, N'Komarov321', N'komar123', 2)
INSERT [dbo].[Users] ([UserID], [Login], [Password], [RoleID]) VALUES (3, N'Kalash12345', N'K12345', 3)
INSERT [dbo].[Users] ([UserID], [Login], [Password], [RoleID]) VALUES (4, N'sav', N'S123321', 1)
GO
INSERT [dbo].[Zones] ([ZoneID], [ZoneName]) VALUES (1, N'Торговый зал')
INSERT [dbo].[Zones] ([ZoneID], [ZoneName]) VALUES (2, N'Складское помещение')
INSERT [dbo].[Zones] ([ZoneID], [ZoneName]) VALUES (3, N'Кассовая зона')
INSERT [dbo].[Zones] ([ZoneID], [ZoneName]) VALUES (4, N'Демонстрационный зал')
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Drives] FOREIGN KEY([DriveID])
REFERENCES [dbo].[Drives] ([DriveID])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Drives]
GO
ALTER TABLE [dbo].[Countrys]  WITH CHECK ADD  CONSTRAINT [FK_Countrys_Cars] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Cars] ([CarID])
GO
ALTER TABLE [dbo].[Countrys] CHECK CONSTRAINT [FK_Countrys_Cars]
GO
ALTER TABLE [dbo].[EnterHistory]  WITH CHECK ADD  CONSTRAINT [FK_EnterHistory_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[EnterHistory] CHECK CONSTRAINT [FK_EnterHistory_Users]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Countrys] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countrys] ([CountryID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Countrys]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Cars] FOREIGN KEY([CarID])
REFERENCES [dbo].[Cars] ([CarID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Cars]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Services] FOREIGN KEY([ServID])
REFERENCES [dbo].[Services] ([ServID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Services]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Staff] FOREIGN KEY([StuffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Staff]
GO
ALTER TABLE [dbo].[QR-Codes]  WITH CHECK ADD  CONSTRAINT [FK_QR-Codes_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[QR-Codes] CHECK CONSTRAINT [FK_QR-Codes_Orders]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Roles]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Zones] FOREIGN KEY([ZoneID])
REFERENCES [dbo].[Zones] ([ZoneID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Zones]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
USE [master]
GO
ALTER DATABASE [AutoSphere] SET  READ_WRITE 
GO
