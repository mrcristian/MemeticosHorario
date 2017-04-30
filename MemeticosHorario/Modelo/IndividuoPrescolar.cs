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
        public IndividuoPrescolar(List<Gen> genes)
            : base(genes)
        {

        }

        public override void Evaluar()
        {
            int valor = 0;
            //se sumará el coste de los horarios asignados
            //valor += Genes
            //    .Select(gen => gen.Coste)
            //    .Sum();

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

            //Calcular restriccion de carga académiva
            // 4 veces por semana

            valor += 10 * Genes.
                GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count(),
                    P = Math.Abs(gen.Count() - 4)
                })
                .Where(res => res.Count != 4)
                .Sum(e => e.P);

            //Cada asignatura se debe ver solo 1 vez al dia

            var lunes = new List<int>() { 0, 1, 2, 3 };
            var martes = new List<int>() { 4, 5, 6, 7 };
            var miercoles = new List<int>() { 8, 9, 10, 11 };
            var jueves = new List<int>() { 12, 13, 14, 15 };
            var viernes = new List<int>() { 16, 17, 18, 19 };

            valor += 15 * Genes
                .Where(res => lunes.Contains((int)res.Horario))
                .GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(res => res.Count > 1)
                .Sum(res => res.Count);

            valor += 15 * Genes
            .Where(res => martes.Contains((int)res.Horario))
            .GroupBy(gen => new
            {
                Asignatura = gen.Asignatura,
                Aula = gen.Aula
            })
            .Select(gen => new
            {
                Key = gen.Key,
                Count = gen.Count()
            })
            .Where(res => res.Count > 1)
            .Sum(res => res.Count);

            valor += 15 * Genes
                .Where(res => miercoles.Contains((int)res.Horario))
                .GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(res => res.Count > 1)
                .Sum(res => res.Count);

            valor += 15 * Genes
                .Where(res => jueves.Contains((int)res.Horario))
                .GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(res => res.Count > 1)
                .Sum(res => res.Count);

            valor += 15 * Genes
                .Where(res => viernes.Contains((int)res.Horario))
                .GroupBy(gen => new
                {
                    Asignatura = gen.Asignatura,
                    Aula = gen.Aula
                })
                .Select(gen => new
                {
                    Key = gen.Key,
                    Count = gen.Count()
                })
                .Where(res => res.Count > 1)
                .Sum(res => res.Count);

            this.Fitness = valor;
        }

        public override List<Individual> getNeighbourhood()
        {
            var individuos = new List<Individual>();
            int horarios = HorarioHelper.NumHorarios();
            for (int i = 0; i < horarios; i++)
            {
                var genes = Genes
                .Select(gen =>
                {
                    return new Gen()
                    {
                        //Asignatura = gen.Asignatura,
                        //Coste = 0,
                        //Horario = gen.Horario,
                        //Aula = AulaHelper.Aleatorea(gen.Asignatura.TipoAula,
                        //gen.Horario)
                        Asignatura = AsignaturaHelper.Aleatorea(),
                        Coste = 0,
                        Horario = gen.Horario,
                        Aula = gen.Aula
                    };
                }).ToList();
                individuos.Add(new IndividuoPrescolar(genes));
            }
            return individuos;
        }

        public override Individual clonar()
        {
            return new IndividuoPrescolar(this.Genes);
        }

        public override string toString()
        {
            var res = "";
            var query = this.Genes
                .GroupBy(gen => gen.Aula.Nombre)
                .ToList();
            foreach (var item in query)
            {
                res = $"Aula: {item.Key}\n";
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
