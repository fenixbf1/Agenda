<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        tbusuario = New TextBox()
        tbcontrasena = New TextBox()
        btlogin = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(110, 67)
        Label1.Name = "Label1"
        Label1.Size = New Size(46, 15)
        Label1.TabIndex = 0
        Label1.Text = "Correo:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(110, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 15)
        Label2.TabIndex = 1
        Label2.Text = "Contraseña:"
        ' 
        ' tbusuario
        ' 
        tbusuario.Location = New Point(196, 64)
        tbusuario.Name = "tbusuario"
        tbusuario.Size = New Size(100, 23)
        tbusuario.TabIndex = 2
        ' 
        ' tbcontrasena
        ' 
        tbcontrasena.Location = New Point(196, 104)
        tbcontrasena.Name = "tbcontrasena"
        tbcontrasena.PasswordChar = "*"c
        tbcontrasena.Size = New Size(100, 23)
        tbcontrasena.TabIndex = 3
        ' 
        ' btlogin
        ' 
        btlogin.Location = New Point(208, 133)
        btlogin.Name = "btlogin"
        btlogin.Size = New Size(75, 23)
        btlogin.TabIndex = 4
        btlogin.Text = "Login"
        btlogin.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(468, 248)
        Controls.Add(btlogin)
        Controls.Add(tbcontrasena)
        Controls.Add(tbusuario)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Inicio de sesion"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbusuario As TextBox
    Friend WithEvents tbcontrasena As TextBox
    Friend WithEvents btlogin As Button



End Class
