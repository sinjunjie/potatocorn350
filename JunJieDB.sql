USE [master]
GO
/****** Object:  Database [JunjieDB]    Script Date: 8/6/2016 4:41:06 AM ******/
CREATE DATABASE [JunjieDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JunjieDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JunjieDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JunjieDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JunjieDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JunjieDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JunjieDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JunjieDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JunjieDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JunjieDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JunjieDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JunjieDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [JunjieDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JunjieDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JunjieDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JunjieDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JunjieDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JunjieDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JunjieDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JunjieDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JunjieDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JunjieDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JunjieDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JunjieDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JunjieDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JunjieDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JunjieDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JunjieDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JunjieDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JunjieDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JunjieDB] SET RECOVERY FULL 
GO
ALTER DATABASE [JunjieDB] SET  MULTI_USER 
GO
ALTER DATABASE [JunjieDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JunjieDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JunjieDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JunjieDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [JunjieDB]
GO
/****** Object:  User [swen]    Script Date: 8/6/2016 4:41:06 AM ******/
CREATE USER [swen] FOR LOGIN [swen] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [root]    Script Date: 8/6/2016 4:41:06 AM ******/
CREATE USER [root] FOR LOGIN [root] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [swen]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [swen]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [swen]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [swen]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [swen]
GO
ALTER ROLE [db_datareader] ADD MEMBER [swen]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [swen]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[isAdmin] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CreditCard]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CreditCard](
	[creditcardId] [int] IDENTITY(1,1) NOT NULL,
	[creditCardNumber] [nvarchar](100) NOT NULL,
	[creditCardHolderName] [nvarchar](100) NOT NULL,
	[creditCardExpiration] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CreditCard] PRIMARY KEY CLUSTERED 
