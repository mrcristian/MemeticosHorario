using LibTabu.algoritmo_base.comparadores;
using MemeticosHorario.DAL;
using MemeticosHorario.Modelo;
using System;
using System.Collections.Generic;

namespace MemeticosHorario.Control
{
    class Controlador
    {
        private List<Individuo> _individuos;
        

        public Controlador()
        {
            AulaHelper.Inicializar(ModelLoader.Get_Aulas());
            var ind =
                Individuo.Aleatoreo(ModelLoader.Get_Asignaturas());
            TabuSearch busqueda = new TabuSearch();
            Console.Write("Evaluación: " + ind.getEvaluacion()
                + "   Individuo: " + ind.ToString());
            Individuo best = (Individuo)busqueda.tabuSearch(ind);
            Console.Write("Evaluación: " + best.getEvaluacion()
                + "   Individuo: " + best.ToString());
            Console.ReadKey();

        }
    }
}
