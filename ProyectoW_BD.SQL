USE [master]
GO
/****** Object:  Database [ProyectoW_BD]    Script Date: 28/3/2023 13:53:57 ******/
CREATE DATABASE [ProyectoW_BD]

USE [ProyectoW_BD]
GO
/****** Object:  Table [dbo].[BITACORAS]    Script Date: 28/3/2023 13:53:57 ******/
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

CREATE TABLE [dbo].[CARRITO](
	[IdCarrito] [bigint] IDENTITY(1,1) NOT NULL,
	[ConsecutivoUsuario] [bigint] NOT NULL,
	[IdProducto] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_CARRITO] PRIMARY KEY CLUSTERED 
(
	[IdCarrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DETALLE](
	[IdDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMaestro] [bigint] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[IdProducto] [bigint] NOT NULL,
 CONSTRAINT [PK_DETALLE] PRIMARY KEY CLUSTERED 
(
	[IdDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[ERRORES]    Script Date: 28/3/2023 13:53:58 ******/
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







/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 28/3/2023 13:53:58 ******/
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
/****** Object:  Table [dbo].[RESERVAS]    Script Date: 28/3/2023 13:53:58 ******/
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
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 28/3/2023 13:53:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UK_CorreoElectronico] UNIQUE NONCLUSTERED 
(
	[CorreoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ERRORES]  WITH CHECK ADD  CONSTRAINT [FK_ERRORES_USUARIOS] FOREIGN KEY([ConsecutivoUsuario])
REFERENCES [dbo].[USUARIOS] ([ConsecutivoUsuario])
GO
ALTER TABLE [dbo].[ERRORES] CHECK CONSTRAINT [FK_ERRORES_USUARIOS]
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
/****** Object:  StoredProcedure [dbo].[RegistrarBitacora]    Script Date: 28/3/2023 13:53:58 ******/
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
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 28/3/2023 13:53:58 ******/
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
USE [master]
GO
ALTER DATABASE [ProyectoW_BD] SET  READ_WRITE 
GO


INSERT INTO [ProyectoW_BD].[dbo].[PROVINCIAS] VALUES 
										(1,'San José'),
										(2,'Alajuela'),
										(3,'Cartago'),
										(4,'Heredia'),
										(5,'Guanacaste'),
										(6,'Puntarenas'),
										(7,'Limón')
GO

INSERT INTO [ProyectoW_BD].[dbo].[USUARIOS] VALUES
									('jretana80675@ufide.ac.cr', 80675, 1,'Jose Pablo Retana Pereira', 305380675,1,88888888,'Administrador'),
									('jsegura90582@ufide.ac.cr', 90582, 1,'Jostin Segura Noguera', 116290582,1,88888888,'Administrador'),
									('jquiros90650@ufide.ac.cr', 90650, 1,'Jason Quiros Fonseca', 112790650,1,88888888,'Administrador'),
									('jgarcia60845@ufide.ac.cr', 60845, 1,'Josué García Roldán', 116860845,1,88888888,'Administrador'),
									('ecalvo90415@ufide.ac.cr', 90415, 1,'Eduardo Calvo Castillo', 304590415,1,88888888,'Administrador'),
									('usuario1234@ufide.ac.cr', 12345, 1,'Usuario de Prueba 1', 116860848, 4, 88888888,'Usuario'),
									('usuario4321@ufide.ac.cr', 12345, 1,'Usuario de Prueba 1', 116290585, 4, 88888888,'Afiliado')
GO

INSERT INTO [ProyectoW_BD].[dbo].[RESERVAS] VALUES
									(1,'2023-05-12',1,1,0,1)
GO


USE [ProyectoW_BD]
GO



/****** Object:  Table [dbo].[BITACORA_CONTACTO]    Script Date: 9/4/2023 08:19:21 ******/
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


SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[obtenerHospedajesConNombreProvincia]
AS
BEGIN
    SELECT a.Nombre, a.CodProvincia, p.NombreProvincia, a.Precio, a.Disponibilidad 
    FROM HOSPEDAJE a 
    INNER JOIN PROVINCIAS p ON a.CodProvincia = p.CodProvincia
END
GO


