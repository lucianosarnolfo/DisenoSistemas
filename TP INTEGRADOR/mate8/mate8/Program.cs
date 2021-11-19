using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;



namespace mate8
{
      public class Cliente
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contrasena { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public List<Tarjeta> tarjetas = new List<Tarjeta>();
        public List<Producto> productos = new List<Producto>();

        public Cliente()
        {

        }
        public Cliente(string email, string nombre, string apellido, string contrasena, string dni, string telefono)
        {
            this.email = email;
            this.nombre = nombre;
            this.apellido = apellido;
            this.contrasena = contrasena;
            this.dni = dni;
            this.telefono = telefono;
        }

        public override string ToString()
        {
            return string.Format("Nombre: "+this.nombre+" "+this.apellido+"\nDNI: "+this.dni+"\nTelefono: "+this.telefono); 
        }

    }
    public class Tarjeta
    {
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string numero { get; set; }
        public Cliente cliente { get; set; }

        public Tarjeta(string nombre, string tipo, string numero, Cliente cliente)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.numero = numero;
            this.cliente = cliente;
        }
        public Tarjeta()
        {

        }
    }
    public class Producto
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public Cliente cliente { get; set; }

        public Producto(string nombre, string descripcion, decimal precio)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public Producto(string nombre, Cliente cliente)
        {
            this.nombre = nombre;
            this.cliente = cliente;
        }
        public Producto()
        {

        }
    }







    class Program
    {
        static void Main(string[] args)
        {
            const string REGISTRO = "C:\\Users\\lucia\\Desktop\\proyecto.txt";
            List<Cliente> clientes = new List<Cliente>();
            List<Producto> productos = new List<Producto>();
            List<Producto> favoritos = new List<Producto>();
            List<Producto> historial = new List<Producto>();
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            Cliente cliente1 = new Cliente("jota@", "jota", "hache", "jota", "465645", "35615");
            Cliente cliente2 = new Cliente("luciano@gmail.com", "luciano", "arnolfo", "asdf", "3213123", "11321");
            Cliente cliente3 = new Cliente("admin", "admin", "admin", "admin", "11111", "123456798");
            Producto mateMetal = new Producto("Metal", "Mate de acero inoxidable", 1500);
            Producto mateCalabaza = new Producto("Calabaza","Mate hecho de calabaza curada",1000);
            clientes.Add(cliente1);
            clientes.Add(cliente2);
            clientes.Add(cliente3);
            productos.Add(mateMetal);
            productos.Add(mateCalabaza);

            int caseSwitchLogin = 0;
            int caseSwitchCliente = 0;
            bool caseWhile = true;
            string ingresarEmail;
            string ingresarContrasena;
            do
            {
                menuInicio:
                Console.WriteLine("Opcion 1: Registar\nOpcion 2: Iniciar sesion\nOpcion 3: Salir");
                caseSwitchLogin = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (caseSwitchLogin)
                {
                    case 1:
                        Console.Clear();
                        string emailRegistrar;
                        string nombreRegistrar;
                        string apellidoRegistrar;
                        string contrasenaRegistrar;
                        string dniRegistrar;
                        string telefonoRegistrar;
     
                        Console.WriteLine("Ingrese el email");
                        emailRegistrar = Console.ReadLine();
                        Console.WriteLine("Ingrese la contraseña");
                        contrasenaRegistrar = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre");
                        nombreRegistrar = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido");
                        apellidoRegistrar = Console.ReadLine();
                        Console.WriteLine("Ingrese el DNI");
                        dniRegistrar = Console.ReadLine();
                        Console.WriteLine("Ingrese el telefono");
                        telefonoRegistrar = Console.ReadLine();

                        foreach (var email in clientes)
                        {
                            if (email.email == emailRegistrar)
                            {
                                Console.WriteLine("El email ya existe, no se puede crear usuario");
                                caseWhile = false;
                                break;
                            }
                        }
                        if (caseWhile==true)
                        {
                            clientes.Add(AgregarCliente(emailRegistrar, nombreRegistrar, apellidoRegistrar, contrasenaRegistrar, dniRegistrar, telefonoRegistrar));
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese el email: ");
                        ingresarEmail = Console.ReadLine();
                        Console.WriteLine("Ingrese la contraseña: ");
                        ingresarContrasena = Console.ReadLine();
                        foreach (var cliente in clientes)
                        {
                            if (cliente.email == ingresarEmail && cliente.contrasena == ingresarContrasena)
                            {
                                menuCliente:
                                Console.Clear();                                
                                Console.WriteLine("Bienvenido " + cliente.nombre + " " + cliente.apellido);
                                Console.WriteLine("¿Que desea hacer?\n1- Ver tu informacion\n2- Ver productos favoritos\n3- Ver productos\n4- Ver historial de productos\n5- Ver tarjetas\n6- Agregar Tarjeta\n7- Eliminar Usuario\n8- Salir");
                                caseSwitchCliente = Convert.ToInt32(Console.ReadLine());
                                switch (caseSwitchCliente)
                                {
                                    //Ver tu informacion
                                    case 1:
                                        Console.WriteLine(cliente.ToString());
                                        Console.WriteLine("Pulse una tecla para continuar");
                                        Console.ReadKey();
                                        goto menuCliente;
                                    //Ver productos favoritos
                                    case 2:
                                        Console.WriteLine("Productos: ");
                                        foreach (Producto favorito in favoritos)
                                        {
                                            if (favorito.cliente.email == cliente.email)
                                            {
                                                Console.WriteLine(favorito.nombre);
                                            }
                                        }
                                        Console.WriteLine("Pulse una tecla para continuar");
                                        Console.ReadKey();
                                        goto menuCliente;
                                    // Ver productos
                                    case 3:
                                        Console.WriteLine("Escriba el nombre del producto para mas informacion");
                                        foreach (Producto producto in productos)
                                        {
                                            Console.WriteLine("Producto: "+producto.nombre);
                                        }
                                        Console.WriteLine("\n");
                                        string verProducto = Console.ReadLine();
                                        if (verProducto != null)
                                        {
                                            historial.Add(AgregarHistorial(verProducto,cliente));
                                            foreach (Producto producto in productos)
                                            {
                                                if (producto.nombre == verProducto)
                                                {
                                                    Console.WriteLine("Producto: " + producto.nombre + "\nDescripcion: " + producto.descripcion + "\nPrecio: " + producto.precio);
                                                    Console.WriteLine("1- Agregar a favoritos  2- Volver al menu");
                                                    int opcion = Convert.ToInt32(Console.ReadLine());
                                                    if (opcion == 1)
                                                    {
                                                        favoritos.Add(AgregarFavorito(verProducto, cliente));
                                                    }
                                                    else
                                                    {
                                                        goto menuCliente;
                                                    }
                                                }
                                            }
                                        }
                                        goto menuCliente;
                                    //Ver historial de productos
                                    case 4:
                                        Console.WriteLine("Usted visito los siguientes productos");
                                        foreach (Producto producto in historial)
                                        {
                                            Console.WriteLine(producto.nombre);
                                        }
                                        Console.WriteLine("Pulse una tecla para continuar");
                                        Console.ReadKey();
                                        goto menuCliente;
                                    //Ver tarjetas
                                    case 5:
                                        foreach  (Tarjeta tarjeta in tarjetas)
                                        {
                                            if (tarjeta.cliente.nombre == cliente.nombre)
                                            {
                                                Console.WriteLine("Tarjeta: "+tarjeta.nombre+"\nTipo: "+tarjeta.tipo+"\nNumero: "+tarjeta.numero);
                                            }
                                        }
                                        Console.WriteLine("Pulse una tecla para continuar");
                                        Console.ReadKey();
                                        goto menuCliente;
                                    //Agregar tarjetas
                                    case 6:
                                        Console.WriteLine("Nombre de la tarjeta: ");
                                        string tarjetaNombre = Console.ReadLine();
                                        Console.WriteLine("Tipo de tarjeta(credito/debito)");
                                        string tarjetaTipo = Console.ReadLine();
                                        Console.WriteLine("Numero de la tarjeta: ");
                                        string tarjetaNumero = Console.ReadLine();

                                        tarjetas.Add(AgregarTarjeta(tarjetaNombre,tarjetaTipo,tarjetaNumero,cliente));

                                        Console.WriteLine("Pulse una tecla para continuar");
                                        Console.ReadKey();
                                        goto menuCliente;
                                    //Eliminar cliente
                                    case 7:
                                        Console.WriteLine("Esta a pundo de eliminar el usuario\n1 para continuar, 2 para cancelar");
                                        int opcionEliminar = Convert.ToInt32(Console.ReadLine());
                                        if (opcionEliminar == 1)
                                        {
                                            clientes.Remove(cliente);
                                            goto menuInicio;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                    case 3:
                        caseWhile = false;
                        break;
                    default:
                        break;
                }
            } while (caseWhile == true);
            string jsonString = JsonSerializer.Serialize(clientes);
            using (StreamWriter registro = new StreamWriter(REGISTRO)) {
                registro.WriteLine(jsonString);
            }
        }
        //METODOS

        private static Cliente AgregarCliente(string email, string nombre, string apellido, string contrasena, string dni, string telefono)
        {
            Cliente cliente = new Cliente();
            cliente.email = email;
            cliente.nombre = nombre;
            cliente.apellido = apellido;
            cliente.contrasena = contrasena;
            cliente.dni = dni;
            cliente.telefono = telefono;

            return cliente;
        }

        private static Producto AgregarFavorito(string nombre, Cliente cliente)
        {
            Producto producto = new Producto();
            producto.nombre = nombre;
            producto.cliente = cliente;

            return producto;
        }
        private static Producto AgregarHistorial(string nombre, Cliente cliente)
        {
            Producto producto = new Producto();
            producto.nombre = nombre;
            producto.cliente = cliente;

            return producto;
        }

        private static Tarjeta AgregarTarjeta(string nombre, string tipo, string numero, Cliente cliente)
        {
            Tarjeta tarjeta = new Tarjeta();
            tarjeta.nombre = nombre;
            tarjeta.tipo = tipo;
            tarjeta.numero = numero;
            tarjeta.cliente = cliente;

            return tarjeta;
        }
    }
}
