using LibTabu.algoritmo_base.comparadores;
using MemeticosHorario.DAL;
using MemeticosHorario.Modelo;
using MemeticosHorario.Modelo.IndividuoFactory;
using MemeticosHorario.PseudocodigoMemetico;
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
            //ModelLoader.Inicializar("Datos/Datos_Universidad/Aulas.txt",
            //   "Datos/Datos_Universidad/Asignaturas.txt",
            //   "Datos/Datos_Universidad/Profesores.txt");
            AsignaturaHelper.Inicializar(ModelLoader.Get_Asignaturas());
            AulaHelper.Inicializar(ModelLoader.Get_Aulas());
        }

        public void Test()
        {
            _factory = new IIndividuoFactory_Preescolar();

            TabuSearch busqueda = new TabuSearch();

            Pseudocodigo memetico = new Pseudocodigo(_factory,50);

            var m = memetico.empezar();
            Console.WriteLine(m);

            Console.ReadKey();
        }
        public void Test3()
        {
            _factory = new IIndividuoFactory_Universidad();

            TabuSearch busqueda = new TabuSearch();

            Pseudocodigo memetico = new Pseudocodigo(_factory, 10);

            var m = memetico.empezar();
            Console.WriteLine(m);

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
                var ind4 = individuos[i].Cruce(individuos[i + 1]);
                Console.WriteLine($"{i}:{individuos[i].Fitness}-{individuos[i+1].Fitness}" +
                    $"H: {ind3.Fitness} - {ind4.Fitness}");
            }
            Console.ReadKey();
        }
    }
}
