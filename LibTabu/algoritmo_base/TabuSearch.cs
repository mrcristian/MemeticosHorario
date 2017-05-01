using LibTabu.algoritmo_base.criterios_aspiracion;
using LibTabu.algoritmo_base.criterios_parada;
using LibTabu.algoritmo_base.lista_tabu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTabu.algoritmo_base.comparadores
{
    public class TabuSearch
    {

        /**
         * Estrategia que será aplicada para el criterio de aspiracion
         */
        private StrategyAspiracion estrategiaAspiracion;
        /**
         * Estrategia que será aplicada para el criterio de parada
         */
        private StrategyParada estrategiaParada;
        /**
         * Criterio de aspiración por defecto
         */
        private AspiracionPorDefault aspiracionPorDefecto;
        /**
         * Es la lista tabú que usa el algoritmo
         */
        private TabuList listaTabu;
        private ConfiguracionTabuSearch _configuracion;

        public TabuSearch()
        {
            _configuracion = new ConfiguracionTabuSearch();
            _configuracion.setTipoProblema(false);
            _configuracion.setCriterioParada(CriteriosParadaEnum.NUM_ITERACIONES, 1000);
            _configuracion.setCriterioAspiracion(CriteriosAspiracionEnum.POR_OBJETIVO);
            _configuracion.setListaTabu(new TabuListMovimientos(), 5);

            var _this = this;
            _configuracion.aplicarConfiguración(ref _this);

        }
        /**
         * Permite aplicar el algoritmo de búsqueda tabú
         * @param configuration corresponde a la configuración con la cual va a ser
         * ejecutado el algoritmo
         * @param seed es una solución semilla que se le provee al algoritmo
         * @return el Individuo con la mejor evaluación al momento de cumplir el
         * criterio de parada establecido en la configuración
         */
        public Individual tabuSearch(Individual seed)
        {
            

            //Configuración y declaración de variables
            seed.getEvaluacion();
            Individual currentSolution = seed;
            Individual bestSolution = seed;
            Individual previousSolution = seed;
            Individual promisingSolution;
            listaTabu.createTabuList(seed.getIndividualSize());
            int n = 0;
            while (!estrategiaParada.debeParar(bestSolution) && n<50)
            {
                n++;
                promisingSolution = null;
                //Se genera el vecindario y se lo ordena según el valor de la evaluación
                List<Individual> neighbourhood = currentSolution.getNeighbourhood();
                neighbourhood.Sort();
                //Se obtiene la mejor solución que no sea tabú
                foreach (Individual neighbour in neighbourhood)
                {
                    if (!listaTabu.isTabu(neighbour, currentSolution)
                            || (estrategiaAspiracion != null && estrategiaAspiracion.esAceptado(neighbour, bestSolution, currentSolution, previousSolution)))
                    {
                        promisingSolution = neighbour.clonar();
                        break;
                    }
                }
                //En caso de que todo el vecindario sea tabú se aplica el criterio
                //de aspiración por defecto
                if (promisingSolution == null)
                    promisingSolution = aspiracionPorDefecto.getIndividuoAceptado(currentSolution, neighbourhood, listaTabu);
                //Se actualiza la lista tabú
                listaTabu.actualizar(promisingSolution, currentSolution);
                //Se actualizan las referencias a las soluciones
                previousSolution = currentSolution.clonar();
                currentSolution = promisingSolution.clonar();
                //Se actualiza el mejor, si la nueva solución es mejor
                if (promisingSolution.CompareTo(bestSolution) < 0)
                {
                    bestSolution = promisingSolution.clonar();
                }
            }
            return bestSolution;
        }

        /**
         * Permite fijar la estrategia para el criterio de aspiración
         * @param estrategiaAspiracion es la estrategia ha ser usada para el criterio
         * de aspiración
         */
        public void setEstrategiaAspiracion(StrategyAspiracion estrategiaAspiracion)
        {
            this.estrategiaAspiracion = estrategiaAspiracion;
        }

        /**
         * Permite fijar la estrategia para el criterio de parada
         * @param estrategiaParada es la estrategia ha ser usada para el criterio
         * de parada
         */
        public void setEstrategiaParada(StrategyParada estrategiaParada)
        {
            this.estrategiaParada = estrategiaParada;
        }

        /**
         * Permite fijar la lista tabú que va a ser usada
         * @param listaTabu es la lista tabú que será usada por el algoritmo
         */
        public void setListaTabu(TabuList listaTabu)
        {
            this.listaTabu = listaTabu;
        }

        /**
         * Permite fijar un comparador de individuos
         * @param comparador es el que comparador que será usado
         */
        //public void setComparador(Comparator comparador)
        //{
        //    this.comparador = comparador;
        //}

        /**
         * Permite fijar la estrategia de aspiración por defecto
         * @param aspiracionPorDefecto es el criterio de aspiración por defecto a ser
         * usado
         */
        public void setAspiracionPorDefecto(AspiracionPorDefault aspiracionPorDefecto)
        {
            this.aspiracionPorDefecto = aspiracionPorDefecto;
        }
    }
}
