using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1Progra3KendallFonseca
{
    public class Tarea
    {
        public string Descripcion { get; set; } 
        public bool Completada { get; set; }

        public enum Prioridad
        {
            ALTA, MEDIA, BAJA
        }

       

        public Tarea(string descripcion)
        {
            Descripcion = descripcion;
            Completada = false;
        }

        public void CompletarTarea()
        {
            Completada = true;
        }

        public virtual void MostrarTarea()
        {
            Console.WriteLine($"{Descripcion} - {(Completada ? "Completada" : "Pendiente")}");
        }

    }
}