(
	[creditcardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Duty]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duty](
	[dutyId] [int] IDENTITY(1,1) NOT NULL,
	[dutyType] [nchar](40) NOT NULL,
 CONSTRAINT [PK_Duty_1] PRIMARY KEY CLUSTERED 
(
	[dutyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guest]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[guestId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[phoneNum] [int] NOT NULL,
	[email] [nvarchar](50) NULL,
	[guestAddress] [nvarchar](100) NOT NULL,
	[country] [nvarchar](50) NULL,
	[numberOfAdult] [int] NULL,
	[numberOfChildren] [int] NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[guestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelStaff]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelStaff](
	[staffId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[bankAccountNumber] [nvarchar](100) NOT NULL,
	[staffAddress] [nvarchar](100) NOT NULL,
	[phoneNumber] [int] NOT NULL,
	[dutyId] [int] NOT NULL,
	[accountId] [int] NOT NULL,
 CONSTRAINT [PK_HotelStaff] PRIMARY KEY CLUSTERED 
(
	[staffId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[invoiceId] [int] NOT NULL,
	[paymentType] [nchar](40) NOT NULL,
	[guestId] [int] NOT NULL,
	[reservationId] [int] NOT NULL,
	[creditCardId] [int] IDENTITY(1,1) NOT NULL,
	[amount] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[invoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[reservationId] [int] IDENTITY(1,1) NOT NULL,
	[guestId] [int] NULL,
	[dateStart] [datetime] NOT NULL,
	[dateEnd] [datetime] NOT NULL,
	[numberOfAdult] [int] NOT NULL,
	[numberOfChildren] [int] NOT NULL,
	[additionalRemarks] [nchar](100) NOT NULL,
	[roomId] [int] NOT NULL,
 CONSTRAINT [PK_Reservation_1] PRIMARY KEY CLUSTERED 
(
	[reservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 8/6/2016 4:41:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[roomId] [int] IDENTITY(1,1) NOT NULL,
	[roomType] [nvarchar](100) NOT NULL,
	[roomPrice] [decimal](10, 2) NOT NULL,
	[roomHeader] [nvarchar](2) NULL,
	[roomNumber] [nvarchar](2) NULL,
	[roomStatus] [nvarchar](20) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[roomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (1, N'jessica', N'12345678', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (2, N'taylor', N'87654321', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (3, N'wanwan', N'wantwo', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (4, N'swift', N'potatoisgood', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (5, N'apple', N'iloveturtles', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (7, N'wang', N'besthotelinsingapore', 1)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (8, N'hello', N'123', 1)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (9, N'Wang', N'WangWang', 1)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (10, N'awdas', N'asdas', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (12, N'junjie', N'121', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (14, N'nigel', N'nigel', 0)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (16, N'MrWang', N'MrWang', 1)
INSERT [dbo].[Account] ([accountId], [username], [password], [isAdmin]) VALUES (17, N'MrWang', N'MrWang', 1)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[CreditCard] ON 

INSERT [dbo].[CreditCard] ([creditcardId], [creditCardNumber], [creditCardHolderName], [creditCardExpiration]) VALUES (6, N'454-212-767-3', N'jame', N'16/04/2016')
INSERT [dbo].[CreditCard] ([creditcardId], [creditCardNumber], [creditCardHolderName], [creditCardExpiration]) VALUES (7, N'12345678876543121', N'Fat', N'12 2020')
INSERT [dbo].[CreditCard] ([creditcardId], [creditCardNumber], [creditCardHolderName], [creditCardExpiration]) VALUES (8, N'464-979-644-6', N'jackie', N'26/09/2018')
INSERT [dbo].[CreditCard] ([creditcardId], [creditCardNumber], [creditCardHolderName], [creditCardExpiration]) VALUES (9, N'786-787-868-8', N'tipol', N'16/02/2019')
INSERT [dbo].[CreditCard] ([creditcardId], [creditCardNumber], [creditCardHolderName], [creditCardExpiration]) VALUES (10, N'454-090-343-3', N'nigguh', N'17/04/2020')
SET IDENTITY_INSERT [dbo].[CreditCard] OFF
SET IDENTITY_INSERT [dbo].[Duty] ON 

INSERT [dbo].[Duty] ([dutyId], [dutyType]) VALUES (1, N'GM-General Maintainance                 ')
INSERT [dbo].[Duty] ([dutyId], [dutyType]) VALUES (2, N'RM-Room Maintainance                    ')
INSERT [dbo].[Duty] ([dutyId], [dutyType]) VALUES (3, N'EM-Estate Maintainance                  ')
INSERT [dbo].[Duty] ([dutyId], [dutyType]) VALUES (4, N'Securitiiiii                            ')
SET IDENTITY_INSERT [dbo].[Duty] OFF
SET IDENTITY_INSERT [dbo].[Guest] ON 

INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (2, N'Dinner', N'is served!', 91234321, N'haha@lol.com', N'Blk 261, Pasir Ris Drive 6', N'Malaysia', 2, 0)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (3, N'Fat', N'Belly', 97283681, N'bellyfat@hotmail.com', N'123 Kowloon Road', N'Hong Kong', 2, 2)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (4, N'Jack', N'Danial', 87392683, N'jackdanial@hotmail.com', N'Blk 783, Eunos Crescent', N'California', 1, 0)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (5, N'Hardcore', N'Drinker', 97392391, N'hardcoredrinker@hotmail.com', N'Blk 124, Tech Whye Lane', N'Sick my Duck', 3, 0)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (6, N'Putang', N'ina', 1111124444, N'mo', N'bobo', N'Your mother', 2, 0)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (7, N'Nigel', N'swift', 999, N'lol', N'lol', N'your mother', 2, 1)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (8, N'Nigel', N'Yee', 91234213, N'nigel@yee.com', N'1337 boom', N'Singapore', NULL, NULL)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (9, N'hello', N'im new', 12345678, N'new@guy.com', N'new road #12-345', N'New country', NULL, NULL)
INSERT [dbo].[Guest] ([guestId], [firstName], [lastName], [phoneNum], [email], [guestAddress], [country], [numberOfAdult], [numberOfChildren]) VALUES (10, N'Jon', N'Snow', 9999999, N'IKnow@Nothing.com', N'Westeros', N'Winterfell', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Guest] OFF
SET IDENTITY_INSERT [dbo].[HotelStaff] ON 

INSERT [dbo].[HotelStaff] ([staffId], [firstName], [lastName], [dateOfBirth], [bankAccountNumber], [staffAddress], [phoneNumber], [dutyId], [accountId]) VALUES (24, N'Edmundi', N'Chow', CAST(0xC3240B00 AS Date), N'472-421411-2', N'Blk 21,Marine', 92213123, 1, 1)
INSERT [dbo].[HotelStaff] ([staffId], [firstName], [lastName], [dateOfBirth], [bankAccountNumber], [staffAddress], [phoneNumber], [dutyId], [accountId]) VALUES (25, N'Niggaf', N'Higgal', CAST(0xCCAC0A00 AS Date), N'42141-4141-1', N'Blk 27, Punggol Ave', 878732334, 2, 2)
SET IDENTITY_INSERT [dbo].[HotelStaff] OFF
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (1, N'cash                                    ', 1, 1, 3, CAST(999.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (2, N'credit                                  ', 2, 2, 12, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (3, N'credit                                  ', 1, 1, 14, CAST(120.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (4, N'cash                                    ', 3, 3, 15, CAST(1337.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (5, N'Credit card                             ', 4, 2, 17, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (6, N'Cash                                    ', 2, 1, 18, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Invoice] ([invoiceId], [paymentType], [guestId], [reservationId], [creditCardId], [amount]) VALUES (7, N'Cash                                    ', 3, 3, 19, CAST(50.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (1, 2, CAST(0x0000A69600000000 AS DateTime), CAST(0x0000A6B100000000 AS DateTime), 3, 1, N'King size bed                                                                                       ', 7)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (2, 3, CAST(0x0000A60100000000 AS DateTime), CAST(0x0000A60700000000 AS DateTime), 2, 0, N'King size bed                                                                                       ', 2)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (3, 4, CAST(0x0000A5DB00000000 AS DateTime), CAST(0x0000A5DF00000000 AS DateTime), 2, 2, N'Queen size bed                                                                                      ', 3)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (4, 5, CAST(0x0000A61D00000000 AS DateTime), CAST(0x0000A62B00000000 AS DateTime), 4, 4, N'King size bed                                                                                       ', 5)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (5, 2, CAST(0x0000A620001DEEE4 AS DateTime), CAST(0x0000A627001DEEE4 AS DateTime), 1, 2, N'Test Remarks                                                                                        ', 14)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (6, 5, CAST(0x0000A620001DEEE4 AS DateTime), CAST(0x0000A627001DEEE4 AS DateTime), 9, 52, N'Ayy                                                                                                 ', 56)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (7, 5, CAST(0x0000A620001DEEE4 AS DateTime), CAST(0x0000A627001DEEE4 AS DateTime), 9, 52, N'Ayy                                                                                                 ', 56)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (8, 9, CAST(0x0000A61F0024B5BE AS DateTime), CAST(0x0000A6280024B544 AS DateTime), 1, 4, N'None                                                                                                ', 8)
INSERT [dbo].[Reservation] ([reservationId], [guestId], [dateStart], [dateEnd], [numberOfAdult], [numberOfChildren], [additionalRemarks], [roomId]) VALUES (9, 5, CAST(0x0000A61D0027C1BC AS DateTime), CAST(0x0000A62B0027C1BC AS DateTime), 2, 2, N'Test                                                                                                ', 2)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (2, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'01', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (3, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'02', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (5, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'03', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (6, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'04', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (7, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'05', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (8, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'06', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (11, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'07', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (12, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'08', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (14, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'09', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (16, N'Standard Single', CAST(50.00 AS Decimal(10, 2)), N'2', N'10', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (17, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'01', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (20, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'02', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (22, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'03', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (23, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'04', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (24, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'05', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (25, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'06', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (26, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'07', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (27, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'08', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (28, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'09', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (29, N'Deluxe Single', CAST(90.00 AS Decimal(10, 2)), N'3', N'10', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (30, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'01', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (33, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'02', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (34, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'03', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (35, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'04', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (36, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'05', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (37, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'06', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (38, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'07', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (39, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'08', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (40, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'09', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (41, N'Standard Double', CAST(150.00 AS Decimal(10, 2)), N'4', N'10', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (42, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'01', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (43, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'02', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (44, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'03', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (45, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'04', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (46, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'05', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (47, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'06', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (48, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'07', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (49, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'08', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (50, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'09', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (52, N'Deluxe Double', CAST(230.00 AS Decimal(10, 2)), N'5', N'10', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (53, N'Premium Suite', CAST(400.00 AS Decimal(10, 2)), N'6', N'01', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (54, N'Premium Suite', CAST(400.00 AS Decimal(10, 2)), N'6', N'02', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (55, N'Premium Suite', CAST(400.00 AS Decimal(10, 2)), N'6', N'03', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (56, N'Premium Suite', CAST(400.00 AS Decimal(10, 2)), N'6', N'04', N'Available')
INSERT [dbo].[Room] ([roomId], [roomType], [roomPrice], [roomHeader], [roomNumber], [roomStatus]) VALUES (57, N'Premium Suite', CAST(400.00 AS Decimal(10, 2)), N'6', N'05', N'Available')
SET IDENTITY_INSERT [dbo].[Room] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Account] FOREIGN KEY([accountId])
REFERENCES [dbo].[Account] ([accountId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Account]
GO
ALTER TABLE [dbo].[HotelStaff]  WITH CHECK ADD  CONSTRAINT [FK_HotelStaff_Account] FOREIGN KEY([accountId])
REFERENCES [dbo].[Account] ([accountId])
GO
ALTER TABLE [dbo].[HotelStaff] CHECK CONSTRAINT [FK_HotelStaff_Account]
GO
ALTER TABLE [dbo].[HotelStaff]  WITH CHECK ADD  CONSTRAINT [FK_HotelStaff_Duty] FOREIGN KEY([dutyId])
REFERENCES [dbo].[Duty] ([dutyId])
GO
ALTER TABLE [dbo].[HotelStaff] CHECK CONSTRAINT [FK_HotelStaff_Duty]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Guest] FOREIGN KEY([guestId])
REFERENCES [dbo].[Guest] ([guestId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Guest]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room] FOREIGN KEY([roomId])
REFERENCES [dbo].[Room] ([roomId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room]
GO
USE [master]
GO
ALTER DATABASE [JunjieDB] SET  READ_WRITE 
GO
