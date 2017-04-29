using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.lista_tabu
{
    public interface TabuList
    {
        /**
 * Permite actualizar la lista tabú en cada iteración. Esta función sólo debe
 * invocarse una vez por cada iteración del algoritmo, de lo contrario podrían
 * producirse resultados inesperados
 * @param newSolution es la nueva solución obtenida en la iteración actual
 * del algoritmo de Búsqueda Tabú
 * @param currentSolution es la solución a partir de la cual se generó el
 * vecindario de la iteración actual, es decir, a partir de la cual se generó
 * newSolution
 */
        void actualizar(Individual newSolution, Individual currentSolution);
        /**
         * Permite establecer si un individuo pertenece a la lista tabú
         * @param promisingSolution es el individuo sobre el cual se desea saber si
         * pertenece o no a la lista tabú
         * @param currentSolution es la solución a partir de la cual se generó el
         * vecindario de la iteración actual, es decir, a partir de la cual se generó
         * promisingSolution
         * @return true si el individuo pertenece a la lista tabú, y false si no
         * pertenece a ella
         */
        bool isTabu(Individual promisingSolution, Individual currentSolution);
        /**
         * Permite fijar el Tabu Tenure de la lista tabú, es decir, el número de
         * iteraciones que un elemento va a permanecer en la lista
         * @param tabuTenure es el Tabu Tenure que va a ser establecido para la
         * lista tabú
         */
        void setTabuTenure(int tabuTenure);
        /**
         * Permite obtener el tiempo (número de iteraciones) que le falta a una
         * solución promesa para dejar la lista tabú
         * @param promisingSolution es el Individuo sobre el cual se desea conocer
         * su tiempo restante en la lista tabú
         * @param currentSolution es la solución a partir de la cual se generó el
         * vecindario de la iteración actual, es decir, a partir de la cual se generó
         * promisingSolution
         * @return 0 si el Individuo no se encuentra en la lista tabú. De lo contrario
         * se retorna el número de iteraciones faltante para que el Individuo dejé
         * de estar en la lista tabú
         */
        int tiempoTabu(Individual promisingSolution, Individual currentSolution);
        /**
         * Permite crear e inicializar la lista tabú
         * @param individualSize es el tamaño del Individuo del problema para el cual
         * se va a usar la lista tabú
         */
        void createTabuList(int individualSize);
    }
}
