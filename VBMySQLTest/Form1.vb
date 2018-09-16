Imports MySql.Data.MySqlClient
Public Class Form1
    Public conn As New MySqlConnection("Server=localhost; User Id=root1; Password=''; Database=db_pratice")
    Public adapter As New MySqlDataAdapter
    Public command As New MySqlCommand
    Dim ds As DataSet

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("insert into tbl_accounts (firstname, lastname, username, password) VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')", conn)
        adapter.Fill(ds, "tbl_accounts")

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        MsgBox("Registered!")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("select * from tbl_accounts where username = '" & TextBox5.Text &
                                       "' and password = '" & TextBox6.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")

        If ds.Tables("tbl_accounts").Rows.Count > 0 Then
            MsgBox("Successful Login!")
            TextBox5.Clear()
            TextBox6.Clear()
        Else
            MsgBox("Invalid username and password!")
        End If
    End Sub
End Class
