﻿USE RecibosDB
GO

CREATE TABLE [dbo].[Proveedores]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
)

CREATE TABLE [dbo].[Monedas]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Acronimo VARCHAR(3) NOT NULL
)

CREATE TABLE [dbo].[Recibos]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
    Monto DECIMAL(19,4) NOT NULL,    
	Fecha DATETIME NOT NULL,
	Comentario  VARCHAR(200),
	ProveedorId_FK INT NOT NULL,
	FOREIGN KEY (ProveedorId_FK) REFERENCES Proveedores(Id),
	MonedaId_FK INT NOT NULL,
	FOREIGN KEY (MonedaId_FK) REFERENCES Monedas(Id)
)

CREATE TABLE [dbo].[Usuarios]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
    Nombres VARCHAR(50) NOT NULL,    
	FechaNacimiento DATETIME NOT NULL,
	Apellidos  VARCHAR(50),
	Email VARCHAR(50),
	Telefono VARCHAR(20) NOT NULL,
	Activo BIT NOT NULL
)

CREATE TABLE [dbo].[Seguridad]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,	
	Usuario VARCHAR(20) NOT NULL,
    NombreUsuario VARCHAR(20) NOT NULL, 
	Contrasena  VARCHAR(200),
	Rol VARCHAR(20) NOT NULL
)


ALTER TABLE Recibos
ADD UsuarioId_FK int
FOREIGN KEY (UsuarioId_FK) REFERENCES Usuarios(Id);


