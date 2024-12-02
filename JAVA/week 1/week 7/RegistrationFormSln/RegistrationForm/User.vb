Public Class User

    Public Property Name As String
    Public Property Email As String
    Public Property Password As String
    Public Property Gender As String
    Public Property Address As String
    Public Property Province As String
    Public Property Country As String
    Public Property PhoneNumber As String


    Public Sub New(name As String, email As String, password As String, gender As String,
                   address As String, province As String, country As String, phoneNumber As String)
        Me.Name = name
        Me.Email = email
        Me.Password = password
        Me.Gender = gender
        Me.Address = address
        Me.Province = province
        Me.Country = country
        Me.PhoneNumber = phoneNumber
    End Sub

    ' Constructor
    Public Sub New()
    End Sub

End Class

