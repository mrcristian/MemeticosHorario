using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public enum Horario
    {
        L_7_9,
        L_9_11,
        L_11_1,
        L_2_4,
        L_4_6,
        L_6_8,
        M_7_9,
        M_9_11,
        M_11_1,
        M_2_4,
        M_4_6,
        M_6_8,
        X_7_9,
        X_9_11,
        X_11_1,
        X_2_4,
        X_6_8,
        J_7_9,
        J_9_11,
        J_11_1,
        J_2_4,
        J_4_6,
        J_6_8,
        V_7_9,
        V_9_11,
        V_11_1,
        V_2_4,
        V_4_6,
        V_6_8
    }

    public static class HorarioHelper
    {
        private static Random r = new Random(10);
        private static int numHorarios = Enum.GetNames(typeof(Horario)).Length;
        public static Horario HorarioAleatoreo()
        {
            return (Horario)r.Next(0, numHorarios);
        }
    }
}
