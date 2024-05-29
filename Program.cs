// See https://aka.ms/new-console-template for more information
using Datos;
using misClases;
/*
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

*/

//////Punto 2////////

var ListaResultados = new List<Operacion>();
int comienzo = 0;
int repetir = 1;

double valorDouble;
Console.Write("Ingrese un numero: ");
string valor = Console.ReadLine();
double.TryParse(valor, out valorDouble);
Calculadora miCalculadora = new Calculadora(valorDouble);

string opcion, num1;
int opcionConvert;
double num1Convert, resultado;
while (repetir == 1)
{
    do
    {
        Console.WriteLine("\n");
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("1) Sumar");
        Console.WriteLine("2) Restar");
        Console.WriteLine("3) Multiplicar");
        Console.WriteLine("4) Dividir");
        Console.WriteLine("5) Limpiar");
        Console.WriteLine("6) Salir");
        Console.Write("Ingrese la opcion deseada:");
        opcion = Console.ReadLine();
        int.TryParse(opcion, out opcionConvert);

        switch (opcionConvert)
        {
            case 1:
                string opcion1;

                Console.Write("Ingrese un numero: ");
                num1 = Console.ReadLine();
                double.TryParse(num1, out num1Convert);
                miCalculadora.Sumar(num1Convert);
                resultado = miCalculadora.Resultado;
                Console.WriteLine("El resultado obtenido es: " + resultado);

                if (comienzo == 0)
                {
                    Operacion misOperaciones = new Operacion(valorDouble, resultado, TipoOperacion.Suma);
                    ListaResultados.Add(misOperaciones);
                }
                else
                {
                    Operacion misOperaciones = new Operacion(ListaResultados.Last().NuevoValor, resultado, TipoOperacion.Suma);
                    ListaResultados.Add(misOperaciones);
                }
                miCalculadora.Resultado = resultado;
                comienzo++;

                do
                {
                    Console.WriteLine("Desea continuar calculando:");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    opcion1 = Console.ReadLine();
                    if (opcion1 == "2")
                    {
                        repetir = 0;
                    }

                } while (opcion1 != "1" && opcion1 != "2");

                break;
            case 2:
                string opcion2;

                Console.Write("Ingrese un numero: ");
                num1 = Console.ReadLine();
                double.TryParse(num1, out num1Convert);
                miCalculadora.Restar(num1Convert);
                resultado = miCalculadora.Resultado;
                Console.WriteLine("El resultado obtenido es: " + resultado);

                if (comienzo == 0)
                {
                    Operacion misOperaciones = new Operacion(valorDouble, resultado, TipoOperacion.Resta);
                    ListaResultados.Add(misOperaciones);
                }
                else
                {
                    Operacion misOperaciones = new Operacion(ListaResultados.Last().NuevoValor, resultado, TipoOperacion.Resta);
                    ListaResultados.Add(misOperaciones);
                }
                miCalculadora.Resultado = resultado;
                comienzo++;

                do
                {
                    Console.WriteLine("Desea continuar calculando:");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    opcion2 = Console.ReadLine();
                    if (opcion2 == "2")
                    {
                        repetir = 0;
                    }

                } while (opcion2 != "1" && opcion2 != "2");

                break;
            case 3:
                string opcion3;

                Console.Write("Ingrese un numero: ");
                num1 = Console.ReadLine();
                double.TryParse(num1, out num1Convert);
                miCalculadora.Multiplicar(num1Convert);
                resultado = miCalculadora.Resultado;
                Console.WriteLine("El resultado obtenido es: " + resultado);

                if (comienzo == 0)
                {
                    Operacion misOperaciones = new Operacion(valorDouble, resultado, TipoOperacion.Multiplicacion);
                    ListaResultados.Add(misOperaciones);
                }
                else
                {
                    Operacion misOperaciones = new Operacion(ListaResultados.Last().NuevoValor, resultado, TipoOperacion.Multiplicacion);
                    ListaResultados.Add(misOperaciones);
                }
                miCalculadora.Resultado = resultado;
                comienzo++;

                do
                {
                    Console.WriteLine("Desea continuar calculando:");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    opcion3 = Console.ReadLine();
                    if (opcion3 == "2")
                    {
                        repetir = 0;
                    }

                } while (opcion3 != "1" && opcion3 != "2");
                break;
            case 4:
                string opcion4;

                Console.Write("Ingrese un numero: ");
                num1 = Console.ReadLine();
                double.TryParse(num1, out num1Convert);
                miCalculadora.Dividir(num1Convert);
                resultado = miCalculadora.Resultado;
                Console.WriteLine("El resultado obtenido es: " + resultado);

                if (comienzo == 0)
                {
                    Operacion misOperaciones = new Operacion(valorDouble, resultado, TipoOperacion.Division);
                    ListaResultados.Add(misOperaciones);
                }
                else
                {
                    Operacion misOperaciones = new Operacion(ListaResultados.Last().NuevoValor, resultado, TipoOperacion.Division);
                    ListaResultados.Add(misOperaciones);
                }
                miCalculadora.Resultado = resultado;
                comienzo++;

                do
                {
                    Console.WriteLine("Desea continuar calculando:");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    opcion4 = Console.ReadLine();
                    if (opcion4 == "2")
                    {
                        repetir = 0;
                    }

                } while (opcion4 != "1" && opcion4 != "2");

                break;
            case 5:
                miCalculadora.Limpiar();
                Console.WriteLine("El valor fue limpiado correctamente");
                resultado = miCalculadora.Resultado;
                Console.WriteLine("El resultado obtenido es: " + resultado);
                ListaResultados.Clear();
                if (ListaResultados.Count() == 0)
                    Console.WriteLine("El historial quedo vacio");
                comienzo = 0;
                break;
            case 6:
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, ingrese una opción válida.");
                break;
        }

    } while (opcionConvert != 1 && opcionConvert != 2 && opcionConvert != 3 && opcionConvert != 4 && opcionConvert != 5 && opcionConvert != 6);

    if (ListaResultados.Count > 0)
        Operacion.MostrarOperaciones(ListaResultados);
}