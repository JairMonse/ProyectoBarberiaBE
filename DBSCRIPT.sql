USE [master]
GO
/****** Object:  Database [DB_Barberia]    Script Date: 27/1/2024 22:46:55 ******/
CREATE DATABASE [DB_Barberia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Barberia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_Barberia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Barberia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DB_Barberia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_Barberia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Barberia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Barberia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Barberia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Barberia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Barberia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Barberia] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Barberia] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DB_Barberia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Barberia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Barberia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Barberia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Barberia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Barberia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Barberia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Barberia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Barberia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Barberia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Barberia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Barberia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Barberia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Barberia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Barberia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Barberia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Barberia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_Barberia] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Barberia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Barberia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Barberia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Barberia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Barberia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Barberia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Barberia', N'ON'
GO
ALTER DATABASE [DB_Barberia] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_Barberia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_Barberia]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 27/1/2024 22:46:56 ******/
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
/****** Object:  Table [dbo].[Barberos]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barberos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](255) NOT NULL,
	[EspecialidadId] [int] NOT NULL,
	[JornadaId] [int] NOT NULL,
	[Experiencia] [int] NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
	[ImageName] [nvarchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaReg] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Barberos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarritoCliente]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarritoCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [real] NOT NULL,
	[total] [real] NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CarritoCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CitasCliente]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CitasCliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fechaCita] [nvarchar](max) NOT NULL,
	[hora] [nvarchar](max) NOT NULL,
	[nombreBarbero] [nvarchar](255) NOT NULL,
	[nombreCliente] [nvarchar](255) NOT NULL,
	[telefono] [int] NOT NULL,
	[correoE] [nvarchar](255) NOT NULL,
	[tipoServicio] [nvarchar](255) NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_CitasCliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaReg] [datetime2](7) NOT NULL,
	[Contrasena] [nvarchar](50) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaReg] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventarios]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombreProducto] [nvarchar](255) NOT NULL,
	[cantidadProducto] [int] NOT NULL,
	[precio] [real] NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL,
	[categoria] [nvarchar](255) NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Inventarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jornadas]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jornadas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[disponibilidad] [nvarchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaReg] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Jornadas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](255) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaReg] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 27/1/2024 22:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fechaRegistro] [nvarchar](max) NOT NULL,
	[nombreCliente] [nvarchar](255) NOT NULL,
	[nombreProducto] [nvarchar](255) NOT NULL,
	[cantidad] [int] NOT NULL,
	[metodoPago] [nvarchar](255) NOT NULL,
	[fechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231209000633_Initial-V1', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231209192308_Initial-V2', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231224031515_Initial-V3', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231224032345_Initial-V4', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240107035138_Initial_V5', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240107222037_Initial_V6', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240108010220_Initial_V7', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240108172732_Initial_V8', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240117023815_Initial_V9', N'7.0.9')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240128023315_Initial_V10', N'7.0.9')
GO
SET IDENTITY_INSERT [dbo].[Barberos] ON 

INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (4, N'Axel Melten', 3, 3, 5, N'0911223323', N'imagen1.jpg', 1, CAST(N'2023-12-08T19:10:44.3466667' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (5, N'María González', 2, 2, 6, N'0999890909', N'imagen2.jpg', 1, CAST(N'2023-12-08T19:11:22.2200000' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (6, N'Carlos Ramírez', 3, 3, 5, N'0990909223', N'imagen3.jpg', 1, CAST(N'2023-12-08T19:11:42.1600000' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (7, N'Peter Villamar', 1, 1, 8, N'0987654321', N'imagen4.jpg', 1, CAST(N'2023-12-08T19:11:59.0400000' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (16, N'Juan García', 5, 3, 3, N'0988834332', N'imagen5.jpg', 1, CAST(N'2023-12-08T19:13:03.4166667' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (18, N'Ana Martínez', 6, 2, 5, N'0956567877', N'imagen6.jpg', 1, CAST(N'2023-12-08T19:13:24.8433333' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (19, N'Angelo Merchan', 2, 1, 7, N'0988786766', N'imagen7.jpg', 1, CAST(N'2023-12-08T22:04:25.2766667' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (22, N'Juan Mendez', 3, 4, 7, N'0988978900', N'imagen3.jpg', 1, CAST(N'2023-12-09T14:25:10.1933333' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (23, N'Carolina Mendoza', 3, 4, 5, N'0988787888', N'imagen4.jpg', 0, CAST(N'2023-12-09T14:34:21.3566667' AS DateTime2))
INSERT [dbo].[Barberos] ([Id], [Nombres], [EspecialidadId], [JornadaId], [Experiencia], [Telefono], [ImageName], [Estado], [FechaReg]) VALUES (25, N'jair monse', 4, 1, 15, N'0987654321', N'5c40a1589f15d5b3ca52c74fad23015f.jpg', 1, CAST(N'2024-01-06T23:05:24.9500000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Barberos] OFF
GO
SET IDENTITY_INSERT [dbo].[CarritoCliente] ON 

INSERT [dbo].[CarritoCliente] ([Id], [name], [cantidad], [precio], [total], [fechaCreacion]) VALUES (2, N'ert', 5, 4, 20, CAST(N'2024-10-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[CarritoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[CitasCliente] ON 

INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (1, N'2023-06-12', N'3:15 AM', N'David S', N'ert', 1234567890, N'dv4@gmail.com', N'Afeitar', CAST(N'2024-01-07T17:25:53.8318058' AS DateTime2))
INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (2, N'2020-10-19', N'3:15 AM', N'David S', N'ert', 1234567890, N'dv4@gmail.com', N'Afeitar', CAST(N'2024-01-07T17:28:34.5026635' AS DateTime2))
INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (3, N'2023-02-14', N'6:21 AM', N'David S', N'ert', 1234567890, N'dv4@gmail.com', N'Afeitar', CAST(N'2024-01-07T17:30:08.9791766' AS DateTime2))
INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (6, N'2023-05-12', N'8:50 AM', N'William Q', N'editNuevo', 1234567890, N'dv4@gmail.com', N'Afeitar', CAST(N'2024-01-07T17:56:19.6585221' AS DateTime2))
INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (11, N'2023-05-12', N'3:14 AM', N'William Q', N'dav', 1234567890, N'dv4@gmail.com', N'Corte de pelo', CAST(N'2024-01-18T22:13:57.5241655' AS DateTime2))
INSERT [dbo].[CitasCliente] ([Id], [fechaCita], [hora], [nombreBarbero], [nombreCliente], [telefono], [correoE], [tipoServicio], [fechaCreacion]) VALUES (12, N'2024-05-11', N'16:28 PM', N'Jose', N'David', 1122445566, N'wsd@hotmail.com', N'AAAA', CAST(N'2024-01-26T22:20:14.8567977' AS DateTime2))
SET IDENTITY_INSERT [dbo].[CitasCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (1, N'0997877777', N'Castro Miguell', N'Villamar Militao', N'castro@ug.edu.ec', 0, CAST(N'2023-12-23T22:31:22.4400000' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (4, N'0989898878', N'Juan Pedro', N'Castro Perez', N'juan@ug.edu.ec', 0, CAST(N'2023-12-23T22:32:34.7133333' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (5, N'0989898992', N'Carolina Betsy', N'Perez Donoso', N'carolina@ug.edu.ec', 0, CAST(N'2023-12-23T23:44:48.1800000' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (6, N'0989887878', N'lucero', N'ponce', N'434', 0, CAST(N'2023-12-24T00:06:41.4700000' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (7, N'0998999999', N'Ryan Miguel', N'Pedri Podro', N'ryan@ug.edu.ec', 0, CAST(N'2023-12-24T00:11:59.5800000' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (8, N'0999999999', N'qw', N'eww', N'23', 0, CAST(N'2023-12-24T00:50:38.8000000' AS DateTime2), N'', N'')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (12, N'0989888787', N'Katalella', N'Quimiz', N'katalella@gmail.com', 1, CAST(N'2023-12-24T01:17:39.6000000' AS DateTime2), N'kati77', N'kat74')
INSERT [dbo].[Clientes] ([Id], [Cedula], [Nombre], [Apellido], [Correo], [Estado], [FechaReg], [Contrasena], [Usuario]) VALUES (20, N'0987654321', N'karol', N'Miro', N'carol@gmail.com', 1, CAST(N'2023-12-24T00:55:20.5166667' AS DateTime2), N'karol004', N'karol123')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidades] ON 

INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (1, N'Corte de pelo', 1, CAST(N'2023-12-08T19:07:43.8800000' AS DateTime2))
INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (2, N'Afeitado clásico', 1, CAST(N'2023-12-08T19:07:43.8833333' AS DateTime2))
INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (3, N'Diseño de barba', 1, CAST(N'2023-12-08T19:07:43.8833333' AS DateTime2))
INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (4, N'Corte moderno', 1, CAST(N'2023-12-08T19:07:43.8833333' AS DateTime2))
INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (5, N'Afeitado de precisión', 1, CAST(N'2023-12-08T19:07:43.8833333' AS DateTime2))
INSERT [dbo].[Especialidades] ([Id], [Descripcion], [Estado], [FechaReg]) VALUES (6, N'Coloración de cabello', 1, CAST(N'2023-12-08T19:07:43.8833333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventarios] ON 

INSERT [dbo].[Inventarios] ([Id], [nombreProducto], [cantidadProducto], [precio], [descripcion], [categoria], [fechaCreacion]) VALUES (4, N'abc', 8, 33.3, N'aabbcc', N'aseo personal edit', CAST(N'2024-01-15T21:37:33.4554606' AS DateTime2))
INSERT [dbo].[Inventarios] ([Id], [nombreProducto], [cantidadProducto], [precio], [descripcion], [categoria], [fechaCreacion]) VALUES (5, N'cremas afeitar', 8, 45.3, N'crema de afeitar para adulto', N'aseo ABC', CAST(N'2024-01-17T20:58:32.1329548' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Inventarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Jornadas] ON 

INSERT [dbo].[Jornadas] ([Id], [disponibilidad], [Estado], [FechaReg]) VALUES (1, N'Matutina', 1, CAST(N'2023-12-08T19:09:31.0100000' AS DateTime2))
INSERT [dbo].[Jornadas] ([Id], [disponibilidad], [Estado], [FechaReg]) VALUES (2, N'Vespertina', 1, CAST(N'2023-12-08T19:09:31.0100000' AS DateTime2))
INSERT [dbo].[Jornadas] ([Id], [disponibilidad], [Estado], [FechaReg]) VALUES (3, N'Full día', 1, CAST(N'2023-12-08T19:09:31.0133333' AS DateTime2))
INSERT [dbo].[Jornadas] ([Id], [disponibilidad], [Estado], [FechaReg]) VALUES (4, N'Fines de Semana', 1, CAST(N'2023-12-08T19:09:31.0133333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Jornadas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombres], [Username], [Password], [Estado], [FechaReg]) VALUES (1, N'Axel Castro', N'axel09', N'castro@', 1, CAST(N'2023-12-08T19:09:53.0833333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([Id], [fechaRegistro], [nombreCliente], [nombreProducto], [cantidad], [metodoPago], [fechaCreacion]) VALUES (2, N'2024-01-19T05:00:00.000Z', N'Ceras para peinar', N'Navajas y maquinillas de afeitar', 8, N'Paypal', CAST(N'2024-01-15T21:39:46.3540208' AS DateTime2))
INSERT [dbo].[Ventas] ([Id], [fechaRegistro], [nombreCliente], [nombreProducto], [cantidad], [metodoPago], [fechaCreacion]) VALUES (3, N'2024-04-21', N'Oscar', N'Locion para afeitar', 11, N'Visa', CAST(N'2024-01-17T21:02:07.8882299' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
/****** Object:  Index [IX_Barberos_EspecialidadId]    Script Date: 27/1/2024 22:46:56 ******/
CREATE NONCLUSTERED INDEX [IX_Barberos_EspecialidadId] ON [dbo].[Barberos]
(
	[EspecialidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Barberos_JornadaId]    Script Date: 27/1/2024 22:46:56 ******/
CREATE NONCLUSTERED INDEX [IX_Barberos_JornadaId] ON [dbo].[Barberos]
(
	[JornadaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Clientes_Cedula]    Script Date: 27/1/2024 22:46:56 ******/
CREATE NONCLUSTERED INDEX [IX_Clientes_Cedula] ON [dbo].[Clientes]
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Barberos] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO
ALTER TABLE [dbo].[Barberos] ADD  DEFAULT (getdate()) FOR [FechaReg]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (getdate()) FOR [FechaReg]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [Contrasena]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [Usuario]
GO
ALTER TABLE [dbo].[Especialidades] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO
ALTER TABLE [dbo].[Especialidades] ADD  DEFAULT (getdate()) FOR [FechaReg]
GO
ALTER TABLE [dbo].[Jornadas] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO
ALTER TABLE [dbo].[Jornadas] ADD  DEFAULT (getdate()) FOR [FechaReg]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (CONVERT([bit],(1))) FOR [Estado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaReg]
GO
ALTER TABLE [dbo].[Barberos]  WITH CHECK ADD  CONSTRAINT [FK_Barberos_Especialidades_EspecialidadId] FOREIGN KEY([EspecialidadId])
REFERENCES [dbo].[Especialidades] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Barberos] CHECK CONSTRAINT [FK_Barberos_Especialidades_EspecialidadId]
GO
ALTER TABLE [dbo].[Barberos]  WITH CHECK ADD  CONSTRAINT [FK_Barberos_Jornadas_JornadaId] FOREIGN KEY([JornadaId])
REFERENCES [dbo].[Jornadas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Barberos] CHECK CONSTRAINT [FK_Barberos_Jornadas_JornadaId]
GO
USE [master]
GO
ALTER DATABASE [DB_Barberia] SET  READ_WRITE 
GO
