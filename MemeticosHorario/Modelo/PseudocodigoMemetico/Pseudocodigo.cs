using LibTabu.algoritmo_base.comparadores;
using MemeticosHorario.Modelo;
using MemeticosHorario.Modelo.IndividuoFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.PseudocodigoMemetico
{
    class Pseudocodigo
    {
        List<Individuo> poblacion;
        IIndividuoFactory factory;
        int tamanioPoblacion;
        TabuSearch busquedaTabu;

        public Pseudocodigo(IIndividuoFactory inFactory, int inTamañoPoblacion)
        {
            this.poblacion = new List<Individuo>();
            this.factory = inFactory;
            this.tamanioPoblacion = inTamañoPoblacion;
            busquedaTabu = new TabuSearch();
        }

        public Individuo empezar()
        {
            inicializarPoblacion();
            ordenarPoblacion();
            Console.WriteLine("**************Mejor individuo en la primera vuelta: " + poblacion[0].toString() +"Evaluacion: "+ poblacion[0].Fitness);
            int i = 1000;
            //poblacion[0]
            while (i > 0 )
            {
                busquedaTabu = new TabuSearch();
                Individuo hijo = cruce(poblacion[0], poblacion[1]);                
                hijo = (Individuo)busquedaTabu.tabuSearch(hijo);
                poblacion.Add(hijo);
                ordenarPoblacion();
                i--;
                Console.WriteLine($"{i}: ************ Evaluacion: " + poblacion[0].Fitness);
            }            
            return poblacion[0];            
        }

        private void inicializarPoblacion()
        {
            for (int i = 0; i < tamanioPoblacion; i++)
            {
                poblacion.Add(factory.Aleatoreo());
            }
        }
        private void ordenarPoblacion()
        {
            poblacion = poblacion
                .OrderBy(ind => ind)
                .Take(tamanioPoblacion)
                .ToList();
            //poblacion.Sort();
        }

        private Individuo cruce(Individuo padre, Individuo madre)
        {
            return madre.Cruce(padre);

        }
    }
}
