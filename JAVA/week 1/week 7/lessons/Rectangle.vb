Public Class Rectangle : Inherits Square
    Private _otherside As Decimal

    Public Sub New(ByVal height As Decimal, ByVal width As Decimal, ByVal color As String)
        MyBase.New(width, color)
        Me._otherside = height
    End Sub
    'Description
    Public Overrides Function Description() As String
        Dim desc As String = ""
        desc &= "Height: " & Me._otherside & "CM " & vbNewLine
        desc &= "Width: " & Me._side & "CM " & vbNewLine
        desc &= "Color: " & Me._color & vbNewLine

        Return desc
    End Function


    'Methods
    Public Overrides Sub area()
        Dim area As Decimal = Me.Side * Me.Otherside
        Console.WriteLine("Area of Rectangle : " & area & "CM2")
    End Sub

    Public Overrides Sub perimeter()
        Dim perimeter As Decimal = Me.Side * 2 + Me.Otherside * 2
        Console.WriteLine("Perimeter of Rectangle : " & perimeter & "CM")
    End Sub

    'Getter & Setter
    Public Property Otherside() As String
        Get
            Return _otherside
        End Get
        Set(ByVal value As String)
            _otherside = value
        End Set
    End Property
    Public Class Form1


    End Class

End Class
