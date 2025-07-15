// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;

namespace FigurasGeometricas
{
    // Clase que representa un Círculo
    public class Circulo
    {
        private double radio;
        public Circulo(double radio) { this.radio = radio; }
        public double CalcularArea() { return Math.PI * radio * radio; }
        public double CalcularPerimetro() { return 2 * Math.PI * radio; }
    }

    // Clase que representa un Cuadrado
    public class Cuadrado
    {
        private double lado;
        public Cuadrado(double lado) { this.lado = lado; }
        public double CalcularArea() { return lado * lado; }
        public double CalcularPerimetro() { return 4 * lado; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear e instanciar un círculo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

            // Crear e instanciar un cuadrado con lado 4
            Cuadrado miCuadrado = new Cuadrado(4);
            Console.WriteLine("Área del cuadrado: " + miCuadrado.CalcularArea());
            Console.WriteLine("Perímetro del cuadrado: " + miCuadrado.CalcularPerimetro());
        }
    }
}
