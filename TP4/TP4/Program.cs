using System;
using System.Collections.Generic;

namespace TP4
{
    public class Persona
    {
        public Persona(int dNI, string nombre, string apellido, Empresa empresa)
        {
            this.dNI = dNI;
            this.nombre = nombre;
            this.apellido = apellido;
            this.empresa = empresa;
        }

        public int dNI { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }
        public String email { get; set; }

      
        public DateTime habilitacionFin { get; set; }
        public Empresa empresa;

        public override string ToString()
        {
            return string.Format("Nombre y apellido: " + this.nombre + " " + this.apellido + "\nDNI: " + this.dNI + "\n");
        }



    }

    public enum Actividad { educacion, salud, campo, seguridad, otros, desconocido };

    public class Empresa
    {
        public String razonSocial { get; set; }
        public String cuit { get; set; }
        public String domicilio { get; set; }
        public String localidad { get; set; }
        public String email { get; set; }
        public String telefono { get; set; }
        public Actividad actividadEmpresa;
        public int id { get; set; }
        public Empresa(string razonSocial, Actividad actividadEmpresa, String localidad, int id)
        {
            this.razonSocial = razonSocial;
            this.actividadEmpresa = actividadEmpresa;
            this.localidad = localidad;
            this.id = id;
        }

        public override string ToString()
        {
            return string.Format("ID: " + this.id + "\nRazon social: " + this.razonSocial + "\nActividad: " + this.actividadEmpresa + "\nLocalidad: " + this.localidad+"\n\n");
        }
    }

    public class Control
    {
        public Persona persona { get; set; }
        public double temperatura { get; set; }
        public String patente { get; set; }
        public String destino { get; set; }
        public Boolean aprobado { get; set; }

        public Control(Persona persona, double temperatura, string patente, string destino)
        {
            this.persona = persona;
            this.temperatura = temperatura;
            this.patente = patente;
            this.destino = destino;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int key = 0;
            int key2 = 0;
            int key3 = 0;


            List<Persona> personas = new List<Persona>();
            List<Persona> autorizadas = new List<Persona>();
            List<Empresa> empresas = new List<Empresa>();
            List<Control> controles = new List<Control>();
            List<Persona> rechazada = new List<Persona>();

            Empresa empresa1 = new Empresa("RESAK", Actividad.seguridad, "Brinkmann", 1);
            Empresa empresa2 = new Empresa("RAFITI", Actividad.salud, "San Nicolas", 2);

            Persona persona1 = new Persona(1, "Luciano", "Arnolfo", empresa1);
            Persona persona2 = new Persona(2, "Miguel", "Manrique", empresa1);
            Persona persona3 = new Persona(3, "Jose", "Bossana", empresa1);
            Persona persona4 = new Persona(4, "Maria", "Borgatello", empresa2);

            Control control1 = new Control(persona1, 37.5,"AMV 755", "Miramar");
            Control control2 = new Control(persona4, 36.1, "MAG 212", "Altos de Chipion");
            Control control3 = new Control(persona3, 37, "KDA 102", "Brinkmann");


            personas.Add(persona1);
            personas.Add(persona2);
            personas.Add(persona3);
            personas.Add(persona4);
            empresas.Add(empresa1);
            empresas.Add(empresa2);
            controles.Add(control1);
            controles.Add(control2);
            controles.Add(control3);



            do
            {
                Console.Clear();
                try
                {
                    Console.Write("\n1- Menu Control\n2- Menu empresa\n3- Salir\n");
                    key = int.Parse(Console.ReadLine());
                }
                catch (FormatException) {}

                switch (key)
                {
                    case 1:
                        Console.Clear();
                        do
                        {
                            try
                            {
                                Console.WriteLine("---------MENU CONTROL---------");
                                Console.Write("1- Lista de personas\n2- Lista de empresas\n3- Autorización\n4- Salir\n");
                                key2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException) { }
                            switch (key2)
                            {
                                case 1:
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
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Lista de empresas:");
                                    foreach (var empresa in empresas)
                                    {
                                        Console.Write(empresa);
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Lista de personas autorizadas:");
                                    foreach (var autorizada in personas)
                                    {
                                        if (autorizada.habilitacionFin > DateTime.Today) { 
                                            autorizadas.Add(autorizada);
                                            
                                            foreach(var control in controles)
                                            {
                                                if(autorizada.dNI == control.persona.dNI)
                                                {
                                                    if (control.temperatura > 37)
                                                    {
                                                        Console.WriteLine("La persona " + control.persona.nombre + " " + control.persona.apellido + " registra una temperatura mayor a 37° de " + control.temperatura+"°\n NO ESTA PERMITIDO EL INGRESO");
                                                        rechazada.Add(control.persona);
                                                    }
                                                    else Console.WriteLine("La persona " + control.persona.nombre + " " + control.persona.apellido + " puede pasar");
                                                }
                                            }


                                        }
                                    }

                                    foreach (var lista in autorizadas)
                                    {
                                       
                                        Console.WriteLine(lista);
                                    }
                                    autorizadas.Clear();
                                    break;
                                default:
                                    break;
                            }

                        } while (key2 != 4);
                        break;

                    case 2:

                        int ident;
                        Console.Clear();
                        Console.WriteLine("Lista de empresas:");
                        foreach (var empresa in empresas)
                        {
                            Console.Write(empresa);
                        }
                        Console.WriteLine("Ingresar ID de la empresa: ");
                        ident = int.Parse(Console.ReadLine());
                        

                        do
                        {
                            Console.WriteLine("---------MENU EMPRESA---------");
                            Console.WriteLine("1- Empleados\n2- Autorizar empleado\n3- Desautorizar empleado\n4- Salir\n");
                            key3 = int.Parse(Console.ReadLine());
                            switch (key3)
                            {
                                case 1:
                                    Console.Clear();
                                    foreach (var empleado in personas)
                                    {
                                        if(empleado.empresa.id==ident)
                                        Console.WriteLine(empleado);
                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    int idenEmpleado=0;
                                    Console.WriteLine("Ingresar DNI de empleado: ");
                                    idenEmpleado = int.Parse(Console.ReadLine());

                                    foreach (var empleado in personas)
                                    {
                                        if (empleado.empresa.id == ident && empleado.dNI == idenEmpleado)
                                        {
                                            Console.WriteLine(empleado);
                                            Console.WriteLine("\nIngresar la fecha en que termina la habilitación en formato DD/MM/YY");
                                            empleado.habilitacionFin = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine(empleado.habilitacionFin);
                                        }
                                    }

                                    break;

                                case 3:
                                    Console.Clear();
                                    idenEmpleado = 0;
                                    Console.WriteLine("Ingresar DNI de empleado: ");
                                    idenEmpleado = int.Parse(Console.ReadLine());
                                    foreach (var empleado in personas)
                                    {
                                        if (empleado.empresa.id == ident && empleado.dNI == idenEmpleado)
                                        {
                                            Console.WriteLine(empleado);
                                            empleado.habilitacionFin = Convert.ToDateTime(null);
                                            Console.WriteLine("El empleado "+empleado.nombre + " "+empleado.apellido+" fue desautorizado\n");
                                        }
                                    }

                                    break;

                                default:
                                    break;
                            }

                        } while (key3 != 4);
                        break;
                    default:
                        break;
                }
            } while (key != 3);
        }
    }
}
