using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.criterios_parada
{
    class StrategyParadaNumIteraciones : StrategyParada
    {

        /**
         * Representa el número de iteraciones transcurridas
         */
        private int numIteraciones;
        /**
         * Representa el número máximo de iteraciones que se pueden dar
         */
        private readonly int maxIteraciones;

        /**
         * Crea una StrategyParadaNumIteraciones con un número máximo de iteraciones
         * @param maxIteraciones es el número máximo de iteraciones que se va a fijar
         */
        public StrategyParadaNumIteraciones(int maxIteraciones)
        {
            numIteraciones = 0;
            this.maxIteraciones = maxIteraciones;
        }

        public bool debeParar(Individual bestSolution)
        {
        numIteraciones++;
        return (numIteraciones > maxIteraciones);
        }
    }
}
