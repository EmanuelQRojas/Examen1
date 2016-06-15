using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Examen1QuirosEmanuel
{
    class Program
    {
        static int i = 0;
        static int frituras = 0, reposteria = 0, gaseosos = 0, naturales = 0, confiteria = 0;
        static string listado = "                            Global Machines                              " +
            "\n==========================================================================" +
            "\n                         Listado de Productos                             " +
            "\n==========================================================================" +
            "\nReg  Codigo  Nombre  Tipo    Vencimiento Proveedor   Posicion    Precio   ";
        struct articulo
        {
            public int codigo;
            public string nombre;
            public int tipo;
            public string vencimiento;
            public string proveedor;
            public int posicion_estante;
            public int precio;
            public int reg;
        }
        enum tipo {frituras=1, reposteria, refrescos_gaseosos, refrescos_naturales, confiteria };
        enum estante {nivel_1=1, nivel_2, nivel_3, nivel_4, nivel_5 };
        static void AddItem()
        {
            int preguntar = 0;
            while (preguntar != 2)
            {
                Console.Clear();
                if (i < articulos.Length)
                {
                    articulos[i].reg = i + 1;
                    Console.WriteLine("Ingrese el codigo del producto: ");
                    articulos[i].codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nombre del producto: ");
                    articulos[i].nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el tipo del producto: " +
                            "\n1.frituras" +
                            "\n2.reposteria" +
                            "\n3.refrescos_gaseosos" +
                            "\n4.refrescos_naturales" +
                            "\n5.confiteria");
                    int clas = Convert.ToInt32(Console.ReadLine());
                    if (clas==1) { frituras++; }
                    if (clas == 2) { reposteria++; }
                    if (clas == 3) { gaseosos++; }
                    if (clas == 4) { naturales++; }
                    if (clas == 5) { confiteria++; }
                    articulos[i].tipo = clas;
                    Console.WriteLine("Ingrese la fecha de vencimiento(dd/mm/aaaa): ");
                    Console.WriteLine("Dia:");
                    String dia = Console.ReadLine();
                    Console.WriteLine("Mes:");
                    String mes = Console.ReadLine();
                    Console.WriteLine("Año:");
                    String annio = Console.ReadLine();
                    String fecha= dia + "/" + mes + "/" + annio;
                    articulos[i].vencimiento = fecha;
                    Console.WriteLine("Ingrese el nombre del proveedor: ");
                    articulos[i].proveedor = Console.ReadLine();
                    Console.WriteLine("Ingrese la posicion en el estante del producto: " +
                            "\n1.nivel 1" +
                            "\n2.nivel 2" +
                            "\n3.nivel 3" +
                            "\n4.nivel 4" +
                            "\n5.nivel 5");
                    articulos[i].posicion_estante = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el precio del producto: ");
                    articulos[i].precio = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Desea ingresar otro producto?"
                       + "\n1.Si" +
                       "\n2.No");
                    int pregunta = Convert.ToInt32(Console.ReadLine());
                    if (pregunta == 2)
                        preguntar = 2;

                }
                else
                {
                    Console.WriteLine("Registro de articulos lleno..");
                    preguntar = 1;
                    Console.ReadKey();
                }
            }

        }
        static void SeekItem()
        {
            bool found = false;//saber si lo encontró
            int Codigo = 0;
            int preguntar = 0;
            while (preguntar != 2)
            {
                Console.Clear();
                Console.WriteLine("Busqueda de Articulos.           ");
                Console.WriteLine("Digite el Codigo del articulo a buscar:");
                Codigo = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < articulos.Length; i++)
                {
                    if (Codigo == articulos[i].codigo)
                    {
                        Console.WriteLine("Codigo:       " + articulos[i].codigo);
                        Console.WriteLine("Nombre:   " + articulos[i].nombre);
                        string tipo = "";
                        if (articulos[i].tipo==1) { tipo = "fritura"; }
                        if (articulos[i].tipo == 2) { tipo = "reposteria"; }
                        if (articulos[i].tipo == 3) { tipo = "refresco gaseoso"; }
                        if (articulos[i].tipo == 4) { tipo = "refresco natural"; }
                        if (articulos[i].tipo == 5) { tipo = "confite"; }
                        Console.WriteLine("Tipo:     " + tipo);
                        Console.WriteLine("Vencimiento:       " + articulos[i].vencimiento);
                        Console.WriteLine("Proveedor:   " + articulos[i].proveedor);
                        Console.WriteLine("Posicion en el estante:       " + articulos[i].posicion_estante);
                        Console.WriteLine("Precio:       " + articulos[i].precio);
                        Console.WriteLine("Registro:    " + articulos[i].reg);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No se encontro ese articulo");
                    found = false;
                }
                Console.WriteLine("Desea buscar otro articulo?" +
                    "1-Sí 2-No");
                preguntar = Convert.ToInt32(Console.ReadLine());

            }
            
        }
        static bool DeleteItem() {
            bool found = false;
            bool confirm = false;//saber si lo borró
            int Codigo = 0;
            int preguntar = 0;
            while (preguntar != 2)
            {
                Console.Clear();
                Console.WriteLine("Eliminacion de Articulos.           ");
                Console.WriteLine("Digite el Codigo del articulo a buscar:");
                Codigo = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < articulos.Length; i++)
                {
                    if (Codigo == articulos[i].codigo)
                    {
                        Console.WriteLine("Seguro que desea eliminar este articulo?"+"\n1.Si\n2.No");
                        int confirmar = Convert.ToInt32(Console.ReadLine());
                        if (confirmar == 1)
                        {
                            articulos[i].codigo = 0;
                            articulos[i].nombre = "";
                            int clas = articulos[i].tipo;
                            if (clas == 1) { frituras--; }
                            if (clas == 2) { reposteria--; }
                            if (clas == 3) { gaseosos--; }
                            if (clas == 4) { naturales--; }
                            if (clas == 5) { confiteria--; }
                            articulos[i].tipo = 0;
                            articulos[i].vencimiento = "";
                            articulos[i].proveedor = "";
                            articulos[i].posicion_estante = 0;
                            articulos[i].precio = 0;
                            articulos[i].reg = 0;
                            confirm = true;
                        }
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No se encontro ese articulo");
                    found = false;
                }
                Console.WriteLine("Desea eliminar otro articulo?" +
                    "1-Sí 2-No");
                preguntar = Convert.ToInt32(Console.ReadLine());
            }
            
            return confirm;
        }
        static bool ModifyItem()
        {
            bool found = false;
            bool confirm = false;
            int Codigo = 0;
            int preguntar = 0;
            while (preguntar != 2)
            {
                Console.Clear();
                Console.WriteLine("Modificacion de Articulos.           ");
                Console.WriteLine("Digite el Codigo del articulo a Modificar:");
                Codigo = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < articulos.Length; i++)
                {
                    if (Codigo == articulos[i].codigo)
                    {
                            
                            Console.WriteLine("Ingrese el nombre del producto: ");
                            articulos[i].nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese el tipo del producto: " +
                                    "\n1.frituras" +
                                    "\n2.reposteria" +
                                    "\n3.refrescos_gaseosos" +
                                    "\n4.refrescos_naturales" +
                                    "\n5.confiteria");
                            int clas = Convert.ToInt32(Console.ReadLine());
                            if (clas == 1) { frituras++; }
                            if (clas == 2) { reposteria++; }
                            if (clas == 3) { gaseosos++; }
                            if (clas == 4) { naturales++; }
                            if (clas == 5) { confiteria++; }
                            articulos[i].tipo = clas;
                            Console.WriteLine("Ingrese la fecha de vencimiento(dd/mm/aaaa): ");
                            Console.WriteLine("Dia:");
                            String dia = Console.ReadLine();
                            Console.WriteLine("Mes:");
                            String mes = Console.ReadLine();
                            Console.WriteLine("Año:");
                            String annio = Console.ReadLine();
                            articulos[i].vencimiento = dia + "/" + mes + "/" + annio;
                            Console.WriteLine("Ingrese el nombre del proveedor: ");
                            articulos[i].proveedor = Console.ReadLine();
                            Console.WriteLine("Ingrese la posicion en el estante del producto: " +
                                    "\n1.nivel 1" +
                                    "\n2.nivel 2" +
                                    "\n3.nivel 3" +
                                    "\n4.nivel 4" +
                                    "\n5.nivel 5");
                            articulos[i].posicion_estante = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese el precio del producto: ");
                            articulos[i].precio = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("No se encontro ese articulo");
                    found = false;
                }
                Console.WriteLine("Desea modificar otro articulo?" +
                      "1-Sí 2-No");
                preguntar = Convert.ToInt32(Console.ReadLine());
            }
            return confirm;
        }
        static void PrintData()     {
            Console.Clear();
            for (int i = 0; i < articulos.Length; i++) 
                if (articulos[i].codigo != 0) {
                    listado += "\n"+articulos[i].reg + "\t\t" + articulos[i].codigo + "\t\t" + articulos[i].nombre + "\t\t" +
                        articulos[i].tipo + "\t\t" + articulos[i].vencimiento + "\t\t" + articulos[i].proveedor + "\t\t" +
                        articulos[i].posicion_estante + "\t\t" + articulos[i].precio;
                }

            listado += "\n==========================================================================";
            listado += "\nFin de Listado";
        }
       
        static articulo[] articulos;
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la cantidad maxima de articulos para la maquina: ");
            articulos = new articulo[Convert.ToInt32(Console.ReadLine())];
            int opcion = 0;
            do {
                Console.WriteLine("*-*\t\tGlobal Machines\t\t*-*"+
                    "\n1.Ingreso de Productos" +
                    "\n2.Modificacion de Productos" +
                    "\n3.Eliminacion de Productos" +
                    "\n4.Busquedas de Productos" +
                    "\n5.Listado de Productos" +
                    "\n6.Venta de Productos" +
                    "\n7.Salir");
                opcion = (Convert.ToInt32(Console.ReadLine()) );
                switch (opcion) {
                    case 1:
                        AddItem();
                        
                        break;
                    case 2:
                        ModifyItem();
                        break;
                    case 3:
                        DeleteItem();
                        break;
                    case 4:
                        SeekItem();
                        break;
                    case 5:
                        PrintData();
                        Console.WriteLine(listado);

                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Por favor ingrese una opcion valida.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcion != 7);

        }
    }
}
