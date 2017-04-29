using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.criterios_aspiracion
{
    class StrategyAspiracionPorObjetivo : StrategyAspiracion
    {
    private readonly bool maximizacion;
    
    /**
     * Crea un StrategyAspiracionPorObjetivo
     * @param maximizacion indica si el problema es de maximización (true), o
     * de minimizacion (false)
     */
    public StrategyAspiracionPorObjetivo(bool maximizacion)
        {
            this.maximizacion = maximizacion;
        }

        public bool esAceptado(Individual promisingSolution, Individual bestSolution, Individual currentSolution, Individual previousSolution)
        {
            if (maximizacion)
                return (promisingSolution.getEvaluacion() > bestSolution.getEvaluacion());
            else
                return (promisingSolution.getEvaluacion() < bestSolution.getEvaluacion());
        }
    }
}
