using LibTabu.algoritmo_base.comparadores;
using MemeticosHorario.DAL;
using MemeticosHorario.Modelo;
using System;
using System.Collections.Generic;

namespace MemeticosHorario.Control
{
    class Controlador
    {
        private List<IndividuoPrescolar> _individuos;
        

        public Controlador()
        {
            ModelLoader.Inicializar("Datos/Datos_Preescolar/Aulas.txt",
                "Datos/Datos_Preescolar/Asignaturas.txt",
                "Datos/Datos_Preescolar/Profesores.txt");

            AsignaturaHelper.Inicializar(ModelLoader.Get_Asignaturas());


            AulaHelper.Inicializar(ModelLoader.Get_Aulas());
            var ind =
                IndividuoPrescolar.Aleatoreo(ModelLoader.Get_Asignaturas(),
                ModelLoader.Get_Aulas());
            TabuSearch busqueda = new TabuSearch();
            Console.Write("Evaluación: " + ind.getEvaluacion()
                + "   Individuo: " + ind.toString());
            Console.WriteLine("=======================");
            IndividuoPrescolar best = (IndividuoPrescolar)busqueda.tabuSearch(ind);
            Console.Write("Evaluación: " + best.getEvaluacion()
                + "   Individuo: " + best.toString());
            Console.ReadKey();
        
        }
    }
}
