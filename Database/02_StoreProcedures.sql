
CREATE PROCEDURE Usuario_Create

@ID INT,
@CondicionFiscalID INT,
@UsuarioTipoID INT,
@Nombre VARCHAR(200),
@Apellido VARCHAR(200),
@Dni VARCHAR(10),
@Email VARCHAR(400),
@NetworkID VARCHAR(100),
@Clave VARCHAR(200)

AS
BEGIN	
		
	SET @ID = (SELECT TOP(1)ID FROM Usuario ORDER BY ID);	

	IF(@ID IS NULL)
	INSERT INTO Usuario(
	ID,
	CondicionFiscalID,
	UsuarioTipoID,
	Nombre,
	Apellido,
	Dni,
	Email,
	NetworkID,
	Clave
	)
	VALUES(
	1,
	@CondicionFiscalID,
	@UsuarioTipoID,
	@Nombre,
	@Apellido,
	@Dni,
	@Email,
	@NetworkID,
	@Clave);
	ELSE
	INSERT INTO Usuario(
	ID,
	CondicionFiscalID,
	UsuarioTipoID,
	Nombre,
	Apellido,
	Dni,
	Email,
	NetworkID,
	Clave
	)
	VALUES(
	@ID + 1,
	@CondicionFiscalID,
	@UsuarioTipoID,
	@Nombre,
	@Apellido,
	@Dni,
	@Email,
	@NetworkID,
	@Clave);
    
END
GO