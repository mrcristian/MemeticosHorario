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
        public string NombreProfesor { get; set; }

        private static Random r;


        public Asignatura(string nombre, string codigo, int tipo,
            string nombreProfesor)
        {
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.TipoAula = (TipoAula)tipo;
            this.NombreProfesor = nombreProfesor;
        }
    }

    public static class AsignaturaHelper {
        private static Random r;
        public static List<Asignatura> Asignaturas { get; set; }

        public static void Inicializar(List<Asignatura> asignaturas)
        {
            r = new Random();
            Asignaturas = asignaturas;
        }

        public static Asignatura Aleatorea()
        {
            var n = r.Next(0, Asignaturas.Count);
            var asignatura = Asignaturas[n];
            return asignatura;
        }
    }
}
