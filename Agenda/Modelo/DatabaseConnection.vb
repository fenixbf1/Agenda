Imports System.Data.SqlClient
Public Class DatabaseConnection
    Private connectionString As String = "Server=DESKTOP-GHFD461;Database=Agenda;Integrated Security=True;"
    Public Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
End Class

