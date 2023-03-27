USE [master]
GO

CREATE DATABASE [ProyectoW_BD]
GO

USE [ProyectoW_BD]
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

CREATE TABLE [dbo].[PROVINCIAS](
	[CodProvincia] [tinyint] NOT NULL,
	[NombreProvincia] [varchar](20) NOT NULL,
 CONSTRAINT [PK_PROVINCIAS] PRIMARY KEY CLUSTERED 
(
	[CodProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[USUARIOS](
	[ConsecutivoUsuario] [bigint] IDENTITY(1,1) NOT NULL,
	[CorreoElectronico] [varchar](70) NOT NULL,
	[Contrasenna] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Identificacion] [varchar](20) NULL,
	[CodProvincia] [tinyint] NULL,
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

ALTER TABLE [dbo].[USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOS_PROVINCIAS] FOREIGN KEY([CodProvincia])
REFERENCES [dbo].[PROVINCIAS] ([CodProvincia])
GO
ALTER TABLE [dbo].[USUARIOS] CHECK CONSTRAINT [FK_USUARIOS_PROVINCIAS]
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

INSERT INTO [dbo].[PROVINCIAS] VALUES 
										(1,'San Jos�'),
										(2,'Alajuela'),
										(3,'Cartago'),
										(4,'Heredia'),
										(5,'Guanacaste'),
										(6,'Puntarenas'),
										(7,'Lim�n')
GO

INSERT INTO [dbo].[USUARIOS] VALUES
									('jretana80675@ufide.ac.cr', 80675, 1,'Jose Pablo Retana Pereira', 123,1,'Administrador'),
									('jsegura90582@ufide.ac.cr', 90582, 1,'Jostin Segura Noguera', 123,1,'Administrador'),
									('jquiros90650@ufide.ac.cr', 90650, 1,'Jason Quiros Fonseca', 123,1,'Administrador'),
									('jgarcia60845@ufide.ac.cr', 60845, 1,'Josu� Garc�a Rold�n', 116860845,1,'Administrador'),
									('ecalvo90415@ufide.ac.cr', 90415, 1,'Eduardo Calvo Castillo', 123490415,1,'Administrador'),
									('usuario1234@ufide.ac.cr', 12345, 1,'Usuario de Prueba 1', 123456789, 4, 'Usuario')
go