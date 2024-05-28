// See https://aka.ms/new-console-template for more information
using Datos;

var ListaPendientes = new List<Tareas>();
var ListaRealizados = new List<Tareas>();
Tareas tareaAux = null;

Tareas miTarea = new Tareas();
int opcion;
do
{
    Console.WriteLine("\n MENU INTERACTIVO\n");
    Console.WriteLine("1) Agregar Tareas Pendientes");
    Console.WriteLine("2) Cambiar Tarea Pendiente a Tarea Realizada");
    Console.WriteLine("3) Mostrar Lista Pendiente");
    Console.WriteLine("4) Mostrar Lista Realizada");
    Console.WriteLine("5) Buscar Tarea por ID");
    Console.WriteLine("6) Buscar Tarea por Palabra Clave");
    Console.WriteLine("7) Salir");
    Console.Write("\nIngrese la opcion deseada: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            int condicion;
            do
            {
                Console.Write("Ingrese la descripcion: ");
                string desc = Console.ReadLine();
                miTarea.insertarTareaPendiente(ListaPendientes, desc);
                Console.WriteLine("\nTarea agregada correctamente");
                Console.WriteLine("\nDeseas agregar otra Tarea Pendiente:");
                Console.WriteLine("1) Si");
                Console.WriteLine("2) No");

                condicion = int.Parse(Console.ReadLine());
            } while (condicion == 1);
            break;
        case 2:
            Console.WriteLine("\nElija la tarea de la Lista de Pendientes que desea pasar a la Lista de Realizadas(Ingrese ID): ");
            string cambiarTarea = Console.ReadLine();
            int.TryParse(cambiarTarea, out int opcionElegida);

            foreach (var tarea in ListaPendientes)
            {
                if(tarea.Id == opcionElegida)
                {
                    tareaAux = tarea;
                    break;
                }
            }
            ListaRealizados.Add(tareaAux);
            ListaPendientes.Remove(tareaAux);
            Console.WriteLine("\nLa tarea fue pasada correctamente");
            break;
        case 3:
            int cantidad = ListaPendientes.Count();
            if (cantidad == 0)
            {
                Console.WriteLine("\nLa lista esta vacia");
            }
            else
            {
                foreach (var tarea in ListaPendientes)
                {
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }
            }
            break;
        case 4:
            int cantidad2 = ListaRealizados.Count();
            if (cantidad2 == 0)
            {
                Console.WriteLine("\nLa lista esta vacia");
            }
            else
            {
                foreach (var tarea in ListaRealizados)
                {
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }
            }
            break;
        case 5:
            Console.WriteLine("\n\nIngrese el ID de la tarea buscada: ");
            string idBuscado = Console.ReadLine();
            int.TryParse(idBuscado, out int idConvertido);
            miTarea.buscarTareaPorId(ListaPendientes, ListaRealizados, idConvertido);
            break;
        case 6:
            Console.WriteLine("\n\nIngrese una palabra clave por la cual quiere buscar una tarea: ");
            string palabra = Console.ReadLine();
            miTarea.buscarPorPalabra(ListaPendientes, ListaRealizados, palabra);
            break;
        case 7:
            break;
        default:
            Console.WriteLine("\nOpcion no valida. Por favor, ingrese una opcion valida.\n");
            break;
    }

} while (opcion != 7);

/*var tarea1 = new Tareas(1,"Ir a Simoca",20);
var tarea2 = new Tareas(1,"Ir a Tafi del Valle",20);
var tarea3 = new Tareas(1,"Ir a San Pedro",20);
var tarea4 = new Tareas(1,"Ir a simoca",20);

ListaPendiente.Add(tarea1);
ListaPendiente.Add(tarea2);
ListaPendiente.Add(tarea3);
ListaPendiente.Add(tarea4);*/

