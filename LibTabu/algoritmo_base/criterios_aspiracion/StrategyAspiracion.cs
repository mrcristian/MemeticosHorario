using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.criterios_aspiracion
{
    public interface StrategyAspiracion
    {
        /**
 * Permite evaluar si un individuo promesa pertenece a la lista de aspiración
 * de acuerdo a la estrategia definida
 * @param promisingSolution es la solución promesa, es decir, la que se desea
 * evaluar si pertenece o no a la lista de aspiración
 * @param bestSolution es el mejor individuo encontrado hasta el momento
 * @param currentSolution es el individuo que fue utilizado como base para
 * la generación del vecindario en la iteración actual
 * @param previousSolution es el individuo que fue utilizado como base para
 * la generación del vecindario en la iteración anterior
 * @return true si la solución promesa cumple con el criterio de aspiración
 * establecido en la estrategia, false en caso de que no lo cumpla
 */
        bool esAceptado(Individual promisingSolution, Individual bestSolution,
                Individual currentSolution, Individual previousSolution);
    }
}
