CREATE DATABASE ProyectoW_BD

USE ProyectoW_BD

CREATE TABLE USUARIOS (
ConsecutivoUsuario bigint primary key identity(1,1) not null,
CorreoElectronico varchar(70) not null,
Nombre varchar(15) not null,
Apellidos varchar(40) not null,
Contrasenna varchar(10) not null,
Estado bit not null
);

CREATE TABLE ERRORES (
ConsecutivoError bigint primary key identity(1,1) not null,
DescripcionError varchar(max) not null,
FechaHora datetime not null,
ConsecutivoUsuario bigint not null,
Origen varchar(100) not null,
CONSTRAINT FK_ConsecutivoUsuario FOREIGN KEY (ConsecutivoUsuario) REFERENCES USUARIOS (ConsecutivoUsuario)
);

CREATE TABLE BITACORA (
ConsecutivoError bigint primary key identity(1,1) not null,
DescripcionError varchar(max) not null,
FechaHora datetime not null,
Origen varchar(100) not null,
);


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