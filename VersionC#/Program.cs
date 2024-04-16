namespace VersionC_
{
    public class Program
    {
        public static List<Compra> Compras = new List<Compra>();
        private static void Main(string[] args)
        {
            string real = "no";
            do
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("Bienvenido a tu lista de compras :3");
                Console.WriteLine("Aquí podrás guardar todas las compras de la semana");
                Console.WriteLine("Selecciona una opción: ");
                Console.WriteLine("1. Guardar una compra");
                Console.WriteLine("2. Listar todas las compras");
                Console.WriteLine("3. Consultar una compra");
                Console.WriteLine("4. Eliminar una compra");
                Console.WriteLine("5. Modificar una compra");
                Console.WriteLine("6. Salir");
                var respuesta = Console.ReadKey();
                Console.WriteLine("\n");
                switch (respuesta.KeyChar)
                {
                    case '1':
                        Crear();
                        break;
                    case '2':
                        Listar();
                        break;
                    case '3':
                        Consultar();
                        break;
                    case '4':
                        Eliminar();
                        break;
                    case '5':
                        Modificar();
                        break;
                    case '6':
                        Console.WriteLine("Hasta la próxima :3");
                        real = "si";
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (real == "no");
        }

        public static void Crear()
        {
            Compra compra = new();
            Console.WriteLine("Escribe el nombre del producto comprado: ");
            compra.Nombre = Console.ReadLine();
            bool verdad;
            do
            {
                Console.WriteLine("Escribe el precio del producto comprado: ");
                verdad = double.TryParse(Console.ReadLine(), out double precio);
                compra.Precio = precio;
            } while (!verdad);
            Console.WriteLine("Escribe el lugar donde se compró el producto: ");
            compra.Lugar = Console.ReadLine();
            compra.Fecha = DateTime.Now;
            compra.Id = (Compras.Count != 0) ? Compras.Last().Id + 1 : 1;
            Compras.Add(compra);
            Console.WriteLine("Felicidades, se guardó exitósamente la compra :3");
        }

        public static void Modificar()
        {
            if (Compras.Count == 0)
            {
                Console.WriteLine("Disculpe, tiene que tener compras para modificarlas");
                return;
            }
            Listar();
            bool verdad;
            int id;
            do
            {
                Console.WriteLine("Escribe la id del producto comprado: ");
                verdad = int.TryParse(Console.ReadLine(), out id);
            } while (!verdad && Compras.Any(x => x.Id == id));
            var compra = Compras.Find(x => x.Id == id);
            if (compra == null)
            {
                Console.WriteLine("Disculpe, no se encontró la compra en la lista");
                return;
            }
            Console.WriteLine("Escribe el nombre del producto comprado: ");
            Console.WriteLine($"(Dato original: {compra.Nombre})");
            compra.Nombre = Console.ReadLine();
            verdad = false;
            do
            {
                Console.WriteLine("Escribe el precio del producto comprado: ");
                Console.WriteLine($"(Dato original: {compra.Precio})");
                verdad = double.TryParse(Console.ReadLine(), out double precio);
                compra.Precio = precio;
            } while (!verdad);
            Console.WriteLine("Escribe el lugar donde se compró el producto: ");
            Console.WriteLine($"(Dato original: {compra.Lugar})");
            compra.Lugar = Console.ReadLine();
            var lugar = Compras.IndexOf(compra);
            Compras[lugar] = compra;
            Console.WriteLine("Felicidades, se modificó exitósamente la compra :3");
        }

        public static void Eliminar()
        {
            if (Compras.Count == 0)
            {
                Console.WriteLine("Disculpe, tiene que tener compras para eliminarlas");
                return;
            }
            Listar();
            bool verdad;
            int id;
            do
            {
                Console.WriteLine("Escribe la id del producto comprado: ");
                verdad = int.TryParse(Console.ReadLine(), out id);
            } while (!verdad && Compras.Any(x => x.Id == id));
            var compra = Compras.Find(x => x.Id == id);
            if (compra == null)
            {
                Console.WriteLine("Disculpe, no se encontró la compra en la lista");
                return;
            }
            verdad = Compras.Remove(compra);
            if (verdad) Console.WriteLine("Felicidades, se eliminó exitósamente la compra :3");
            else Console.WriteLine("Disculpe, no se pudo eliminar la compra");
        }

        public static void Consultar()
        {
            if (Compras.Count == 0)
            {
                Console.WriteLine("Disculpe, tiene que tener compras para consultarlas");
                return;
            }
            Listar();
            bool verdad;
            int id;
            do
            {
                Console.WriteLine("Escribe la id del producto comprado: ");
                verdad = int.TryParse(Console.ReadLine(), out id);
            } while (!verdad && Compras.Any(x => x.Id == id));
            var compra = Compras.Find(x => x.Id == id);
            if (compra == null)
            {
                Console.WriteLine("Disculpe, no se encontró la compra en la lista");
                return;
            }
            Console.WriteLine(compra);
            Console.WriteLine("Felicidades, se consultó exitósamente la compra :3");
        }

        public static void Listar()
        {
            Console.WriteLine("|--|------|------|-----|-----|");
            Console.WriteLine("|Id|Nombre|Precio|Lugar|Fecha|");
            Compras.ForEach(x =>
            {
                Console.WriteLine("|--|------|------|-----|-----|");
                Console.WriteLine($"|{x.Id}|{x.Nombre}|{x.Precio}|{x.Lugar}|{x.Fecha}|");
            });
            Console.WriteLine("|--|------|------|-----|-----|");
        }
    }
}