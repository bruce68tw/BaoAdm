/****** Object:  Database [Bao]    Script Date: 2022/1/23 下午 02:04:23 ******/
/*
CREATE DATABASE [Bao]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bao', FILENAME = N'C:\Users\bruce\Bao.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bao_log', FILENAME = N'C:\Users\bruce\Bao_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bao].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bao] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bao] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bao] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bao] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bao] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bao] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bao] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bao] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bao] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bao] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bao] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bao] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bao] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bao] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bao] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bao] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bao] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bao] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bao] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bao] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bao] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bao] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bao] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bao] SET  MULTI_USER 
GO
ALTER DATABASE [Bao] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bao] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bao] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bao] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bao] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bao] SET QUERY_STORE = OFF
GO
*/
/****** Object:  Table [dbo].[Attend]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attend](
	[UserId] [varchar](10) NOT NULL,
	[BaoId] [varchar](10) NOT NULL,
	[AttendStatus] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Attend] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[BaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bao]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bao](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[IsBatch] [bit] NOT NULL,
	[IsMove] [bit] NOT NULL,
	[GiftType] [char](1) NOT NULL,
	[GiftName] [nvarchar](100) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[StageCount] [tinyint] NOT NULL,
	[LaunchStatus] [char](10) NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Revised] [datetime] NOT NULL,
 CONSTRAINT [PK_Bao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cms]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cms](
	[Id] [varchar](10) NOT NULL,
	[CmsType] [varchar](10) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Html] [nvarchar](max) NULL,
	[Note] [nvarchar](255) NULL,
	[FileName] [nvarchar](100) NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Reviser] [varchar](10) NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Cms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reply]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply](
	[Id] [varchar](10) NOT NULL,
	[BaoId] [varchar](10) NOT NULL,
	[UserId] [varchar](10) NOT NULL,
	[Reply] [nvarchar](500) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stage]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stage](
	[Id] [varchar](10) NOT NULL,
	[BaoId] [varchar](10) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[AppHint] [nvarchar](100) NULL,
	[CustHint] [nvarchar](100) NULL,
	[Answer] [varchar](22) NOT NULL,
	[Sort] [smallint] NOT NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Account] [varchar](20) NOT NULL,
	[Pwd] [varchar](22) NOT NULL,
	[Status] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserApp]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserApp](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [varchar](100) NULL,
	[Address] [nvarchar](255) NULL,
	[Created] [datetime] NOT NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_UserApp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCust]    Script Date: 2022/1/23 下午 02:04:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCust](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Account] [varchar](30) NOT NULL,
	[Pwd] [varchar](22) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[IsCorp] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_UserCust] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D5V46GGVKA', N'動物園尋寶', CAST(N'2021-12-01T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 1, N'G', N'熊讚布偶', N'', 3, N'0         ', 1, N'C001', CAST(N'2021-12-04T16:33:38.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D5XA7DPSUA', N'文湖線尋寶', CAST(N'2021-12-02T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 1, 1, N'M', N'1000', N'', 3, N'0         ', 1, N'C001', CAST(N'2021-12-04T16:44:56.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D6EEN7TNGA', N'尋寶1', CAST(N'2021-12-15T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 0, N'M', N'500', N'', 0, N'0         ', 1, N'C001', CAST(N'2021-12-13T16:28:42.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D6EENPNYVA', N'尋寶2', CAST(N'2021-12-16T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 0, N'M', N'500', N'', 0, N'0         ', 1, N'C001', CAST(N'2021-12-13T16:28:48.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D6EEP3YG1A', N'尋寶3', CAST(N'2021-12-17T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 0, N'M', N'500', N'', 0, N'0         ', 1, N'C001', CAST(N'2021-12-13T16:28:55.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D6EEPMM36A', N'尋寶4', CAST(N'2021-12-18T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 0, N'M', N'500', N'', 0, N'0         ', 1, N'C001', CAST(N'2021-12-13T16:28:31.000' AS DateTime))
INSERT [dbo].[Bao] ([Id], [Name], [StartTime], [EndTime], [IsBatch], [IsMove], [GiftType], [GiftName], [Note], [StageCount], [LaunchStatus], [Status], [Creator], [Revised]) VALUES (N'D6EEQPGMVA', N'尋寶5', CAST(N'2021-12-19T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 0, 0, N'M', N'500', N'', 0, N'0         ', 1, N'C001', CAST(N'2021-12-13T16:29:13.000' AS DateTime))
GO
INSERT [dbo].[Cms] ([Id], [CmsType], [Title], [Text], [Html], [Note], [FileName], [StartTime], [EndTime], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D655G2BSJA', N'Msg', N'系統維護公告', N'因系統升級，本系統將於2021/12/20 00:00 ~ 01:00 進行停機維護。', NULL, NULL, NULL, CAST(N'2021-12-20T00:00:00.000' AS DateTime), CAST(N'2021-12-21T00:00:00.000' AS DateTime), 1, N'U001', CAST(N'2021-12-08T19:27:48.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Cms] ([Id], [CmsType], [Title], [Text], [Html], [Note], [FileName], [StartTime], [EndTime], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D65626P4TA', N'Msg', N'系統功能異動', N'即日起，個人資料維護Email欄位改為唯讀。', NULL, NULL, NULL, CAST(N'2021-12-20T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 1, N'U001', CAST(N'2021-12-08T19:40:59.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Cms] ([Id], [CmsType], [Title], [Text], [Html], [Note], [FileName], [StartTime], [EndTime], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D65KUEVM4A', N'Card', N'新年賀卡', NULL, N'<p>恭喜新年好!!</p><p><img src="/image/CmsCard/D65KU9XSXA.png"><br></p>', NULL, NULL, CAST(N'2021-12-30T00:00:00.000' AS DateTime), CAST(N'2021-12-31T00:00:00.000' AS DateTime), 1, N'U001', CAST(N'2021-12-09T00:47:43.000' AS DateTime), NULL, NULL)
INSERT [dbo].[Cms] ([Id], [CmsType], [Title], [Text], [Html], [Note], [FileName], [StartTime], [EndTime], [Status], [Creator], [Created], [Reviser], [Revised]) VALUES (N'D65KWJ19RA', N'Card', N'春節賀卡', NULL, N'<p>春節快樂!!</p><p><img src="/image/CmsCard/D65KW4Y59A.jpg"><br></p>', NULL, NULL, CAST(N'2022-01-25T00:00:00.000' AS DateTime), CAST(N'2022-01-27T00:00:00.000' AS DateTime), 1, N'U001', CAST(N'2021-12-09T00:49:05.000' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5VJR9D85A', N'D5V46GGVKA', N'panda.jpg', N'牠的食物', N'竹子', N'm8TrdH3SD96eric3tb_1Xw', 1)
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5VJT4ZGMA', N'D5V46GGVKA', N'map.png', N'東南方向', N'小浣熊', N'5o1o3JVdMjoyjKfOizv25g', 0)
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5XA7DQ7UA', N'D5XA7DPSUA', N'car.jpg', N'站名', N'大安', N'fpcw2DJb1cyUbx0SnqYxTw', 0)
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5XA7DQPEA', N'D5XA7DPSUA', N'food.png', N'餐廳名稱', N'貓大爺', N'ZNZRfpkUV_c1Yv1ohcw33g', 1)
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5XB16D7HA', N'D5V46GGVKA', N'zoo.jpg', N'海報', N'大象', N'4z0QHK4vkFbVQmrqUGQ0MA', 2)
INSERT [dbo].[Stage] ([Id], [BaoId], [FileName], [AppHint], [CustHint], [Answer], [Sort]) VALUES (N'D5XBJERMBA', N'D5XA7DPSUA', N'night.jpg', N'活動名稱', N'夜店', N'pac41t5DOnRKSLIMesHwBA', 2)
GO
INSERT [dbo].[User] ([Id], [Name], [Account], [Pwd], [Status], [IsAdmin]) VALUES (N'D656GB3BFA', N'Peter', N'pp', N'xIP2zoUcns2fuDX_dVFzfA', 1, 0)
INSERT [dbo].[User] ([Id], [Name], [Account], [Pwd], [Status], [IsAdmin]) VALUES (N'U001', N'Alex', N'aa', N'QSS8CpM1wn8IbyS6IHpJEg', 1, 1)
GO
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'A001', N'A001', N'090012345', N'a1@bb.cc', N'Taipei', CAST(N'2021-12-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'A002', N'A002', N'090012346', N'a2@bb.cc', N'Taipei', CAST(N'2021-12-02T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'D6AQ4CD37A', N'尋寶1', N'0912345678', N'aa@bb.cc', N'Taipei', CAST(N'2021-12-11T17:29:38.000' AS DateTime), NULL)
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'D6ARG4R1XA', N'尋寶2', N'0912345678', N'aa@bb.cc', N'Taipei', CAST(N'2021-12-11T17:59:35.000' AS DateTime), NULL)
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'D6AS9YMEJA', N'尋寶1', N'0912345678', N'aa@bb.cc', N'Taipei', CAST(N'2021-12-11T18:17:48.000' AS DateTime), NULL)
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'D6ASCJ59RA', N'尋寶1a', N'0912345678', N'aa@bb.cc', N'Taipei', CAST(N'2021-12-11T18:19:29.000' AS DateTime), CAST(N'2021-12-13T18:49:08.000' AS DateTime))
INSERT [dbo].[UserApp] ([Id], [Name], [Phone], [Email], [Address], [Created], [Revised]) VALUES (N'D7K52P38FA', N'尋寶1a', N'0912345678', N'aa@bb.cc', N'Taipei', CAST(N'2022-01-03T01:07:22.000' AS DateTime), NULL)
GO
INSERT [dbo].[UserCust] ([Id], [Name], [Account], [Pwd], [Phone], [Email], [Address], [IsCorp], [Status], [Created]) VALUES (N'C001', N'Alex', N'aa', N'QSS8CpM1wn8IbyS6IHpJEg', N'091234567', N'aa@bb.cc', N'Taipei', 1, 1, CAST(N'2021-01-01T12:00:00.000' AS DateTime))
INSERT [dbo].[UserCust] ([Id], [Name], [Account], [Pwd], [Phone], [Email], [Address], [IsCorp], [Status], [Created]) VALUES (N'C002', N'Bob', N'bb', N'', N'091234568', N'a2@bb.cc', N'Taipei', 0, 1, CAST(N'2021-12-01T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[Bao] ADD  CONSTRAINT [DF_Bao_LaunchStatus]  DEFAULT ('0') FOR [LaunchStatus]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Pwd]  DEFAULT ('') FOR [Pwd]
GO
ALTER TABLE [dbo].[UserCust] ADD  CONSTRAINT [DF_UserCust_Pwd]  DEFAULT ('') FOR [Pwd]
GO
--ALTER DATABASE [Bao] SET  READ_WRITE 
--GO
