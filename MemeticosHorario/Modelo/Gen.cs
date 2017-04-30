using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public class Gen
    {
        public Asignatura Asignatura { get; set; }
        public Aula Aula { get; set; }
        public int Coste { get; set; }
        public Horario Horario { get; set; }

        public static Gen Aleatoreo()
        {
            var asg = AsignaturaHelper.Aleatorea();
            var hor = HorarioHelper.HorarioAleatoreo();
            return new Gen()
            {
                Asignatura = asg,
                Aula = AulaHelper.Aleatorea(asg.TipoAula, hor),
                Horario = hor
            };
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var gen = (Gen)obj;
            return (gen.Asignatura.Nombre == Asignatura.Nombre &&
                gen.Aula.Nombre == Aula.Nombre && gen.Horario == Horario); 
        }
    }
}
