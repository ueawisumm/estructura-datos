using System;

namespace ListaEnlazadaRango
{
    public class Nodo
    {
        public int Valor;
        public Nodo Siguiente;

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    public class ListaEnlazada
    {
        private Nodo cabeza;

        public void Agregar(int valor)
        {
            Nodo nuevo = new Nodo(valor);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        public void EliminarFueraDeRango(int min, int max)
        {
            // Eliminar nodos desde el principio si están fuera de rango
            while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;
            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();
            Random rnd = new Random();

            // Agregar 50 números aleatorios entre 1 y 999
            for (int i = 0; i < 50; i++)
            {
                int num = rnd.Next(1, 1000);
                lista.Agregar(num);
            }

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            Console.Write("\: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el valor máximo del rango: ");
            int max = int.Parse(Console.ReadLine());

            lista.EliminarFueraDeRango(min, max);

            Console.WriteLine("\nLista después de eliminar nodos fuera del rango [{0}, {1}]:", min, max);
            lista.Mostrar();
        }
    }
}
