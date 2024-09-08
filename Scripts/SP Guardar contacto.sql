USE Agenda;
GO

CREATE PROCEDURE GuardarContacto
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
    -- Insertar datos en la tabla Informacion
    INSERT INTO Informacion (nombre, apellidoP, apellidoM)
    VALUES (@nombre, @apellidoP, @apellidoM);

    DECLARE @idInformacion INT;
    SET @idInformacion = SCOPE_IDENTITY();

    -- Insertar datos en la tabla Direccion
    INSERT INTO Direccion (calle, numeroint, numeroext, colonia, localidad, municipio, estado, cp, tipoDireccion)
    VALUES (@calle, @numeroint, @numeroext, @colonia, @localidad, @municipio, @estado, @cp, @tipoDireccion);

    DECLARE @idDireccion INT;
    SET @idDireccion = SCOPE_IDENTITY();

    -- Insertar datos en la tabla Correo_electronico
    INSERT INTO Correo_electronico (correo)
    VALUES (@correo);

    DECLARE @idCorreoE INT;
    SET @idCorreoE = SCOPE_IDENTITY();

    -- Insertar datos en la tabla Contacto
    INSERT INTO Contacto (idInformacion, idDireccion, idCorreoE, curp, puesto, sueldo, MontoCredito, DiasCredito, regimenFiscal, Descripcion, fechaEntregaMercancia, FechaAlta, idUsuario)
    VALUES (@idInformacion, @idDireccion, @idCorreoE, @curp, @puesto, @sueldo, @MontoCredito, @DiasCredito, @regimenFiscal, @Descripcion, @fechaEntregaMercancia, GETDATE(), @idUsuario);

    DECLARE @idContacto INT;
    SET @idContacto = SCOPE_IDENTITY();

    -- Insertar datos en la tabla Telefono
    INSERT INTO Telefono (idContacto, telefono, tipoTelefono)
    VALUES (@idContacto, @telefono, @tipoTelefono);
END;
