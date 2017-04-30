using LibTabu.algoritmo_base.comparadores;
using MemeticosHorario.DAL;
using MemeticosHorario.Modelo;
using MemeticosHorario.Modelo.IndividuoFactory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemeticosHorario.Control
{
    class Controlador
    {
        private List<IndividuoPrescolar> _individuos;
        private IIndividuoFactory _factory;


        public Controlador()
        {
            ModelLoader.Inicializar("Datos/Datos_Preescolar/Aulas.txt",
                "Datos/Datos_Preescolar/Asignaturas.txt",
                "Datos/Datos_Preescolar/Profesores.txt");
            AsignaturaHelper.Inicializar(ModelLoader.Get_Asignaturas());
            AulaHelper.Inicializar(ModelLoader.Get_Aulas());
            
        
        }

        public void Test()
        {
            
            _factory = new IIndividuoFactory_Preescolar();

            var ind = _factory.Aleatoreo();
            var ind2 = _factory.Aleatoreo();
            var ind3 = ind.Cruce(ind2);
            TabuSearch busqueda = new TabuSearch();
            //IndividuoPrescolar best 
            //    = (IndividuoPrescolar)busqueda.tabuSearch(ind);

            Console.WriteLine("=======================Individuo 1=======================");
            Console.WriteLine("Evaluación: " + ind.getEvaluacion()
                + "   Individuo: " + ind.toString());
            Console.WriteLine("=======================Individuo 2=======================");            
            Console.WriteLine("Evaluación: " + ind2.getEvaluacion()
                + "   Individuo: " + ind2.toString());
            Console.WriteLine("=======================Individuo Hijo=======================");
            Console.WriteLine("Evaluación: " + ind3.getEvaluacion()
                + "   Individuo: " + ind3.toString());

            Console.ReadKey();
        }

        public void Test2()
        {
            _factory = new IIndividuoFactory_Preescolar();

            var individuos = Enumerable.Range(0, 20)
                .Select(i =>
                {
                    return _factory.Aleatoreo();
                }).ToList();

            for (int i = 0; i < individuos.Count-1; i++)
            {
                var ind3 = individuos[i].Cruce(individuos[i + 1]);
                var ind4 = individuos[i].Cruce2(individuos[i + 1]);
                Console.WriteLine($"{i}:{individuos[i].Fitness}-{individuos[i+1].Fitness}" +
                    $"H: {ind3.Fitness} - {ind4.Fitness}");
            }
            Console.ReadKey();
        }
    }
}
