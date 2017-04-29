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
                Horario.L_7_9,
                Horario.L_9_11,
                Horario.L_11_1,
                Horario.L_2_4,
                Horario.L_4_6,
                Horario.L_6_8,
                Horario.M_7_9,
                Horario.M_9_11,
                Horario.M_11_1,
                Horario.M_2_4,
                Horario.M_4_6,
                Horario.M_6_8,
                Horario.X_7_9,
                Horario.X_9_11,
                Horario.X_11_1,
                Horario.X_2_4,
                Horario.X_6_8,
                Horario.J_7_9,
                Horario.J_9_11,
                Horario.J_11_1,
                Horario.J_2_4,
                Horario.J_4_6,
                Horario.J_6_8,
                Horario.V_7_9,
                Horario.V_9_11,
                Horario.V_11_1,
                Horario.V_2_4,
                Horario.V_4_6,
                Horario.V_6_8

            };
        }
    }

    public static class AulaHelper
    {
        private static Random r;
        public static List<Aula> Aulas { get; set; }

        public static void Inicializar(List<Aula> aulas)
        {
            r = new Random(10);
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
