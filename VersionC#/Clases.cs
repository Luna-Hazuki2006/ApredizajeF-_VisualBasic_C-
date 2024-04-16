using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VersionC_
{
    public class Compra
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public string? Lugar { get; set; }
        public DateTime Fecha { get; set; }

        public Compra()
        {
            Id = 0;
            Nombre = "";
            Precio = 0.0;
            Lugar = "";
            Fecha = DateTime.Now;
        }

        public Compra(int id, string nombre, double precio, string lugar, DateTime fecha)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Lugar = lugar;
            Fecha = fecha;
        }

        public override string ToString()
        {
            string valor = $"Id: {Id}\n";
            valor += $"Nombre: {Nombre}\n";
            valor += $"Precio: {Precio}\n";
            valor += $"Lugar: {Lugar}\n";
            valor += $"Fecha: {Fecha}";
            return valor;
        }
    }
}
