using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Individuo : Individual
    {
        public Individuo(List<Gen> genes)
        {
            this.Genes = genes;
            Evaluar();

        }
        public List<Gen> Genes { get; set; }
        //public double adaptacion { get; set; }
        public int Fitness { get; set; }


        public void Evaluar()
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

            valor += 50 * Genes
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

            valor += 50 * Genes
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

            valor += 50 * Genes
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

            valor += 50 * Genes
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

            valor += 50 * Genes
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

        public static Individuo Aleatoreo(List<Asignatura> asignaturas,
            List<Aula> aulas)
        {
            Random r = new Random();
            var genes = new List<Gen>();
            int horarios = HorarioHelper.NumHorarios();
            foreach (var item in aulas)
            {
                for (int i = 0; i < horarios; i++)
                {
                    genes.Add(new Gen()
                    {
                        Aula = item,
                        Horario = (Horario)i,
                        Asignatura = asignaturas[r.Next(asignaturas.Count)],
                        Coste = 0
                    });
                }
            }
            return new Individuo(genes);

        }

        public List<Individual> getNeighbourhood()
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
                individuos.Add(new Individuo(genes));
            }
            return individuos;
        }

        public double getEvaluacion()
        {

            return this.Fitness;
        }

        public int getIndividualSize()
        {
            return Genes.Count;
        }

        public double getValue(int position)
        {
            return 0;
        }

        public Individual clonar()
        {
            return new Individuo(this.Genes);
        }

        public int CompareTo(object obj)
        {
            return this.Fitness - ((Individuo)obj).Fitness;
        }
        public string toString()
        {

            var query = this.Genes
                .GroupBy(gen => gen.Aula.Nombre)
                .ToList();
            foreach (var item in query)
            {
                Console.WriteLine($"Aula: {item.Key}");
                foreach (var subItem in item
                    .OrderBy(i => i.Horario)
                    .ToList())
                {
                    Console.WriteLine($"Asignatura {subItem.Asignatura.Nombre}: Horario: {subItem.Horario}");
                }

            }
            string res = "";
            //foreach (var item in this.Genes) {
            //    res = res + "Asignatura: " + item.Asignatura.Nombre + ",Aula :" + item.Aula.Nombre + ",Horario:" + item.Horario +"\n";
            //}
            return res;
        }
    }

}
