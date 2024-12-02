Public Class MyClass1
    'properties
    Public _name As String
    'constructor
    Public Sub New()
        Console.WriteLine("I'm the constructor.")
    End Sub
    'constructor overload
    Public Sub New(name As String)
        _name = name
    End Sub

    Sub description()
        Dim desc As String = ""
        desc += "Name: " & _name & vbNewLine

        Console.WriteLine(desc)
    End Sub

End Class
