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

        public Individuo(List<Gen> genes)
        {
            this.Genes = genes;
            Evaluar();

        }

        public List<Gen> Genes { get; set; }

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

        public virtual Individuo Cruce2(Individuo Padre)
        {
            var genesPadre = Padre.Genes;
            int n = Genes.Count();
            var genesComunes = Genes
                .Where(gen => genesPadre.Contains(gen)).ToList();

            var genes = genesComunes
                .Union(
                Enumerable.Range(0, n - genesComunes.Count())
                .Select( i =>
                {
                    return Gen.Aleatoreo();
                }));

            return getNuevoIndividuo(genes.ToList());
        }

        protected abstract Individuo getNuevoIndividuo(List<Gen> genes);

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

        public abstract Individual clonar();

        public int CompareTo(object obj)
        {
            return this.Fitness - ((Individuo)obj).Fitness;
        }

        public abstract string toString();
    }
}
