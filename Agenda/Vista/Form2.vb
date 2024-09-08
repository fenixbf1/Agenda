Imports System.Data.SqlClient

Public Class Form2
    Private idUsuario As Integer

    Public Sub New(idUsuario As Integer)
        InitializeComponent()
        Me.idUsuario = idUsuario
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btguardar.Click
        ' Crear una instancia de la clase DatabaseConnection
        Dim dbConnection As New DatabaseConnection()

        ' Obtener la conexión a la base de datos
        Using connection As SqlConnection = dbConnection.ObtenerConexion()
            ' Crear el comando para el procedimiento almacenado
            Using command As New SqlCommand("GuardarContacto", connection)
                command.CommandType = CommandType.StoredProcedure

                ' Agregar los parámetros del procedimiento almacenado
                command.Parameters.AddWithValue("@nombre", TextBox1.Text)
                command.Parameters.AddWithValue("@apellidoP", TextBox2.Text)
                command.Parameters.AddWithValue("@apellidoM", TextBox3.Text)
                command.Parameters.AddWithValue("@calle", TextBox4.Text)
                command.Parameters.AddWithValue("@numeroint", TextBox5.Text)
                command.Parameters.AddWithValue("@numeroext", TextBox6.Text)
                command.Parameters.AddWithValue("@colonia", TextBox7.Text)
                command.Parameters.AddWithValue("@localidad", TextBox8.Text)
                command.Parameters.AddWithValue("@municipio", TextBox9.Text)
                command.Parameters.AddWithValue("@estado", TextBox10.Text)
                command.Parameters.AddWithValue("@cp", TextBox11.Text)
                command.Parameters.AddWithValue("@tipoDireccion", ComboBox3.SelectedItem.ToString())
                command.Parameters.AddWithValue("@correo", TextBox19.Text)
                command.Parameters.AddWithValue("@curp", TextBox12.Text)
                command.Parameters.AddWithValue("@puesto", TextBox23.Text)
                command.Parameters.AddWithValue("@sueldo", Convert.ToDecimal(TextBox24.Text))
                command.Parameters.AddWithValue("@MontoCredito", Convert.ToDecimal(TextBox25.Text))
                command.Parameters.AddWithValue("@DiasCredito", Convert.ToInt32(TextBox25.Text))
                command.Parameters.AddWithValue("@regimenFiscal", ComboBox4.SelectedItem.ToString())
                command.Parameters.AddWithValue("@Descripcion", TextBox28.Text)
                command.Parameters.AddWithValue("@fechaEntregaMercancia", DateTimePicker1.Value)
                command.Parameters.AddWithValue("@idUsuario", Me.idUsuario)
                command.Parameters.AddWithValue("@telefono", TextBox21.Text)
                command.Parameters.AddWithValue("@tipoTelefono", ComboBox2.SelectedItem.ToString())

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()

                MessageBox.Show("Contacto guardado exitosamente.")
            End Using
        End Using
    End Sub
    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TabControl1.TabPages.Remove(TabPage1)
        If Not TabControl1.TabPages.Contains(TabPage2) Then
            TabControl1.TabPages.Add(TabPage2)
        End If

    End Sub

    Private toolTip As New ToolTip()

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox24.KeyPress, TextBox25.KeyPress, TextBox40.KeyPress, TextBox41.KeyPress
        Dim textBox As TextBox = CType(sender, TextBox)
        Dim regex As New System.Text.RegularExpressions.Regex("^\d*\.\d*$")
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso (e.KeyChar <> "."c) Then
            e.Handled = True
        End If

        If (e.KeyChar = "."c) AndAlso textBox.Text.IndexOf("."c) > -1 Then
            e.Handled = True
        End If

        If (e.KeyChar = "."c) AndAlso textBox.SelectionStart = 0 Then
            e.Handled = True
        End If

        Dim newText As String = textBox.Text.Substring(0, textBox.SelectionStart) & e.KeyChar & textBox.Text.Substring(textBox.SelectionStart)
        If Not regex.IsMatch(newText) Then
            toolTip.ToolTipTitle = "Formato Incorrecto"
            toolTip.Show("Utiliza el formato 0.0", textBox, 0, -40, 3000)
        Else
            toolTip.Hide(textBox)
        End If
    End Sub




    Private Sub ButtonAgregarCancelar_Click(sender As Object, e As EventArgs) Handles btcancelar.Click
        TabControl1.TabPages.Add(TabPage1)
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox29.Text = ""
        TextBox31.Text = ""
        TextBox32.Text = ""
        TextBox33.Text = ""
        TextBox34.Text = ""
        TextBox35.Text = ""
        TextBox36.Text = ""
        TextBox38.Text = ""
        TextBox39.Text = ""
        TextBox40.Text = ""
        TextBox41.Text = ""
        TextBox42.Text = ""
        TextBox43.Text = ""
        TextBox44.Text = ""
        TextBox45.Text = ""
        TextBox46.Text = ""

        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox12.SelectedIndex = -1
        ComboBox13.SelectedIndex = -1
        ComboBox15.SelectedIndex = -1

        DateTimePicker1.Value = DateTime.Now
        DateTimePicker2.Value = DateTime.Now

    End Sub
    Private Sub ButtonModificarCancelar_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.TabPages.Add(TabPage1)
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)



    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dataAccess As New DataAccess()
        Dim contactos As List(Of ContactoCompleto) = dataAccess.ObtenerContactosCompletos()
        DataGridView1.DataSource = contactos

        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)

        ComboBox1.SelectedIndex = 0

        GroupBox2.Visible = True
        GroupBox3.Visible = False
        GroupBox4.Visible = False



        Dim btnColumn As New DataGridViewButtonColumn()
        btnColumn.HeaderText = "Acción"
        btnColumn.Text = "Modificar"
        btnColumn.Name = "btnModificar"
        btnColumn.UseColumnTextForButtonValue = True
        DataGridView1.Columns.Insert(0, btnColumn)

    End Sub
    Private Sub TextBox43_TextChanged(sender As Object, e As EventArgs) Handles TextBox43.TextChanged
        ' Si el TextBox tiene texto, seleccionar la primera opción del ComboBox
        If TextBox43.Text <> "" Then
            ComboBox16.SelectedIndex = 0
        Else
            If TextBox40.Text <> "" Then
                ComboBox16.SelectedIndex = 1
            Else
                ' Si el TextBox está vacío, deseleccionar cualquier opción del ComboBox
                ComboBox16.SelectedIndex = 2
            End If
        End If

    End Sub
    Private Sub TextBox40_TextChanged(sender As Object, e As EventArgs) Handles TextBox40.TextChanged
        ' Si el TextBox tiene texto, seleccionar la primera opción del ComboBox

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case ComboBox1.SelectedIndex
            Case 0
                GroupBox2.Visible = True
                GroupBox3.Visible = False
                GroupBox14.Visible = False
                GroupBox4.Visible = False
                TextBox12.Text = ""
                TextBox23.Text = ""
                TextBox24.Text = ""
                TextBox25.Text = ""
                TextBox26.Text = ""
                TextBox28.Text = ""

                ComboBox4.SelectedIndex = -1

            Case 1
                GroupBox2.Visible = False
                GroupBox3.Visible = True
                GroupBox14.Visible = True
                GroupBox4.Visible = False
                TextBox12.Text = ""
                TextBox23.Text = ""
                TextBox24.Text = ""
                TextBox25.Text = ""
                TextBox26.Text = ""
                TextBox28.Text = ""
                ComboBox4.SelectedIndex = -1
            Case 2
                GroupBox2.Visible = False
                GroupBox3.Visible = False
                GroupBox14.Visible = True
                GroupBox4.Visible = True
                TextBox12.Text = ""
                TextBox23.Text = ""
                TextBox24.Text = ""
                TextBox25.Text = ""
                TextBox26.Text = ""
                TextBox28.Text = ""
                ComboBox4.SelectedIndex = -1
        End Select
    End Sub
    Private Sub ComboBox16_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox16.SelectedIndexChanged

        Select Case ComboBox16.SelectedIndex
            Case 0
                GroupBox11.Visible = True
                GroupBox10.Visible = False
                GroupBox13.Visible = False
                GroupBox9.Visible = False
                TextBox43.Text = ""
                TextBox42.Text = ""
                TextBox41.Text = ""
                TextBox40.Text = ""
                TextBox39.Text = ""
                TextBox38.Text = ""

                ComboBox15.SelectedIndex = -1

            Case 1
                GroupBox11.Visible = False
                GroupBox10.Visible = True
                GroupBox13.Visible = True
                GroupBox9.Visible = False
                TextBox43.Text = ""
                TextBox42.Text = ""
                TextBox41.Text = ""
                TextBox40.Text = ""
                TextBox39.Text = ""
                TextBox38.Text = ""

                ComboBox15.SelectedIndex = -1
            Case 2
                GroupBox11.Visible = False
                GroupBox10.Visible = False
                GroupBox13.Visible = True
                GroupBox9.Visible = True
                TextBox43.Text = ""
                TextBox42.Text = ""
                TextBox41.Text = ""
                TextBox40.Text = ""
                TextBox39.Text = ""
                TextBox38.Text = ""

                ComboBox15.SelectedIndex = -1
        End Select
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridView1.Columns("btnModificar").Index Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox46.Text = row.Cells("nombreInformacion").Value.ToString()
            TextBox45.Text = row.Cells("apellidoPInformacion").Value.ToString()
            TextBox44.Text = row.Cells("apellidoMInformacion").Value.ToString()
            TextBox29.Text = row.Cells("calleDireccion").Value.ToString()
            TextBox32.Text = row.Cells("numerointDireccion").Value.ToString()
            TextBox35.Text = row.Cells("numeroextDireccion").Value.ToString()
            TextBox36.Text = row.Cells("coloniaDireccion").Value.ToString()
            TextBox34.Text = row.Cells("localidadDireccion").Value.ToString()
            TextBox33.Text = row.Cells("municipioDireccion").Value.ToString()
            TextBox31.Text = row.Cells("estadoDireccion").Value.ToString()
            TextBox27.Text = row.Cells("cpDireccion").Value.ToString()
            ComboBox13.Text = row.Cells("tipoDireccionDireccion").Value.ToString()
            TextBox20.Text = row.Cells("correoElectronico").Value.ToString()
            TextBox22.Text = row.Cells("telefono").Value.ToString()
            ComboBox12.Text = row.Cells("tipoTelefono").Value.ToString()
            TextBox43.Text = row.Cells("curpContacto").Value.ToString()
            TextBox42.Text = row.Cells("puestoContacto").Value.ToString()
            TextBox41.Text = row.Cells("sueldoContacto").Value.ToString()
            TextBox40.Text = row.Cells("MontoContacto").Value.ToString()
            TextBox39.Text = row.Cells("diasCreditoContacto").Value.ToString()
            ComboBox15.Text = row.Cells("regimenFiscalContacto").Value.ToString()
            TextBox38.Text = row.Cells("descripcionContacto").Value.ToString()
            DateTimePicker2.Text = row.Cells("fechaEntregaMercanciaContacto").Value.ToString()

            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Add(TabPage3)
            TabControl1.SelectedTab = TabPage3
        End If
    End Sub
    Private Sub ButtonModificar_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim idContacto As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("idContacto").Value)
        Dim nombreInformacion As String = TextBox46.Text
        Dim apellidoPInformacion As String = TextBox45.Text
        Dim apellidoMInformacion As String = TextBox44.Text
        Dim calleDireccion As String = TextBox29.Text
        Dim numerointDireccion As String = TextBox32.Text
        Dim numeroextDireccion As String = TextBox35.Text
        Dim coloniaDireccion As String = TextBox36.Text
        Dim localidadDireccion As String = TextBox34.Text
        Dim municipioDireccion As String = TextBox33.Text
        Dim estadoDireccion As String = TextBox31.Text
        Dim cpDireccion As String = TextBox27.Text
        Dim tipoDireccionDireccion As String = ComboBox13.Text
        Dim correoElectronico As String = TextBox20.Text
        Dim telefono As String = TextBox22.Text
        Dim tipoTelefono As String = ComboBox12.Text
        Dim curpContacto As String = TextBox43.Text
        Dim puestoContacto As String = TextBox42.Text
        Dim sueldoContacto As Decimal = Convert.ToDecimal(TextBox41.Text)
        Dim montoCreditoContacto As Decimal = Convert.ToDecimal(TextBox40.Text)
        Dim diasCreditoContacto As Integer = Convert.ToInt32(TextBox39.Text)
        Dim regimenFiscalContacto As String = ComboBox15.Text
        Dim descripcionContacto As String = TextBox38.Text
        Dim fechaEntregaMercanciaContacto As Date = DateTimePicker2.Value

        Dim dbConnection As New DatabaseConnection()
        Using con As SqlConnection = dbConnection.ObtenerConexion()
            Dim cmd As New SqlCommand("ModificarContacto", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idContacto", idContacto)
            cmd.Parameters.AddWithValue("@nombre", nombreInformacion)
            cmd.Parameters.AddWithValue("@apellidoP", apellidoPInformacion)
            cmd.Parameters.AddWithValue("@apellidoM", apellidoMInformacion)
            cmd.Parameters.AddWithValue("@calle", calleDireccion)
            cmd.Parameters.AddWithValue("@numeroint", numerointDireccion)
            cmd.Parameters.AddWithValue("@numeroext", numeroextDireccion)
            cmd.Parameters.AddWithValue("@colonia", coloniaDireccion)
            cmd.Parameters.AddWithValue("@localidad", localidadDireccion)
            cmd.Parameters.AddWithValue("@municipio", municipioDireccion)
            cmd.Parameters.AddWithValue("@estado", estadoDireccion)
            cmd.Parameters.AddWithValue("@cp", cpDireccion)
            cmd.Parameters.AddWithValue("@tipoDireccion", tipoDireccionDireccion)
            cmd.Parameters.AddWithValue("@correo", correoElectronico)
            cmd.Parameters.AddWithValue("@telefono", telefono)
            cmd.Parameters.AddWithValue("@tipoTelefono", tipoTelefono)
            cmd.Parameters.AddWithValue("@curp", curpContacto)
            cmd.Parameters.AddWithValue("@puesto", puestoContacto)
            cmd.Parameters.AddWithValue("@sueldo", sueldoContacto)
            cmd.Parameters.AddWithValue("@montoCredito", montoCreditoContacto)
            cmd.Parameters.AddWithValue("@diasCredito", diasCreditoContacto)
            cmd.Parameters.AddWithValue("@regimenFiscal", regimenFiscalContacto)
            cmd.Parameters.AddWithValue("@descripcion", descripcionContacto)
            cmd.Parameters.AddWithValue("@fechaEntregaMercancia", fechaEntregaMercanciaContacto)
            cmd.Parameters.AddWithValue("@idUsuario", Me.idUsuario)
            con.Open()
            cmd.ExecuteNonQuery()
        End Using

        Dim dataAccess As New DataAccess()
        DataGridView1.DataSource = dataAccess.ObtenerContactosCompletos()

        TabControl1.TabPages.Add(TabPage1)
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)

    End Sub
    Private Sub CerrarSesionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New Form1()
            loginForm.Show()
        End If
    End Sub
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim result As DialogResult = MessageBox.Show("¿Estás seguro de que deseas cerrar la aplicación?", "Cerrar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

End Class

