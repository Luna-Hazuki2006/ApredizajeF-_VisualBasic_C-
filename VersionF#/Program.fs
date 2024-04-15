// For more information see https://aka.ms/fsharp-console-apps
open System
open System.Collections.Generic
open Clases

let mutable Compras = new List<Compra>()

let Crear() = 
    let compra = new Compra()
    Console.WriteLine("Escribe el nombre del producto comprado: ")
    compra.Nombre <- Console.ReadLine()
    let mutable verdad = false
    while not verdad do 
        let mutable precio = 0.0
        Console.WriteLine("Escribe el precio del producto comprado: ")
        verdad <- Double.TryParse(Console.ReadLine(), &precio)
        compra.Precio <- precio
    Console.WriteLine("Escribe el lugar donde se compró el producto: ")
    compra.Lugar <- Console.ReadLine()
    compra.Fecha <- DateTime.Now
    compra.Id <- if Compras.Count <> 0 then Compras.FindLast(fun x -> x.Id <> -1).Id + 1 else 1
    Compras.Add(compra)
    Console.WriteLine("Felicidades, se guardó exitósamente la compra :3")

let Listar() = 
    Console.WriteLine("|--|------|------|-----|-----|")
    Console.WriteLine("|Id|Nombre|Precio|Lugar|Fecha|")
    Compras.ForEach(fun x -> 
        Console.WriteLine("|--|------|------|-----|-----|")
        Console.WriteLine($"|{x.Id}|{x.Nombre}|{x.Precio}|{x.Lugar}|{x.Fecha}|"))
    Console.WriteLine("|--|------|------|-----|-----|")

let Modificar() = 
    if Compras.Count = 0 then 
        Console.WriteLine("Disculpe, tiene que tener compras para consultarlas")
    else 
        Listar()
        let mutable verdad = false
        let mutable id = 0
        while not verdad do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad <- Int32.TryParse(Console.ReadLine(), &id)
            verdad <- Compras.Exists(fun x -> x.Id = id)
        let mutable compra = Compras.Find(fun x -> x.Id = id)
        Console.WriteLine("Escribe el nombre del producto comprado: ")
        Console.WriteLine($"(Dato original: {compra.Nombre})")
        compra.Nombre <- Console.ReadLine()
        let mutable verdad = false
        while not verdad do 
            let mutable precio = 0.0
            Console.WriteLine("Escribe el precio del producto comprado: ")
            Console.WriteLine($"(Dato original: {compra.Precio})")
            verdad <- Double.TryParse(Console.ReadLine(), &precio)
            compra.Precio <- precio
        Console.WriteLine("Escribe el lugar donde se compró el producto: ")
        Console.WriteLine($"(Dato original: {compra.Lugar})")
        compra.Lugar <- Console.ReadLine()
        let lugar = Compras.IndexOf(compra)
        Compras[lugar] <- compra
        Console.WriteLine("Felicidades, se modificó exitósamente la compra :3")


let Eliminar() = 
    if Compras.Count = 0 then 
        Console.WriteLine("Disculpe, tiene que tener compras para consultarlas")
    else 
        Listar()
        let mutable verdad = false
        let mutable id = 0
        while not verdad do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad <- Int32.TryParse(Console.ReadLine(), &id)
            verdad <- Compras.Exists(fun x -> x.Id = id)
        let mutable compra = Compras.Find(fun x -> x.Id = id)
        verdad <- Compras.Remove(compra)
        if verdad then Console.WriteLine("Felicidades, se eliminó exitósamente la compra :3")
        else Console.WriteLine("Disculpe, no se pudo eliminar la compra")

let Consultar() = 
    Console.WriteLine("Consultar")
    if Compras.Count = 0 then 
        Console.WriteLine("Disculpe, tiene que tener compras para consultarlas")
    else 
        Listar()
        let mutable verdad = false
        let mutable id = 0
        while not verdad do
            Console.WriteLine("Escribe la id del producto comprado: ")
            verdad <- Int32.TryParse(Console.ReadLine(), &id)
            verdad <- Compras.Exists(fun x -> x.Id = id)
        let mutable compra = Compras.Find(fun x -> x.Id = id)
        Console.WriteLine(compra);
        Console.WriteLine("Felicidades, se consultó exitósamente la compra :3");


let mutable real = "no"
while real = "no" do
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
    let mutable respuesta = Console.ReadKey();
    Console.WriteLine("\n")
    if respuesta.KeyChar = '1' then Crear()
    elif respuesta.KeyChar = '2' then Listar()
    elif respuesta.KeyChar = '3' then Consultar()
    elif respuesta.KeyChar = '4' then Eliminar()
    elif respuesta.KeyChar = '5' then Modificar()
    elif respuesta.KeyChar = '6' then 
        Console.WriteLine("Hasta la próxima :3")
        real <- "si"
    else Console.Clear()
    