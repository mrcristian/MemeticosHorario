using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.criterios_parada
{
    class StrategyParadaNumIteracionesSinMejora : StrategyParada
    {
        /**
          * Representa el número de iteraciones transcurridas sin que haya mejora
          */
        private int numIteraciones;
        /**
         * Representa el número máximo de iteraciones que se pueden dar sin que haya
         * una mejora
         */
        private readonly int maxIteraciones;
        /**
         * Indica si el problema es de maximización. Si el valor es false significa
         * que el problema es de minimización
         */
        private bool maximizacion;
        /**
         * Representa la mejorEvaluacion encontrada hasta el momento
         */
        private double mejorEvaluacion;

        /**
         * Crea una StrategyParadaNumIteracionesSinMejora con un número máximo de 
         * iteraciones
         * @param maxIteraciones es el número máximo de iteraciones que se va a fijar
         * @param maximizacion indica si el problema es de maximización (true), o
         * de minimizacion (false)
         */
        public StrategyParadaNumIteracionesSinMejora(int maxIteraciones, bool maximizacion)
        {
            numIteraciones = 0;
            this.maxIteraciones = maxIteraciones;
            this.maximizacion = maximizacion;
        }
        public bool debeParar(Individual bestSolution)
        {
            if (numIteraciones == 0)
                this.mejorEvaluacion = bestSolution.getEvaluacion();
            else
            {
                if ((maximizacion && bestSolution.getEvaluacion() > this.mejorEvaluacion)
                        || (!maximizacion && bestSolution.getEvaluacion() < this.mejorEvaluacion))
                {
                    this.mejorEvaluacion = bestSolution.getEvaluacion();
                    numIteraciones = 0;
                }
            }
            numIteraciones++;
            return (numIteraciones > maxIteraciones);
        }
    }
}
