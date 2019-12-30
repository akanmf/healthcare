USE [master]
GO
/****** Object:  Database [HealthCare]    Script Date: 30/12/2019 14:04:03 ******/
CREATE DATABASE [HealthCare]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthCare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HealthCare.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HealthCare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\HealthCare_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HealthCare] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthCare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthCare] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthCare] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthCare] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthCare] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthCare] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthCare] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthCare] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthCare] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthCare] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthCare] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthCare] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthCare] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthCare] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthCare] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthCare] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthCare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthCare] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthCare] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthCare] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthCare] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthCare] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthCare] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthCare] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HealthCare] SET  MULTI_USER 
GO
ALTER DATABASE [HealthCare] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthCare] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthCare] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthCare] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HealthCare] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HealthCare] SET QUERY_STORE = OFF
GO
USE [HealthCare]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 30/12/2019 14:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](500) NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactForm]    Script Date: 30/12/2019 14:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Message] [varchar](5000) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ContactForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Translation]    Script Date: 30/12/2019 14:04:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [varchar](150) NOT NULL,
	[Language] [varchar](10) NOT NULL,
	[Message] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AppUser] ON 
GO
INSERT [dbo].[AppUser] ([Id], [FullName], [Email], [Password]) VALUES (4, N'Mehmet Fatih AKAN', N'akanmf@yahoo.com', N'R0UFcS9qnjP+u96mA7izAfRonRk=')
GO
SET IDENTITY_INSERT [dbo].[AppUser] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactForm] ON 
GO
INSERT [dbo].[ContactForm] ([Id], [Name], [PhoneNumber], [Email], [Message], [CreateDate]) VALUES (1, N'Fatih', N'5544422525', N'akanmf@yahoo.com', N'deneme', CAST(N'2019-10-02T17:54:49.447' AS DateTime))
GO
INSERT [dbo].[ContactForm] ([Id], [Name], [PhoneNumber], [Email], [Message], [CreateDate]) VALUES (2, N'string', N'string', N'string', N'string', CAST(N'2019-10-02T18:15:46.457' AS DateTime))
GO
INSERT [dbo].[ContactForm] ([Id], [Name], [PhoneNumber], [Email], [Message], [CreateDate]) VALUES (3, N'nnnnnnnnnn', N'pppppppp', N'akanmf@yahoo.com', N'mmmmmmmmmmm', CAST(N'2019-10-02T18:39:40.453' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ContactForm] OFF
GO
SET IDENTITY_INSERT [dbo].[Translation] ON 
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (1, N'Hello', N'tr-tr', N'Merhaba')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (2, N'Hello', N'en-us', N'Hello')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (3, N'ReadMore', N'tr-tr', N'Detay')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (4, N'ReadMore', N'en-us', N'Read More')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (5, N'Hello', N'bs', N'Zdravo')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (6, N'Hello', N'ar-sa', N'Ehlen ve Sehlen')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (7, N'Hello', N'es-es', N'Hola')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (8, N'WorkingHours', N'tr-tr', N'Çalisma Saatleri')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (9, N'WorkingHours', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (10, N'WorkingHours', N'en-us', N'Working Hours')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (11, N'WorkingHours', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (12, N'WorkingHours', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (13, N'EmergencyCases', N'tr-tr', N'Acil Durumlar')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (14, N'EmergencyCases', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (15, N'EmergencyCases', N'en-us', N'Emergency Cases')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (16, N'EmergencyCases', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (17, N'EmergencyCases', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (18, N'ReadMore', N'bs', N'dd')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (19, N'ReadMore', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (20, N'ReadMore', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (21, N'Monday', N'tr-tr', N'Pazartesi')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (22, N'Monday', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (23, N'Monday', N'en-us', N'Monday')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (24, N'Monday', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (25, N'Monday', N'es-es', N'Lunes')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (26, N'Friday', N'tr-tr', N'Cuma')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (27, N'Friday', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (28, N'Friday', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (29, N'Friday', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (30, N'Friday', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (31, N'OFFICE_PHONE_NUMBER', N'tr-tr', N'+90 554 443 09 03')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (32, N'OFFICE_PHONE_NUMBER', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (33, N'OFFICE_PHONE_NUMBER', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (34, N'OFFICE_PHONE_NUMBER', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (35, N'OFFICE_PHONE_NUMBER', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (36, N'OFFICE_ADDRESS', N'tr-tr', N'Dumankaya IKON, A3-191, Atasehir / Istanbul')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (37, N'OFFICE_ADDRESS', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (38, N'OFFICE_ADDRESS', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (39, N'OFFICE_ADDRESS', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (40, N'OFFICE_ADDRESS', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (41, N'USEFUL_LINKS', N'tr-tr', N'Faydali Linkler')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (42, N'USEFUL_LINKS', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (43, N'USEFUL_LINKS', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (44, N'USEFUL_LINKS', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (45, N'USEFUL_LINKS', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (46, N'FAQ', N'tr-tr', N'S.S.S.')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (47, N'FAQ', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (48, N'FAQ', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (49, N'FAQ', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (50, N'FAQ', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (51, N'FREE_SERVICES', N'tr-tr', N'Ücretsiz Hizmetler')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (52, N'FREE_SERVICES', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (53, N'FREE_SERVICES', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (54, N'FREE_SERVICES', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (55, N'FREE_SERVICES', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (56, N'ABOUT_US', N'tr-tr', N'Hakkimizda')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (57, N'ABOUT_US', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (58, N'ABOUT_US', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (59, N'ABOUT_US', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (60, N'ABOUT_US', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (61, N'HOME', N'tr-tr', N'Ana Sayfa')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (62, N'HOME', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (63, N'HOME', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (64, N'HOME', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (65, N'HOME', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (66, N'LOGOUT', N'tr-tr', N'Çikis')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (67, N'LOGOUT', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (68, N'LOGOUT', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (69, N'LOGOUT', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (70, N'LOGOUT', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (71, N'REQUEST_AN_APPOINTMENT', N'tr-tr', N'Randevu Alin')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (72, N'REQUEST_AN_APPOINTMENT', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (73, N'REQUEST_AN_APPOINTMENT', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (74, N'REQUEST_AN_APPOINTMENT', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (75, N'REQUEST_AN_APPOINTMENT', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (76, N'SATURDAY', N'tr-tr', N'Cumartesi')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (77, N'SATURDAY', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (78, N'SATURDAY', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (79, N'SATURDAY', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (80, N'SATURDAY', N'es-es', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (81, N'SUNDAY', N'tr-tr', N'Pazar')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (82, N'SUNDAY', N'bs', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (83, N'SUNDAY', N'en-us', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (84, N'SUNDAY', N'ar-sa', N'')
GO
INSERT [dbo].[Translation] ([Id], [Key], [Language], [Message]) VALUES (85, N'SUNDAY', N'es-es', N'')
GO
SET IDENTITY_INSERT [dbo].[Translation] OFF
GO
ALTER TABLE [dbo].[ContactForm] ADD  CONSTRAINT [DF_ContactForm_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
USE [master]
GO
ALTER DATABASE [HealthCare] SET  READ_WRITE 
GO
