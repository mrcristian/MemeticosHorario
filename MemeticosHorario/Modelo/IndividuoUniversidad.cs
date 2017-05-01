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
        public IndividuoUniversidad(IEnumerable<Gen> genes)
            :base(genes)
        {

        }
        public IndividuoUniversidad()
        {

        }
        public override void Evaluar()
        {
            return;
            int valor = 0;
            //se sumará el coste de los horarios asignados
            //valor += Genes
            //    .Select(gen => gen.Coste)
            //    .Sum();

            var genes = Genes.Select(gen => new
            {
                Profesor = gen.Asignatura.NombreProfesor,
                Horario = gen.Horario,
                Asignatura = gen.Asignatura.Nombre,
                Aula = gen.Aula.Nombre
            });
            //se calcula el número de apariciones del profesor
            //en el mismo horario

            valor += 5 * genes
                .GroupBy(gen => new
                {
                    CodigoProf = gen.Profesor,
                    Horario = gen.Horario
                })
                .Where(gen => gen.Count() > 1)
                .Count();

            //se calcula el número de apariciones del profesor
            //en el mismo horario

            valor += 5 * Genes
                .GroupBy(gen => new
                {
                    Horario = gen.Horario,
                    Aula = gen.Aula.Nombre
                })
                .Where(res => res.Count() > 1)
                .Count();
            this.Fitness = valor;
        }        

        public override List<Individual> getNeighbourhood()
        {
            var individuos = new List<Individual>();
            for (int i = 0; i < 10; i++)
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
            var ind=  new IndividuoUniversidad();
            ind.Genes = Genes;
            ind.Fitness = Fitness;
            return ind;
        }
        
        protected override Individuo getNuevoIndividuo(List<Gen> genes)
        {
            return new IndividuoUniversidad(genes);
        }

        public override string ToString()
        {
            return "";
        }
    }
}
