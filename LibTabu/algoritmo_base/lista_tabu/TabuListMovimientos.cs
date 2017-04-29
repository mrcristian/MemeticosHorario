using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibTabu.algoritmo_base.comparadores;

namespace LibTabu.algoritmo_base.lista_tabu
{
    class TabuListMovimientos : TabuList
    {

        /**
         * Representa a los elementos en la lista tabú. Para este caso se usa una
         * matriz en la cual un 0 indica que el movimiento respectivo no pertenece
         * a la lista tabú, y un número mayor a 0 indica que si pertenece; éste número
         * indica el número de iteraciones faltantes para que el movimiento salga de
         * la lista tabú. e.g. si hay un 5 en [2][3], el intercambio de [2] 
         * a [3] estará prohibido durante 5 iteraciones.
         */
        private int[,] listaTabu;
        /**
         * Representa el Tabu Tenure de la lista tabú
         */
        private int tabuTenure;

        public void actualizar(Individual newSolution, Individual currentSolution)
        {
            int posX = -1, posY = -1;
            for (int i = 0; i < listaTabu.GetLength(0); i++)
            {
                if (newSolution.getValue(i) != currentSolution.getValue(i))
                {
                    if (posX == -1) posX = i;
                    else posY = i;
                }
                for (int j = 0; j < listaTabu.GetLength(0); j++)
                {
                    listaTabu[i,j] = (listaTabu[i,j] == 0) ? 0 : listaTabu[i,j] - 1;
                }
            }
            if (!(posX == -1 || posY == -1))
                listaTabu[posX,posY] = tabuTenure;
        }

        public void createTabuList(int individualSize)
        {
            listaTabu = new int[individualSize, individualSize];
        }

        public bool isTabu(Individual promisingSolution, Individual currentSolution)
        {
            int posX = -1, posY = -1;
            for (int i = 0; i < listaTabu.GetLength(0); i++)
            {
                if (promisingSolution.getValue(i) != currentSolution.getValue(i))
                {
                    if (posX == -1) posX = i;
                    else posY = i;
                }
            }
            if (posX == -1 || posY == -1)
                return false;
            return listaTabu[posX,posY] != 0;
        }

        public void setTabuTenure(int tabuTenure)
        {
            this.tabuTenure = tabuTenure;
        }

        public int tiempoTabu(Individual promisingSolution, Individual currentSolution)
        {
            int posX = -1, posY = -1;
            for (int i = 0; i < listaTabu.GetLength(0); i++)
            {
                if (promisingSolution.getValue(i) != currentSolution.getValue(i))
                {
                    if (posX == -1) posX = i;
                    else posY = i;
                }
            }
            return listaTabu[posX,posY];
        }
    }
}
