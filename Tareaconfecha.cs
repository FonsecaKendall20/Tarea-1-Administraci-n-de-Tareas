using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1Progra3KendallFonseca
{
    public class Tareaconfecha: Tarea
    {
         DateTime FechaVencimiento;

        public Tareaconfecha(string descripcion, DateTime fechaVencimiento) : base(descripcion)
        {
            FechaVencimiento = fechaVencimiento;
            
        }

        public override void MostrarTarea()
        {

            Console.WriteLine($"{Descripcion} - {(Completada ? "Completada" : "Pendiente")} - Fecha de vencimiento: {FechaVencimiento.ToShortDateString()}");
        }
    }
}
