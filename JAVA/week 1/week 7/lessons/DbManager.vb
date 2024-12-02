Imports MySql.Data.MySqlClient

Public Class DbManager
    Private Property connectionString = "server=localhost;user id=root;password=;database=test2"
    Private Property connect As MySqlConnection

    'constructor
    Public Sub New()
        Try
            Me.connect = New MySqlConnection(connectionString)
            Me.connect.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connection Failed")
        End Try
    End Sub
    ''' <summary>
    ''' test the connection
    ''' </summary>
    Public Sub TestConnection()
        If Me.connect.State = ConnectionState.Open Then
            MsgBox("I am openn")
        Else
            MsgBox("Not open yet!")
        End If
    End Sub

    Public Function GetAllUser()
        Dim query As String = "SELECT * FROM test WHERE status = 1"
        Dim dataset As New DataSet

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim adaptor As New MySqlDataAdapter(cmd) 'Interaction with existing data sources is controlled through the DataAdapter.
            adaptor.Fill(dataset, "Users")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try

        Return dataset.Tables("Users").Rows
    End Function

    Public Function GetAllUserList() As List(Of User)
        Dim query As String = "SELECT * FROM test WHERE status = 1"
        Dim dataset As New DataSet
        Dim userList As New List(Of User)
        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim adaptor As New MySqlDataAdapter(cmd)
            adaptor.Fill(dataset, srcTable:="test")
            For Each row As DataRow In dataset.Tables("test").Rows
                userList.Add(New User(row("id"), row("fname"), row("lname"), row("age"), row("gender"), row("status")))
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "CONNECTION FAILED")
        End Try

        Return userList
    End Function

    Public Function GetSingleUser(id As Integer) As User
        Dim query As String = "SELECT * FROM test WHERE id = " & id
        Dim user As New User

        Try
            Dim cmd As New MySqlCommand(query, Me.connect)
            Dim reader As MySqlDataReader = cmd.ExecuteReader

            If reader.Read Then
                user.Id = reader.GetInt16(0)
                user.Firstname = reader.GetString(1)
                user.Lastname = reader.GetString(2)
                user.Age = reader.GetInt16(3)
                user.Gender = reader.GetString(4)
                user.Status = reader.GetBoolean(5)

            End If
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try

        Return user
    End Function

    Public Sub AddUser(user As User)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "INSERT INTO test VALUES(default, @firstname, @lastname, @age, @gender, default)"
            cmd.Parameters.AddWithValue("@firstname", user.Firstname)
            cmd.Parameters.AddWithValue("@lastname", user.Lastname)
            cmd.Parameters.AddWithValue("@age", user.Age)
            cmd.Parameters.AddWithValue("@gender", user.Gender)

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Row affected: " & rowAffected)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

    Public Sub EditUser(user As User)
        Dim cmd As New MySqlCommand

        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE test SET fname = @firstname, lname = @lastname, age = @age, gender = @gender WHERE id = @id"
            cmd.Parameters.AddWithValue("@firstname", user.Firstname)
            cmd.Parameters.AddWithValue("@lastname", user.Lastname)
            cmd.Parameters.AddWithValue("@age", user.Age)
            cmd.Parameters.AddWithValue("@gender", user.Gender)
            cmd.Parameters.AddWithValue("@id", user.Id)

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Row affected: " & rowAffected)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try
    End Sub

    Public Sub DeleteUser(id As Integer)
        Dim cmd As New MySqlCommand
        Try
            cmd.Connection = Me.connect
            cmd.CommandText = "UPDATE test SET status = 0 WHERE id = " & id

            Dim rowAffected = cmd.ExecuteNonQuery
            MsgBox("Row Affected: " & rowAffected)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connectionn Faild")
        End Try

    End Sub
End Class
