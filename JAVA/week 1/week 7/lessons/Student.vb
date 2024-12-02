Public Class Student
    'properties
    Private _name As String
    Private _age As Integer
    Private _program As String

    'constructor
    Public Sub New()
        Console.WriteLine("Hi there.")
    End Sub

    Public Sub New(name As String, age As Integer, program As String)
        _name = name
        _age = age
        _program = program
    End Sub

    Sub description()
        Dim desc As String = ""
        desc += "Name: " & _name & vbNewLine
        desc += "Age: " & _age & vbNewLine
        desc += "Program: " & _program & vbNewLine

        Console.WriteLine(desc)
    End Sub

    Property Name As String
        Get
            Return _name
        End Get
        Set(name As String)
            _name = name
        End Set
    End Property



    'Property Name As String
    '    Get
    '        Return _name
    '    End Get
    '    Set(name As String)
    '        _name = name
    '    End Set
    'End Property

    Property Age As Integer
        Get
            Return _age
        End Get
        Set(age As Integer)
            If age <= 0 Then
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Invalid age value")
                Console.ForegroundColor = ConsoleColor.Gray
            Else
                _age = age
            End If

        End Set
    End Property

    Property Program As String
        Get
            Return _program
        End Get
        Set(program As String)
            _program = program
        End Set
    End Property

End Class
