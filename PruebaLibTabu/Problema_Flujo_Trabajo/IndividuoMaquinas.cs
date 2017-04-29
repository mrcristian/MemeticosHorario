using LibTabu.algoritmo_base.comparadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLibTabu.Problema_Flujo_Trabajo
{
    class IndividuoMaquinas : Individual
    {

        int[,] matriz;
        int[] vec;
        

        public IndividuoMaquinas(int[,] matriz, int[] vector)
        {
            this.matriz = matriz;
            this.vec = vector;
        }


        public Individual clonar()
        {
            return new IndividuoMaquinas(matriz, vec);
        }

        public int CompareTo(object obj)
        {
            return (int)
                (this.getEvaluacion() - ((Individual)obj).getEvaluacion());
        }

        public double getEvaluacion()
        {
            return evaluarFila(this.vec.Length - 1, this.matriz.GetLength(0) - 1);
        }

        public int getIndividualSize()
        {
            return this.vec.Length;
        }

        public List<Individual> getNeighbourhood()
        {
            List<Individual> vecinos = new List<Individual>();
            Random r = new Random();
            int n = r.Next(this.vec.Length);

            for (int i = 0; i < this.vec.Length; i++)
            {
                int[] vecResultado = (int[])vec.Clone();
                int aux = vecResultado[i];
                vecResultado[i] = this.vec[n];
                vecResultado[n] = aux;
                vecinos.Add(new IndividuoMaquinas(this.matriz, vecResultado));
            }
            return vecinos;
        }

        public double getValue(int position)
        {
            return this.vec[position];
        }


        private double evaluarFila(int posTarea, int numMaq)
        {
            double value;
            if (posTarea <= 0 && numMaq == 0)
            {

                return this.T(this.vec[0], 0);
            }
            if (posTarea <= 0)
            {
                value = this.evaluarFila(0,
                        numMaq - 1)
                        + this.T(this.vec[0], numMaq);
                return value;
            }
            if (numMaq <= 0)
            {
                value = this.evaluarFila(posTarea - 1,
                        0) + this.T(this.vec[posTarea], 0);
                return value;
            }
            double v1 = this.evaluarFila(posTarea, numMaq - 1);
            double v2 = this.evaluarFila(posTarea - 1, numMaq);
            value = Math.Max(
                    v1,
                    v2)
                    + this.T(this.vec[posTarea], numMaq);
            return value;
        }

        private double T(int t, int m)
        {
            return this.matriz[m,t];
        }

        public string GetToString()
        {
            String str = "[";
            foreach (int n in this.vec)
            {
                str += " " + n;

            }

            str += "]";
            return str;
        }
    }
}
