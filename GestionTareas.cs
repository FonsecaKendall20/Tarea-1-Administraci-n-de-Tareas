using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tarea1Progra3KendallFonseca.Tarea;

namespace Tarea1Progra3KendallFonseca
{
    public class GestionTareas
    {
        public List<Tarea> listaTareas = new List<Tarea>();
       
        public List<Tarea> Tareas = new List<Tarea>();

        public void AgregarTarea(Tarea tarea)
        {
            listaTareas.Add(tarea);
        }

        public void EliminarTarea(string descripcion)
        {
            var tarea = listaTareas.FirstOrDefault(t => t.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));

            if (tarea != null)
            {
                listaTareas.Remove(tarea);
                Console.WriteLine($"La tarea \"{descripcion}\" ha sido eliminada.");
            }
            else
            {
                Console.WriteLine($"No se encontró una tarea con la descripción: {descripcion}");
            }
        }

        public void MostrarTareas()
        {
            foreach (var tarea in listaTareas)
            {
                tarea.MostrarTarea();
            }
        }

        public void MostrarTareasPorPrioridad()
        {
            var tareasOrdenadas = listaTareas.OrderBy(t =>   //El OrderBy nos permite ver las tareas tirando primero las de Prioridad Alta, Media, Baja y sin prioridad
        t is TareaPrioritaria tareaPrioritaria ? (int)tareaPrioritaria.ObtenerPrioridad() : 4).ToList();  //

            Console.WriteLine("\n--- Tareas Ordenadas por Prioridad ---");

            foreach (var tarea in tareasOrdenadas)
            {
                tarea.MostrarTarea();
            }
        }
        public List<Tarea> ObtenerTareas()
        {
            return listaTareas;
        }
        public void MarcarTareaComoRealizada(string descripcion)
        {
            var tarea = listaTareas.FirstOrDefault(t => t.Descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase));

            if (tarea != null)
            {
                tarea.CompletarTarea();
                Console.WriteLine($"La tarea \"{descripcion}\" ha sido marcada como completada."); 
            }
            else
            {
                Console.WriteLine($"No se encontró una tarea con la descripción: {descripcion}");
            }
        }

    }
}
