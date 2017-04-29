using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.criterios_aspiracion
{
    class StrategyAspiracionPorDireccionBusqueda : StrategyAspiracion
    {
        private readonly bool maximizacion;

        public StrategyAspiracionPorDireccionBusqueda(bool maximizacion)
        {
            this.maximizacion = maximizacion;
        }

        public bool esAceptado(Individual promisingSolution, Individual bestSolution, Individual currentSolution, Individual previousSolution)
        {
            if (maximizacion)
                return (promisingSolution.getEvaluacion() > currentSolution.getEvaluacion()
                        && currentSolution.getEvaluacion() > previousSolution.getEvaluacion());
            else
                return (promisingSolution.getEvaluacion() < bestSolution.getEvaluacion()
                        && currentSolution.getEvaluacion() < previousSolution.getEvaluacion());
        }
    }
}
