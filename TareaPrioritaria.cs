using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1Progra3KendallFonseca
{
    public class TareaPrioritaria: Tarea
    {
        private Prioridad nivelPrioridad;

        public TareaPrioritaria(string descripcion, Prioridad prioridad) : base(descripcion)
        {
            this.nivelPrioridad = prioridad;
        }

        public override void MostrarTarea()
        {
            Console.WriteLine($"{Descripcion} - {(Completada ? "Completada" : "Pendiente")} - Prioridad: {nivelPrioridad}");
        }

        public Prioridad ObtenerPrioridad()
        {
            return nivelPrioridad;
        }
    }
}
