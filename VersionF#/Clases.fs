module Clases

open System

type Compra(id : int, nombre : string, precio : double, lugar : string, fecha : DateTime) = 
    inherit Object()
    let mutable id = id
    let mutable nombre = nombre
    let mutable precio = precio
    let mutable lugar = lugar
    let mutable fecha = fecha
    member this.Id with get() = id and set(x) = id <- x
    member this.Nombre with get() = nombre and set(x) = nombre <- x
    member this.Precio with get() = precio and set(x) = precio <- x
    member this.Lugar with get() = lugar and set(x) = lugar <- x
    member this.Fecha with get() = fecha and set(x) = fecha <- x

    new() = Compra(0, "", 0.0, "", DateTime.Now)

    override this.ToString() = 
        let mutable valor = $"Id: {this.Id}\n"
        valor <- valor + $"Nombre: {this.Nombre}\n"
        valor <- valor + $"Precio: {this.Precio}\n"
        valor <- valor +  $"Lugar: {this.Lugar}\n"
        valor <- valor + $"Fecha: {this.Fecha}"
        valor
