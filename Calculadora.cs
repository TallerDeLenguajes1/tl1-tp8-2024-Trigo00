namespace misClases // Es un agrupador logico de clases
{
    public class Calculadora
    {
        private double dato;

        public Calculadora(double valorInicial)//Constructor
        {
            dato = valorInicial;
        }

        public void Sumar(double termino)
        {
            dato += termino;
        }

        public void Restar(double termino)
        {
            dato -= termino;
        }

        public void Multiplicar(double termino)
        {
            dato *= termino;
        }
        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                dato /= termino;
            }
            else
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
        }
        public void Limpiar()
        {
            dato = 0;
        }

        public double Resultado
        {
            get => dato;//Sirve para mostrar, pero no para escribir o modificar, para eso esta el set
            set => dato = value;
        }
    }

    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }

    public class Operacion
    {
        private double resultadoAnterior;
        private double nuevoValor;
        private TipoOperacion operacion;

        public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
        {
            this.resultadoAnterior = (double)resultadoAnterior;
            this.nuevoValor = (double)nuevoValor;
            this.operacion = operacion;
        }

        public double NuevoValor { get => nuevoValor; }
        public double ResultadoAnterior { get => resultadoAnterior; }

        public static void MostrarOperaciones(List<Operacion> lista)
        {
            int contador = 1;
            foreach (var operacion in lista)
            {
                Console.WriteLine("Operacion " + contador);
                Console.WriteLine("Operacion: " + operacion.operacion);
                Console.WriteLine("Resultado anterior: " + operacion.ResultadoAnterior);
                Console.WriteLine("Nuevo resultado: " + operacion.NuevoValor);
                switch (operacion.operacion)
                {
                    case TipoOperacion.Suma:
                        Console.WriteLine("Es decir, realizaste una " + operacion.operacion + ": " + operacion.ResultadoAnterior + " + " + (operacion.NuevoValor - operacion.ResultadoAnterior));
                        break;
                    case TipoOperacion.Resta:
                        Console.WriteLine("Es decir, realizaste una " + operacion.operacion + ": " + operacion.ResultadoAnterior + " - " + (operacion.ResultadoAnterior - operacion.NuevoValor));
                        break;
                    case TipoOperacion.Multiplicacion:
                        Console.WriteLine("Es decir, realizaste una " + operacion.operacion + ": " + operacion.ResultadoAnterior + " x " + (operacion.NuevoValor / operacion.ResultadoAnterior));
                        break;
                    case TipoOperacion.Division:
                        Console.WriteLine("Es decir, realizaste una " + operacion.operacion + ": " + operacion.ResultadoAnterior + " / " + (operacion.ResultadoAnterior / operacion.NuevoValor));
                        break;
                }
                Console.WriteLine();
                contador++;
            }
        }
    }
}


