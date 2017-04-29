using LibTabu.algoritmo_base.comparadores;
using PruebaLibTabu.Problema_Flujo_Trabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PruebaLibTabu
{
    class main
    {
        static void Main(string[] args)
        {
            TabuSearch busqueda = new TabuSearch();
            //Problema del Flow Shop
            //CIUDADES     
            //        Individual seed = new IndividualViajeroProblem();
            //        IndividualViajeroProblem best = (IndividualViajeroProblem) busqueda.tabuSearch(configuracion, seed);
            int[,] mat = {
            {5, 5, 3, 6, 3, 3},
            {4, 4, 2, 4, 4, 1},
            {4, 4, 2, 4, 1, 3},
            {3, 6, 3, 2, 5, 10},
            {3, 6, 3, 2, 5, 1}
        };            
            int[] vec = { 2, 3, 4, 5, 1, 0 };
            Individual seed = new IndividuoMaquinas(mat, vec);
            Console.Write("Evaluación: " + seed.getEvaluacion() + "   Individuo: " + seed.ToString());
            IndividuoMaquinas best = (IndividuoMaquinas)busqueda.tabuSearch(seed);
            Console.Write("Evaluación: " + best.getEvaluacion() + "   Individuo: " + best.GetToString());
            Console.ReadKey();            
        }
    }
}
