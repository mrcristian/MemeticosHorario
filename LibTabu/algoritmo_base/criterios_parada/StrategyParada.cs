using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.criterios_parada
{
    public interface StrategyParada
    {
        /**
 * Permite definir si el algoritmo de Búsqueda Tabú ha cumplido el criterio
 * de parada y por lo tanto puede seguir. Para los criterios de parada en
 * los cuales el número de iteraciones es importante, internamente debe
 * actualizarse dicho valor. Esta función sólo debe usarse una vez por cada
 * iteración del algoritmo, ya que múltiples invocaciones a la función podrían
 * causar resultados erróneos debido a una cuenta inapropiada del número de
 * iteraciones transcurridas.
 * @param bestSolution es la mejor solución encontrada hasta el momento
 * @return true si se ha cumplido el criterio de parada definido por la
 * estrategia, y false si el criterio no se cumple
 */
        bool debeParar(Individual bestSolution);
    }
}
