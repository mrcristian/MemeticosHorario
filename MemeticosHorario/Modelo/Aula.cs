using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public class Aula
    {
        public string Nombre { get; set; }
        public TipoAula Tipo { get; set; }
        public List<Horario> Horarios { get; set; }
        public bool Disponible(Horario h)
        {
            return Horarios.Contains(h);
        }

        public Aula(string nombre, int tipo)
        {
            this.Nombre = nombre;
            this.Tipo = (TipoAula)tipo;
            Horarios = new List<Horario>() {
                Horario.L_8_9,
                Horario.L_9_10,
                Horario.L_10_11,
                Horario.L_11_12,
                Horario.M_8_9,
                Horario.M_9_10,
                Horario.M_10_11,
                Horario.M_11_12,
                Horario.X_8_9,
                Horario.X_9_10,
                Horario.X_10_11,
                Horario.X_11_12,
                Horario.J_8_9,
                Horario.J_9_10,
                Horario.J_10_11,
                Horario.J_11_12,
                Horario.V_8_9,
                Horario.V_9_10,
                Horario.V_10_11,
                Horario.V_11_12
            };
        }
    }

    public static class AulaHelper
    {
        private static Random r;
        public static List<Aula> Aulas { get; set; }

        public static void Inicializar(List<Aula> aulas)
        {
            r = new Random();
            Aulas = aulas;
        }

        public static Aula Aleatorea(TipoAula tipo, Horario h)
        {
            bool ok = false;
            while (!ok)
            {
                var n = r.Next(0, Aulas.Count);
                var aula = Aulas[n];
                if (aula.Tipo == tipo &&
                    aula.Disponible(h))
                    return aula;
            }
            return null;
        }

    }
}
