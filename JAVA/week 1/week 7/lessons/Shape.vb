Public MustInherit Class Shape
    'Properties
    Protected Property _side As Decimal
    Protected Property _color As String
    Protected Shared _count As Integer = 0

    Public Sub New(side As Decimal, color As String)
        Me._side = side
        Me._color = color
        _count += 1
    End Sub

    Public Overridable Function description() As String
        Dim desc As String = ""
        desc += "Side: " & _side & vbNewLine
        desc += "Color: " & _color & vbNewLine
        Return desc
    End Function


    Public Property Side() As Decimal
        Get
            Return _side
        End Get
        Set(side As Decimal)
            _side = side
        End Set
    End Property

    Public Property Color As String
        Get
            Return _color
        End Get
        Set(color As String)
            _color = color
        End Set
    End Property

    Public Property Count As Integer
        Get
            Return _count
        End Get
        Set(value As Integer)
            _count = value
        End Set
    End Property
End Class
