using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Individuo
    {
        public Individuo(List<Gen> genes)
        {
            this.Genes = genes;
            this.Fitness = 0;
        }
        public List<Gen> Genes { get; set; }
        //public double adaptacion { get; set; }
        public double Fitness { get; set; }


        public void Evaluar()
        {
            int valor = 0;
            //se sumará el coste de los horarios asignados
            valor += Genes
                .Select(gen => gen.Coste)
                .Sum();

            //se calcula el número de apariciones del profesor
            //en el mismo horario

            valor += 5* Genes
                .GroupBy(gen => new
                {
                    CodigoProf = gen.Asignatura.NombreProfesor,
                    Horario = gen.Horario
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(gen => gen.Count > 1)
                .Count();

            //se calcula el número de apariciones del profesor
            //en el mismo horario

            valor += 3* Genes
                .GroupBy(gen => new
                {
                    Horario = gen.Horario,
                    Aula = gen.Aula.Nombre
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(res => res.Count > 1)
                .Count();
            this.Fitness = valor;
        }

        public static Individuo Aleatoreo(List<Asignatura> asignaturas) {
            var genes = asignaturas
                .Select(asg => {
                    var horario = HorarioHelper.HorarioAleatoreo();
                    return new Gen()
                    {
                        Asignatura = asg,
                        Coste = 0,
                        Horario = horario,
                        Aula = AulaHelper.Aleatorea(asg.TipoAula, horario)
                    };
                }).ToList();
            return new Individuo(genes);

        }
    }

}
