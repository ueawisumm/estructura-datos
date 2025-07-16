dt
Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

namespace AgendaClinica
{
    class PacienteTurno
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string HoraTurno { get; set; }

        public PacienteTurno(string cedula, string nombre, string horaTurno)
        {
            Cedula = cedula;
            Nombre = nombre;
            HoraTurno = horaTurno;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Cédula: {Cedula} | Nombre: {Nombre} | Hora: {HoraTurno}");
        }
    }

    class Program
    {
        static List<PacienteTurno> turnos = new List<PacienteTurno>();

        static void Main(string[] args)
        {
            // Pacientes y turnos pre-registrados
            turnos.Add(new PacienteTurno("1401264738", "Billy", "15:00"));
            turnos.Add(new PacienteTurno("1703456789", "Ana López", "09:00"));
            turnos.Add(new PacienteTurno("1809876543", "Carlos Pérez", "11:00"));
            turnos.Add(new PacienteTurno("1901234567", "María Gómez", "13:00"));

            int opcion;

            do
            {
                Console.WriteLine("\n--- Agenda de Turnos de la Clínica ---");
                Console.WriteLine("1. Registrar turno");
                Console.WriteLine("2. Consultar turnos");
                Console.WriteLine("3. Eliminar turno");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor ingrese un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarTurno();
                        break;
                    case 2:
                        ConsultarTurnos();
                        break;
                    case 3:
                        EliminarTurno();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 4);
        }

        static void RegistrarTurno()
        {
            Console.Write("Ingrese la cédula del paciente: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el nombre del paciente: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la hora del turno (ejemplo 15:00): ");
            string hora = Console.ReadLine();

            bool existe = turnos.Exists(t => t.Cedula == cedula && t.HoraTurno == hora);
            if (existe)
            {
                Console.WriteLine("Ya existe un turno para este paciente a esa hora.");
                return;
            }

            PacienteTurno nuevo = new PacienteTurno(cedula, nombre, hora);
            turnos.Add(nuevo);

            Console.WriteLine("Turno registrado correctamente.");
        }

        static void ConsultarTurnos()
        {
            Console.WriteLine("\n--- Lista de Turnos ---");
            if (turnos.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
            }
            else
            {
                foreach (var turno in turnos)
                {
                    turno.Mostrar();
                }
            }
        }

        static void EliminarTurno()
        {
            Console.Write("Ingrese la cédula del paciente para eliminar su turno: ");
            string cedula = Console.ReadLine();

            PacienteTurno encontrado = turnos.Find(t => t.Cedula == cedula);

            if (encontrado != null)
            {
                turnos.Remove(encontrado);
                Console.WriteLine("Turno eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un turno con esa cédula.");
            }
        }
    }
}