// See https://aka.ms/new-console-template for more information


using Tarea1Progra3KendallFonseca;
using static Tarea1Progra3KendallFonseca.Tarea;

List<Tarea> listaTareas = new List<Tarea>();
GestionTareas gestionTareas = new GestionTareas();
bool salir = false;

while (!salir)
{
    try
    {
        Console.WriteLine("\n--- Menú Principal ---");
        Console.WriteLine("1. Agregar tarea");
        Console.WriteLine("2. Mostrar tareas");
        Console.WriteLine("3. Marcar tarea como realizada");
        Console.WriteLine("4. Eliminar tarea");
        Console.WriteLine("5. Mostrar tareas por prioridad");
        Console.WriteLine("6. Salir");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {


            case 1:
                Console.WriteLine("Ingrese la descripción de la tarea:");
                string descripcion = Console.ReadLine();

                Console.WriteLine("¿La tarea tiene fecha de vencimiento? (si/no)");
                string tieneFecha = Console.ReadLine().Trim().ToLower();

                DateTime fechaVencimiento = DateTime.MinValue; 
                bool esConFecha = false;

                if (tieneFecha == "si")
                {
                    Console.WriteLine("Ingrese la fecha de vencimiento (formato: YYYY-MM-DD):");
                    while (!DateTime.TryParse(Console.ReadLine(), out fechaVencimiento))
                    {
                        Console.WriteLine("Fecha inválida. Intente nuevamente (formato: YYYY-MM-DD):");
                    }
                    esConFecha = true;
                }

                Console.WriteLine("¿La tarea tiene prioridad? (si/no)");
                string tienePrioridad = Console.ReadLine().Trim().ToLower();

                Prioridad prioridad = Prioridad.BAJA; //Este valor es por si no se dijita ninguna prioridad se sabe que es baja o sin prioridad

                if (tienePrioridad == "si")
                {
                    Console.WriteLine("Ingrese la prioridad (ALTA, MEDIA, BAJA):");
                    while (!Enum.TryParse(Console.ReadLine().ToUpper(), out prioridad))
                    {
                        Console.WriteLine("Prioridad inválida. Intente nuevamente (ALTA, MEDIA, BAJA):");
                    }
                }

              
                if (esConFecha && tienePrioridad == "si")
                {
                    
                    gestionTareas.AgregarTarea(new TareaPrioritaria(descripcion, prioridad));
                }
                else if (esConFecha)
                {
                    
                    gestionTareas.AgregarTarea(new Tareaconfecha(descripcion, fechaVencimiento));
                }
                else if (tienePrioridad == "si")
                {
                  
                    gestionTareas.AgregarTarea(new TareaPrioritaria(descripcion, prioridad));
                }
                else
                {
                   
                    gestionTareas.AgregarTarea(new Tarea(descripcion));
                }

                Console.WriteLine("Tarea agregada.");
                break;

            case 2:
                gestionTareas.MostrarTareas();
                break;

            case 3:

                if (gestionTareas.ObtenerTareas().Count == 0)  //Vemos si las tareas estan vacias
                {
                    Console.WriteLine("No hay tareas para completar.");
                    break;
                }

                Console.WriteLine("Lista de tareas pendientes:\n"); //Recorremos la lista y mostramos las tareas
                foreach (var tarea in gestionTareas.ObtenerTareas())
                {
                    tarea.MostrarTarea();
                }

                Console.WriteLine("Ingrese el nombre de la tarea que desea marcar como completada:"); // Ingresamos el nombre de la tarea a completar
                string nombreTarea = Console.ReadLine();

                gestionTareas.MarcarTareaComoRealizada(nombreTarea);

                Console.Write("Tarea Completada");
                break;

            case 4:

                if (gestionTareas.ObtenerTareas().Count == 0)  //Vemos si las tareas estan vacias
                {
                    Console.WriteLine("No hay tareas para eliminar.");
                    break;
                }

                Console.WriteLine("Lista de tareas pendientes:\n"); //Recorremos la lista y mostramos las tareas
                foreach (var tarea in gestionTareas.ObtenerTareas())
                {
                    tarea.MostrarTarea();
                }

                Console.WriteLine("Ingrese el nombre de la tarea que desea eliminar:"); //Ponemos el nombre de la tarea que deseamos eliminar
                string nombreEliminar = Console.ReadLine();

                gestionTareas.EliminarTarea(nombreEliminar);

                Console.WriteLine("Tarea Eliminada");

                break;

            case 5:
                if (gestionTareas.ObtenerTareas().Count == 0)  
                {
                    Console.WriteLine("No hay tareas ");

                }
                gestionTareas.MostrarTareasPorPrioridad();

                break;

            case 6:

                Console.WriteLine("Saliendo del gestionador de Tarea");
                salir = true;

                break;


        }
    }
    catch (Exception ex)
    {

        Console.WriteLine($"Error: {ex.Message}");
    }
}
    









