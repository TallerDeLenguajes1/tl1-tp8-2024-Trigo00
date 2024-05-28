using System;
using System.Collections.Generic;

namespace Datos
{
    public class Tareas
    {
        private static Random random = new Random(); // Añadir Random como estático para compartirlo entre todas las instancias
        private int id;
        private string descripcion;
        private int duracion;

        public Tareas()
        {
            id = 0;
            descripcion = "";
            duracion = 0;
        }

        public Tareas(int id, string descripcion, int duracion)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public void insertarTareaPendiente(List<Tareas> miLista, string descripcion)
        {
            int id = random.Next(1, 10000); // Generar un id aleatorio entre 1 y 9999
            int duracion = random.Next(1, 21);
            miLista.Add(new Tareas(id, descripcion, duracion));
        }

        public void buscarTareaPorId(List<Tareas> miLista, List<Tareas> miLista2, int id2)
        {
            foreach (var tarea in miLista)
            {
                if(tarea.Id == id2){
                    Console.WriteLine("La tarea fue encontrada en la LISTA DE PENDIENTES\n");
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }
            }

            foreach (var tarea in miLista2)
            {
                  if(tarea.Id == id2){
                    Console.WriteLine("La tarea fue encontrada en la LISTA DE REALIZADAS\n");
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }              
            }
        }

        public void buscarPorPalabra(List<Tareas> miLista, List<Tareas> miLista2, string palabra)
        {
            foreach (var tarea in miLista)
            {
                if(tarea.Descripcion.Contains(palabra)){
                    Console.WriteLine("La tarea fue encontrada en la LISTA DE PENDIENTES\n");
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }
            }

            foreach (var tarea in miLista2)
            {
                  if(tarea.Descripcion.Contains(palabra)){
                    Console.WriteLine("La tarea fue encontrada en la LISTA DE REALIZADAS\n");
                    Console.WriteLine("Id: " + tarea.Id);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion);
                }              
            }
        }
    }
}
