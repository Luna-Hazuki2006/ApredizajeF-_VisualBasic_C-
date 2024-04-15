Public Class Compra
    Public Property Id As Integer
    Public Property Nombre As String
    Public Property Precio As Double
    Public Property Lugar As String
    Public Property Fecha As Date
    Public Sub New()
        Id = 0
        Nombre = ""
        Precio = 0.0
        Lugar = ""
        Fecha = Date.Now
    End Sub
    Public Sub New(Id As Integer, Nombre As String, Precio As Double, Lugar As String,
                   Fecha As Date)
        Me.Id = Id
        Me.Nombre = Nombre
        Me.Precio = Precio
        Me.Lugar = Lugar
        Me.Fecha = Fecha
    End Sub
    Public Overrides Function ToString() As String
        Dim valor = $"Id: {Id}{vbCrLf}"
        valor += $"Nombre: {Nombre}{vbCrLf}"
        valor += $"Precio: {Precio}{vbCrLf}"
        valor += $"Lugar: {Lugar}{vbCrLf}"
        valor += $"Fecha: {Fecha}"
        Return valor
    End Function
End Class
