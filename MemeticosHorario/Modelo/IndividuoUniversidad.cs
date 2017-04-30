using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class IndividuoUniversidad : Individuo
    {
        public IndividuoUniversidad(List<Gen> genes)
            :base(genes)
        {

        }

        public override void Evaluar()
        {
            int valor = 0;
            //se sumará el coste de los horarios asignados
            valor += Genes
                .Select(gen => gen.Coste)
                .Sum();

            //se calcula el número de apariciones del profesor
            //en el mismo horario

            valor += 5 * Genes
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

            valor += 3 * Genes
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

        public override List<Individual> getNeighbourhood()
        {
            var individuos = new List<Individual>();
            for (int i = 0; i < 20; i++)
            {
                var genes = Genes
                .Select(gen => {
                    return new Gen()
                    {
                        Asignatura = gen.Asignatura,
                        Coste = 0,
                        Horario = gen.Horario,
                        Aula = AulaHelper.Aleatorea(gen.Asignatura.TipoAula,
                        gen.Horario)
                    };
                }).ToList();
                individuos.Add(new IndividuoUniversidad(genes));
            }
            return individuos;
        }

        public override Individual clonar()
        {
            return new IndividuoUniversidad(this.Genes);
        }
        
        protected override Individuo getNuevoIndividuo(List<Gen> genes)
        {
            return new IndividuoUniversidad(genes);
        }

        public override string toString()
        {
            return "";
        }
    }
}
