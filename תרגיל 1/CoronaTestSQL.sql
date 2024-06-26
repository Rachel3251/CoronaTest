USE [master]
GO
/****** Object:  Database [CoronaDB]    Script Date: 28/03/2024 18:23:07 ******/
CREATE DATABASE [CoronaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoronaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CoronaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoronaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CoronaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CoronaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoronaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoronaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CoronaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CoronaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CoronaDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CoronaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoronaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoronaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoronaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CoronaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CoronaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoronaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CoronaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoronaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CoronaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoronaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoronaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoronaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoronaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoronaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoronaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoronaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CoronaDB] SET  MULTI_USER 
GO
ALTER DATABASE [CoronaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoronaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoronaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoronaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CoronaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CoronaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CoronaDB] SET QUERY_STORE = OFF
GO
USE [CoronaDB]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/03/2024 18:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[ID] [nvarchar](9) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AddressCity] [nvarchar](50) NULL,
	[AddressStreet] [nvarchar](50) NULL,
	[AddressNumber] [nvarchar](50) NULL,
	[DateOfBirth] [nvarchar](50) NULL,
	[Phone] [nvarchar](10) NULL,
	[MobilePhone] [nvarchar](10) NULL,
	[RecoveryDate] [nvarchar](50) NULL,
	[PositiveResultDate] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vaccinations]    Script Date: 28/03/2024 18:23:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vaccinations](
	[VaccinationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[VaccinationDate] [date] NULL,
	[VaccineManufacturer] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[VaccinationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (15, N'123456789', N'Gila', N'Tenenboim', N'Bnei Brak', N'Even Gvirol', N'24', N'Feb  9 2017 12:00AM', N'0556720873', N'0556735789', N'Feb  9 2017 12:00AM', N'Feb  9 2017 12:00AM')
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (17, N'111222333', N'Moshe', N'Tenenboim', N'Bnie Brak', N'Even Gvirol', N'24', N'Mar  6 2024 12:00AM', N'0556720873', N'0556735789', N'Feb  9 2017 12:00AM', N'Feb  9 2017 12:00AM')
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (21, N'212282677', N'Rivka', N'coen', N'Bnei Brak', N'Yeuda Halevi', N'13', N'Feb 27 2024 12:00AM', N'0556720873', N'1231231231', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (23, N'123454321', N'Gila', N'טננבוים', N'Tel Aviv', N'Arlozorov', N'1', N'Mar  6 2013 12:00AM', N'1111111111', N'1111111111', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (24, N'123123123', N'Efrat', N'Chaim', N'Yaffo', N'Y', N'12', N'Dec 12 2000 12:00AM', N'0556720873', N'1231231231', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (25, N'342134213', N'Shoshi', N'baron', N'Bnei Brak', N'Zchria', N'11', N'Dec 12 2022 12:00AM', N'1234567890', N'1111111111', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (26, N'123451234', N'Miri', N'Werchner', N'BB', N'RA', N'158', N'Dec 12 2002 12:00AM', N'0583287204', N'0548453710', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (27, N'123456787', N'Ayala', N'Wormsser', N'BB', N'TH', N'13', N'Mar 11 2024 12:00AM', N'0533173469', N'016189360', N'Mar 12 2024 12:00AM', N'Mar 19 2024 12:00AM')
INSERT [dbo].[Users] ([UserID], [ID], [FirstName], [LastName], [AddressCity], [AddressStreet], [AddressNumber], [DateOfBirth], [Phone], [MobilePhone], [RecoveryDate], [PositiveResultDate]) VALUES (28, N'987654321', N'רחל', N'כהן', N'בני ברק', N'ברגמן', N'10', N'Mar 12 2024 12:00AM', N'1212121212', N'1111111111', N'Mar 19 2024 12:00AM', N'Mar 20 2024 12:00AM')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Vaccinations] ON 

INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (14, 15, CAST(N'2024-03-06' AS Date), N'1')
INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (15, 15, CAST(N'2024-03-20' AS Date), N'd')
INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (21, 17, CAST(N'2024-03-14' AS Date), N'd')
INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (22, 17, CAST(N'2024-03-10' AS Date), N'd')
INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (23, 17, CAST(N'2024-03-04' AS Date), N'd')
INSERT [dbo].[Vaccinations] ([VaccinationID], [UserID], [VaccinationDate], [VaccineManufacturer]) VALUES (24, 17, CAST(N'2024-02-27' AS Date), N'd')
SET IDENTITY_INSERT [dbo].[Vaccinations] OFF
GO
ALTER TABLE [dbo].[Vaccinations]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [CoronaDB] SET  READ_WRITE 
GO
