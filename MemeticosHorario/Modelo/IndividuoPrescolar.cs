using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class IndividuoPrescolar : Individuo
    {
        public IndividuoPrescolar(IEnumerable<Gen> genes)
            : base(genes)
        {

        }
        public IndividuoPrescolar()
        {

        }

        public override void Evaluar()
        {
            
            int valor = 0;
            var genes = Genes.Select(gen => new
            {
                Horario = gen.Horario,
                Asignatura = gen.Asignatura.Nombre,
                Aula = gen.Aula.Nombre,
                Profesor = gen.Asignatura.NombreProfesor
            });

            valor += 10 * genes
                .GroupBy(gen => new
                {
                    CodigoProf = gen.Profesor,
                    Horario = gen.Horario
                })
                .Where(gen => gen.Count() > 1)
                .Count();


            valor += 10 * genes
                .GroupBy(gen => new
                {
                    Horario = gen.Horario,
                    Aula = gen.Aula
                })
                .Where(res => res.Count() > 1)
                .Count();

            valor += 5 * genes.
                GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Where(res => res.Count() != 4)
                .Count();

            valor += 3 * genes
                .GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula,
                    Dia = HorarioHelper.Dia(gen.Horario)
                })
                .Where(res => res.Count() > 1)
                .Count();



            this.Fitness = valor;
        }
        private List<Individual> individuos = new List<Individual>();
        public override List<Individual> getNeighbourhood()
        {
            individuos.Clear();
            int horarios = HorarioHelper.NumHorarios();
            for (int i = 0; i < 5; i++)
            {
                var genes = Genes
                .Select(gen =>
                {
                    return new Gen()
                    {
                        Asignatura = AsignaturaHelper.Aleatorea(),
                        Coste = 0,
                        Horario = gen.Horario,
                        Aula = gen.Aula
                    };
                });
                individuos.Add(new IndividuoPrescolar(genes));
            }
            return individuos;
        }

        public override Individual clonar()
        {
            var ind = new IndividuoPrescolar();
            ind.Genes = Genes;
            ind.Fitness = Fitness;
            return ind;
        }


        public override string ToString()
        {
            var res = "";
            var query = this.Genes
                .GroupBy(gen => gen.Aula.Nombre)
                .ToList();
            foreach (var item in query)
            {
                res += $"Aula: {item.Key}\n";
                foreach (var subItem in item
                    .OrderBy(i => i.Horario)
                    .ToList())
                {
                    res += $"{subItem.Horario} - " +
                    $"{subItem.Asignatura.Nombre} \n";
                }

            }
            return res;
        }

        protected override Individuo getNuevoIndividuo(List<Gen> genes)
        {
            return new IndividuoPrescolar(genes);
        }
    }

}
