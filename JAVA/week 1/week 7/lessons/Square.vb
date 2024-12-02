Public Class Square : Inherits Shape

    'Constructor
    Public Sub New(side As Decimal, color As String)
        MyBase.New(side, color)

    End Sub
    ' -------Methods-------
    ''' <summary>
    ''' Display Square description (overrides from parent (Shape)
    ''' </summary>
    Public Overrides Function description() As String
        Dim desc As String = ""
        desc += MyBase.description()
        Return desc
    End Function
    ''' <summary>
    ''' Calculate area of square
    ''' </summary>
    Public Overridable Sub area()
        Console.WriteLine("Area of Square: " & Me.Side * Me.Side)
    End Sub
    ''' <summary>
    ''' calculate perimeter of square
    ''' </summary>
    Public Overridable Sub perimeter()
        Console.WriteLine("Perimeter of Square: " & 4 * Me.Side)
    End Sub


End Class
