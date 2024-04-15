Imports System
Imports VersionVisualBasic
Module Program
    Public Compras As New List(Of Compra)
    Public Sub Main(args As String())
        Dim real As String = "no"
        Do
            Console.WriteLine("***********************************")
            Console.WriteLine("Bienvenido a tu lista de compras :3")
            Console.WriteLine("Aquí podrás guardar todas las compras de la semana")
            Console.WriteLine("Selecciona una opción: ")
            Console.WriteLine("1. Guardar una compra")
            Console.WriteLine("2. Listar todas las compras")
            Console.WriteLine("3. Consultar una compra")
            Console.WriteLine("4. Eliminar una compra")
            Console.WriteLine("5. Modificar una compra")
            Console.WriteLine("6. Salir")
            Dim respuesta = Console.ReadKey()
            Console.WriteLine(vbCrLf)
            If respuesta.KeyChar = "1" Then
                Crear()
            ElseIf respuesta.KeyChar = "2" Then
                Listar()
            ElseIf respuesta.KeyChar = "3" Then
                Consultar()
            ElseIf respuesta.KeyChar = "4" Then
                Eliminar()
            ElseIf respuesta.KeyChar = "5" Then
                Modificar()
            ElseIf respuesta.KeyChar = "6" Then
                Console.WriteLine("Hasta la próxima :3")
                real = "si"
            Else
                Console.Clear()
            End If
        Loop While real.Equals("no")
    End Sub

    Public Sub Crear()
        Dim compra As New Compra()
        Console.WriteLine("Escribe el nombre del producto comprado: ")
        compra.Nombre = Console.ReadLine()
        Dim verdad As Boolean
        Do
            Console.WriteLine("Escribe el precio del producto comprado: ")
            verdad = Double.TryParse(Console.ReadLine, compra.Precio)
        Loop Until verdad
        Console.WriteLine("Escribe el lugar donde se compró el producto: ")
        compra.Lugar = Console.ReadLine()
        compra.Fecha = Date.Now
        compra.Id = If(Compras.Count <> 0, Compras.Last().Id + 1, 1)
        Compras.Add(compra)
        Console.WriteLine("Felicidades, se guardó exitósamente la compra :3")
    End Sub

    Public Sub Modificar()
        If Compras.Count.Equals(0) Then
            Console.WriteLine("Disculpe, tiene que tener compras para modificarlas")
            Return
        End If
        Listar()
        Dim verdad As Boolean
        Dim id As Integer
        Do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad = Integer.TryParse(Console.ReadLine(), id)
        Loop While Not verdad And Compras.Any(Function(x) x.Id.Equals(id))
        Dim compra = Compras.Find(Function(x) x.Id.Equals(id))
        If compra Is Nothing Then
            Console.WriteLine("Disculpe, no se encontró la compra en la lista")
            Return
        End If
        Console.WriteLine("Escribe el nombre del producto comprado: ")
        Console.WriteLine($"(Dato original: {compra.Nombre})")
        compra.Nombre = Console.ReadLine()
        verdad = False
        Do
            Console.WriteLine("Escribe el precio del producto comprado: ")
            Console.WriteLine($"(Dato original: {compra.Precio})")
            verdad = Double.TryParse(Console.ReadLine, compra.Precio)
        Loop Until verdad
        Console.WriteLine("Escribe el lugar donde se compró el producto: ")
        Console.WriteLine($"(Dato original: {compra.Lugar})")
        compra.Lugar = Console.ReadLine()
        Dim lugar = Compras.IndexOf(compra)
        Compras.ForEach(
            Sub(x)
                If x.Id.Equals(compra.Id) Then
                    x = compra
                    Return
                End If
            End Sub)
        Console.WriteLine("Felicidades, se modificó exitósamente la compra :3")
    End Sub

    Public Sub Eliminar()
        If Compras.Count.Equals(0) Then
            Console.WriteLine("Disculpe, tiene que tener compras para eliminarlas")
            Return
        End If
        Listar()
        Dim verdad As Boolean
        Dim id As Integer
        Do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad = Integer.TryParse(Console.ReadLine(), id)
        Loop While Not verdad And Compras.Any(Function(x) x.Id.Equals(id))
        Dim compra = Compras.Find(Function(x) x.Id.Equals(id))
        If compra Is Nothing Then
            Console.WriteLine("Disculpe, no se encontró la compra en la lista")
            Return
        End If
        verdad = Compras.Remove(compra)
        If verdad Then
            Console.WriteLine("Felicidades, se eliminó exitósamente la compra :3")
        Else Console.WriteLine("Disculpe, no se pudo eliminar la compra")
        End If
    End Sub

    Public Sub Consultar()
        If Compras.Count.Equals(0) Then
            Console.WriteLine("Disculpe, tiene que tener compras para consultarlas")
            Return
        End If
        Listar()
        Dim verdad As Boolean
        Dim id As Integer
        Do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad = Integer.TryParse(Console.ReadLine(), id)
        Loop While Not verdad And Compras.Any(Function(x) x.Id.Equals(id))
        Dim compra = Compras.Find(Function(x) x.Id.Equals(id))
        If compra Is Nothing Then
            Console.WriteLine("Disculpe, no se encontró la compra en la lista")
            Return
        End If
        Console.WriteLine(compra)
        Console.WriteLine("Felicidades, se consultó exitósamente la compra :3")
        Return
    End Sub

    Public Sub Listar()
        Console.WriteLine("|--|------|------|-----|-----|")
        Console.WriteLine("|Id|Nombre|Precio|Lugar|Fecha|")
        Compras.ForEach(
            Sub(x)
                Console.WriteLine("|--|------|------|-----|-----|")
                Console.WriteLine($"|{x.Id}|{x.Nombre}|{x.Precio}|{x.Lugar}|{x.Fecha}|")
            End Sub)
        Console.WriteLine("|--|------|------|-----|-----|")
    End Sub
End Module
