using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.criterios_aspiracion
{
    public enum CriteriosAspiracionEnum
    {
        /**
 * Criterio de aspiración en el cual se acepta una solución si todas las
 * soluciones del vecindario son soluciones tabú. Se elige la solución menos
 * tabú, que es, la solución a la cual le falta el menor número de iteraciones
 * para salir de la lista tabú
 */
        POR_DEFAULT,
        /**
         * Criterio en el cual se acepta una solución si ésta posee una mejor solución
         * que el mejor individuo encontrado hasta el momento. El significado de una
         * mejor evaluación cambia dependiendo de si es un problema de maximización
         * o minimización
         */
        POR_OBJETIVO,
        /**
         * Criterio de aspiración en el cual se acepta una solución si la solución
         * actual es de mejora y la solución promesa también mejora a la solución
         * actual.  El significado de una mejor evaluación cambia dependiendo de si 
         * es un problema de maximización o minimización
         */
        POR_DIRECCION_BUSQUEDA
    }
}
