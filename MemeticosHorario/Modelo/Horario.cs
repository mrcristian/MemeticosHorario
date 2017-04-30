using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public enum Horario
    {
        L_8_9,
        L_9_10,
        L_10_11,
        L_11_12,
        M_8_9,
        M_9_10,
        M_10_11,
        M_11_12,
        X_8_9,
        X_9_10,
        X_10_11,
        X_11_12,
        J_8_9,
        J_9_10,
        J_10_11,
        J_11_12,
        V_8_9,
        V_9_10,
        V_10_11,
        V_11_12
    }

    public static class HorarioHelper
    {
        private static Random r = new Random(10);
        private static int numHorarios = Enum.GetNames(typeof(Horario)).Length;
        public static Horario HorarioAleatoreo()
        {
            return (Horario)r.Next(0, numHorarios);
        }

        public static int NumHorarios()
        {
            return numHorarios;
        }
    }
}
