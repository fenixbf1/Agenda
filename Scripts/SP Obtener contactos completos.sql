
USE Agenda;
GO

IF OBJECT_ID(N'[dbo].[ObtenerContactosCompletos]', N'P') IS NOT NULL
DROP PROCEDURE [dbo].[ObtenerContactosCompletos];
GO

CREATE PROCEDURE ObtenerContactosCompletos
AS
BEGIN
    SELECT 
        c.idContacto,
        i.nombre AS nombre_informacion,
        i.apellidoP AS apellidoP_informacion,
        i.apellidoM AS apellidoM_informacion,
        d.calle AS calle_direccion,
        d.numeroint AS numeroint_direccion,
        d.numeroext AS numeroext_direccion,
        d.colonia AS colonia_direccion,
        d.localidad AS localidad_direccion,
        d.municipio AS municipio_direccion,
        d.estado AS estado_direccion,
        d.cp AS cp_direccion,
        d.tipoDireccion AS tipoDireccion_direccion,
        ce.correo AS correo_electronico,
        t.telefono AS telefono,
        t.tipoTelefono AS tipoTelefono,
		c.curp AS curp_contacto,
		c.puesto AS puesto_contacto,
		c.sueldo AS sueldo_contacto,
		c.MontoCredito AS montocredito_contacto,
		c.DiasCredito AS diascredito_contacto,
		c.regimenFiscal AS regimenfiscal_contacto,
		c.Descripcion AS descripcion_contacto,
		c.fechaEntregaMercancia AS fechaentregamercancia_contacto,
		c.FechaAlta AS fechaalta_contacto,
		c.FechaM AS fecham_contacto,
		u.nombre AS nombre_usuarios
    FROM 
        Contacto c
    INNER JOIN 
        Informacion i ON c.idInformacion = i.idInformacion
    INNER JOIN 
        Direccion d ON c.idDireccion = d.idDireccion
    INNER JOIN 
        Correo_electronico ce ON c.idCorreoE = ce.idCorreoE
    INNER JOIN 
        Telefono t ON c.idContacto = t.idContacto
	INNER JOIN
		Usuarios u ON c.idUsuario = u.idUsuario;
END;
GO
