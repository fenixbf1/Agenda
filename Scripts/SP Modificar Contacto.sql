USE Agenda;
GO

CREATE PROCEDURE ModificarContacto
    @idContacto INT,
    @nombre NVARCHAR(100),
    @apellidoP NVARCHAR(100),
    @apellidoM NVARCHAR(100),
    @calle NVARCHAR(100),
    @numeroint NVARCHAR(10),
    @numeroext NVARCHAR(10),
    @colonia NVARCHAR(100),
    @localidad NVARCHAR(100),
    @municipio NVARCHAR(100),
    @estado NVARCHAR(100),
    @cp NVARCHAR(10),
    @tipoDireccion NVARCHAR(50),
    @correo NVARCHAR(100),
    @curp NVARCHAR(18),
    @puesto NVARCHAR(100),
    @sueldo DECIMAL(18, 2),
    @MontoCredito DECIMAL(18, 2),
    @DiasCredito INT,
    @regimenFiscal NVARCHAR(50),
    @Descripcion NVARCHAR(255),
    @fechaEntregaMercancia DATE,
    @idUsuario INT,
    @telefono NVARCHAR(20),
    @tipoTelefono NVARCHAR(50)
AS
BEGIN
    -- Modificar datos en la tabla Informacion
    UPDATE Informacion
    SET nombre = @nombre,
        apellidoP = @apellidoP,
        apellidoM = @apellidoM
    WHERE idInformacion = (SELECT idInformacion FROM Contacto WHERE idContacto = @idContacto);

    -- Modificar datos en la tabla Direccion
    UPDATE Direccion
    SET calle = @calle,
        numeroint = @numeroint,
        numeroext = @numeroext,
        colonia = @colonia,
        localidad = @localidad,
        municipio = @municipio,
        estado = @estado,
        cp = @cp,
        tipoDireccion = @tipoDireccion
    WHERE idDireccion = (SELECT idDireccion FROM Contacto WHERE idContacto = @idContacto);

    -- Modificar datos en la tabla Correo_electronico
    UPDATE Correo_electronico
    SET correo = @correo
    WHERE idCorreoE = (SELECT idCorreoE FROM Contacto WHERE idContacto = @idContacto);

    -- Modificar datos en la tabla Contacto
    UPDATE Contacto
    SET curp = @curp,
        puesto = @puesto,
        sueldo = @sueldo,
        MontoCredito = @MontoCredito,
        DiasCredito = @DiasCredito,
        regimenFiscal = @regimenFiscal,
        Descripcion = @Descripcion,
        fechaEntregaMercancia = @fechaEntregaMercancia,
        FechaM = GETDATE(),
        idUsuario = @idUsuario
    WHERE idContacto = @idContacto;

    -- Modificar datos en la tabla Telefono
    UPDATE Telefono
    SET telefono = @telefono,
        tipoTelefono = @tipoTelefono
    WHERE idContacto = @idContacto;
END;
