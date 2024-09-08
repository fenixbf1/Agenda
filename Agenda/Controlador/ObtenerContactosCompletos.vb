Imports System.Data.SqlClient

Public Class DataAccess
    Private dbConnection As New DatabaseConnection()

    Public Function ObtenerContactosCompletos() As List(Of ContactoCompleto)
        Dim contactosCompletos As New List(Of ContactoCompleto)()
        Using con As SqlConnection = dbConnection.ObtenerConexion()
            Dim cmd As New SqlCommand("ObtenerContactosCompletos", con)
            cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim contacto As New ContactoCompleto()
                    contacto.IdContacto = Convert.ToInt32(reader("idContacto"))
                    contacto.NombreInformacion = reader("nombre_informacion").ToString()
                    contacto.ApellidoPInformacion = reader("apellidoP_informacion").ToString()
                    contacto.ApellidoMInformacion = reader("apellidoM_informacion").ToString()
                    contacto.CalleDireccion = reader("calle_direccion").ToString()
                    contacto.NumerointDireccion = reader("numeroint_direccion").ToString()
                    contacto.NumeroextDireccion = reader("numeroext_direccion").ToString()
                    contacto.ColoniaDireccion = reader("colonia_direccion").ToString()
                    contacto.LocalidadDireccion = reader("localidad_direccion").ToString()
                    contacto.MunicipioDireccion = reader("municipio_direccion").ToString()
                    contacto.EstadoDireccion = reader("estado_direccion").ToString()
                    contacto.CpDireccion = reader("cp_direccion").ToString()
                    contacto.TipoDireccionDireccion = reader("tipoDireccion_direccion").ToString()
                    contacto.CorreoElectronico = reader("correo_electronico").ToString()
                    contacto.Telefono = reader("telefono").ToString()
                    contacto.TipoTelefono = reader("tipoTelefono").ToString()
                    contacto.CurpContacto = reader("curp_contacto").ToString()
                    contacto.PuestoContacto = reader("puesto_contacto").ToString()
                    contacto.SueldoContacto = reader("sueldo_contacto").ToString()
                    contacto.MontoContacto = reader("montocredito_contacto").ToString()
                    contacto.DiascreditoContacto = reader("diascredito_contacto").ToString()
                    contacto.RegimenfiscalContacto = reader("regimenfiscal_contacto").ToString()
                    contacto.DescripcionContacto = reader("descripcion_contacto").ToString()
                    contacto.FechaentregamercanciaContacto = reader("fechaentregamercancia_contacto").ToString()
                    contacto.FechaaltaContacto = reader("fechaalta_contacto").ToString()
                    contacto.FechamContacto = reader("fecham_contacto").ToString()
                    contacto.NombreUsuarios = reader("nombre_usuarios").ToString()
                    contactosCompletos.Add(contacto)
                End While
            End Using
        End Using
        Return contactosCompletos
    End Function
End Class
