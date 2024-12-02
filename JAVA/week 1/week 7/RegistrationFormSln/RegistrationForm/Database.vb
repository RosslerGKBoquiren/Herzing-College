Imports MySql.Data.MySqlClient


Public Class Database

    Private ReadOnly connectionString As String = "Server=localhost;Database=registration;Uid=root;Pwd=;"

    ' database connection
    Public Function TestConnection() As Boolean
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Console.WriteLine("Database connection successful!")
                Return True
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
            Return False
        End Try
    End Function

    ' Insert a User into the database
    Public Function AddUser(user As User) As Boolean
        Dim query = "INSERT INTO users (name, email, password, gender, address, province, country, phone) " &
               "VALUES (@Name, @Email, @Password, @Gender, @Address, @Province, @Country, @Phone)"
        Try
            Using conn As New MySqlConnection(connectionString),
                  cmd As New MySqlCommand(query, conn)
                ' Bind parameters
                cmd.Parameters.AddWithValue("@Name", user.Name)
                cmd.Parameters.AddWithValue("@Email", user.Email)
                cmd.Parameters.AddWithValue("@Password", user.Password)
                cmd.Parameters.AddWithValue("@Gender", user.Gender)
                cmd.Parameters.AddWithValue("@Address", user.Address)
                cmd.Parameters.AddWithValue("@Province", user.Province)
                cmd.Parameters.AddWithValue("@Country", user.Country)
                cmd.Parameters.AddWithValue("@Phone", user.PhoneNumber)

                conn.Open()
                cmd.ExecuteNonQuery()
                Return True
            End Using
        Catch ex As MySqlException When ex.Number = 1062 ' MySQL duplicate entry error code
            MessageBox.Show("The email address is already registered. Please use a different email.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        Catch ex As Exception
            MessageBox.Show($"Error adding user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Class
