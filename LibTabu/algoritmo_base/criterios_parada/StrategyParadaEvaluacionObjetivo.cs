using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.criterios_parada
{
    class StrategyParadaEvaluacionObjetivo : StrategyParada
    {

        /**
         * Representa el valor de evaluación objetivo
         */
        private readonly double objetivo;
        /**
         * Indica si el problema es de maximización. Si el valor es false significa
         * que el problema es de minimización
         */
        private readonly bool maximizacion;
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
         * Representa la mejorEvaluacion encontrada hasta el momento
         */
        private double mejorEvaluacion;

        /**
         * Crea un StrategyParadaEvaluacionObjetivo
         * @param objetivo es el valor objetivo para el criterio de parada
         * @param maximizacion indica si el problema es de maximización (true), o
         * de minimizacion (false)
         * @param maxIteraciones es el número máximo de iteraciones que se va a fijar
         */
        public StrategyParadaEvaluacionObjetivo(double objetivo, bool maximizacion, int maxIteraciones)
        {
            this.objetivo = objetivo;
            this.maximizacion = maximizacion;
            this.maxIteraciones = maxIteraciones;
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
            if (maximizacion)
            {
                return (bestSolution.getEvaluacion() > objetivo || numIteraciones > maxIteraciones);
            }
            else
            {
                return (bestSolution.getEvaluacion() < objetivo || numIteraciones > maxIteraciones);
            }
        }
    }
}
