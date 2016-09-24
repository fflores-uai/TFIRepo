CREATE PROCEDURE Usuario_Update

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
		
		UPDATE Usuario SET
		CondicionFiscalID = @CondicionFiscalID,
		UsuarioTipoID = @UsuarioTipoID,
		Nombre = @Nombre,
		Apellido = @Apellido,
		Dni = @Dni,
		Email = @Email,
		NetworkID = @NetworkID,
		Clave = @Clave
		WHERE ID = @ID	
    
END
GO