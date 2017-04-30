using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    public abstract class Individuo: Individual
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
    }
}
