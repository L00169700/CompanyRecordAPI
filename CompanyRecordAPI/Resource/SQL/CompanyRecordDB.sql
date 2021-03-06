USE [master]
GO
/****** Object:  Database [CompanyRecordDB]    Script Date: 22/04/2021 19:47:34 ******/
CREATE DATABASE [CompanyRecordDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyRecordDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.RODSQL17\MSSQL\DATA\CompanyRecordDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyRecordDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.RODSQL17\MSSQL\DATA\CompanyRecordDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CompanyRecordDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyRecordDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyRecordDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CompanyRecordDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyRecordDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyRecordDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CompanyRecordDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyRecordDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CompanyRecordDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyRecordDB] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyRecordDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyRecordDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyRecordDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyRecordDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyRecordDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyRecordDB] SET QUERY_STORE = OFF
GO
USE [CompanyRecordDB]
GO
/****** Object:  User [3DReporting]    Script Date: 22/04/2021 19:47:34 ******/
CREATE USER [3DReporting] FOR LOGIN [3DReporting] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/04/2021 19:47:34 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyRecords]    Script Date: 22/04/2021 19:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Exchange] [nvarchar](max) NULL,
	[Ticker] [nvarchar](max) NULL,
	[ISIN] [nvarchar](max) NULL,
	[Website] [nvarchar](max) NULL,
 CONSTRAINT [PK_CompanyRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22/04/2021 19:47:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210419202318_InitialCreate', N'5.0.5')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420120334_Users', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[CompanyRecords] ON 
GO
INSERT [dbo].[CompanyRecords] ([Id], [Name], [Exchange], [Ticker], [ISIN], [Website]) VALUES (1, N'Update Test 1', N'Exchange 1', N'6752', N'BR38668345', N'Test.com')
GO
INSERT [dbo].[CompanyRecords] ([Id], [Name], [Exchange], [Ticker], [ISIN], [Website]) VALUES (2, N'Apple Inc.', N'NASDAQaaaaa', N'AAPL', N'AAE000PAH0038', N'http://www.apple.com')
GO
INSERT [dbo].[CompanyRecords] ([Id], [Name], [Exchange], [Ticker], [ISIN], [Website]) VALUES (3, N'British Airways Plc.', N'Pink Sheets', N'BAIRY', N'BC000PAH0038', N'http://www.test.com')
GO
INSERT [dbo].[CompanyRecords] ([Id], [Name], [Exchange], [Ticker], [ISIN], [Website]) VALUES (4, N'Create Test 1', N'Exchange 1', N'6752', N'JP38668345', N'Test.com')
GO
INSERT [dbo].[CompanyRecords] ([Id], [Name], [Exchange], [Ticker], [ISIN], [Website]) VALUES (5, N'Create Test 1', N'Exchange 1', N'6752', N'CC38668345', N'Test.com')
GO
SET IDENTITY_INSERT [dbo].[CompanyRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'admin', N'admin')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [CompanyRecordDB] SET  READ_WRITE 
GO
