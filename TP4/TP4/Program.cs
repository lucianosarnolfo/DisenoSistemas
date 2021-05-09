using System;
using System.Collections.Generic;

namespace TP4
{
    public class Persona
    {
        public Persona(int dNI, string nombre, string apellido, Actividad actividadPersona)
        {
            this.dNI = dNI;
            this.nombre = nombre;
            this.apellido = apellido;
            this.actividadPersona = actividadPersona;
        }

        public int dNI { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public String email { get; set; }

        public Actividad actividadPersona;


        public override string ToString()
        {
            return string.Format("Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.dNI + "\n");
        }

    }

    public enum Actividad { educacion, salud, campo, seguridad, otros, desconocido };



    class Program
    {
        static void Main(string[] args)
        {
            int key = 0;
            Console.WriteLine("Hello World!");

            List<Persona> personas = new List<Persona>();

            Persona persona1 = new Persona(123, "Luciano", "Arnolfo", Actividad.campo);
            Persona persona2 = new Persona(124, "Miguel", "Manrique", Actividad.educacion);
            Persona persona3 = new Persona(125, "Jose", "Bossana", Actividad.otros);

            personas.Add(persona1);
            personas.Add(persona2);
            personas.Add(persona3);
            do
            {
                Console.Write("\n1- Comprobar persona\n2- Lista de personas\n3- Salir\n");
                key = Convert.ToInt16(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        int dni;
                        Console.Write("Ingrese el DNI: ");
                        dni = Convert.ToInt32(Console.ReadLine());
                        foreach (var persona in personas)
                        {
                            if (persona.dNI == dni)
                            {

                                if (persona.actividadPersona == Actividad.desconocido || persona.actividadPersona == Actividad.otros)
                                {
                                    Console.WriteLine("{0} {1} NO esta autorizado/a", persona.nombre, persona.apellido);
                                }
                                else { Console.WriteLine("{0} {1} SI esta autorizado/a", persona.nombre, persona.apellido); }
                            }
                        }
                        break;
                    case 2:
                        int totalPersonas = 0;
                        Console.Clear();
                        Console.WriteLine("Lista de personas:");
                        foreach (var persona in personas)
                        {
                            Console.Write(persona);
                            totalPersonas++;
                        }
                        Console.WriteLine("Total= " + totalPersonas);
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

            } while (key != 3);

            //prueba
        }
    }
}
