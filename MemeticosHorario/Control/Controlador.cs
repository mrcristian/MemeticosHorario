using MemeticosHorario.DAL;
using MemeticosHorario.Modelo;
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
            ind.Evaluar();
        }
    }
}
