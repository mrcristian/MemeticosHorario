using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public class Profesor
    {
        string Nombre { get; set; }
        string Codigo { get; set; }
        public virtual List<Asignatura> Asignaturas { get; set; }
        List<Costo_Hora_Prof> HorariosPreferentes { get; set; }

        public Profesor(string nombre, string codigo)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
        }
        public Profesor(string nombre, string codigo,
            List<Asignatura> asignaturas)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Asignaturas = asignaturas;
        }
        

       
    }
}
