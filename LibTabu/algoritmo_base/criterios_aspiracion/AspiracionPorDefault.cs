using LibTabu.algoritmo_base.comparadores;
using LibTabu.algoritmo_base.lista_tabu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.criterios_aspiracion
{
    public class AspiracionPorDefault
    {
        /**
         * Permite obtener el Individuo aceptado en caso de que se use el criterio de
         * aspiración por defecto
         * @param currentSolution es la solución a partir de la cual se generó el vecindario
         * @param neighbourhood es el conjunto de individuos (vecindario) generado en
         * la iteración actual del algoritmo de Búsqueda Tabú
         * @param listaTabu es la lista tabú actual
         * @return el Individuo del vecindario al cual le queda menos tiempo para salir
         * de la lista tabú
         */
        public Individual getIndividuoAceptado(Individual currentSolution, List<Individual> neighbourhood, TabuList listaTabu)
        {
            int i = 0, posMenor, auxTiempo, menorTiempo = int.MaxValue;
            foreach (Individual neighbour in neighbourhood)
            {
                auxTiempo = listaTabu.tiempoTabu(currentSolution, neighbour);
                if (auxTiempo < menorTiempo)
                {
                    menorTiempo = auxTiempo;
                    posMenor = i;
                }
                i++;
            }
            return neighbourhood[i];
        }
    }
}
