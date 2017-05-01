using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public abstract class Individuo : Individual
    {
        public List<List<Gen>> CrucesProfesor
        {
            get
            {
                return Genes
                .GroupBy(gen => new
                {
                    CodigoProf = gen.Asignatura.NombreProfesor,
                    Horario = gen.Horario
                })
                .Where(gen => gen.Count() > 1)
                .Select(r => r.ToList())
                .ToList();
            }
        }
        public List<List<Gen>> CrucesMateria
        {
            get
            {
                return Genes
                .GroupBy(gen => new
                {
                    CodigoProf = gen.Asignatura.Nombre,
                    Horario = gen.Horario
                })
                .Where(gen => gen.Count() > 1)
                .Select(r => r.ToList())
                .ToList();
            }
        }
        public Individuo() { }
        public Individuo(IEnumerable<Gen> genes)
        {
            this.Genes = genes;
            Evaluar();
        }


        public IEnumerable<Gen> Genes { get; set; }

        public int Fitness { get; set; }

        public abstract void Evaluar();

        public abstract List<Individual> getNeighbourhood();

        public virtual Individuo Cruce(Individuo Padre)
        {
            var genesPadre = Padre.Genes;
            int n = Genes.Count();
            var genes = (n % 2 == 0) ?
                Genes.Take(n/2).Concat(genesPadre.Skip(n/2))
                : Genes.Take((n/2)+1).Concat(genesPadre.Skip(n/2));
            return getNuevoIndividuo(genes.ToList());
        }
        

        protected abstract Individuo getNuevoIndividuo(List<Gen> genes);

        public double getEvaluacion()
        {

            return this.Fitness;
        }

        public int getIndividualSize()
        {
            return Genes.Count();
        }

        public double getValue(int position)
        {
            return 0;
        }

        public abstract Individual clonar();

        public int CompareTo(object obj)
        {
            return this.Fitness - ((Individuo)obj).Fitness;
        }
        
    }
}
