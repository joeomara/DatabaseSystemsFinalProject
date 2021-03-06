USE [master]
GO
/****** Object:  Database [CS487]    Script Date: 11/15/2017 8:51:46 PM ******/
CREATE DATABASE [CS487]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CS487', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CS487.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CS487_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CS487_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CS487] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CS487].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CS487] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CS487] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CS487] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CS487] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CS487] SET ARITHABORT OFF 
GO
ALTER DATABASE [CS487] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CS487] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CS487] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CS487] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CS487] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CS487] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CS487] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CS487] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CS487] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CS487] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CS487] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CS487] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CS487] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CS487] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CS487] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CS487] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CS487] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CS487] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CS487] SET  MULTI_USER 
GO
ALTER DATABASE [CS487] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CS487] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CS487] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CS487] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CS487] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CS487]
GO
/****** Object:  Table [dbo].[Bracket]    Script Date: 11/15/2017 8:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bracket](
	[Name] [nvarchar](50) NOT NULL,
	[PointsPerWin] [int] NOT NULL CONSTRAINT [DF_Bracket_PointsPerWin]  DEFAULT ((1)),
	[EventDateTime] [datetime] NOT NULL,
	[GameName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bracket] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BracketParticipants]    Script Date: 11/15/2017 8:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BracketParticipants](
	[BracketName] [nvarchar](50) NOT NULL,
	[ParticipantId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Game]    Script Date: 11/15/2017 8:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Player]    Script Date: 11/15/2017 8:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Id] [uniqueidentifier] NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](25) NOT NULL,
	[LastName] [nvarchar](25) NOT NULL,
	[TeamId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Team]    Script Date: 11/15/2017 8:51:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Wins] [int] NOT NULL CONSTRAINT [DF_Team_Wins]  DEFAULT ((0)),
	[Losses] [int] NOT NULL CONSTRAINT [DF_Team_Losses]  DEFAULT ((0)),
	[Score] [int] NOT NULL CONSTRAINT [DF_Team_Score]  DEFAULT ((0)),
	[GameName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Bracket] ([Name], [PointsPerWin], [EventDateTime], [GameName]) VALUES (N'2017 LCS', 100, CAST(N'2017-12-15 18:00:00.000' AS DateTime), N'League of Legends')
INSERT [dbo].[Bracket] ([Name], [PointsPerWin], [EventDateTime], [GameName]) VALUES (N'2017 SFV Championship', 100, CAST(N'2017-11-30 14:00:00.000' AS DateTime), N'Street Fighter V')
INSERT [dbo].[Bracket] ([Name], [PointsPerWin], [EventDateTime], [GameName]) VALUES (N'2017 Smash Championship', 100, CAST(N'2017-12-10 12:30:00.000' AS DateTime), N'Super Smash Bros.')
INSERT [dbo].[Bracket] ([Name], [PointsPerWin], [EventDateTime], [GameName]) VALUES (N'2017 Winter Championship', 100, CAST(N'2017-12-20 12:30:00.000' AS DateTime), N'Overwatch')
INSERT [dbo].[Bracket] ([Name], [PointsPerWin], [EventDateTime], [GameName]) VALUES (N'2018 Winter Championship', 100, CAST(N'2018-12-20 12:30:00.000' AS DateTime), N'Overwatch')
INSERT [dbo].[BracketParticipants] ([BracketName], [ParticipantId]) VALUES (N'2017 SFV Championship', N'9968986b-6449-4d5f-92ca-c2d454f4079f')
INSERT [dbo].[BracketParticipants] ([BracketName], [ParticipantId]) VALUES (N'2017 SFV Championship', N'9968986b-6449-4d5f-92ca-c2d432f4079d')
INSERT [dbo].[BracketParticipants] ([BracketName], [ParticipantId]) VALUES (N'2017 SFV Championship', N'9123486b-6449-4d5f-93ca-c2d454f4079d')
INSERT [dbo].[BracketParticipants] ([BracketName], [ParticipantId]) VALUES (N'2017 SFV Championship', N'9123486b-1234-4d5f-94ca-c2d454f4079d')
INSERT [dbo].[BracketParticipants] ([BracketName], [ParticipantId]) VALUES (N'2017 SFV Championship', N'9123486b-6449-1234-1337-c2d454f4079d')
INSERT [dbo].[Game] ([Name]) VALUES (N'Counter Strike: Global Offensive')
INSERT [dbo].[Game] ([Name]) VALUES (N'Dota 2')
INSERT [dbo].[Game] ([Name]) VALUES (N'League of Legends')
INSERT [dbo].[Game] ([Name]) VALUES (N'Overwatch')
INSERT [dbo].[Game] ([Name]) VALUES (N'Street Fighter V')
INSERT [dbo].[Game] ([Name]) VALUES (N'Super Smash Bros.')
INSERT [dbo].[Player] ([Id], [DisplayName], [FirstName], [LastName], [TeamId]) VALUES (N'b93c999d-dd5a-4ccf-9e44-c550135ed7b7', N'Fuudo', N'Keita', N'Ai', N'9123486b-1234-4d5f-94ca-c2d454f4079d')
INSERT [dbo].[Player] ([Id], [DisplayName], [FirstName], [LastName], [TeamId]) VALUES (N'503b45ec-adfd-4102-8aa7-c67cc0ab11cb', N'Kazunoko', N'Ryota', N'Inoue', N'9968986b-6449-4d5f-92ca-c2d454f4079f')
INSERT [dbo].[Player] ([Id], [DisplayName], [FirstName], [LastName], [TeamId]) VALUES (N'503b45ed-adfd-4102-8aa7-c67cc0ab11cb', N'Xiao Hai', N'Zhou Jun', N'Zeng', N'9968986b-6449-4d5f-92ca-c2d432f4079d')
INSERT [dbo].[Player] ([Id], [DisplayName], [FirstName], [LastName], [TeamId]) VALUES (N'503b45ef-adfd-4102-8aa7-c67cc0ab11cb', N'Arman', N'Phenom', N'Hanjani', N'9123486b-6449-4d5f-93ca-c2d454f4079d')
INSERT [dbo].[Team] ([Id], [Name], [Wins], [Losses], [Score], [GameName]) VALUES (N'9968986b-6449-4d5f-92ca-c2d432f4079d', N'Method', 24, 3, 500, N'Street Fighter V')
INSERT [dbo].[Team] ([Id], [Name], [Wins], [Losses], [Score], [GameName]) VALUES (N'9123486b-6449-1234-1337-c2d454f4079d', N'Punk', 24, 3, 500, N'Street Fighter V')
INSERT [dbo].[Team] ([Id], [Name], [Wins], [Losses], [Score], [GameName]) VALUES (N'9123486b-6449-4d5f-93ca-c2d454f4079d', N'Team Japan', 24, 3, 500, N'Street Fighter V')
INSERT [dbo].[Team] ([Id], [Name], [Wins], [Losses], [Score], [GameName]) VALUES (N'9123486b-1234-4d5f-94ca-c2d454f4079d', N'Team USA', 24, 3, 500, N'Street Fighter V')
INSERT [dbo].[Team] ([Id], [Name], [Wins], [Losses], [Score], [GameName]) VALUES (N'9968986b-6449-4d5f-92ca-c2d454f4079f', N'SK Gaming', 24, 3, 500, N'Street Fighter V')
ALTER TABLE [dbo].[Bracket]  WITH CHECK ADD  CONSTRAINT [FK_Bracket_Bracket] FOREIGN KEY([GameName])
REFERENCES [dbo].[Game] ([Name])
GO
ALTER TABLE [dbo].[Bracket] CHECK CONSTRAINT [FK_Bracket_Bracket]
GO
ALTER TABLE [dbo].[BracketParticipants]  WITH CHECK ADD  CONSTRAINT [FK_BracketParticipants_Bracket] FOREIGN KEY([BracketName])
REFERENCES [dbo].[Bracket] ([Name])
GO
ALTER TABLE [dbo].[BracketParticipants] CHECK CONSTRAINT [FK_BracketParticipants_Bracket]
GO
ALTER TABLE [dbo].[BracketParticipants]  WITH CHECK ADD  CONSTRAINT [FK_BracketParticipants_Team] FOREIGN KEY([ParticipantId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[BracketParticipants] CHECK CONSTRAINT [FK_BracketParticipants_Team]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Team]
GO
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Game] FOREIGN KEY([GameName])
REFERENCES [dbo].[Game] ([Name])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Game]
GO
USE [master]
GO
ALTER DATABASE [CS487] SET  READ_WRITE 
GO
