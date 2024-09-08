
Public Class Form1
    Private usuarioController As New UsuarioController()

    Private Sub btLogin_Click(sender As Object, e As EventArgs) Handles btlogin.Click
        Dim email As String = tbusuario.Text
        Dim password As String = tbcontrasena.Text

        Dim idUsuario As Integer? = usuarioController.ValidarUsuario(email, password)
        If idUsuario.HasValue Then
            MessageBox.Show("Inicio de sesión exitoso.")
            Dim mainForm As New Form2(idUsuario.Value)
            mainForm.Show()
            Me.Hide()
        Else
            MessageBox.Show("Correo electrónico o contraseña incorrectos.")
        End If
    End Sub

End Class
