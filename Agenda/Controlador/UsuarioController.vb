
Imports System.Data.SqlClient

Public Class UsuarioController
    Private conexion As New DatabaseConnection()

    Public Function ValidarUsuario(email As String, password As String) As Integer?
        Dim idUsuario As Integer? = Nothing

        Using conn As SqlConnection = conexion.ObtenerConexion()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT idUsuario FROM Usuarios WHERE email = @correo AND password = @contrasena", conn)
            cmd.Parameters.AddWithValue("@correo", email)
            cmd.Parameters.AddWithValue("@contrasena", password)
            Dim result As Object = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                idUsuario = Convert.ToInt32(result)
            End If
        End Using

        Return idUsuario
    End Function
End Class
