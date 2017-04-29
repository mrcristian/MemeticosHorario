using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.comparadores
{
    public interface Individual : IComparable
    {
        /**
 * Permite obtener el vecindario de éste Individuo. La forma de generar el
 * vecindario varía según el problema
 * @return el conjunto de individuos generados a partir del individuo actual
 * (el vecindario)
 */
        List<Individual> getNeighbourhood();
        /**
         * Permite obtener la evaluación del individuo. La forma de calcular la evaluación
         * depende del problema estudiado
         * @return la evaluación del individuo
         */
        double getEvaluacion();
        /**
         * Permite obtener el tamaño de un individuo, es decir, el tamaño del arreglo
         * que representa a una solución
         * @return el tamaño del arreglo que representa a un Individuo
         */
        int getIndividualSize();
        /**
         * Permite obtener un valor del arreglo que representa a un Individuo
         * @param position es la posición en el arreglo que se desea obtener
         * @return el valor correspondiente al arreglo del Individuo que se encuentra
         * en la posición indicada
         */
        double getValue(int position);
        /**
         * Permite crear una copia idéntica pero independiente del Individuo
         * @return una copia del individuo
         */
        Individual clonar();
    }
}
