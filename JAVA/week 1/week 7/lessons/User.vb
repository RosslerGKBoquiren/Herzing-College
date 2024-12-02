Public Class User
    'Properties
    Private Property _id As Integer = 0
    Private Property _firstname As String
    Private Property _lastname As String
    Private Property _age As Integer
    Private Property _gender As String
    Private Property _status As Boolean

    'constructors
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, fname As String, lname As String, age As Integer, gender As String, status As Integer)
        Me._id = id
        Me._firstname = fname
        Me._lastname = lname
        Me._age = age
        Me._gender = gender
        Me._status = status
    End Sub
    Public Sub New(fname As String, lname As String, age As Integer, gender As String)
        Me._firstname = fname
        Me._lastname = lname
        Me._age = age
        Me._gender = gender
    End Sub

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property Firstname() As String
        Get
            Return _firstname
        End Get
        Set(value As String)
            _firstname = value
        End Set
    End Property
    Public Property Lastname() As String
        Get
            Return _lastname
        End Get
        Set(value As String)
            _lastname = value
        End Set
    End Property
    Public Property Age() As Integer
        Get
            Return _age
        End Get
        Set(value As Integer)
            _age = value
        End Set
    End Property

    Public Property Gender() As String
        Get
            Return _gender
        End Get
        Set(value As String)
            _gender = value
        End Set
    End Property

    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(value As Boolean)
            _status = value
        End Set
    End Property
End Class
