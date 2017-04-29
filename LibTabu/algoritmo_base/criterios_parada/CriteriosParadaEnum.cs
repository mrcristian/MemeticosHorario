using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.criterios_parada
{
    public enum CriteriosParadaEnum
    {
        /**
         * Indica que el algoritmo se ejecutará durante un número determinado de iteracioens
         */
        NUM_ITERACIONES,
        /**
         * Indica que el algoritmo dejará de ejecutarse cuando la mejor solución no
         * mejore en un número determinado de iteraciones
         */
        NUM_ITERACIONES_SIN_MEJORA,
        /**
         * Indica que el algoritmo dejará de ejecutarse cuando alguna solución tenga
         * una evaluación mejor que un valor de evaluación establecido. Para el caso
         * de minimización se considera que un valor es mejor cuando es menor, y para
         * maximización se considera que es mejor cuando es mayor
         */
        EVALUACION_OBJETIVO
    }
}
