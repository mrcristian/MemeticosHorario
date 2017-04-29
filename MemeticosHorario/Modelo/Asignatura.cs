using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public class Asignatura
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public TipoAula TipoAula { get; set; }
        public int Codigo_Profesor { get; set; }

        public Asignatura(string nombre, string codigo, int tipo)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.TipoAula = (TipoAula)tipo;
        }
    }
}
