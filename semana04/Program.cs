using System;
using System.Collections.Generic;

class Curso
{
    public List<string> Asignaturas { get; private set; }
    public Dictionary<string, double> Notas { get; private set; }

    public Curso()
    {
        Asignaturas = new List<string> {"Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Notas = new Dictionary<string, double>();
    }

    public void PedirNotas()
    {
        foreach (var asignatura in Asignaturas)
        {
            Console.Write($"Introduce la nota de {asignatura}:");
            double nota = Convert.ToDouble(Console.ReadLine());
            Notas[asignatura] = nota;
        }
    }

    public void MostrarNotas()
    {
        foreach (var par in Notas)
        {
            Console.WriteLine($"En {par.Key} has sacado {par.Value}");
        }
    }
}

class Program

{
    static void Main()
    {
        Curso curso = new Curso();
        curso.PedirNotas();
        Console.WriteLine("\nResumen de notas:");
        curso.MostrarNotas();
    }