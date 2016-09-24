USE TFINegocio_dev

CREATE TABLE UsuarioTipo
(	ID INT NOT NULL,
	Descripcion VARCHAR(200)
	CONSTRAINT [PK_UsuarioTipo] PRIMARY KEY([ID]))

CREATE TABLE CondicionFiscal
(	ID INT NOT NULL,
	Descripcion VARCHAR(200)
	CONSTRAINT [PK_CondicionFiscal] PRIMARY KEY([ID]))

CREATE TABLE Usuario
(	ID INT NOT NULL,
	CondicionFiscalID INT,
	UsuarioTipoID INT NOT NULL,
	Nombre VARCHAR(200) NOT NULL,
	Apellido VARCHAR(200) NOT NULL,
	Dni VARCHAR(10),
	CUIT VARCHAR(11) NOT NULL,
	Email VARCHAR(400) NOT NULL,
	NetworkID VARCHAR(100) NOT NULL,
	Clave VARCHAR(200) NOT NULL
	CONSTRAINT [PK_Usuario] PRIMARY KEY(ID, CUIT, NetworkID))

CREATE TABLE Lenguaje
(
	ID INT NOT NULL,
	Descripcion VARCHAR(200) NOT NULL
	CONSTRAINT [PK_Lenguaje] PRIMARY KEY(ID))

CREATE TABLE LenguajeControl
(
	Texto VARCHAR(400) NOT NULL,
	LenguajeID INT NOT NULL,
	Valor VARCHAR(400) NOT NULL
	CONSTRAINT [PK_LenguageControl_Lenguage] PRIMARY KEY(Texto,LenguajeID))

CREATE TABLE Patente
(
	ID INT NOT NULL,
	Nombre VARCHAR(200) NOT NULL
	CONSTRAINT [PK_Patente] PRIMARY KEY(ID))

CREATE TABLE Familia
(
	ID INT NOT NULL,
	Nombre VARCHAR(200) NOT NULL
	CONSTRAINT [PK_Familia] PRIMARY KEY(ID))

CREATE TABLE PatenteFamilia
(
	PatenteID INT NOT NULL,
	FamiliaID INT NOT NULL
	CONSTRAINT [PK_Patente_Familia] PRIMARY KEY(PatenteID,FamiliaID))

CREATE TABLE UsuarioFamilia
(
	UsuarioID INT NOT NULL,
	FamiliaID INT NOT NULL
	CONSTRAINT [PK_Patente_Familia] PRIMARY KEY(UsuarioID,FamiliaID))

CREATE TABLE UsuarioPatente
(
	UsuarioID INT NOT NULL,
	PatenteID INT NOT NULL
	CONSTRAINT [PK_Usuario_Familia] PRIMARY KEY(UsuarioID,PatenteID))

CREATE TABLE Direccion
(
	ID INT NOT NULL,
	Calle VARCHAR(200) NOT NULL,
	Numero VARCHAR(10) NOT NULL,
	Piso VARCHAR(10),
	Departamento VARCHAR(100) NOT NULL,
	Localidad VARCHAR(200) NOT NULL,
	Provincia VARCHAR(200),
	Barrio VARCHAR(200),
	DireccionTipoID INT

	CONSTRAINT [PK_Direccion] PRIMARY KEY(ID))

CREATE TABLE DireccionTipo
(
	ID INT NOT NULL,
	Descripcion VARCHAR(200) NOT NULL
	CONSTRAINT [PK_DireccionTipo] PRIMARY KEY(ID))

CREATE TABLE DireccionUsuario
(
	DireccionID INT NOT NULL,
	UsuarioID INT NOT NULL
	CONSTRAINT [PK_Direccion_Cliente] PRIMARY KEY(DireccionID,UsuarioID))


CREATE TABLE BitacoraLog
(
	ID INT NOT NULL,
	CONSTRAINT [PK_BitacoraLog] PRIMARY KEY(ID))



ALTER TABLE Usuario ADD CONSTRAINT [FK_Usuario_UsuarioTipo] FOREIGN KEY (UsuarioTipoID) REFERENCES UsuarioTipo(ID)

ALTER TABLE LenguajeControl ADD CONSTRAINT [FK_LenguageControl_Lenguage] FOREIGN KEY (LenguajeID) REFERENCES Lenguaje(ID)

ALTER TABLE Direccion ADD CONSTRAINT [FK_Direccion_DireccionTipo] FOREIGN KEY (DireccionTipoID) REFERENCES DireccionTipo(ID)

ALTER TABLE DireccionUsuario ADD CONSTRAINT [FK_DireccionUsuario_Direccion] FOREIGN KEY (DireccionID) REFERENCES Direccion(ID)
ALTER TABLE DireccionUsuario ADD CONSTRAINT [FK_DireccionUsuario_Cliente] FOREIGN KEY (UsuarioID) REFERENCES Usuario(ID)

ALTER TABLE PatenteFamilia ADD CONSTRAINT [FK_PatenteFamilia_Patente] FOREIGN KEY (PatenteID) REFERENCES Patente(ID)
ALTER TABLE PatenteFamilia ADD CONSTRAINT [FK_PatenteFamilia_Familia] FOREIGN KEY (FamiliaID) REFERENCES Familia(ID)

ALTER TABLE UsuarioFamilia ADD CONSTRAINT [FK_UsuarioFamilia_Usuario] FOREIGN KEY (PatenteID) REFERENCES Usuario(ID)
ALTER TABLE UsuarioFamilia ADD CONSTRAINT [FK_UsuarioFamilia_Familia] FOREIGN KEY (FamiliaID) REFERENCES Familia(ID)

ALTER TABLE UsuarioPatente ADD CONSTRAINT [FK_UsuarioPatente_Patente] FOREIGN KEY (PatenteID) REFERENCES Patente(ID)
ALTER TABLE UsuarioPatente ADD CONSTRAINT [FK_UsuarioPatente_Usuario] FOREIGN KEY (FamiliaID) REFERENCES Usuario(ID)
