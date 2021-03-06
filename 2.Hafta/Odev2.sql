USE [master]
GO
/****** Object:  Database [ListenASongDb]    Script Date: 6.02.2022 23:02:49 ******/
CREATE DATABASE [ListenASongDb] ON  PRIMARY 
( NAME = N'ListenASongDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\ListenASongDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ListenASongDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\ListenASongDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ListenASongDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ListenASongDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ListenASongDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ListenASongDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ListenASongDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ListenASongDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ListenASongDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ListenASongDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ListenASongDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ListenASongDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ListenASongDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ListenASongDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ListenASongDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ListenASongDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ListenASongDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ListenASongDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ListenASongDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ListenASongDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ListenASongDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ListenASongDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ListenASongDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ListenASongDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ListenASongDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ListenASongDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ListenASongDb] SET  MULTI_USER 
GO
ALTER DATABASE [ListenASongDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ListenASongDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ListenASongDb', N'ON'
GO
USE [ListenASongDb]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] NOT NULL,
	[AlbumName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] NOT NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bands]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bands](
	[BandId] [int] NOT NULL,
	[BandName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Bands] PRIMARY KEY CLUSTERED 
(
	[BandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PaymentDate] [datetime] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayingSongs]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayingSongs](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[SongId] [int] NOT NULL,
 CONSTRAINT [PK_PlayingSongs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists](
	[PlaylistId] [int] NOT NULL,
	[PlaylistName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Singers]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Singers](
	[SingerId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Singers] PRIMARY KEY CLUSTERED 
(
	[SingerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongLyrics']    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongLyrics'](
	[SongLyricsId] [int] NOT NULL,
	[Lyrics] [nvarchar](max) NULL,
 CONSTRAINT [PK_SongLyrics'] PRIMARY KEY CLUSTERED 
(
	[SongLyricsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[AlbumId] [int] NOT NULL,
	[SongTypeId] [int] NOT NULL,
	[SongLyricsId] [int] NOT NULL,
	[SongName] [nvarchar](150) NOT NULL,
	[SongDuration] [int] NOT NULL,
	[ReleaseDate] [datetime] NULL,
 CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongsInPlaylists]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongsInPlaylists](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[PlaylistId] [int] NOT NULL,
	[SongId] [int] NOT NULL,
 CONSTRAINT [PK_SongsInPlaylists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongTypes]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongTypes](
	[SongTypeId] [int] NOT NULL,
	[TypeName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_SongTypes] PRIMARY KEY CLUSTERED 
(
	[SongTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6.02.2022 23:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bands]  WITH CHECK ADD  CONSTRAINT [FK_Bands_Artists] FOREIGN KEY([BandId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Bands] CHECK CONSTRAINT [FK_Bands_Artists]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users]
GO
ALTER TABLE [dbo].[PlayingSongs]  WITH CHECK ADD  CONSTRAINT [FK_PlayingSongs_Songs] FOREIGN KEY([SongId])
REFERENCES [dbo].[Songs] ([SongId])
GO
ALTER TABLE [dbo].[PlayingSongs] CHECK CONSTRAINT [FK_PlayingSongs_Songs]
GO
ALTER TABLE [dbo].[PlayingSongs]  WITH CHECK ADD  CONSTRAINT [FK_PlayingSongs_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[PlayingSongs] CHECK CONSTRAINT [FK_PlayingSongs_Users]
GO
ALTER TABLE [dbo].[Singers]  WITH CHECK ADD  CONSTRAINT [FK_Singers_Artists] FOREIGN KEY([SingerId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Singers] CHECK CONSTRAINT [FK_Singers_Artists]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Albums] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([AlbumId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Albums]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Artists] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Artists]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_SongLyrics'] FOREIGN KEY([SongLyricsId])
REFERENCES [dbo].[SongLyrics'] ([SongLyricsId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_SongLyrics']
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_SongTypes] FOREIGN KEY([SongTypeId])
REFERENCES [dbo].[SongTypes] ([SongTypeId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_SongTypes]
GO
ALTER TABLE [dbo].[SongsInPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_SongsInPlaylists_Playlists] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlists] ([PlaylistId])
GO
ALTER TABLE [dbo].[SongsInPlaylists] CHECK CONSTRAINT [FK_SongsInPlaylists_Playlists]
GO
ALTER TABLE [dbo].[SongsInPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_SongsInPlaylists_Songs] FOREIGN KEY([SongId])
REFERENCES [dbo].[Songs] ([SongId])
GO
ALTER TABLE [dbo].[SongsInPlaylists] CHECK CONSTRAINT [FK_SongsInPlaylists_Songs]
GO
ALTER TABLE [dbo].[SongsInPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_SongsInPlaylists_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[SongsInPlaylists] CHECK CONSTRAINT [FK_SongsInPlaylists_Users]
GO
USE [master]
GO
ALTER DATABASE [ListenASongDb] SET  READ_WRITE 
GO
