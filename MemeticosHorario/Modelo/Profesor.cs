using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Profesor
    {
        public Profesor(string nombre, string codigo)
        {
            this.nombre = nombre;
            this.codigo = codigo;
        }
        public Profesor(string nombre, string codigo,
            List<Asignatura> asignaturas)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.asignaturas = asignaturas;
        }
        string nombre { get; set; }
        string codigo { get; set; }
        public virtual List<Asignatura> asignaturas { get; set; }

        List<Costo_Hora_Prof> horariosPreferentes { get; set; }

       
    }
}
