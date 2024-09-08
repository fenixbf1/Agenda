USE Agenda;
GO

-- Crear tabla Direccion
CREATE TABLE Direccion (
    idDireccion INT IDENTITY(1,1) PRIMARY KEY,
    calle NVARCHAR(100),
    numeroint NVARCHAR(10),
    numeroext NVARCHAR(10),
    colonia NVARCHAR(100),
    localidad NVARCHAR(100),
    municipio NVARCHAR(100),
    estado NVARCHAR(100),
    cp NVARCHAR(10),
    tipoDireccion NVARCHAR(50)
);

-- Crear tabla Informacion
CREATE TABLE Informacion (
    idInformacion INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    apellidoP NVARCHAR(100),
    apellidoM NVARCHAR(100)
);

-- Crear tabla Correo_electronico
CREATE TABLE Correo_electronico (
    idCorreoE INT IDENTITY(1,1) PRIMARY KEY,
    correo NVARCHAR(100)
);

-- Crear tabla Contacto
CREATE TABLE Contacto (
    idContacto INT IDENTITY(1,1) PRIMARY KEY,
    idInformacion INT,
    idDireccion INT,
    idCorreoE INT,
    curp NVARCHAR(18),
    puesto NVARCHAR(100),
    sueldo DECIMAL(18, 2),
    MontoCredito DECIMAL(18, 2),
    DiasCredito INT,
    regimenFiscal NVARCHAR(50),
    Descripcion NVARCHAR(255),
    fechaEntregaMercancia DATE,
    FechaAlta DATE,
    FechaM DATE,
    idUsuario INT,
    FOREIGN KEY (idInformacion) REFERENCES Informacion(idInformacion),
    FOREIGN KEY (idDireccion) REFERENCES Direccion(idDireccion),
    FOREIGN KEY (idCorreoE) REFERENCES Correo_electronico(idCorreoE),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario) -- Asumiendo que existe una tabla Usuario
);

-- Crear tabla Telefono
CREATE TABLE Telefono (
    idTelefono INT IDENTITY(1,1) PRIMARY KEY,
    idContacto INT,
    telefono NVARCHAR(20),
    tipoTelefono NVARCHAR(50),
    FOREIGN KEY (idContacto) REFERENCES Contacto(idContacto)
);
