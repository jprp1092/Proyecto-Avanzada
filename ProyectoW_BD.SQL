CREATE DATABASE ProyectoW_BD
USE [ProyectoW_BD]
GO
/****** Object:  Table [dbo].[BITACORA_CONTACTO]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORA_CONTACTO](
	[ID_MENSAJE] [int] IDENTITY(1,1) NOT NULL,
	[TIPO_MENSAJE] [varchar](50) NOT NULL,
	[EMISOR] [varchar](100) NOT NULL,
	[CORREO_EMISOR] [varchar](250) NOT NULL,
	[CUERPO_CORREO] [varchar](max) NOT NULL,
	[FECHA_REGISTRO] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_MENSAJE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BITACORAS]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BITACORAS](
	[ConsecutivoError] [bigint] IDENTITY(1,1) NOT NULL,
	[DescripcionError] [varchar](max) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Origen] [varchar](100) NOT NULL,
 CONSTRAINT [PK_BITACORAS] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CARRITO]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CARRITO](
	[IdCarrito] [bigint] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [bigint] NOT NULL,
	[ConsecutivoHospedaje] [int] NOT NULL,
	[CantNoches] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[FechaSalida] [datetime] NOT NULL,
 CONSTRAINT [PK_CARRITO] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE](
	[IdDetalle] [bigint] NOT NULL,
	[IdMaestro] [bigint] NOT NULL,
	[CantNoches] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[ConsecutivoHospedaje] [int] NOT NULL,
 CONSTRAINT [PK_DETALLE] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ERRORES]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ERRORES](
	[ConsecutivoError] [bigint] IDENTITY(1,1) NOT NULL,
	[DescripcionError] [varchar](max) NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[ConsecutivoUsuario] [bigint] NOT NULL,
	[Origen] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ERRORES] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoError] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOSPEDAJE]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOSPEDAJE](
	[ConsecutivoHospedaje] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CodProvincia] [tinyint] NOT NULL,
	[Precio] [float] NOT NULL,
	[Disponibilidad] [varchar](50) NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[ConsecutivoUsuario] [bigint] NULL,
 CONSTRAINT [PK_HOSPEDAJE] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoHospedaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MAESTRO]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MAESTRO](
	[IdMaestro] [bigint] NOT NULL,
	[FechaCompra] [datetime] NOT NULL,
	[Subtotal] [decimal](10, 2) NOT NULL,
	[Impuestos] [decimal](10, 2) NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[ConsecutivoUsuario] [bigint] NOT NULL,
 CONSTRAINT [PK_MAESTRO] PRIMARY KEY CLUSTERED 
(
	[IdMaestro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVINCIAS](
	[CodProvincia] [tinyint] NOT NULL,
	[NombreProvincia] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PROVINCIAS] PRIMARY KEY CLUSTERED 
(
	[CodProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVAS]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVAS](
	[ConsecutivoReservas] [bigint] NOT NULL,
	[FechaReserva] [datetime] NOT NULL,
	[CodUsuario] [bigint] NOT NULL,
	[CodDestino] [bigint] NOT NULL,
	[Pago] [bit] NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_RESERVAS] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoReservas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 24/4/2023 07:28:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[ConsecutivoUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[CorreoElectronico] [varchar](70) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Identificacion] [varchar](20) NULL,
	[CodProvincia] [tinyint] NULL,
	[Telefono] [int] NULL,
	[Rol] [varchar](20) NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[ConsecutivoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BITACORAS] ON 
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (1, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T00:57:28.053' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (2, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T00:58:22.913' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (3, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T00:59:06.987' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (4, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T00:59:13.293' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (5, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T00:59:14.363' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (6, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:01:07.250' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (7, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:06:39.450' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (8, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:10:54.363' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (9, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:13:08.103' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (10, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:14:28.827' AS DateTime), N'Hospedaje-MisHospedajes')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (11, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:16:47.460' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (12, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:16:54.690' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (13, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:17:41.380' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (14, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:17:42.517' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (15, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:18:05.377' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (16, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:18:06.443' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (17, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T01:18:07.310' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (18, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:04:16.390' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (19, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:04:18.180' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (20, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:04:18.827' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (21, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:10.143' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (22, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:11.033' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (23, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:31.817' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (24, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:32.617' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (25, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:43.087' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (26, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:43.773' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (27, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:45.913' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (28, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:46.587' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (29, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:47.203' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (30, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:47.917' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (31, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:49.230' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (32, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:49.963' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (33, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:07:59.213' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (34, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:00.100' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (35, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:00.613' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (36, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:01.247' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (37, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:02.020' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (38, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:03.117' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (39, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:04.003' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (40, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:48.410' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (41, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:55.977' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (42, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:57.653' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (43, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:08:59.920' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (44, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:09:24.163' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (45, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:09:25.470' AS DateTime), N'Home-Packages')
GO
INSERT [dbo].[BITACORAS] ([ConsecutivoError], [DescripcionError], [FechaHora], [Origen]) VALUES (46, N'Se han producido uno o varios errores.', CAST(N'2023-04-24T19:10:32.380' AS DateTime), N'Home-Packages')
GO
SET IDENTITY_INSERT [dbo].[BITACORAS] OFF
GO
SET IDENTITY_INSERT [dbo].[HOSPEDAJE] ON 
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (1, N'Hotel Villa Prueba', 1, 20000, N'Disponible', NULL, 1)
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (2, N'Hotel Plata Dorada', 1, 500, N'Disponible', NULL, 2)
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (3, N'Cabañas El Sapo', 4, 200, N'Disponible', NULL, 3)
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (4, N'Hotel Miramar', 5, 100, N'Disponible', NULL, 4)
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (5, N'Hotel Paso Dorado', 7, 50, N'Disponible', NULL, 2)
GO
INSERT [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje], [Nombre], [CodProvincia], [Precio], [Disponibilidad], [FechaRegistro], [ConsecutivoUsuario]) VALUES (21, N'Prueba de Hotel', 3, 1302, N'Disponible', CAST(N'2023-04-24T01:16:47.357' AS DateTime), 3)
GO
SET IDENTITY_INSERT [dbo].[HOSPEDAJE] OFF
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (1, N'San José')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (2, N'Alajuela')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (3, N'Cartago')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (4, N'Heredia')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (5, N'Guanacaste')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (6, N'Puntarenas')
GO
INSERT [dbo].[PROVINCIAS] ([CodProvincia], [NombreProvincia]) VALUES (7, N'Limón')
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (1, N'jretana80675@ufide.ac.cr', N'80675', 1, N'Jose Pablo Retana Pereira', N'305380675', 1, 88888888, N'Administrador')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (2, N'jsegura90582@ufide.ac.cr', N'90582', 1, N'Jostin Segura Noguera', N'116290582', 1, 88888888, N'Administrador')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (3, N'jquiros90650@ufide.ac.cr', N'90650', 1, N'Jason Quiros Fonseca', N'112790650', 1, 88888888, N'Administrador')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (4, N'jgarcia60845@ufide.ac.cr', N'60845', 1, N'Josué García Roldán', N'116860845', 1, 88888888, N'Administrador')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (5, N'ecalvo90415@ufide.ac.cr', N'90415', 1, N'Eduardo Calvo Castillo', N'304590415', 1, 88888888, N'Administrador')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (6, N'usuario1234@ufide.ac.cr', N'12345', 1, N'Usuario de Prueba 1', N'116860848', 4, 88888888, N'Usuario')
GO
INSERT [dbo].[USUARIOS] ([ConsecutivoUsuario], [CorreoElectronico], [Contrasenna], [Estado], [Nombre], [Identificacion], [CodProvincia], [Telefono], [Rol]) VALUES (7, N'usuario4321@ufide.ac.cr', N'12345', 1, N'Usuario de Prueba 1', N'116290585', 4, 88888888, N'Afiliado')
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_CorreoElectronico]    Script Date: 24/4/2023 07:28:56 ******/
ALTER TABLE [dbo].[USUARIOS] ADD  CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CARRITO]  WITH CHECK ADD  CONSTRAINT [FK_CARRITO_CARRITO] FOREIGN KEY([ConsecutivoHospedaje])
REFERENCES [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje])
GO
ALTER TABLE [dbo].[CARRITO] CHECK CONSTRAINT [FK_CARRITO_CARRITO]
GO
ALTER TABLE [dbo].[CARRITO]  WITH CHECK ADD  CONSTRAINT [FK_CARRITO_USUARIOS] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[CARRITO] CHECK CONSTRAINT [FK_CARRITO_USUARIOS]
GO
ALTER TABLE [dbo].[DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_DETALLE] FOREIGN KEY([IdDetalle])
REFERENCES [dbo].[DETALLE] ([IdDetalle])
GO
ALTER TABLE [dbo].[DETALLE] CHECK CONSTRAINT [FK_DETALLE_DETALLE]
GO
ALTER TABLE [dbo].[DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_HOSPEDAJE] FOREIGN KEY([ConsecutivoHospedaje])
REFERENCES [dbo].[HOSPEDAJE] ([ConsecutivoHospedaje])
GO
ALTER TABLE [dbo].[DETALLE] CHECK CONSTRAINT [FK_DETALLE_HOSPEDAJE]
GO
ALTER TABLE [dbo].[DETALLE]  WITH CHECK ADD  CONSTRAINT [FK_DETALLE_MAESTRO] FOREIGN KEY([IdMaestro])
REFERENCES [dbo].[MAESTRO] ([IdMaestro])
GO
ALTER TABLE [dbo].[DETALLE] CHECK CONSTRAINT [FK_DETALLE_MAESTRO]
GO
ALTER TABLE [dbo].[ERRORES]  WITH CHECK ADD  CONSTRAINT [FK_ERRORES_USUARIOS] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[ERRORES] CHECK CONSTRAINT [FK_ERRORES_USUARIOS]
GO
ALTER TABLE [dbo].[HOSPEDAJE]  WITH CHECK ADD  CONSTRAINT [FK_HOSPEDAJE_PROVINCIAS] FOREIGN KEY([CodProvincia])
REFERENCES [dbo].[PROVINCIAS] ([CodProvincia])
GO
ALTER TABLE [dbo].[HOSPEDAJE] CHECK CONSTRAINT [FK_HOSPEDAJE_PROVINCIAS]
GO
ALTER TABLE [dbo].[HOSPEDAJE]  WITH CHECK ADD  CONSTRAINT [FK_HOSPEDAJE_USUARIOS] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[HOSPEDAJE] CHECK CONSTRAINT [FK_HOSPEDAJE_USUARIOS]
GO
ALTER TABLE [dbo].[MAESTRO]  WITH CHECK ADD  CONSTRAINT [FK_MAESTRO_USUARIOS] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[MAESTRO] CHECK CONSTRAINT [FK_MAESTRO_USUARIOS]
GO
ALTER TABLE [dbo].[RESERVAS]  WITH CHECK ADD  CONSTRAINT [FK_RESERVAS_USUARIOS] FOREIGN KEY([CodUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[RESERVAS] CHECK CONSTRAINT [FK_RESERVAS_USUARIOS]
GO
ALTER TABLE [dbo].[USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOS_PROVINCIAS] FOREIGN KEY([CodProvincia])
REFERENCES [dbo].[PROVINCIAS] ([CodProvincia])
GO
ALTER TABLE [dbo].[USUARIOS] CHECK CONSTRAINT [FK_USUARIOS_PROVINCIAS]
GO
/****** Object:  StoredProcedure [dbo].[obtenerHospedajesConNombreProvincia]    Script Date: 24/4/2023 07:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[obtenerHospedajesConNombreProvincia]
AS
BEGIN
SELECT a.Nombre, a.CodProvincia, p.NombreProvincia, a.Precio, a.Disponibilidad
FROM HOSPEDAJE a
INNER JOIN PROVINCIAS p ON a.CodProvincia = p.CodProvincia
WHERE a.Disponibilidad = 'Disponible'
END
GO
/****** Object:  StoredProcedure [dbo].[obtenerHospedajesPorUsuario]    Script Date: 24/4/2023 07:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[obtenerHospedajesPorUsuario]
    @ConsecutivoUsuario int
AS
BEGIN
    SELECT h.Nombre, h.CodProvincia, p.NombreProvincia, h.Precio, h.Disponibilidad, h.FechaRegistro
    FROM Hospedaje h
    INNER JOIN Provincias p ON h.CodProvincia = p.CodProvincia
    WHERE h.Disponibilidad = 'Disponible' AND h.ConsecutivoUsuario = @ConsecutivoUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 24/4/2023 07:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegistrarBitacora]
	@Descripcion VARCHAR(MAX),
	@Origen VARCHAR(100)
AS
BEGIN

	INSERT INTO [dbo].[BITACORAS] ([DescripcionError],[FechaHora],[Origen])
    VALUES (@Descripcion,GETDATE(),@Origen)

END
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 24/4/2023 07:28:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ValidarUsuario]
	@CorreoElectronico	VARCHAR(70),
	@Contrasenna		VARCHAR(10)
AS
BEGIN

	SELECT	ConsecutivoUsuario,
			CorreoElectronico,
			Estado
	FROM dbo.USUARIOS
	WHERE	CorreoElectronico = @CorreoElectronico
		AND Contrasenna		  = @Contrasenna
		AND Estado			  = 1

END
GO
