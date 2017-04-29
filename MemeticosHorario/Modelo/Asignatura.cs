using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Asignatura
    {
        public string nombre { get; set; }
        public string codigo { get; set; }
        public TipoAula tipoAula { get; set; }
        public int codigo_Profesor { get; set; }

        public Asignatura(string nombre, string codigo, int tipo)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.tipoAula = (TipoAula)tipo;
        }
    }
}
