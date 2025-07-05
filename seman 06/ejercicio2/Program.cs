// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using System;

namespace EstacionamientoVehiculos
{
    public class Vehiculo
    {
        public string Placa;
        public string Marca;
        public string Modelo;
        public int Anio;
        public decimal Precio;
        public Vehiculo Siguiente;

        public Vehiculo(string placa)
        {
            Placa = placa;
            Marca = "Toyota";
            Modelo = "Hilux CD";
            Anio = 2025;
            Precio = 25000;
            Siguiente = null;
         }
    }

    public class ListaVehiculos
    {
        private Vehiculo cabeza;

        public void Agregar(Vehiculo nuevo)
        {
            nuevo.Siguiente = cabeza;
            cabeza = nuevo;
            Console.WriteLine($"Vehículo {nuevo.Placa} agregado.");
        }

        public void BuscarPorPlaca(string placa)
        {
            Vehiculo actual = cabeza;
            while (actual != null)
            {
                if (actual.Placa == placa)
                {
                    MostrarVehiculo(actual);
                    return;
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine($"Vehículo con placa {placa} no encontrado.");
        }

        public void VerPorAnio(int anio)
        {
            bool encontrado = false;
            Vehiculo actual = cabeza;
            while (actual != null)
            {
                if (actual.Anio == anio)
                {
                    MostrarVehiculo(actual);
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }
            if (!encontrado)
                Console.WriteLine($"No hay vehículos del año {anio}.");
        }

        public void VerTodos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }
            Vehiculo actual = cabeza;
            while (actual != null)
            {
                MostrarVehiculo(actual);
                actual = actual.Siguiente;
            }
        }

        public void EliminarPorPlaca(string placa)
        {
            if (cabeza == null)
            {
                Console.WriteLine(" No hay vehículos registrados.");
                return;
            }

            if (cabeza.Placa == placa)
            {
                cabeza = cabeza.Siguiente;
                Console.WriteLine($" Vehículo con placa {placa} eliminado.");
                return;
            }

            Vehiculo actual = cabeza;
            while (actual.Siguiente != null && actual.Siguiente.Placa != placa)
            {
                actual = actual.Siguiente;
            }

            if (actual.Siguiente != null)
            {
                actual.Siguiente = actual.Siguiente.Siguiente;
                Console.WriteLine($" Vehículo con placa {placa} eliminado.");
            }
            else
            {
                Console.WriteLine($"Vehículo con placa {placa} no encontrado.");
            }
        }

        private void MostrarVehiculo(Vehiculo v)
        {
            Console.WriteLine($"Placa: {v.Placa}, Marca: {v.Marca}, Modelo: {v.Modelo}, Año: {v.Anio}, Precio: ${v.Precio:N2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaVehiculos lista = new ListaVehiculos();

            // Vehículo pre-registrado
            Vehiculo predefinido = new Vehiculo("ABC123");
            lista.Agregar(predefinido);

            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú Estacionamiento ---");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos");
                Console.WriteLine("5. Eliminar vehículo por placa");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese placa: ");
                        string placa = Console.ReadLine();

                        Vehiculo nuevo = new Vehiculo(placa);
                        lista.Agregar(nuevo);
                        break;

                    case 2:
                        Console.Write("Ingrese la placa a buscar: ");
                        string placaBuscar = Console.ReadLine();
                        lista.Busc
arPorPlaca(placaBuscar);
                        break;

                    case 3:
                        Console.Write("Ingrese el año a consultar: ");
                        int anioConsulta = int.Parse(Console.ReadLine());
                        lista.VerPorAnio(anioConsulta);
                        break;

                    case 4:
                        lista.VerTodos();
                        break;

                    case 5:
                        Console.Write("Ingrese la placa a eliminar: ");
                        string placaEliminar = Console.ReadLine();
                        lista.EliminarPorPlaca(placaEliminar);
                        break;

                    case 6:
                        Console.WriteLine(" saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 6);
        }
    }
}
